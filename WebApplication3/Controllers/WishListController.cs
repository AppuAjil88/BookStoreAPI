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
    public class WishListController : ApiController
    {
        IWishListRepository repository;

        public WishListController()
        {
            repository = new WishListSQLImpl();
        }
        [HttpGet]
        [Route("api/wishlist/{userId}")]
        public IHttpActionResult GetWishListById(int userId)
        {
            var data = repository.GetWishListById(userId);
            return Ok(data);
        }

        [HttpGet]
        [Route("api/wishlist/add/{userId}/{bookId}")]
        public HttpResponseMessage addBookToWishListById(int userId, int bookId)
        {
            var data = repository.addBookToWishListById(userId, bookId);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, " book not added to cart");
            }
        }

        [HttpGet]
        [Route("api/wishlist/remove/{userId}/{bookId}")]
        public HttpResponseMessage RemoveFromWishListById(int userId, int bookId)
        {
            var result = repository.RemoveFromWishListById(userId, bookId);
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
        [Route("api/wishlist/remove/{userId}")]
        public HttpResponseMessage RemoveWishListofUser(int userId)
        {
            var result = repository.RemoveWishListofUser(userId);
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
