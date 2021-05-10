using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;  
using System.Web;
using System.Web.Mvc;
using Entities;
using Logic;
using Data;
using System.Web.Http.Description;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;

namespace MVC_ABM_Api.Controllers
    {
        public class ABMApiController : ApiController
        {
            private NorthwindContext db = new NorthwindContext();

        //// GET: api/Employees
        //public IQueryable<Products> GetProducts()
        //{
        //    return db.Products;
        //}

            public List<Products> Get()
            {
                ProductsLogic productsLogic = new ProductsLogic();
                return productsLogic.GetAll();
            }

        // GET: api/Employees/5
        //[ResponseType(typeof(Products))]
        [HttpGet]
        public IHttpActionResult GetProducts(int id)
        {
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        // PUT: api/Employees/5
        //[ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult PutProducts(int id, Products products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != products.ProductID)
            {
                return BadRequest();
            }

            db.Entry(products).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Employees
        [HttpPost]
        [ResponseType(typeof(Products))]
        public IHttpActionResult PostProducts(Products products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(products);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = products.ProductID }, products);
        }

        // DELETE: api/Employees/5
        [ResponseType(typeof(Products))]
        public IHttpActionResult DeleteProducts(int id)
        {
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return NotFound();
            }

            db.Products.Remove(products);
            db.SaveChanges();

            return Ok(products);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductsExists(int id)
        {
            return db.Products.Count(p => p.ProductID == id) > 0;
        }
    }
}