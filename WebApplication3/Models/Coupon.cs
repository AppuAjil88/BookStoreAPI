using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Coupon
    {
        public int CouponID { get; set; }
        public int Discount { get; set; }
        public int MaxAmount { get; set; }
        public string CouponCode { get; set; }
    }
}