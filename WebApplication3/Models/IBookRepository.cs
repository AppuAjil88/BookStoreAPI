using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public interface IBookRepository
    {
        List<Book> GetBookByCatId(int id);
        List<Book> BestSeller();
        Book GetBookById(int id);
        Book AddBook(Book b);
        Book UpdateBook(int id, Book b);
        void DeleteBook(int id);
    }
}