using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Address
    {
        public int AddressID { get; set; }
        public int  UserID { get; set; }
        public string AddressStr { get; set; }
    }
}