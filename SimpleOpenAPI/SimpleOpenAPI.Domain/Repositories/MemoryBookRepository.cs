using System.Collections.Generic;
using System.Linq;
using SimpleOpenAPI.Domain.Models;

namespace SimpleOpenAPI.Domain.Repositories
{
    public class MemoryBookRepository : IBookRepository
    {
        private List<Book> _books = new List<Book>();

        public Book GetBook(string id)
            => _books.FirstOrDefault(c => c.Id == id);

        public IEnumerable<Book> GetAllBooks()
            => _books;

        public void SaveBook(Book book)
            => _books.Add(book);

        public void DeleteBook(string id)
            => _books.RemoveAll(c => c.Id == id);
    }
}