using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication3.Models;
using System.Web.Http.Cors;
using System.Data.SqlClient;

namespace WebApplication3.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BookController : ApiController
    {
        private IBookRepository repository;
        public BookController()
        {
            this.repository = new BookSQLImpl();
        }

        [HttpGet]
        public List<Book> Get()
        {
            return repository.BestSeller();
        }
        [HttpGet]
        [Route("api/book/catid/{id}")]
        public List<Book> Get(int id)
        {
            return repository.GetBookByCatId(id);
        }
        [HttpGet]
        public Book GetBook(int id)
        {
            return repository.GetBookById(id);
        }

        [HttpPost]
        public Book Post(Book book)
        {
            return repository.AddBook(book);
        }

        [HttpDelete]
        public void Post(int id)
        {
             repository.DeleteBook(id);
        }

        [HttpPut]
        public Book Put(int id, Book book)
        {
            return repository.UpdateBook(id, book);
        }

        //public static List<Book> bookList = new List<Book>()
        //{
        //    new Book(){ Id=1, Title="Inferno", Author="Dan Brown", Price=500},
        //    new Book(){ Id=2, Title="Harry Potter", Author="JK Rowling", Price=600},
        //    new Book(){ Id=3, Title="2 States", Author="Chetan Bhagat", Price=300},
        //    new Book(){ Id=4, Title="Looking For Alaska", Author="John Green", Price=500},
        //};

        //private int count = bookList.Count;

        //[HttpGet]
        //public string Get() 
        //{
        //    string connectionString = @"server=localhost\SQLEXPRESS; database=BookDB;trusted_connection=yes";
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    connection.Open();
        //    SqlCommand command = new SqlCommand();
        //    command.Connection = connection;
        //    command.CommandText = "select * from Books";
        //    SqlDataReader dr = command.ExecuteReader();
        //    string mystr = "";
        //    if (dr.HasRows)
        //    {
        //        Console.WriteLine("fsddfs");
        //        while (dr.Read())
        //        {
        //            mystr = mystr + Convert.ToString(dr.GetInt32(0));
        //        }
        //    }
        //    else
        //    {
        //        mystr = "No rows found.";
        //    }
        //    connection.Close();
        //    return mystr;
        //}
        //[HttpGet]
        //public Book Get(int id)
        //{
        //    return bookList.FirstOrDefault(x => x.Id == id);
        //}

        //[HttpPost]
        //public Book Post(Book book)
        //{
        //    book.Id = ++count;
        //    bookList.Add(book);
        //    return book;
        //}

        //[HttpPut]
        //public Book Put(int id, Book book)
        //{
        //    Book b = bookList.FirstOrDefault(x => x.Id == id);
        //    int indexof = bookList.IndexOf(b);
        //    bookList[indexof].Title = book.Title;
        //    bookList[indexof].Author = book.Author;
        //    bookList[indexof].Price = book.Price;
        //    return bookList[indexof];
        //}

        //[HttpDelete]
        //public Book Delete(int id)
        //{
        //    Book b = bookList.FirstOrDefault(x => x.Id == id);
        //    bookList.Remove(b);
        //    return b;
        //}
    }
}
