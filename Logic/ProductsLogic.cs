using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entities;

namespace Logic
{
    public class ProductsLogic : BaseLogic, IABMLogic<Products>
    {
        public List<Products> GetAll()
        {
            return context.Products.ToList();
        }

        public Products GetData(int id)
        {
            Products product = new Products();
            var seleccionProducto = context.Products.FirstOrDefault(r => r.ProductID == id); // throws an exception if producto does not exist
            return seleccionProducto;
        }

        public int GetLastID()
        {
            var seleccionProducto = context.Products.OrderByDescending(u => u.ProductID).FirstOrDefault();
            int ultimoId = seleccionProducto.ProductID;

            return ultimoId;
        }

        public void Add(Products newObject)
        {
            context.Products.Add(newObject);
            context.SaveChanges();
        }


        public void Delete(int id)
        {
            var productoAEliminar = context.Products.FirstOrDefault(r => r.ProductID == id);

            if(productoAEliminar == default(Products))
            {
                throw new Exception("El producto no existe");
            }
            else
            {
                try
                {
                    context.Products.Remove(productoAEliminar);
                    context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    throw ex;
                }
                
            }
        }

        public void Update(Products objectSelected)
        {
            var productUpdate = context.Products.Find(objectSelected.ProductID);

            productUpdate.ProductName = objectSelected.ProductName;
            productUpdate.QuantityPerUnit = objectSelected.QuantityPerUnit;
            productUpdate.UnitPrice = objectSelected.UnitPrice;

            context.SaveChanges();
        }
    }
}
