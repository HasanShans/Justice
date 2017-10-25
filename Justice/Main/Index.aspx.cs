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
    public partial class Index : System.Web.UI.Page
    {
        public Dictionary<string, string> data = new Dictionary<string, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindProducts();
            BindMostSoldProducts();
            BindNewProducts();
            BindConceptProducts();
        }
        private void BindMostSoldProducts()
        {
            if (DB.Connection.State == ConnectionState.Closed)
                DB.Connection.Open();
            SqlCommand sqlCommand = new SqlCommand("ProductsSelectMostSold", DB.Connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count != 0)
            {
                data.Add("MSImagePath", dataTable.Rows[0]["ID"].ToString()+"/"+ dataTable.Rows[0]["Name"].ToString()+ dataTable.Rows[0]["Extention"].ToString());
                data.Add("MSProductName", dataTable.Rows[0]["ProductName"].ToString());
                data.Add("MSPrice", dataTable.Rows[0]["DiscountPrice"].ToString());
            }
            
        }
        private void BindNewProducts()
        {
            if (DB.Connection.State == ConnectionState.Closed)
                DB.Connection.Open();
            SqlCommand sqlCommand = new SqlCommand("ProductsSelectNew", DB.Connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count != 0)
            {
                data.Add("NPImagePath", dataTable.Rows[0]["ID"].ToString() + "/" + dataTable.Rows[0]["Name"].ToString() + dataTable.Rows[0]["Extention"].ToString());
                data.Add("NPProductName", dataTable.Rows[0]["ProductName"].ToString());
                data.Add("NPPrice", dataTable.Rows[0]["DiscountPrice"].ToString());
            }
        }
        private void BindConceptProducts()
        {

        }
        private void BindProducts()
        {
            if (DB.Connection.State == ConnectionState.Closed)
                DB.Connection.Open();
            SqlCommand sqlCommand;
            if (Request.QueryString.AllKeys.Contains("Category"))
            {
                String categoryName = Request.QueryString["Category"].ToString();
                sqlCommand = new SqlCommand("ProductsSelectByCategoryNameJoinCategoriesImages", DB.Connection);
                sqlCommand.Parameters.AddWithValue("@CategoryName", categoryName);
            }
            else
            {
                sqlCommand = new SqlCommand("ProductsSelectAllJoinImages", DB.Connection);
            }
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