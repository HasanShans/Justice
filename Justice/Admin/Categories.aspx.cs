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


namespace Justice.Admin
{
    public partial class Categories : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategories();
            }
        }

        private void BindCategories()
        {
            if (DB.Connection.State == ConnectionState.Closed)
                DB.Connection.Open();
            SqlCommand sqlCommand = new SqlCommand("CategoriesSelectAll", DB.Connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            rprtCategories.DataSource = dataTable;
            rprtCategories.DataBind();
            DB.Connection.Close();
        }

        protected void CategoryEditClick(object sender, EventArgs e)
        {
            int CategoryID = int.Parse(((sender as Button).NamingContainer.FindControl("lblCatID") as Label).Text);
            Response.Redirect("~/Admin/Add/Category?CategoryID=" + CategoryID);
        }

        protected void CategoryDeleteClick(object sender, EventArgs e)
        {
            int CategoryID = int.Parse(((sender as Button).NamingContainer.FindControl("lblCatID") as Label).Text);
            if (DB.Connection.State == ConnectionState.Closed)
                DB.Connection.Open();
            SqlCommand sqlCommand = new SqlCommand("CategoriesDeleteByID", DB.Connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("ID", CategoryID);
            sqlCommand.ExecuteNonQuery();
            BindCategories();
            DB.Connection.Close();
        }
    }
}
