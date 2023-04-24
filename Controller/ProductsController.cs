using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using casestudy.Model;

namespace casestudy.Controller
{
    public class ProductsController : ApiController
    {
        private MyDbContext db = new MyDbContext();


        public IEnumerable<Product> get()
        {
            return db.Products;
        }


        // Post api
        public async Task<IHttpActionResult> Post
        {
            get
            {
                db.SaveChanges();
                var product = new Product();


                var file = HttpContext.Current.Request.Files[0];
                if (file != null)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(HttpContext.Current.Server.MapPath("~/images/"), fileName);
                    file.SaveAs(filePath);

                    product.Image = "/images" + fileName;

                }

               

            }
        }





        // GET: api/Products
        public IQueryable<Product> GetProducts()
        {
            return (IQueryable<Product>)db.Products.ToList();
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        
       
      
        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }

        

        
    }
}