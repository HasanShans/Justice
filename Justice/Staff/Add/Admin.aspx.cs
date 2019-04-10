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
    public partial class Admin : System.Web.UI.Page
    {
        int AdminID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindJails();
            }
            if (Request.QueryString.AllKeys.Contains("AdminID"))
            {
                BindAdminDetails();
            }
            else
            {
                btnSave.Visible = true;
                btnEdit.Visible = false;
            }
        }
        private void BindJails()
        {
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("JailsSelectAll", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count != 0)
                {
                    ddlJails.DataSource = dataTable;
                    ddlJails.DataTextField = "JailName";
                    ddlJails.DataValueField = "JailNo";
                    ddlJails.DataBind();
                }
            }
        }
        private void BindAdminDetails()
        {
            AdminID = Convert.ToInt32(Request.QueryString["AdminID"]);
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("AdminsSelectByID", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ID", AdminID);
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (!IsPostBack)
                {
                    txtAdmin.Text = dataTable.Rows[0]["UserName"].ToString();
                    ddlJails.SelectedValue = dataTable.Rows[0]["JailNum"].ToString();
                    tbPassword.Text = dataTable.Rows[0]["DecryptedPass"].ToString();
                }
                btnEdit.Visible = true;
                btnSave.Visible = false;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            String salt = HashPassword.CreateSalt(10);
            String hashedpassword = HashPassword.GenerateSHA256Hash(tbPassword.Text, salt);
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                SqlCommand sqlCommand;
                if (Request.QueryString.AllKeys.Contains("AdminID"))
                {
                    sqlCommand = new SqlCommand("AdminsUpdate", connection);
                    sqlCommand.Parameters.AddWithValue("@ID", AdminID);
                }
                else
                {
                    sqlCommand = new SqlCommand("AdminsCreate", connection);
                    sqlCommand.Parameters.AddWithValue("@Status", 2);
                }
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@DecryptedPass", tbPassword.Text);
                sqlCommand.Parameters.AddWithValue("@Password", hashedpassword);
                sqlCommand.Parameters.AddWithValue("@Salt", salt);
                sqlCommand.Parameters.AddWithValue("@UserName", txtAdmin.Text.ToString().Trim());
                sqlCommand.Parameters.AddWithValue("@JailNum", Convert.ToInt32(ddlJails.SelectedItem.Value));
                sqlCommand.ExecuteNonQuery();
            }
            Response.Redirect("~/root/satıcılar");
        }
    }
}