using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using Logic;

namespace TP6_LinQ
{
    public partial class _Default : Page
    {
        List<Products> products = new List<Products>();
        List<Customers> customers = new List<Customers>();
        List<Orders> orders = new List<Orders>();
        List<Categories> categories = new List<Categories>();

        protected void Page_Load(object sender, EventArgs e)
        {
            ProductsLogic productsLogic = new ProductsLogic();
            products = productsLogic.GetAll();

            CustomersLogic customersLogic = new CustomersLogic();
            customers = customersLogic.GetAll();

            OrdersLogic orderLogic = new OrdersLogic();
            orders = orderLogic.GetAll();

            CategoriesLogic categoriesLogic = new CategoriesLogic();
            categories = categoriesLogic.GetAll();

            if (IsPostBack)
            {
                gridCustomerList.DataSource = null;
                gridCustomerList.DataBind();

                gridProductList.DataSource = null;
                gridProductList.DataBind();

                gridCustomerListNames1.DataSource = null;
                gridCustomerListNames1.DataBind();

                gridCustomerListNames2.DataSource = null;
                gridCustomerListNames2.DataBind();

                gridJoinCustomerOrders.DataSource = null;
                gridJoinCustomerOrders.DataBind();

                gridCategoriasProductos.DataSource = null;
                gridCategoriasProductos.DataBind();

                gridCustomersOrders.DataSource = null;
                gridCustomersOrders.DataBind();
            }
        }


        protected void btnObjetoCustomer_Click(object sender, EventArgs e)
        {
            gridCustomerList.DataSource = customers.Where(c => c.CustomerID == "CACTU");
            gridCustomerList.DataBind();
        }

        protected void btnProductosSinStock_Click(object sender, EventArgs e)
        {
            gridProductList.DataSource = products.Where(p => p.UnitsInStock == 0);
            gridProductList.DataBind();
        }

        protected void btnStockMasTresUnidad_Click(object sender, EventArgs e)
        {
            gridProductList.DataSource = products.Where(p => p.UnitsInStock > 0)
                                                 .Where(p => p.UnitPrice > 3);
            gridProductList.DataBind();
        }

        protected void btnCustomersWashington_Click(object sender, EventArgs e)
        {
            gridCustomerList.DataSource = customers.Where(c => c.Region == "WA");
            gridCustomerList.DataBind();
        }

        protected void btnPrimerONulo789_Click(object sender, EventArgs e)
        {
            var query2 = products.FirstOrDefault(p => p.ProductID == 789);

            if (query2 == null)
            {
                Response.Write("No se encontró el product ID 789");
            }
            else
            {
                List<Products> p = new List<Products>();
                p.Add(query2);
                gridProductList.DataSource = p;
                gridProductList.DataBind();
            }
        }

        protected void btnNombresMayMin_Click(object sender, EventArgs e)
        {
            var empleadosMayuscula = (
                                      from cust in customers
                                      select cust.ContactName.ToUpper()
                                      ).ToList();

            var empleadosMinuscula = (
                                      from cust in customers
                                      select cust.ContactName.ToLower()
                                      ).ToList();

            gridCustomerListNames1.DataSource = empleadosMayuscula;
            gridCustomerListNames1.DataBind();

            gridCustomerListNames2.DataSource = empleadosMinuscula;
            gridCustomerListNames2.DataBind();

        }

        protected void btnCustomersOrderW1197_Click(object sender, EventArgs e)
        {
            DateTime comparacion = new DateTime(1997, 01, 01);

            var query = from cust in customers
                        join order in orders
                        on cust.CustomerID equals order.CustomerID
                        where cust.Region == "WA" && order.OrderDate > comparacion
                        select new
                        {
                            CustomerID = cust.CustomerID,
                            ContactName = cust.ContactName,
                            City = cust.City,
                            OrderID = order.OrderID,
                            OrderDate = order.OrderDate
                        };

            gridJoinCustomerOrders.DataSource = query;
            gridJoinCustomerOrders.DataBind();
        }

        protected void btnFirst3WA_Click(object sender, EventArgs e)
        {
            var query = (from cust in customers
                         where cust.Region == "WA"
                         select cust).Take(3);

            gridCustomerList.DataSource = query;
            gridCustomerList.DataBind();
        }

        protected void btnProductosOrd_Click(object sender, EventArgs e)
        {
            gridProductList.DataSource = products.OrderBy(p => p.ProductName);
            gridProductList.DataBind();
        }

        protected void btnStockMayorMenor_Click(object sender, EventArgs e)
        {
            var query = from prod in products
                        orderby prod.UnitsInStock descending
                        select prod;

            gridProductList.DataSource = query;
            gridProductList.DataBind();
        }

        protected void btnCategoriasProductos_Click(object sender, EventArgs e)
        {
            var query = from cat in categories
                        join prod in products
                        on cat.CategoryID equals prod.CategoryID
                        select new
                        {
                            CategoryID = cat.CategoryID,
                            CategoryName = cat.CategoryName,
                            Description = cat.Description,
                            ProductID = prod.ProductID,
                            ProductName = prod.ProductName,
                        };

            gridCategoriasProductos.DataSource = query;
            gridCategoriasProductos.DataBind();
        }

        protected void btnPrimerProducto_Click(object sender, EventArgs e)
        {
            gridProductList.DataSource = products.Take(1);
            gridProductList.DataBind();
        }

        protected void btnCustomerOrders_Click(object sender, EventArgs e)
        {
            var query = from cust in customers
                        join ord in orders
                        on cust.CustomerID equals ord.CustomerID into contador
                        select new
                        {
                            ID = cust.CustomerID,
                            ContactName = cust.ContactName,
                            Contador = contador.Count()
                        };;

            gridCustomersOrders.DataSource = query;
            gridCustomersOrders.DataBind();
        }
    }
}