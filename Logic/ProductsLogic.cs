using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Data;

namespace Logic
{
    public class ProductsLogic : BaseLogic
    {
        public List<Products> WithoutStock()
        {
            var products = context.Products.Where(p => p.UnitsInStock == 0).ToList();
            return products;
        }

        public List<Products> WithStockPriceFrom3()
        {
            var products = context.Products.Where(p => p.UnitsInStock > 0)
                                            .Where(p => p.UnitPrice > 3).ToList();
            return products;
        }

        public Products PrimeroONulo(int id)
        {
            var product = context.Products.FirstOrDefault(p => p.ProductID == id);
            return product;
        }

        public List<Products> OrderByName()
        {
            var productosOrdenados = context.Products.OrderBy(p => p.ProductName).ToList();
            return productosOrdenados;
        }

        public List<Products> OrderByStockDesc()
        {
            var productosPorStock = (from prod in context.Products
                                    orderby prod.UnitsInStock descending
                                    select prod).ToList();
            return productosPorStock;
        }

        public Products GetFirstProduct()
        {
            var product = context.Products.First();
            return product;

        }
    }
}
