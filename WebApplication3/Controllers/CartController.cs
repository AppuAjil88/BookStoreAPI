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
    public class CartController : ApiController
    {
        private ICartRepository repository;

        public CartController()
        {
            repository = new CartSQLImpl();
        }
        [HttpGet]
        [Route("api/cart/{userId}")]
        public IHttpActionResult GetCartById(int userId)
        {
            var data = repository.GetCartById(userId);
            return Ok(data);
        }

        [HttpGet]
        [Route("api/cart/add/{userId}/{bookId}")]
        public HttpResponseMessage addBookToCartById(int userId, int bookId)
        {
            var data = repository.addBookToCartById(userId, bookId);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, " book not added to cart");
            }
        }
        //[HttpPost]
        //[Route("api/cart/add/{cartItemPassing}")]
        //public HttpResponseMessage PostaddBookToCartById(cartItemPassing cartItem)
        //{
        //    var data = repository.addBookToCartById(cartItem);
        //    if (data == true)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, data);
        //    }
        //    else
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, " book not added to cart");
        //    }
        //}

        [HttpGet]
        [Route("api/cart/remove/{userId}/{bookId}")]
        public HttpResponseMessage RemoveFromCartById(int userId, int bookId)
        {
            var result = repository.RemoveFromCartById(userId, bookId);
            if (result == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Item removed");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item not removed");
            }
        }

        [HttpGet]
        [Route("api/cart/remove/{userId}")]
        public HttpResponseMessage RemoveCartofUser(int userId)
        {
            var result = repository.RemoveCartofUser(userId);
            if (result == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Cart of the person removed");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Cart not removed");
            }
        }
    }
}