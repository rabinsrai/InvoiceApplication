using InvoiceChildParent.Invoicing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceChildParent
{
    public partial class SelectProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            clsProduct objProduct = new clsProduct();
            dtgProducts.DataSource = objProduct.getProducts();
            dtgProducts.DataBind();
        }
        protected void dtgProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsProduct objproduct = new clsProduct();

            objproduct.ProductId = Convert.ToInt16(dtgProducts.SelectedItem.Cells[1].Text.ToString());
            objproduct.ProductDescription = dtgProducts.SelectedItem.Cells[2].Text.ToString();
            objproduct.UnitCost = Convert.ToDouble(dtgProducts.SelectedItem.Cells[3].Text.ToString());
            Session["SelectedProduct"] = objproduct;
            Response.Redirect("InvoiceEntry.aspx");
        }
    }
}