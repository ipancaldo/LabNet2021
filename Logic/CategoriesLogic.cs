using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Logic
{
    public class CategoriesLogic : BaseLogic
    {
        public IEnumerable<dynamic> CategoriesByProduct()
        {
            var query = from cat in context.Categories
                        join prod in context.Products
                        on cat.CategoryID equals prod.CategoryID
                        orderby cat.CategoryName
                        select new
                        {
                            CategoryID = cat.CategoryID,
                            CategoryName = cat.CategoryName,
                            Description = cat.Description,
                            ProductID = prod.ProductID,
                            ProductName = prod.ProductName,
                        };
            return query;
        }
    }
}