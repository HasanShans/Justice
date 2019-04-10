using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Net;
using Justice.App_Code;

namespace Justice
{
    public partial class Register : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["NAME"] != null)
            {
                Response.Redirect("~/ana-səhifə");
            }
        }
        protected void btSignup_Click(object sender, EventArgs e)
        {
            bool isHuman = Captcha.Validate(txtCaptcha.Text);
            txtCaptcha.Text = null;
            if (tbLicense.Checked == true)
            {
                if (!isHuman)
                {
                    CaptchaErrorLabel.ForeColor = System.Drawing.Color.Red;
                    CaptchaErrorLabel.Text = "Captcha düzgün daxil edilməyib!";
                }
                else
                {
                    CaptchaErrorLabel.Text = "";
                    using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
                    {
                        connection.Open();
                        //Check if user already registered

                        SqlCommand sqlCommand1 = new SqlCommand("CheckIfEmailExists", connection);
                        sqlCommand1.CommandType = CommandType.StoredProcedure;
                        sqlCommand1.Parameters.AddWithValue("@Email", tbEmail.Text.Trim());
                        int records = (int)sqlCommand1.ExecuteScalar();
                        if (records == 0)
                        {
                            //Hash password 
                            String salt = HashPassword.CreateSalt(10);
                            String hashedpassword = HashPassword.GenerateSHA256Hash(tbPassword.Text, salt);

                            //Add user to database

                            SqlCommand sqlCommand = new SqlCommand("UsersCreate", connection);
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddWithValue("@FirstName", tbName.Text.Trim());
                            sqlCommand.Parameters.AddWithValue("@LastName", tbSurname.Text.Trim());
                            sqlCommand.Parameters.AddWithValue("@Email", tbEmail.Text.Trim());
                            sqlCommand.Parameters.AddWithValue("@BirthDate", tbBirthdate.Text.Trim());
                            sqlCommand.Parameters.AddWithValue("@Password", hashedpassword);
                            sqlCommand.Parameters.AddWithValue("@Salt", salt);
                            sqlCommand.ExecuteNonQuery();

                            //Get Last Registered User's ID

                            SqlCommand sqlCommand2 = new SqlCommand("UsersSelectLastRegisteredUser", connection);
                            sqlCommand2.CommandType = CommandType.StoredProcedure;
                            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand2);
                            DataTable dataTable = new DataTable();
                            sqlDataAdapter.Fill(dataTable);
                            int UserID = Convert.ToInt32(dataTable.Rows[0]["ID"]) * 7654321;

                            //Send mail to user for verification

                            String toEmailAddress = tbEmail.Text.Trim().ToString();
                            String username = tbName.Text.Trim().ToString() + " " + tbSurname.Text.Trim().ToString();
                            String messageBody = "Salam, Hörmətli " + username + ". <br/> <br/> Hesabınızı təsdiqləmək üçün <a href=\" https://prisonart.gov.az/login?VerifyAccount=" + UserID + "\">bu linkə</a> klikləyin.<br/><br/>Həbsxana İncəsənəti";
                            MailMessage mailMessage = new MailMessage("youremail@address.com", toEmailAddress);
                            mailMessage.Body = messageBody;
                            mailMessage.IsBodyHtml = true;
                            mailMessage.Subject = "Hesabınızı Təsdiqləyin";

                            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                            smtpClient.Credentials = new NetworkCredential("hebsxana.art@gmail.com", "Puwu6917");
                            smtpClient.EnableSsl = true;
                            smtpClient.Send(mailMessage);

                            //Status Message

                            tbName.Text = tbSurname.Text = tbPassword.Text = tbPasswordConfirm.Text = tbEmail.Text = tbBirthdate.Text = "";
                            tbLicense.Checked = false;
                            ModalSuccess.LabelModalMsg.Text = "Siz Qeydiyyatdan Uğurla Keçdiniz. Hesabınızı Təsdiqləmək Üçün Email Adresinizə Daxil Olun";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                        }
                        else
                        {
                            tbPassword.Text = tbPasswordConfirm.Text = tbEmail.Text = "";
                            tbLicense.Checked = false;
                            lblMsg.ForeColor = System.Drawing.Color.Red;
                            lblMsg.Text = "Bu email ünvanı artıq qeydiyyatda var, xahiş edirik başqa birini seçin";
                        }
                    }
                }
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Qeydiyyatdan keçmək üçün müqavilənin şərtləri ilə razılaşmalısınız";
            }
        }

    }
}