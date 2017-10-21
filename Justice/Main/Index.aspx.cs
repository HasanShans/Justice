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
        
        protected void Page_Load(object sender, EventArgs e)
        {
            BindProducts();
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