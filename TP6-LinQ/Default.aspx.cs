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
        ProductsLogic productsLogic = new ProductsLogic();
        CustomersLogic customersLogic = new CustomersLogic();
        OrdersLogic orderLogic = new OrdersLogic();
        CategoriesLogic categoriesLogic = new CategoriesLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
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

                this.lblError.Text = "";
                this.lblError.Visible = false;
            }
        }


        protected void btnObjetoCustomer_Click(object sender, EventArgs e)
        {
            List<Customers> cust = new List<Customers>();
            string id = "CACTU";

            cust.Add(customersLogic.GetCustomer(id));

            gridCustomerList.DataSource = cust;
            gridCustomerList.DataBind();
        }

        protected void btnProductosSinStock_Click(object sender, EventArgs e)
        {
            gridProductList.DataSource = productsLogic.WithoutStock();
            gridProductList.DataBind();
        }

        protected void btnStockMasTresUnidad_Click(object sender, EventArgs e)
        {
            gridProductList.DataSource = productsLogic.WithStockPriceFrom3();
            gridProductList.DataBind();
        }

        protected void btnCustomersWashington_Click(object sender, EventArgs e)
        {
            gridCustomerList.DataSource = customersLogic.FromWashington();
            gridCustomerList.DataBind();
        }

        protected void btnPrimerONulo789_Click(object sender, EventArgs e)
        {
            Products prod = new Products();

            int id = 789;
            prod = productsLogic.PrimeroONulo(id);

            if (prod == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No se encontró el ID 789')", true);
                this.lblError.Text = "No se encontró el product ID " + id;
                this.lblError.Visible = true;
            }
            else
            {
                List<Products> p = new List<Products>();
                p.Add(prod);
                gridProductList.DataSource = p;
                gridProductList.DataBind();
            }
        }

        protected void btnNombresMayMin_Click(object sender, EventArgs e)
        {
            gridCustomerListNames1.DataSource = customersLogic.CapitalNames();
            gridCustomerListNames1.DataBind();

            gridCustomerListNames2.DataSource = customersLogic.LowerNames();
            gridCustomerListNames2.DataBind();
        }

        protected void btnCustomersOrderW1197_Click(object sender, EventArgs e)
        {
            string Washington = "WA";
            DateTime fecha = new DateTime(1997, 01, 01);

            try
            {
                gridJoinCustomerOrders.DataSource = customersLogic.GetCustomerOrderByRegionAndDate(Washington, fecha).ToList();
                gridJoinCustomerOrders.DataBind();
            }
            catch (Exception ex)
            {
                this.lblError.Text = $"Error al encontrar registros, error: {ex.Message}";
            }
            
        }

        protected void btnFirst3WA_Click(object sender, EventArgs e)
        {
            string Washington = "WA";

            gridCustomerList.DataSource = customersLogic.FirstThreeWashington(Washington);
            gridCustomerList.DataBind();
        }

        protected void btnProductosOrd_Click(object sender, EventArgs e)
        {
            gridProductList.DataSource = productsLogic.OrderByName();
            gridProductList.DataBind();
        }

        protected void btnStockMayorMenor_Click(object sender, EventArgs e)
        {
            gridProductList.DataSource = productsLogic.OrderByStockDesc();
            gridProductList.DataBind();
        }

        protected void btnCategoriasProductos_Click(object sender, EventArgs e)
        {
            gridCategoriasProductos.DataSource = categoriesLogic.CategoriesByProduct().ToList();
            gridCategoriasProductos.DataBind();
        }

        protected void btnPrimerProducto_Click(object sender, EventArgs e)
        {
            List<Products> prod = new List<Products>();

            prod.Add(productsLogic.GetFirstProduct());

            gridProductList.DataSource = prod;
            gridProductList.DataBind();
        }

        protected void btnCustomerOrders_Click(object sender, EventArgs e)
        {
            gridCustomersOrders.DataSource = customersLogic.OrdersByCustomer().ToList();
            gridCustomersOrders.DataBind();
        }
    }
}