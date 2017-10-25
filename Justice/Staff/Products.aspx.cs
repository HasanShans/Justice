using Justice.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace Justice.Staff
{
    public partial class Products : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProducts();
            }
        }

        private void BindProducts()
        {
            if (DB.Connection.State == ConnectionState.Closed)
                DB.Connection.Open();
            SqlCommand sqlCommand = new SqlCommand("ProductsSelectAllJoinCategoriesAndJails", DB.Connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            rprtProducts.DataSource = dataTable;
            rprtProducts.DataBind();
            DB.Connection.Close();
        }

        protected void ProductEditClick(object sender, EventArgs e)
        {
            int ProductID = int.Parse(((sender as Button).NamingContainer.FindControl("lblProductID") as Label).Text);
            Response.Redirect("~/Staff/Add/Product?ProductID=" + ProductID);
        }

        protected void ProductDeleteClick(object sender, EventArgs e)
        {
            int ProductID = int.Parse(((sender as Button).NamingContainer.FindControl("lblProductID") as Label).Text);
            if (DB.Connection.State == ConnectionState.Closed)
                DB.Connection.Open();
            SqlCommand sqlCommand = new SqlCommand("ProductsDeleteByID", DB.Connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@ID", ProductID);
            sqlCommand.ExecuteNonQuery();
            BindProducts();
            DB.Connection.Close();
        }
    }
}
