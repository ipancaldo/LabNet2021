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
        public List<Products> GetAll()
        {
            return context.Products.ToList();
        }

        public Products GetData(int id)
        {
            Products product = new Products();
            var seleccionProducto = context.Products.FirstOrDefault(r => r.ProductID == id);
            return seleccionProducto;
        }
    }
}
