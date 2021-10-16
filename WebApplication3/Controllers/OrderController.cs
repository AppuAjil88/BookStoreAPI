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
    public class OrderController : ApiController
    {
        IOrderRepository repository;
        
        public OrderController()
        {
            repository = new OrderSQLImpl();
        }

        [HttpGet]
        public IHttpActionResult GetByUserId(int id)
        {
            var result = repository.viewOrdersByUserID(id);
            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var result = repository.viewAllOrders();
            return Ok(result);
        }

        [HttpPost]
        public HttpResponseMessage Post(Order order)
        {
            var data = repository.addOrder(order);
            if (data.UserID == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, " order not added ");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
        }

    }
}
