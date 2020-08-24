using System.Collections.Generic;
using System.Linq;
using SimpleOpenAPI.Domain.Models;

namespace SimpleOpenAPI.Domain.Repositories
{
    public class MemoryBookRepository : IBookRepository
    {
        private readonly List<Book> _books = new List<Book>();

        public Book GetBook(string id)
            => _books.FirstOrDefault(c => c.Id == id);

        public IEnumerable<Book> GetAllBooks()
            => _books;

        public void SaveBook(Book book)
            => _books.Add(book);

        public void DeleteBook(string id)
            => _books.RemoveAll(c => c.Id == id);

        public bool UpdateBook(Book book)
        {
            var bookIndex = _books.FindIndex(c => c.Id == book.Id);

            if (bookIndex >= 0)
            {
                _books[bookIndex] = book;
                return true;
            }

            return false;
        }

        public bool BookExists(string id) 
            => _books.FindIndex(c => c.Id == id) >= 0;
    }
}