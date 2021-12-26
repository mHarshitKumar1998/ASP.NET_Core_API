using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL1;
using WebAPIRoutingCode.Customresultype;

namespace WebAPIRoutingCode.Controllers
{
    public class ProductInfoController : ApiController
    {
        DataContext db;
        public ProductInfoController()
        {
            db = new DataContext();
        }


        public IEnumerable<Product> GetAll()
        {
            return db.Products.ToList();
        }

        public IHttpActionResult GetById(int id)
        {
            var product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }

        [HttpPost]
        public IHttpActionResult AddProduct(Product value)
        {
            if (value != null)
            {
                db.Products.Add(value);
                db.SaveChanges();
                return Created(Request.RequestUri, value);
            }
            else
            {
                return BadRequest();

            }

        }
        public IHttpActionResult GetNameById(int id)
        {
            var product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return new TestResult(product.ProductName,Request);
            }
        }

    }

}
