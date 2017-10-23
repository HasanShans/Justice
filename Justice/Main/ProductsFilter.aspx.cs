using Justice.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Justice.Main
{
    public partial class ProductsSoon : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.AllKeys.Contains("ProductsSoon"))
            {
                BindProductsSoon();
            }else if (Request.QueryString.AllKeys.Contains("ProductsMostSold"))
            {
                BindMostSoldProducts();
            }else if (Request.QueryString.AllKeys.Contains("ProductsNew"))
            {
                BindNewProducts();
            }else if (Request.QueryString.AllKeys.Contains("ProductsConcept"))
            {
                BindNewProducts();
            }
        }
        private void BindMostSoldProducts()
        {
            if(DB.Connection.State == ConnectionState.Closed)
                DB.Connection.Open();
            SqlCommand sqlCommand = new SqlCommand("ProductsSelectMostSoldAll", DB.Connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count != 0)
            {
                productRepeater.DataSource = dataTable;
                productRepeater.DataBind();
            }
        }
        private void BindNewProducts()
        {
            if (DB.Connection.State == ConnectionState.Closed)
                DB.Connection.Open();
            SqlCommand sqlCommand = new SqlCommand("ProductsSelectNewAll", DB.Connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count != 0)
            {
                productRepeater.DataSource = dataTable;
                productRepeater.DataBind();
            }
        }
        private void BindConceptProducts()
        {

        }
        private void BindProductsSoon()
        {
            if (DB.Connection.State == ConnectionState.Closed)
                DB.Connection.Open();
            SqlCommand sqlCommand = new SqlCommand("ProductsSelectAllByAvailability", DB.Connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count != 0)
            {
                productRepeater.DataSource = dataTable;
                productRepeater.DataBind();
            }
            else
            {

            }
        }
    }
}