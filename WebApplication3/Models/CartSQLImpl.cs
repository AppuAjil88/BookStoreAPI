using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace WebApplication3.Models
{

    public class CartSQLImpl : ICartRepository
    {
        public List<Book> GetCartById(int userId)
        {
           
            List<Book> BookItems = new List<Book>();
            List<int> Ids = new List<int>();
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "select BookID from Cart where UserID = " + userId + "";
                comm.Connection = conn;
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    Ids.Add(dr.GetInt32(0));
                }
                dr.Close();
                conn.Close();
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                foreach (int i in Ids)
                {
                    comm.CommandText = "select * from Book where BookId = " + i;
                    comm.Connection = conn;
                    conn.Open();
                    SqlDataReader dr = comm.ExecuteReader();

                    while (dr.Read())
                    {
                        Book bookitem = new Book();
                        bookitem.Id = dr.GetInt32(0);
                        bookitem.CatId = dr.GetInt32(1);
                        bookitem.Title = dr.GetString(2);
                        bookitem.ISBN = dr.GetInt32(3);
                        bookitem.Price = dr.GetInt32(4);
                        bookitem.Year = dr.GetInt32(5);
                        bookitem.Description = dr.GetString(6);
                        bookitem.Position = dr.GetInt32(7);
                        bookitem.Status = dr.GetBoolean(8);
                        bookitem.Image = dr.GetString(9);
                        bookitem.Author = dr.GetString(10);
                        BookItems.Add(bookitem);
                    }
                    dr.Close();
                    conn.Close();
                }

            }
            return BookItems;
        }

        //public bool addBookToCartById(int userId, int bookId)
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        SqlCommand comm = new SqlCommand();
        //        comm.CommandText = "insert into Cart  values (" + userId + ", " + bookId + ")";
        //        comm.Connection = conn;
        //        conn.Open();
        //        comm.ExecuteNonQuery();
        //        conn.Close();
        //        return true;
        //    }
        //}
        //public bool addBookToCartById(CartItem cartitem)
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        SqlCommand comm = new SqlCommand();
        //        comm.CommandText = "insert into Cart  values (" + cartitem.userId + ", " + cartitem.bookId + ")";
        //        comm.Connection = conn;
        //        conn.Open();
        //        comm.ExecuteNonQuery();
        //        conn.Close();
        //       return true;
        //    }
        //}
        public bool AddBookToCartById(int userId, int bookId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "insert into Cart  values (" + userId + ", " + bookId + ")";
                comm.Connection = conn;
                conn.Open();
                comm.ExecuteNonQuery();
                conn.Close();
                return true;
            }
        }


        public bool RemoveFromCartById(int userId, int bookId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "delete from Cart where UserId = " + userId + "and BookId = " + bookId;
                comm.Connection = conn;
                conn.Open();
                comm.ExecuteReader();
                conn.Close();
                return true;
            }
        }
        public bool RemoveCartofUser(int userId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "delete from Cart where UserId = " + userId + " ";
                comm.Connection = conn;
                conn.Open();
                comm.ExecuteReader();
                conn.Close();
                return true;
            }
        }
        public bool UpdateCartByQuantity(int userId, int bookId, int quantity)
        {
            return true;
        }
    }
}

