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
using Justice.App_Code;

namespace Justice
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btPassRec_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("UsersSelectByEmail", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Email", tbEmail.Text.Trim());
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count != 0)
                {
                    if (Convert.ToInt32(dataTable.Rows[0]["Verified"]) == 1)
                    {
                        String Name = dataTable.Rows[0]["FirstName"] + " " + dataTable.Rows[0]["LastName"];
                        String myGUID = Guid.NewGuid().ToString();
                        int Uid = Convert.ToInt32(dataTable.Rows[0]["ID"]);
                        SqlCommand sqlCommand1 = new SqlCommand("ForgotPassRequestsCreate", connection);
                        sqlCommand1.CommandType = CommandType.StoredProcedure;
                        sqlCommand1.Parameters.AddWithValue("@ID", myGUID);
                        sqlCommand1.Parameters.AddWithValue("@UserID", Uid);
                        sqlCommand1.Parameters.AddWithValue("@RequestDatetime", DateTime.Now);
                        sqlCommand1.ExecuteNonQuery();

                        //Send Mail

                        String toEmailAddress = dataTable.Rows[0]["Email"].ToString();
                        String messageBody = "Salam, Hörmətli " + Name + ". <br/><br/>Şifrənizi yeniləmək <a href=\"https://prisonart.gov.az/şifrə-bərpası?UserID=" + myGUID + "\">bu linkə</a> klikləyin. <br/><br/>Həbsxana İncəsənəti";
                        MailMessage mailMessage = new MailMessage("youremail@address.com", toEmailAddress);
                        mailMessage.Body = messageBody;
                        mailMessage.IsBodyHtml = true;
                        mailMessage.Subject = "Yeni Şifrə";

                        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                        smtpClient.Credentials = new NetworkCredential("hebsxana.art@gmail.com", "Puwu6917");
                        smtpClient.EnableSsl = true;
                        smtpClient.Send(mailMessage);

                        Label1.Visible = false;
                        Label2.Visible = false;
                        tbEmail.Visible = false;
                        btRequestForgot.Visible = false;
                        lblMsg.Font.Size = 15;
                        lblMsg.Text = "Şifrənizi Yeniləmək Üçün Email-nizi Yoxlayın";
                        lblMsg.ForeColor = System.Drawing.Color.Black;
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
}

