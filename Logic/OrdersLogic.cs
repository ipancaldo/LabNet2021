using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Data;

namespace Logic
{
    public class OrdersLogic : BaseLogic
    {
        public List<Orders> GetAll()
        {
            return context.Orders.ToList();
        }

        public Orders GetData(int id)
        {
            Orders orders = new Orders();
            var seleccionOrder = context.Orders.FirstOrDefault(o => o.OrderID == id);
            return seleccionOrder;
        }
    }
}
