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
    public class CategoryController : ApiController
    {
        private ICategoryRespository repository;

        public CategoryController()
        {
            repository = new CategorySQLImpl();
        }

        public IHttpActionResult Get()
        {
            var data = repository.GetAllCategories();
            return Ok(data);
        }

        public HttpResponseMessage Get(int id)
        {
            var result = repository.GetCategoryById(id);
            if (result.CategoryName != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "category id not found");
            }
        }

        [HttpGet]
        [Route("api/category/disable/{id}")]
        public HttpResponseMessage GetDisable(int id)
        {
            var result = repository.DisableCategory(id);
            if (result == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Category successfully disabled");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Category id ot found");
            }
        }


        [HttpGet]
        [Route("api/category/enable/{id}")]
        public HttpResponseMessage GetEnable(int id)
        {
            var result = repository.EnableCategory(id);
            if (result == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Category successfully enabled");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Category id not found");
            }
        }

        public HttpResponseMessage Post(Category category)
        {
            var data = repository.AddCategory(category);
            if (data == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, " category not added ");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
        }

        
    }
}
