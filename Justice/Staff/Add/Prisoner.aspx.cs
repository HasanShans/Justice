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
    public partial class Prisoner : System.Web.UI.Page
    {
        int PrisonerID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.AllKeys.Contains("PrisonerID"))
            {
                BindPrisonerDetails();
            }
            else
            {
                btnSave.Visible = true;
                btnEdit.Visible = false;
            }
        }
        private void BindPrisonerDetails()
        {
            PrisonerID = Convert.ToInt32(Request.QueryString["PrisonerID"]);
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("PrisonersSelectByID", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ID", PrisonerID);
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (!IsPostBack)
                {
                    txtPrisonerName.Text = dataTable.Rows[0]["FirstName"].ToString();
                    txtPrisonerSurname.Text = dataTable.Rows[0]["LastName"].ToString();
                    txtPrisonerInfo.Text = dataTable.Rows[0]["Information"].ToString();
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
                if (Request.QueryString.AllKeys.Contains("PrisonerID"))
                {
                    sqlCommand = new SqlCommand("PrisonersUpdate", connection);
                    sqlCommand.Parameters.AddWithValue("@ID", PrisonerID);
                }
                else
                {
                    sqlCommand = new SqlCommand("PrisonersCreate", connection);
                }
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@FirstName", txtPrisonerName.Text.ToString().Trim());
                sqlCommand.Parameters.AddWithValue("@LastName", txtPrisonerSurname.Text.ToString().Trim());
                sqlCommand.Parameters.AddWithValue("@Information", txtPrisonerInfo.Text.ToString().Trim());
                sqlCommand.ExecuteNonQuery();
            }
            Response.Redirect("~/root/məhbuslar");
        }
    }
}