using InvoiceChildParent.Invoicing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceChildParent
{
    public partial class InvoiceEntry : System.Web.UI.Page
    {
        private clsProduct objProductSelected;
        private clsInvoiceHeader objInvoiceHeader = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
            if (Session["InvoiceSession"] == null)
            {
                Session["InvoiceSession"] = new clsInvoiceHeader();

            }
            else
            {
                objInvoiceHeader = getSessionInvoice();
            }
            Uri objUri = Request.UrlReferrer;
            if (objUri != null)
            {
                if (objUri.AbsolutePath.Contains("SelectProducts.aspx"))
                {
                    LoadProduct();
                    clsInvoiceHeader obj = (clsInvoiceHeader)Session["InvoiceSession"];
                    setUIfromObject(obj);
                }
            }
        }

        private void LoadProduct()
        {
            objProductSelected = (clsProduct)Session["SelectedProduct"];
            if (objProductSelected != null)
            {

                lblProductDescription.Text = objProductSelected.ProductDescription;
                lblProductUnitCost.Text = objProductSelected.UnitCost.ToString();
                setInvoiceProduct(objProductSelected);
            }
        }
        private void LoadGrid()
        {
            // load the data set in to the data grid
            clsInvoiceHeader objInvoice = new clsInvoiceHeader();
            dtgInvoice.DataSource = objInvoice.getInvoice();
            dtgInvoice.DataBind();
        }
        public void clearText()
        {
            txtInvoiceNumber.Text = "";
            txtComments.Text = "";
            txtInvoiceDate.Text = "";
            txtCustomerName.Text = "";
            txtCustomerAddress.Text = "";
            lblErrorMessage.Text = "";

        }
        public void clearInvoiceDetailText()
        {
            TxtQuantity.Text = "";
            lblTotalAmountToBePaid.Text = "";
            txtTaxAmount.Text = "";
            txtAmountPaid.Text = "";
            lblProductUnitCost.Text = "";
            lblProductDescription.Text = "";

        }
        protected void btnAddInvoice_Click(object sender, EventArgs e)
        {
            try
            {

                clsInvoiceHeader objInvHeader = (clsInvoiceHeader)Session["InvoiceSession"];
                setObjectFromUI(objInvHeader);
                objInvHeader.Insert();
                clearInvoiceDetailText();
                LoadGrid();
                clearInvoiceDetailText();
                clearText();
                clearSession();

            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message.ToString();
            }
        }

        public void setObjectFromUI(clsInvoiceHeader objInvoiceHeader)
        {
            int value;
            objInvoiceHeader.CustomerName = txtCustomerName.Text;
            objInvoiceHeader.CustomerAddress = txtCustomerAddress.Text;
            objInvoiceHeader.InvoiceComments = txtComments.Text;
            objInvoiceHeader.InvoiceDate = Convert.ToDateTime(txtInvoiceDate.Text);
            if (objInvoiceHeader.getSelectedIndex() != 0)
            {
                if (txtTaxAmount.Text != "")
                {
                    objInvoiceHeader.getSelectedInvoice().TaxAmount = Convert.ToDouble(txtTaxAmount.Text);
                }
                if (txtAmountPaid.Text.Length != 0)
                {
                    objInvoiceHeader.getSelectedInvoice().PaidAmount = Convert.ToDouble(txtAmountPaid.Text);
                }
                if (lblTotalAmountToBePaid.Text.Length != 0)
                {
                    objInvoiceHeader.getSelectedInvoice().Amount = Convert.ToDouble(lblTotalAmountToBePaid.Text);
                }
                if (int.TryParse(lblProductUnitCost.Text, out value))
                {
                    objInvoiceHeader.getSelectedInvoice().UnitCost = Convert.ToDouble(lblProductUnitCost.Text);
                }
                if (objProductSelected != null)
                {
                    objInvoiceHeader.getSelectedInvoice().ProductId = objProductSelected.ProductId;
                }
                if (int.TryParse(TxtQuantity.Text, out value))
                {
                    objInvoiceHeader.getSelectedInvoice().Quantity = Convert.ToInt16(TxtQuantity.Text);
                }
            }
        }
        private void setInvoiceProduct(clsProduct objProduct)
        {
            if (objInvoiceHeader.getSelectedIndex() != 0)
            {
                objInvoiceHeader.getSelectedInvoice().UnitCost = objProduct.UnitCost;
                objInvoiceHeader.getSelectedInvoice().ProductDescription = objProduct.ProductDescription;
                objInvoiceHeader.getSelectedInvoice().ProductId = objProduct.ProductId;
            }
        }
        public void setUIfromObject(clsInvoiceHeader objInvoice)
        {
            txtCustomerName.Text = objInvoice.CustomerName;
            txtCustomerAddress.Text = objInvoice.CustomerAddress;
            txtComments.Text = objInvoice.InvoiceComments;
            txtInvoiceDate.Text = objInvoice.InvoiceDate.ToString();
            txtInvoiceNumber.Text = objInvoice.InvoiceReference.ToString();
            if (objInvoice.getSelectedIndex() != 0)
            {
                txtTaxAmount.Text = objInvoice.getSelectedInvoice().TaxAmount.ToString();
                txtAmountPaid.Text = objInvoice.getSelectedInvoice().PaidAmount.ToString();
                lblTotalAmountToBePaid.Text = objInvoice.getSelectedInvoice().Amount.ToString();
                lblProductUnitCost.Text = objInvoice.getSelectedInvoice().UnitCost.ToString();
                TxtQuantity.Text = objInvoice.getSelectedInvoice().Quantity.ToString();
                lblProductName.Text = objInvoice.getSelectedInvoice().ProductDescription.ToString();
                lblProductDescription.Text = lblProductName.Text;
                lblProductUnitCost.Text = objInvoice.getSelectedInvoice().UnitCost.ToString();
                lblTotalAmountToBePaid.Text = objInvoice.getSelectedInvoice().Amount.ToString();
            }
            dtgInvoiceDetails.DataSource = objInvoice.getInvoiceDetails();
            dtgInvoiceDetails.DataBind();

        }
        private void clearSession()
        {
            Session["InvoiceSession"] = null;
            Session["SelectedProduct"] = null;
        }
        protected void btnUpdateInvoice_Click(object sender, EventArgs e)
        {
            clsInvoiceHeader objInvHeader = (clsInvoiceHeader)Session["InvoiceSession"];
            objInvHeader.addInvoiceDetails();
            setObjectFromUI(objInvHeader);
            clearInvoiceDetailText();
            objInvHeader.Update();
            Session["InvoiceSession"] = objInvHeader;
        }
        protected void btnDeleteInvoice_Click(object sender, EventArgs e)
        {

        }

        protected void dtgInvoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsInvoiceHeader objInvoiceHeader = new clsInvoiceHeader();
            objInvoiceHeader.LoadInvoice(Convert.ToInt16(dtgInvoice.Items[dtgInvoice.SelectedIndex].Cells[1].Text));
            dtgInvoiceDetails.DataSource = objInvoiceHeader.getInvoiceDetails();
            dtgInvoiceDetails.DataBind();
            Session["InvoiceSession"] = objInvoiceHeader;
            objInvoiceHeader.MoveNext();
            setUIfromObject(objInvoiceHeader);

        }
        protected void btnProducts_Click(object sender, EventArgs e)
        {

        }
        protected void btnProductsSelect_Click(object sender, EventArgs e)
        {
            try
            {
                setObjectFromUI(getSessionInvoice());
                Response.Redirect("SelectProducts.aspx");
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message.ToString();
            }
        }
        private clsInvoiceHeader getSessionInvoice()
        {
            clsInvoiceHeader objInvoiceHeader = (clsInvoiceHeader)Session["InvoiceSession"];
            return objInvoiceHeader;
        }
        protected void TxtQuantity_TextChanged(object sender, EventArgs e)
        {

            lblTotalAmountToBePaid.Text = Convert.ToString(Convert.ToInt16(TxtQuantity.Text) * Convert.ToDouble(lblProductUnitCost.Text));
            clsInvoiceHeader objInvoiceHeader = getSessionInvoice();
            setObjectFromUI(objInvoiceHeader);
        }

        protected void btnAddInvoiceDetails_Click(object sender, EventArgs e)
        {

            clsInvoiceHeader obj = (clsInvoiceHeader)Session["InvoiceSession"];
            if (obj.getSelectedIndex() == 0)
            {
                obj.addInvoiceDetails();
            }
            if (Session["SelectedProduct"] != null)
            {
                obj.getSelectedInvoice().ProductId = ((clsProduct)Session["SelectedProduct"]).ProductId;
            }
            setObjectFromUI(obj);
            objInvoiceHeader.Update();
            clearInvoiceDetailText();
            setUIfromObject(obj);
        }
        protected void dtgInvoiceDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            objInvoiceHeader = getSessionInvoice();
            objInvoiceHeader.Move(dtgInvoiceDetails.SelectedIndex + 1);
            setUIfromObject(objInvoiceHeader);
        }
    }
}