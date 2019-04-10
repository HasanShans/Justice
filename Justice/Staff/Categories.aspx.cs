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
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("CategoriesSelectAll", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                rprtCategories.DataSource = dataTable;
                rprtCategories.DataBind();
            }
        }

        protected void CategoryEditClick(object sender, EventArgs e)
        {
            int CategoryID = int.Parse(((sender as Button).NamingContainer.FindControl("lblCatID") as Label).Text);
            Response.Redirect("~/root/yeni-kateqoriya?CategoryID=" + CategoryID);
        }

        protected void CategoryDeleteClick(object sender, EventArgs e)
        {
            int CategoryID = int.Parse(((sender as Button).NamingContainer.FindControl("lblCatID") as Label).Text);
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("CategoriesDeleteByID", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("ID", CategoryID);
                sqlCommand.ExecuteNonQuery();
                BindCategories();
            }
        }
    }
}
