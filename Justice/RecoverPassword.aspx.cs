using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Justice.App_Code;

namespace Justice
{
    public partial class RecoverPassword : System.Web.UI.Page
    {
        
        String Guid;
        DataTable dataTable = new DataTable();
        int UserID;
        protected void Page_Load(object sender, EventArgs e)
        {
          
            Guid = Request.QueryString["UserID"];
            if (Guid != null)
            {
                using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand("ForgotPassRequestsGetByGuid", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@ID", Guid);
                    sqlCommand.ExecuteNonQuery();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlDataAdapter.Fill(dataTable);
                    if (dataTable.Rows.Count != 0)
                    {
                        UserID = Convert.ToInt32(dataTable.Rows[0]["UserID"]);
                    }
                    else
                    {
                        lblMsg.Font.Size = 15;
                        lblMsg.ForeColor = System.Drawing.Color.Black;
                        lblMsg.Text = "Sizin Şifrə Yeniləmə Linkinizin Vaxtı Bitib";
                    }
                }
            }
            else
            {
                Response.Redirect("~/login");
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
            if (tbPass.Text == tbPassConf.Text && tbPass.Text != "" && tbPassConf.Text != "")
            {
                using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
                {
                    connection.Open();
                    String newSalt = HashPassword.CreateSalt(10);
                    String newHashedPassword = HashPassword.GenerateSHA256Hash(tbPass.Text, newSalt);
                    SqlCommand sqlCommand = new SqlCommand("UsersUpdatePassword", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@ID", UserID);
                    sqlCommand.Parameters.AddWithValue("@Password", newHashedPassword);
                    sqlCommand.Parameters.AddWithValue("@Salt", newSalt);
                    sqlCommand.ExecuteNonQuery();
                    SqlCommand sqlCommand1 = new SqlCommand("ForgotPassRequestsDeleteByUid", connection);
                    sqlCommand1.CommandType = CommandType.StoredProcedure;
                    sqlCommand1.Parameters.AddWithValue("@UserID", UserID);
                    sqlCommand1.ExecuteNonQuery();
                    tbPass.Visible = false;
                    tbPassConf.Visible = false;
                    lblPass.Visible = false;
                    lblPassConf.Visible = false;
                    btRequestForgot.Visible = false;
                    lblMsg.Font.Size = 15;
                    lblMsg.Text = "Şifrəniz Yeniləndi";
                    ModalSuccess.LabelModalMsg.Text = "Hörmətli istifadəçi, sizin şifrəniz uğurla yeniləndi. Aşağıdakı 'Login' düyməsinə klikləyərək hesabınıza daxil ola bilərsiniz.";
                    ModalSuccess.LabelModalMsg.Font.Size = 12;
                    ModalSuccess.HlLogin.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                }
            }
        }
    }
}