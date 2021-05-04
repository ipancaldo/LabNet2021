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
        public Customers GetCustomer(string id)
        {
            var customer = context.Customers.FirstOrDefault(c => c.CustomerID == "CACTU");
            return customer;
        }

        public List<Customers> FromWashington()
        {
            var customers =  context.Customers.Where(c => c.Region == "WA").ToList();
            return customers;
        }

        public List<string> CapitalNames()
        {
            var nombresMayuscula = (from cust in context.Customers
                                    select cust.ContactName.ToUpper()).ToList();
            return nombresMayuscula;
        }        
        
        public List<string> LowerNames()
        {
            var nombresMinuscula = (from cust in context.Customers
                                    select cust.ContactName.ToLower()).ToList();
            return nombresMinuscula;
        }

        /// <summary>
        /// Devuelve los Customers según la región y a partir de la fecha que asignemos.
        /// </summary>
        /// <param name="region"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public IEnumerable<dynamic> GetCustomerOrderByRegionAndDate(string region, DateTime fecha)
        {
            try
            {
                var query = from cust in context.Customers
                            join order in context.Orders
                            on cust.CustomerID equals order.CustomerID
                            where cust.Region == region && order.OrderDate > fecha
                            select new
                            {
                                CustomerID = cust.CustomerID,
                                ContactName = cust.ContactName,
                                City = cust.City,
                                OrderID = order.OrderID,
                                OrderDate = order.OrderDate
                            };
                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public List<Customers> FirstThreeWashington(string region)
        {
            var customers = (from cust in context.Customers
                            where cust.Region == region
                            select cust).Take(3).ToList();
            return customers;
        }

        public IEnumerable<dynamic> OrdersByCustomer()
        {
            var query = from cust in context.Customers
                        join ord in context.Orders
                        on cust.CustomerID equals ord.CustomerID into contador
                        select new
                        {
                            ID = cust.CustomerID,
                            ContactName = cust.ContactName,
                            Contador = contador.Count()
                        };
            return query;
        }
    }
}
