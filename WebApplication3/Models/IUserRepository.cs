using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public interface IUserRepository
    {
        string Login(User u); // check email is present in table and passwords match.
        User Register(User u); //post && update table

        string Disable(User u); 
        List<User> GetAllUser();
    }
}