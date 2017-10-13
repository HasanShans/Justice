using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Justice.Main
{
    public partial class RecoverPassword : System.Web.UI.Page
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=GADIR\SQLEXPRESS;Initial Catalog=PrisonShop;Integrated Security=True");
        String Guid;
        DataTable dataTable = new DataTable();
        int UserID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();
            Guid = Request.QueryString["UserID"];
            if (Guid != null)
            {
                SqlCommand sqlCommand = new SqlCommand("ForgotPassRequestsGetByGuid", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ID", Guid);
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count != 0)
                {
                    UserID = Convert.ToInt32(dataTable.Rows[0][1]);
                }
                else
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Sizin Şifrə Yeniləmə Linkinizin Vaxtı Bitib";
                }
            }
            else
            {
                Response.Redirect("~/Main/Login.aspx");
            }
            if (!IsPostBack)
            {
                if (dataTable.Rows.Count != 0)
                {
                    tbPass.Visible = true;
                    tbPassConf.Visible = true;
                    lblPass.Visible = true;
                    lblPassConf.Visible = true;
                    btRequestForgot.Visible = true;
                }
                else
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Sizin Şifrə Yeniləmə Linkinizin Vaxtı Bitib";
                }
            }
        }

        protected void btPassRec_Click(object sender, EventArgs e)
        {
            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();
            if (tbPass.Text == tbPassConf.Text && tbPass.Text != "" && tbPassConf.Text != "")
            {
                SqlCommand sqlCommand = new SqlCommand("UsersUpdatePassword", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ID", UserID);
                sqlCommand.Parameters.AddWithValue("@Password", tbPass.Text.Trim());
                sqlCommand.ExecuteNonQuery();
                SqlCommand sqlCommand1 = new SqlCommand("ForgotPassRequestsDeleteByUid", sqlConnection);
                sqlCommand1.CommandType = CommandType.StoredProcedure;
                sqlCommand1.Parameters.AddWithValue("@UserID", UserID);
                sqlCommand1.ExecuteNonQuery();
                sqlConnection.Close();
                Response.Redirect("~/Main/Index.aspx");
            }
        }
    }
}