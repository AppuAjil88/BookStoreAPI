using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace WebApplication3.Models
{
    public class CategorySQLImpl : ICategoryRespository
    {
        public Category AddCategory(Category category)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "insert into Category ( CategoryName, Description, Image, Status, Position, CreatedAt) values ('" + category.CategoryName + "', '" + category.Description + "' , '" + category.Image + "'," + category.Status + "," + category.Position + ", CAST( GETDATE() AS Date )) ";
                comm.Connection = conn;
                conn.Open();
                int rows = comm.ExecuteNonQuery();
                conn.Close();
                return category;

            }
        }

        public bool DisableCategory(int catID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "update Category set status = 0 where CategoryID = " + catID + "";
                comm.Connection = conn;
                conn.Open();
                int rows = comm.ExecuteNonQuery();
                conn.Close();
                if (rows > 0)
                    return true;
                else
                    return false;

            }
        }

        public bool EnableCategory(int catID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "update Category set status = 1 where CategoryID = " + catID + "";
                comm.Connection = conn;
                conn.Open();
                int rows = comm.ExecuteNonQuery();
                conn.Close();
                if (rows > 0)
                    return true;
                else
                    return false;

            }
        }

        public List<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "select * from Category where Status=1";
                comm.Connection = conn;
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    
                    Category category = new Category();
                    category.CategoryID = dr.GetInt32(0);
                    category.CategoryName = dr.GetString(1);
                    category.Description = dr.GetString(2);
                    category.Image = dr.GetString(3);
                    category.Status = dr.GetInt32(4);
                    category.Position = dr.GetInt32(5);
                    category.CreatedAt = dr.GetDateTime(6);
                    categories.Add(category);

                }
                conn.Close();
                return categories;

            }
        }

        public Category GetCategoryById(int id)
        {
            Category category = new Category();
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "select * from Category where CategoryID = " + id + "";
                comm.Connection = conn;
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    category.CategoryID = dr.GetInt32(0);
                    category.CategoryName = dr.GetString(1);
                    category.Description = dr.GetString(2);
                    category.Image = dr.GetString(3);
                    category.Status = dr.GetInt32(4);
                    category.Position = dr.GetInt32(5);
                    category.CreatedAt = dr.GetDateTime(6);
                }
                conn.Close();
                return category;
            }
        }
    }
}