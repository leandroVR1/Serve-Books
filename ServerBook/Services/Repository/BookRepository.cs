using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using ServerBook.Data;
using ServerBook.Models;

namespace ServerBook.Services
{
    public class BookRepository : IBookRepository
    {
        private readonly BaseContext _context;
        public BookRepository(BaseContext context){
            _context = context;
        } 

        public void CreateBook(Book book)
        {
           _context.Books.Add(book);
            _context.SaveChanges();
        }

        public Book GetBookId(int id)
        {
            return _context.Books.Find(id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _context.Books.ToList();
        }

        public void UpdateUser(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }
    }
}