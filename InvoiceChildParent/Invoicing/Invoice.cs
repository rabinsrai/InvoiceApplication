using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using InvoiceChildParent.InvoicingDataLayer;

namespace InvoiceChildParent.Invoicing
{
    public class clsInvoiceDetail
    {
        private int _InvoiceDetailsId;
        private int _Id;
        private int _ProductId;
        private int _Qty;
        private double _Amount;
        private double _PaidAmount;
        private double _TaxAmount;
        private double _UnitCost = 0;
        private bool _boolDelete;
        private string _Description = "";
        public int Id
        {
            set
            {
                _Id = value;
            }
            get
            {
                return _Id;
            }
        }
        public int InvoiceDetailsid
        {
            set
            {
                _InvoiceDetailsId = value;
            }
            get
            {
                return _InvoiceDetailsId;
            }
        }
        public int ProductId
        {
            set
            {
                if (value == 0)
                {
                    throw new Exception("Product  is compulsory");

                }
                _ProductId = value;
            }
            get
            {
                return _ProductId;
            }
        }
        public int Quantity
        {
            set
            {
                if (value < 1)
                {
                    throw new Exception("Quantity should be numeric");
                }
                _Qty = value;
                _Amount = _UnitCost * _Qty;
            }
            get
            {
                return _Qty;
            }
        }
        public double Amount
        {
            set
            {
                _Amount = value;
            }
            get
            {
                return _Amount;
            }
        }
        public double PaidAmount
        {
            set
            {
                _PaidAmount = value;
            }
            get
            {
                return _PaidAmount;
            }
        }
        public double TaxAmount
        {
            set
            {
                _TaxAmount = value;
            }
            get
            {
                return _TaxAmount;
            }
        }
        public double UnitCost
        {
            set
            {
                if (value == 0)
                {
                    throw new Exception("Unit cost is compulsory");
                }
                _UnitCost = value;
                _Amount = _UnitCost * _Qty;
            }
            get
            {
                return _UnitCost;
            }
        }
        public string ProductDescription
        {
            set
            {
                _Description = value;
            }
            get
            {
                return _Description;
            }
        }
        public void Delete()
        {
            _boolDelete = true;
        }
        public void Update(int _InvoiceReference)
        {
            clsInvoiceDB objInvoiceDB = new clsInvoiceDB();
            objInvoiceDB.InsertInvoiceDetails(_Id, _InvoiceReference, _ProductId, _Qty, _Amount, _TaxAmount, _PaidAmount, _UnitCost);

        }
    }
    public class clsInvoiceDetails : CollectionBase
    {
        public void addInvoiceDetails(clsInvoiceDetail objInvoiceDetail)
        {
            List.Add(objInvoiceDetail);
        }
        public clsInvoiceDetail getSelectedIndex(int intSelectedIndex)
        {
            return (clsInvoiceDetail)List[intSelectedIndex - 1];
        }
    }
    public class clsInvoiceHeader
    {
        private clsInvoiceDetails objInvoiceDetails = new clsInvoiceDetails();
        private int intSelectedIndex;
        private int _InvoiceReference;
        private string _InvoiceComments = "";
        private DateTime _InvoiceDate;
        private double _TaxAmount;
        private string _CustomerName = "";
        private string _CustomerAddress = "";
        public int InvoiceReference
        {
            get
            {
                return _InvoiceReference;
            }
        }
        public string InvoiceComments
        {
            set
            {
                _InvoiceComments = value;
            }
            get
            {
                return _InvoiceComments;
            }
        }
        public DateTime InvoiceDate
        {
            set
            {
                _InvoiceDate = value;
            }
            get
            {
                return _InvoiceDate;
            }
        }
        public string CustomerName
        {
            set
            {
                if (value.Length == 0)
                {
                    throw new Exception("Customer Name is compulsory");
                }
                _CustomerName = value;
            }
            get
            {
                return _CustomerName;
            }
        }
        public string CustomerAddress
        {
            set
            {
                _CustomerAddress = value;
            }
            get
            {
                return _CustomerAddress;
            }
        }
        public int getSelectedIndex()
        {
            return intSelectedIndex;
        }
        public void Move(int intIndex)
        {
            intSelectedIndex = intIndex;
        }
        public void MoveNext()
        {
            intSelectedIndex++;
        }
        public void MovePrevious()
        {
            intSelectedIndex--;
        }
        public clsInvoiceDetail getSelectedInvoice()
        {
            return objInvoiceDetails.getSelectedIndex(intSelectedIndex);
        }
        public clsInvoiceDetail getSelectedInvoice(int _intSelectedIndex)
        {
            return objInvoiceDetails.getSelectedIndex(_intSelectedIndex);
        }
        public clsInvoiceDetails getInvoiceDetails()
        {
            return objInvoiceDetails;
        }
        public void addInvoiceDetails()
        {

            clsInvoiceDetail objInvoiceDetail = new clsInvoiceDetail();
            objInvoiceDetails.addInvoiceDetails(objInvoiceDetail);
            intSelectedIndex = objInvoiceDetails.Count;
        }
        public void Insert()
        {
            clsInvoiceDB objInvoiceDb = new clsInvoiceDB();
            _InvoiceReference = objInvoiceDb.InsertInvoiceHeader(_InvoiceReference, _InvoiceComments, _InvoiceDate, _CustomerName, _CustomerAddress);
            foreach (clsInvoiceDetail obj in objInvoiceDetails)
            {
                obj.Update(_InvoiceReference);
            }
        }
        public void Update()
        {
            intSelectedIndex = 0;
        }
        public void Delete()
        {

        }
        public DataSet getInvoice()
        {
            clsInvoiceDB objInvoiceDB = new clsInvoiceDB();
            return objInvoiceDB.getInvoice(0);
        }
        public void LoadInvoice(int InvoiceNumber)
        {
            DataSet objdataset = null;
            int intRef;
            clsInvoiceDB objInvoiceDB = new clsInvoiceDB();
            objdataset = objInvoiceDB.getInvoice(InvoiceNumber);
            if (objdataset.Tables[0].Rows.Count != 0)
            {
                _CustomerName = objdataset.Tables[0].Rows[0]["Customername"].ToString();
                _CustomerAddress = objdataset.Tables[0].Rows[0]["CustomerAddress"].ToString();
                _InvoiceReference = Convert.ToInt16(objdataset.Tables[0].Rows[0]["InvoiceNumber"].ToString());
                _InvoiceComments = objdataset.Tables[0].Rows[0]["InvoiceComments"].ToString();
                _InvoiceDate = Convert.ToDateTime(objdataset.Tables[0].Rows[0]["InvoiceDate"].ToString());

                foreach (DataRow objRow in objdataset.Tables[0].Rows)
                {
                    clsInvoiceDetail objInvDetail = new clsInvoiceDetail();
                    objInvDetail.Id = Convert.ToInt16(objRow["InvoiceDetailsid"].ToString());
                    objInvDetail.InvoiceDetailsid = _InvoiceReference;
                    objInvDetail.ProductId = Convert.ToInt16(objRow["Productid_fk"].ToString());
                    objInvDetail.ProductDescription = objRow["ProductDescription"].ToString();
                    objInvDetail.Quantity = Convert.ToInt16(objRow["Qty"].ToString());
                    objInvDetail.Amount = Convert.ToDouble(objRow["Amount"].ToString());
                    objInvDetail.TaxAmount = Convert.ToDouble(objRow["TaxAmount"].ToString());
                    objInvDetail.PaidAmount = Convert.ToDouble(objRow["PaidAmount"].ToString());
                    objInvDetail.UnitCost = Convert.ToDouble(objRow["UnitCost"].ToString());
                    objInvoiceDetails.addInvoiceDetails(objInvDetail);
                }
            }


        }
    }
    public class clsProduct
    {
        private int _ProductId;
        private string _productDescription;
        private double _UnitCost;
        public int ProductId
        {
            set
            {
                _ProductId = value;
            }
            get
            {
                return _ProductId;
            }
        }
        public string ProductDescription
        {
            set
            {
                _productDescription = value;
            }
            get
            {
                return _productDescription;
            }
        }
        public double UnitCost
        {
            set
            {
                _UnitCost = value;
            }
            get
            {
                return _UnitCost;
            }
        }
        public DataSet getProducts()
        {
            clsInvoiceDB objInvoiceDB = new clsInvoiceDB();
            return objInvoiceDB.getProducts();
        }
    }
}