using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Justice.Admin.Add
{
    public partial class Jail : System.Web.UI.Page
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=GADIR\SQLEXPRESS;Initial Catalog=PrisonShop;Integrated Security=True");
        int JailID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.AllKeys.Contains("JailID"))
            {
                JailID = Convert.ToInt32(Request.QueryString["JailID"]);
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("JailsSelectByID", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ID", JailID);
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (!IsPostBack)
                {
                    txtJail.Text = dataTable.Rows[0][1].ToString();
                }
                btnEdit.Visible = true;
                btnSave.Visible = false;
            }
            else
            {
                btnSave.Visible = true;
                btnEdit.Visible = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("JailsCreate", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@JailName", txtJail.Text.ToString().Trim());
            sqlCommand.ExecuteNonQuery();
            Response.Redirect("~/Admin/Jails.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("JailsUpdate", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@ID", JailID);
            sqlCommand.Parameters.AddWithValue("@JailName", txtJail.Text.ToString().Trim());
            sqlCommand.ExecuteNonQuery();
            Response.Redirect("~/Admin/Jails.aspx");
        }


    }
}