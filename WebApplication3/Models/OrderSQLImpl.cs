using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace WebApplication3.Models
{
    public class OrderSQLImpl : IOrderRepository
    {
        public Order addOrder(Order order)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "insert into Orders ( UserID,BookID,OrderDate ) values (" + order.UserID + ", " + order.BookID + ", CAST( GETDATE() AS Date ) ) ";
                comm.Connection = conn;
                conn.Open();
                int rows = comm.ExecuteNonQuery();
                conn.Close();
                if (rows > 0)
                    return order;
                else
                {
                    Order order1 = new Order(); ; // returning empty address if not successful
                    return order1;
                }

            }
        }

        public List<Order> viewAllOrders()
        {
            List<Order> orders = new List<Order>();
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "select * from Orders";
                comm.Connection = conn;
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {

                    Order order = new Order();
                    order.OrderID = dr.GetInt32(0);
                    order.UserID = dr.GetInt32(1);
                    order.BookID = dr.GetInt32(2);
                    order.OrderDate = dr.GetDateTime(3);
                    orders.Add(order);

                }
                conn.Close();
                return orders;

            }
        }

        public List<Order> viewOrdersByUserID(int id)
        {
            List<Order> orders = new List<Order>();
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "select * from Orders where UserID = "+ id +"";
                comm.Connection = conn;
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {

                    Order order = new Order();
                    order.OrderID = dr.GetInt32(0);
                    order.UserID = dr.GetInt32(1);
                    order.BookID = dr.GetInt32(2);
                    order.OrderDate = dr.GetDateTime(3);
                    orders.Add(order);

                }
                conn.Close();
                return orders;

            }
        }
    }
}