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
    public class AddressController : ApiController
    {
        private IAddressRespository repository;

        public AddressController()
        {
            repository = new AddressSQLImpl();
        }

        public HttpResponseMessage Get(int id)
        {
            var result = repository.viewAddressByID(id);
            if (result.AddressStr != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "address id not found");
            }
        }

        [HttpGet]
        [Route("api/address/getByUserId/{id}")]
        public IHttpActionResult GetByUserId(int id)
        {
            var result = repository.viewAddressByUserID(id);
            return Ok(result);
        }

        public HttpResponseMessage Post(Address address)
        {
            var data = repository.addAddress(address);
            if (data.AddressStr == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, " address not added ");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var data = repository.deleteAddress(id);
            if (data == false)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, " address not deleted (id error most prolly) ");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "address deleted");
            }

        }
        public HttpResponseMessage Put(int id, Address address)
        {
            var data = repository.updateAddress(id, address);
            if (data.AddressStr == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, " address not modified (id error most prolly) ");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }


        }






    }
}
