using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Logic
{
    public class CustomersLogic : BaseLogic
    {
        public List<Customers> GetAll()
        {
            return context.Customers.ToList();
        }

        public Customers GetData(string id)
        {
            Customers customers = new Customers();
            var seleccionCustomer = context.Customers.FirstOrDefault(c => c.CustomerID == id);
            return seleccionCustomer;
        }
    }
}
