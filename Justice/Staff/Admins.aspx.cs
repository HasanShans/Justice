using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Justice.App_Code;

namespace Justice.Staff
{
    public partial class Admins : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAdmins();
            }
        }

        private void BindAdmins()
        {
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("AdminsSelectAll", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                rprtAdmins.DataSource = dataTable;
                rprtAdmins.DataBind();
            }
        }
        protected void AdminDeleteClick(object sender, EventArgs e)
        {
            int AdminID = int.Parse(((sender as Button).NamingContainer.FindControl("lblAdminID") as Label).Text);
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("AdminsDeleteByID", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("ID", AdminID);
                sqlCommand.ExecuteNonQuery();
                BindAdmins();
            }
        }
        protected void AdminEditClick(object sender, EventArgs e)
        {
            int AdminID = int.Parse(((sender as Button).NamingContainer.FindControl("lblAdminID") as Label).Text);
            Response.Redirect("~/root/yeni-admin?AdminID=" + AdminID);
        }
    }
}