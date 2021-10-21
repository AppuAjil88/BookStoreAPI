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
    public class CouponController : ApiController
    {
        private ICouponRepository repository;
        public CouponController()
        {
            repository = new CouponSQLImpl();
        }

        [HttpGet]
        public List<Coupon> GetCoupons()
        {
            return repository.GetCoupons();
        }

        [HttpGet]
        [Route("api/coupon/check/{couponCode}")]
        public bool GetCheckCoupon(string couponCode)
        {
            return repository.checkCoupon(couponCode);
        }
        [HttpPost]
        [Route("api/coupon/add/")]
        public Coupon Post(Coupon coupon)
        {
            return repository.addCoupon(coupon);
        }

        [HttpDelete]
        [Route("api/coupon/delete/{id}")]
        public bool DeleteBook(int id)
        {
            return repository.deleteCouponById(id);
        }

    }
}
