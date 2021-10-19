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
    public class UserController : ApiController
    {
        private IUserRepository  repository;
        public UserController()
        {
            this.repository = new UserSQLImpl();
        }
        [HttpGet]
        public List<User> Get()
        {
            return repository.GetAllUser();
        }

        [HttpGet]
        public User Get(int id)
        {
            return repository.GetUserById(id);
        }

        [HttpPost]
        [Route("register")]
        public User PostRegister(User u)
        {
            return repository.Register(u);
        }
        [HttpPost]
        [Route("login")]
        public String PostLogin(User u)
        {
            return repository.Login(u);
        }

        [HttpPut]
        public String Put(User u)
        {
            return repository.Disable(u);
        }
    }

}
