using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleOpenAPI.Api.Contracts.Requests;
using SimpleOpenAPI.Api.Contracts.Resources;
using SimpleOpenAPI.Api.Contracts.Responses;
using SimpleOpenAPI.Domain.Models;
using SimpleOpenAPI.Domain.Repositories;

namespace SimpleOpenAPI.Api.Controllers
{
    /// <summary>
    /// Books
    /// </summary>
    [Route("api/[controller]")]
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
        /// <returns>A list of all books</returns>
        [HttpGet]
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
        /// <returns>Selected book</returns>
        [HttpGet("{id}")]
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
        /// <returns>Book Id</returns>
        [HttpPost]
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
        /// <param name="request">Book to be added</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult<UpdateBookResponse> UpdateBook([FromRoute] UpdateBookIdRequest idRequest, UpdateBookRequest request)
        {
            var book = _mapper.Map<UpdateBookRequest, Book>(request);

            book.Id = idRequest.Id.ToString();
            
            _bookRepository.UpdateBook(book);

            return CreatedAtAction(nameof(GetBook), new GetBookRequest {Id = idRequest.Id},
                new UpdateBookResponse(idRequest.Id));
        }

        /// <summary>
        /// Delete a book
        /// </summary>
        /// <param name="request">Book Id</param>
        [HttpDelete("{id}")]
        public IActionResult DeleteBook([FromRoute] DeleteBookRequest request)
        {
            _bookRepository.DeleteBook(request.Id.ToString());
            return NoContent();
        }
    }
}
