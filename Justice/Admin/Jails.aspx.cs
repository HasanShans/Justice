using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Justice.App_Code;

namespace Justice.Admin
{
    public partial class Jails : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindJails();
            }
        }

        private void BindJails()
        {
            if (DB.Connection.State == ConnectionState.Closed)
                DB.Connection.Open();
            SqlCommand sqlCommand = new SqlCommand("JailsSelectAll", DB.Connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            rprtJails.DataSource = dataTable;
            rprtJails.DataBind();
            DB.Connection.Close();
        }

        protected void JailEditClick(object sender, EventArgs e)
        {
            int JailID = int.Parse(((sender as Button).NamingContainer.FindControl("lblJailID") as Label).Text);
            Response.Redirect("~/Admin/Add/Jail?JailID=" + JailID);
        }

        protected void JailDeleteClick(object sender, EventArgs e)
        {
            int JailID = int.Parse(((sender as Button).NamingContainer.FindControl("lblJailID") as Label).Text);
            if (DB.Connection.State == ConnectionState.Closed)
                DB.Connection.Open();
            SqlCommand sqlCommand = new SqlCommand("JailsDeleteByID", DB.Connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("ID", JailID);
            sqlCommand.ExecuteNonQuery();
            BindJails();
            DB.Connection.Close();
        }
    }
}