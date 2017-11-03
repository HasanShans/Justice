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

namespace Justice.Main
{
    public partial class RecoverPassword : System.Web.UI.Page
    {
        
        String Guid;
        DataTable dataTable = new DataTable();
        int UserID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DB.Connection.State == ConnectionState.Closed)
                DB.Connection.Open();
            Guid = Request.QueryString["UserID"];
            if (Guid != null)
            {
                SqlCommand sqlCommand = new SqlCommand("ForgotPassRequestsGetByGuid", DB.Connection);
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
            if (DB.Connection.State == ConnectionState.Closed)
                DB.Connection.Open();
            if (tbPass.Text == tbPassConf.Text && tbPass.Text != "" && tbPassConf.Text != "")
            {
                SqlCommand sqlCommand = new SqlCommand("UsersUpdatePassword", DB.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ID", UserID);
                sqlCommand.Parameters.AddWithValue("@Password", tbPass.Text.Trim());
                sqlCommand.ExecuteNonQuery();
                SqlCommand sqlCommand1 = new SqlCommand("ForgotPassRequestsDeleteByUid", DB.Connection);
                sqlCommand1.CommandType = CommandType.StoredProcedure;
                sqlCommand1.Parameters.AddWithValue("@UserID", UserID);
                sqlCommand1.ExecuteNonQuery();
                DB.Connection.Close();
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