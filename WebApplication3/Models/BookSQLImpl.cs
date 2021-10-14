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
                command.CommandText = $"insert into Books (Id, Title, Author, Price, Description) values ({b.Id}, '{b.Title}', '{b.Author}', {b.Price}, '{b.Description}')";
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
            }
            return b;
        }

        public List<Book> BestSeller()
        {
            throw new NotImplementedException();
        }

        public Book DeleteBook(int id)
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


        
        public List<Book> GetBookByCatId(int id)
        {
            List<Book> bookList = new List<Book>();
            string ConnectionStr = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"Select * from Book where CategoryID= '{id}'";
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

        public Book UpdateBook(int id, Book b)
        {
            string connectionStr = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"update Books set Title='{b.Title}', Author='{b.Author}', Price={b.Price}, Description='{b.Description}'  where Id='{id}'";
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                return b;
            }
        }
    }
}