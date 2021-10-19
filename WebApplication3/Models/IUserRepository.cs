using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public interface IUserRepository
    {
        User Login(User u); // check email is present in table and passwords match.
        User Register(User u); //post && update table
        User GetUserById(int id);
        string Disable(User u);
        string Activate(User u);
        List<User> GetAllUser();
    }
}