using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Net.Mail;
using System.Net;

namespace Justice.Main
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=GADIR\SQLEXPRESS;Initial Catalog=PrisonShop;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btPassRec_Click(object sender, EventArgs e)
        {
            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("UsersSelectByEmail", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Email", tbEmail.Text.Trim());
            sqlCommand.ExecuteNonQuery();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count != 0)
            {
                if (Convert.ToInt32(dataTable.Rows[0][11]) == 1)
                {
                    String Name = dataTable.Rows[0][1] + " " + dataTable.Rows[0][2];
                    String myGUID = Guid.NewGuid().ToString();
                    int Uid = Convert.ToInt32(dataTable.Rows[0][0]);
                    SqlCommand sqlCommand1 = new SqlCommand("ForgotPassRequestsCreate", sqlConnection);
                    sqlCommand1.CommandType = CommandType.StoredProcedure;
                    sqlCommand1.Parameters.AddWithValue("@ID", myGUID);
                    sqlCommand1.Parameters.AddWithValue("@UserID", Uid);
                    sqlCommand1.Parameters.AddWithValue("@RequestDatetime", DateTime.Now);
                    sqlCommand1.ExecuteNonQuery();

                    //Send Mail

                    String toEmailAddress = dataTable.Rows[0][3].ToString();
                    String username = dataTable.Rows[0][1].ToString();
                    String messageBody = "Salam, Hörmətli " + Name + ". <br/><br/>Şifrənizi yeniləmək <a href=\" http://localhost:50857/Main/RecoverPassword.aspx?UserID=" + myGUID + "\">bu linkə</a> klikləyin. <br/><br/>Həbsxana İncəsənəti";
                    MailMessage mailMessage = new MailMessage("youremail@address.com", toEmailAddress);
                    mailMessage.Body = messageBody;
                    mailMessage.IsBodyHtml = true;
                    mailMessage.Subject = "Yeni Şifrə";

                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                    smtpClient.Credentials = new NetworkCredential("hebsxana.art@gmail.com", "Puwu6917");
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(mailMessage);

                    lblMsg.Text = "Şifrənizi Yeniləmək Üçün Email-nizi Yoxlayın";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMsg.Text = "Hörmətli İstifadəçi, Sizin Hesabınız Təsdiqlənməyib. Hesabınızı Təsdiqləmək üçün Email-nizi Yoxlayın.";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblMsg.Text = "Hörmətli İstifadəçi, Sizin Email-niz Bizim Bazamızda Tapılmadı";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}

