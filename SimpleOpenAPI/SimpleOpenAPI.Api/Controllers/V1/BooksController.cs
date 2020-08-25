using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleOpenAPI.Api.Contracts.Requests;
using SimpleOpenAPI.Api.Contracts.Resources;
using SimpleOpenAPI.Api.Contracts.Responses;
using SimpleOpenAPI.Domain.Models;
using SimpleOpenAPI.Domain.Repositories;

namespace SimpleOpenAPI.Api.Controllers.V1
{
    /// <summary>
    /// Books
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BooksController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns a list of all books
        /// </summary>
        /// <response code="200">Success - Returns a list of all books</response>
        /// <response code="204">No Content - The are no books</response>
        /// <returns>A list of all books</returns>
        [HttpGet]
        [ProducesResponseType(type: typeof(GetAllBooksResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<GetAllBooksResponse> GetAllBooks()
        {
            var books = _bookRepository.GetAllBooks();
            
            if (books is null || !books.Any())
            {
                return NoContent();
            }

            var bookResources = _mapper.Map<IEnumerable<Book>, IEnumerable<BookResource>>(books);
            
            var response = new GetAllBooksResponse(bookResources);

            return Ok(response);
        }

        /// <summary>
        /// Returns the selected book
        /// </summary>
        /// <param name="request">Book Id</param>
        /// <response code="200">Success - Returns the selected book</response>
        /// <response code="404">Not Found - Book not found</response>
        /// <returns>Selected book</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GetBookResponse> GetBook([FromRoute] GetBookRequest request)
        {
            var book = _bookRepository.GetBook(request.Id.ToString());

            if (book is null)
            {
                return NotFound("Book not found");
            }

            var bookResource = _mapper.Map<Book, BookResource>(book);
            
            var response = new GetBookResponse(bookResource);

            return Ok(response);
        }

        /// <summary>
        /// Add a book
        /// </summary>
        /// <param name="request">Book to be added</param>
        /// <response code="201">Success - The book has been added</response>
        /// <response code="400">BadRequest - If the book data are incorrect</response>
        /// <returns>Book Id</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<AddBookResponse> AddBook(AddBookRequest request)
        {
            var book = _mapper.Map<AddBookRequest, Book>(request);

            book.Id = Guid.NewGuid().ToString();
            
            _bookRepository.SaveBook(book);

            return CreatedAtAction(nameof(GetBook), new GetBookRequest {Id = Guid.Parse(book.Id)},
                new AddBookResponse(Guid.Parse(book.Id)));
        }

        /// <summary>
        /// Update a book
        /// </summary>
        /// <param name="idRequest">Book Id</param>
        /// <param name="request">Book to be updated</param>
        /// <response code="200">Success - The book has been updated</response>
        /// <response code="204">NoContent - There is no specific book</response>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<UpdateBookResponse> UpdateBook([FromRoute] UpdateBookIdRequest idRequest, UpdateBookRequest request)
        {
            var book = _mapper.Map<UpdateBookRequest, Book>(request);

            book.Id = idRequest.Id.ToString();

            if (_bookRepository.BookExists(book.Id))
            {
                _bookRepository.UpdateBook(book);
                return Ok(new UpdateBookResponse(idRequest.Id));
            }

            return NoContent();
        }

        /// <summary>
        /// Delete a book
        /// </summary>
        /// <param name="request">Book Id</param>
        /// <response code="204">Success - The book has been deleted</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteBook([FromRoute] DeleteBookRequest request)
        {
            _bookRepository.DeleteBook(request.Id.ToString());
            return NoContent();
        }
    }
}
