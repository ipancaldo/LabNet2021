using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entities;
using Logic;
using Api_ABM;
using System.Web.Http.Description;
using System.Data.Entity;

namespace Api_ABM.Controllers
{
    public class ApiABMController : ApiController
    {
        private ProductsLogic productsLogic = new ProductsLogic();
        public List<ProductsView> Get()
        {
            var products = productsLogic.GetAll();
            var productsViewList = products.Select(p => new ProductsView
                                                    {
                                                       Id = p.ProductID,
                                                       Name = p.ProductName,
                                                       QuantityPerUnit = p.QuantityPerUnit,
                                                       Price = (decimal)p.UnitPrice
                                                    }).ToList();
            return productsViewList;
        }
        
        // GET
        [ResponseType(typeof(ProductsView))]
        public IHttpActionResult GetProducts(int id)
        {
            Products products = productsLogic.GetData(id);
            if (products == null)
            {
                return NotFound();
            }
            var productsViewList = new ProductsView
                                    {
                                        Id = products.ProductID,
                                        Name = products.ProductName,
                                        QuantityPerUnit = products.QuantityPerUnit,
                                        Price = (decimal)products.UnitPrice
                                    };
            return Ok(productsViewList);
        }

        // PUT
        [ResponseType(typeof(void))]
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

            try
            {
                productsLogic.Update(products);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST
        [ResponseType(typeof(Products))]
        public IHttpActionResult PostProducts(Products products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            productsLogic.Add(products);

            return CreatedAtRoute("DefaultApi", new { id = products.ProductID }, products);
        }

        // DELETE
        [ResponseType(typeof(Products))]
        public IHttpActionResult DeleteProducts(int id)
        {
            Products product = productsLogic.GetData(id);
            if (product == null)
            {
                return NotFound();
            }

            productsLogic.Delete(id);

            return Ok(product);
        }
    }
}