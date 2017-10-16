using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Justice.Admin
{
    public partial class Categories : System.Web.UI.Page
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=GADIR\SQLEXPRESS;Initial Catalog=PrisonShop;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategories();
            }
        }

        private void BindCategories()
        {
            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("CategoriesSelectAll", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            rprtCategories.DataSource = dataTable;
            rprtCategories.DataBind();
        }

        protected void CategoryEditClick(object sender, EventArgs e)
        {
            int CategoryID = int.Parse(((sender as Button).NamingContainer.FindControl("lblCatID") as Label).Text);
            Response.Redirect("~/Admin/Add/Category?CategoryID=" + CategoryID);
        }

        protected void CategoryDeleteClick(object sender, EventArgs e)
        {
            int CategoryID = int.Parse(((sender as Button).NamingContainer.FindControl("lblCatID") as Label).Text);
            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("CategoriesDeleteByID", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("ID", CategoryID);
            sqlCommand.ExecuteNonQuery();
            BindCategories();
        }
    }
}