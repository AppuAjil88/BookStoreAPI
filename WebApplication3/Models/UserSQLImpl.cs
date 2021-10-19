using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models;
using System.Configuration;
using System.Data.SqlClient;
namespace WebApplication3.Models
{
    public class UserSQLImpl : IUserRepository
    {
        public List<User> GetAllUser()
        {
            List<User> userList = new List<User>();
            string ConnectionStr = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"Select * from [User]";
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    User user = new User();
                    user.UserId = dr.GetInt32(0);
                    user.Name = dr.GetString(1);
                    user.Email = dr.GetString(2);
                    user.Password = dr.GetString(3);
                    if (dr.GetBoolean(4)) { user.Active = true; }
                    else { user.Active = false; }
                    userList.Add(user);
                }
            }
            return userList;
        }

        public string Login(User u)
        {
            string password="";
            string ConnectionStr = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"select trim(Password) from [User] where Email='{u.Email}'";
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    password = dr.GetString(0);
                }
            } 
            if(password.Length == 0)
            {
                return "Email not registered.";
            }
            else
            {
                if(password == u.Password)
                {
                    return "Successfully Loggedin";
                }
                else
                {
                    return "Incorrect Email or Password";
                }
            }
            
            
        }

        public User Register(User u)
        {
            string ConnectionStr = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"insert into [User] (Name, Email, Password, Active) values ('{u.Name}', '{u.Email}', '{u.Password}', 1)";
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
            }
            return u;
        } 

        public string Disable(User u)
        {
            string ConnectionStr = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"update  [User] set Active = 0 where UserID = {u.UserId}" ;
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
            }

            return "User disabled";
        }
        public string Activate(User u)
        {
            string ConnectionStr = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"update  [User] set Active = 1 where UserID = {u.UserId}";
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
            }

            return "User activated";
        }

        public User GetUserById(int id)
        {
            User user = new User();
            string ConnectionStr = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"Select * from [User] where UserID = {id}";
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    
                    user.UserId = dr.GetInt32(0);
                    user.Name = dr.GetString(1);
                    user.Email = dr.GetString(2);
                    user.Password = dr.GetString(3);
                    if (dr.GetBoolean(4)) { user.Active = true; }
                    else { user.Active = false; }
                    
                }
            }
            return user;

        }
    }
}