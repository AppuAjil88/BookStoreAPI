using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    interface ICouponRepository
    {
        List<Coupon> GetCoupons();
        bool checkCoupon(string couponCode);
        Coupon addCoupon(Coupon coupon);
        bool deleteCouponById(int id);
    }
}
