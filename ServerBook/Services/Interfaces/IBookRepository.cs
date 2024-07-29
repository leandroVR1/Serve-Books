using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerBook.Models;

namespace ServerBook.Services
{
    public interface IBookRepository
    {
        void CreateBook(Book book);
        void UpdateUser(Book book);
        IEnumerable<Book> GetBooks();
        Book GetBookId(int id);
    }
}