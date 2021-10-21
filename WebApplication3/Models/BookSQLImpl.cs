using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace WebApplication3.Models
{
    public class BookSQLImpl : IBookRepository
    {
        public Book AddBook(Book b)
        {
            string ConnectionStr = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"insert into Book (CategoryId, Title, ISBN, Year, Price, Description, Position, Status, Image, Author) values ({b.CatId}, '{b.Title}', {b.ISBN},{b.Year}, {b.Price}, '{b.Description}', {b.Position}, '{b.Status}', '{b.Image}', '{b.Author}'  )";
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
            }
            return b;
        }

        public List<Book> BestSeller()
        {
            List<Book> bookList = new List<Book>();
            string ConnectionStr = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"Select top 10 * from Book order by Position";
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    Book book = new Book();
                    book.Id = dr.GetInt32(0);
                    book.CatId = dr.GetInt32(1);
                    book.Title = dr.GetString(2);
                    book.ISBN = dr.GetInt32(3);
                    book.Year = dr.GetInt32(4);
                    book.Price = dr.GetInt32(5);
                    book.Description = dr.GetString(6);
                    book.Position = dr.GetInt32(7);
                    if (dr.GetBoolean(8)) { book.Status = true; }
                    else { book.Status = false; }
                    book.Image = dr.GetString(9);
                    book.Author = dr.GetString(10);
                    bookList.Add(book);
                }
            }
            return bookList;
        }

        public void DeleteBook(int id)
        {
            Book book = new Book();
            string ConnectionStr = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"delete from Book where BookId = '{id}'";
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
            }   
        }


        
        public List<Book> GetBookByCatId(int id)
        {
            List<Book> bookList = new List<Book>();
            string ConnectionStr = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"Select * from Book where CategoryID = '{id}'";
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    Book book = new Book();
                    book.Id = dr.GetInt32(0);
                    book.CatId = dr.GetInt32(1);
                    book.Title = dr.GetString(2);
                    book.ISBN = dr.GetInt32(3);
                    book.Year = dr.GetInt32(4);
                    book.Price = dr.GetInt32(5);
                    book.Description = dr.GetString(6);
                    book.Position = dr.GetInt32(7);
                    if (dr.GetBoolean(8)) { book.Status = true; }
                    else { book.Status = false; }
                    book.Image = dr.GetString(9);
                    book.Author = dr.GetString(10);
                    bookList.Add(book);
                }
            }
            return bookList;
        }

        public Book GetBookById(int id)
        {
            Book book = new Book();
            string ConnectionStr = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"Select * from Book where BookId = '{id}'";
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    book.Id = dr.GetInt32(0);
                    book.CatId = dr.GetInt32(1);
                    book.Title = dr.GetString(2);
                    book.ISBN = dr.GetInt32(3);
                    book.Year = dr.GetInt32(4);
                    book.Price = dr.GetInt32(5);
                    book.Description = dr.GetString(6);
                    book.Position = dr.GetInt32(7);
                    if (dr.GetBoolean(8)) { book.Status = true; }
                    else { book.Status = false; }
                    book.Image = dr.GetString(9);
                    book.Author = dr.GetString(10);
                    
                }
            }
            return book;
        }

        public List<Book> GetBookBySearch(string searchString)
        {
            List<Book> bookList = new List<Book>();
            string ConnectionStr = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select * from Book where Title Like '" + searchString + "%'";
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    Book book = new Book();
                    book.Id = dr.GetInt32(0);
                    book.CatId = dr.GetInt32(1);
                    book.Title = dr.GetString(2);
                    book.ISBN = dr.GetInt32(3);
                    book.Year = dr.GetInt32(4);
                    book.Price = dr.GetInt32(5);
                    book.Description = dr.GetString(6);
                    book.Position = dr.GetInt32(7);
                    if (dr.GetBoolean(8)) { book.Status = true; }
                    else { book.Status = false; }
                    book.Image = dr.GetString(9);
                    book.Author = dr.GetString(10);
                    bookList.Add(book);
                }
            }
            return bookList;
        }

        public List<Book> GetBookBySearchISBN(string searchString)
        {
            List<Book> bookList = new List<Book>();
            string ConnectionStr = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select * from Book where ISBN Like '" + searchString + "%'";
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    Book book = new Book();
                    book.Id = dr.GetInt32(0);
                    book.CatId = dr.GetInt32(1);
                    book.Title = dr.GetString(2);
                    book.ISBN = dr.GetInt32(3);
                    book.Year = dr.GetInt32(4);
                    book.Price = dr.GetInt32(5);
                    book.Description = dr.GetString(6);
                    book.Position = dr.GetInt32(7);
                    if (dr.GetBoolean(8)) { book.Status = true; }
                    else { book.Status = false; }
                    book.Image = dr.GetString(9);
                    book.Author = dr.GetString(10);
                    bookList.Add(book);
                }
            }
            return bookList;
        }

        public Book UpdateBook(int id, Book b)
        { 
            int statusTemp;
            if (b.Status) { statusTemp = 1; }
            else { statusTemp = 0; }
            string connectionStr = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"update Book set CategoryId = {b.CatId}, Title = '{b.Title}', ISBN = {b.ISBN}, Year = {b.Year}, Price = {b.Price}, Description = '{b.Description}', Position = {b.Position}, Status = {statusTemp}, Image = '{b.Image}', Author = '{b.Author}' where BookId = {id}";
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                return b;
            }
        }
    }
}