using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace InvoiceChildParent.InvoicingDataLayer
{
    public class clsInvoiceDB
    {
        
       // private Database objDatabase = DatabaseFactory.CreateDatabase("ConnectionString");
        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        Database objDatabase = factory.Create("ConnectionString");
       // private Database objDatabase = DatabaseFactory.CreateDatabase();
        public int InsertInvoiceHeader(int _InvoiceReference, string _InvoiceComments, DateTime _InvoiceDate, string _CustomerName, string _CustomerAddress)
        {
            object[] objParams = { _InvoiceReference, _InvoiceComments, _InvoiceDate, _CustomerName, _CustomerAddress };
            int newRowId = Convert.ToInt32(objDatabase.ExecuteScalar("usp_InsertHeader", objParams));
            if (_InvoiceReference != 0)
            {
                newRowId = _InvoiceReference;
            }

            return newRowId;
        }
        public void InsertInvoiceDetails(int _InvoiceDetailsid, int _InvoiceHeaderidfk, int _productidfk, int _Qty, double _Amount, double _TaxAmount, double _PaidAmount, double _UnitCost)
        {
            objDatabase.ExecuteNonQuery("usp_InsertInvoiceDetails", _InvoiceDetailsid, _InvoiceHeaderidfk, _productidfk, _Qty, _Amount, _TaxAmount, _PaidAmount, _UnitCost);
        }
        public void UpdateInvoice(int _InvoiceReference, string _InvoiceComments, DateTime _InvoiceDate, int _productId, int _Qty, double _Amount, double _TaxAmount, double _PaidAmount, string _CustomerName, string _CustomerAddress, double _UnitCost)
        {
            objDatabase.ExecuteNonQuery("usp_UpdateInvoice", _InvoiceReference, _InvoiceComments, _InvoiceDate, _productId, _Qty, _Amount, _TaxAmount, _PaidAmount, _CustomerName, _CustomerAddress, _UnitCost);

        }
        public void DeleteInvoice(int _InvoiceReference)
        {
            objDatabase.ExecuteNonQuery("usp_DeleteInvoice", _InvoiceReference);
        }
        public DataSet getInvoice(int _InvoiceReference)
        {
            return objDatabase.ExecuteDataSet("usp_getInvoice", _InvoiceReference);
        }
        public DataSet getProducts()
        {
            return objDatabase.ExecuteDataSet("usp_getProducts");
        }
    }
}