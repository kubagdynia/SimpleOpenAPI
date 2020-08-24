using System.Collections.Generic;
using SimpleOpenAPI.Domain.Models;

namespace SimpleOpenAPI.Domain.Repositories
{
    public interface IBookRepository
    {
        Book GetBook(string id);
        IEnumerable<Book> GetAllBooks();
        void SaveBook(Book book);
        void DeleteBook(string id);
        bool UpdateBook(Book book);
        bool BookExists(string id);
    }
}