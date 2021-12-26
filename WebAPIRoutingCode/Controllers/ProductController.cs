using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL1;

namespace WebAPIRoutingCode.Controllers
{
    public class ProductController : ApiController
    {
        DataContext db;
        public ProductController()
        {
            db = new DataContext();
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products.ToList();
        }

        public HttpResponseMessage GetById(int id)
        {
            var product=db.Products.Find(id);
            if(product ==null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, id);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, product);
            }
        }

        [HttpPost]
        public  HttpResponseMessage AddProduct([FromBody]  Product value)
        {
            if(value!=null )
            {
                db.Products.Add(value);  
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.Created, value);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, value);

            }

        }
        [HttpPut]
        public HttpResponseMessage UpdateProduct(int id,Product value)
        {
            if (value != null)
            {

                db.Entry(value).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.Created, value);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, value);

            }

        }
         
        public HttpResponseMessage DeleteById(int id)
        {
            var product = db.Products.Find(id);
            if (product == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, id);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, product);
            }
        }
        //api/product
        //public IEnumerable<Product> GetAll()
        //{
        //    return db.Products.ToList();
        //}

        //[Route("product/show-all")]
        //[AcceptVerbs("GET")]
        //public IEnumerable<Product> ShowAll()
        //{
        //    return db.Products.ToList();
        //}

        //[Route("product/get-details/{id}")]
        ////api/product/<1>
        //public Product GetById(int id)
        //{
        //    return db.Products.Find(id);
        //}

        //api/product
        //public void Post(Product value)
        //{
        //    db.Products.Add(value);
        //    db.SaveChanges();
        //}
        //[HttpPost]
        //public void AddPost(Product value)
        //{
        //    db.Products.Add(value);
        //    db.SaveChanges();
        //}
    }
}
