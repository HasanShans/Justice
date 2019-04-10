using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Justice.App_Code;

namespace Justice.Staff.Add
{
    public partial class Jail : System.Web.UI.Page
    {
        int JailID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.AllKeys.Contains("JailID"))
            {
                BindJailDetails();
            }
            else
            {
                btnSave.Visible = true;
                btnEdit.Visible = false;
            }
        }
        private void BindJailDetails()
        {
            JailID = Convert.ToInt32(Request.QueryString["JailID"]);
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("JailsSelectByID", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ID", JailID);
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (!IsPostBack)
                {
                    txtJail.Text = dataTable.Rows[0]["JailName"].ToString();
                    txtJailNo.Text = dataTable.Rows[0]["JailNo"].ToString();
                }
                btnEdit.Visible = true;
                btnSave.Visible = false;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                SqlCommand sqlCommand;
                if (Request.QueryString.AllKeys.Contains("JailID"))
                {
                    sqlCommand = new SqlCommand("JailsUpdate", connection);
                    sqlCommand.Parameters.AddWithValue("@ID", JailID);
                }
                else
                {
                    sqlCommand = new SqlCommand("JailsCreate", connection);
                }
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@JailName", txtJail.Text.ToString().Trim());
                sqlCommand.Parameters.AddWithValue("@jailNo", txtJailNo.Text.ToString().Trim());
                sqlCommand.ExecuteNonQuery();
            }
            Response.Redirect("~/root/həbsxanalar");
        }
    }
}
