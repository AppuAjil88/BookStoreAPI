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
        public string Name { get; set; }
        public int Mobile { get; set; }
        public string BuildingName { get; set; }
        public int Pincode { get; set; }
        public string Locality { get; set; }
        public string District { get; set; }
        public string Landmark { get; set; }

    }
}