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
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["ID"] != null)
            {
                tbNameSurname.Text = Session["NAME"].ToString();
                tbEmail.Text = Session["EMAIL"].ToString();
            }
        }
        protected void SendMessage_Click(object sender, EventArgs e)
        {
            bool isHuman = Captcha.Validate(txtCaptcha.Text);
            txtCaptcha.Text = null;
            if (!isHuman)
            {
                CaptchaErrorLabel.ForeColor = System.Drawing.Color.Red;
                CaptchaErrorLabel.Text = "Captcha düzgün daxil edilməyib!";
            }
            else
            {
                CaptchaErrorLabel.Text = "";
                String phoneNum = tbPhone.Text;
                if (tbPhone.Text == "" || tbPhone.Text == null)
                {
                    phoneNum = "qeyd edilməyib";
                }
                String toEmailAddress = "hebsxana.art@gmail.com";
                String messageBody = "Mesaj göndərən: " + tbNameSurname.Text + "<br>" +
                    "Əlaqə nömrəsi: " + phoneNum + "<br>" +
                    "Email: " + tbEmail.Text + "<br><br>" +
                    "Mesajın mətni:<br>" +
                    "-- " + tbMessage.Text + " --<br><br>";
                MailMessage mailMessage = new MailMessage("youremail@address.com", toEmailAddress);
                mailMessage.Body = messageBody;
                mailMessage.IsBodyHtml = true;
                mailMessage.Subject = "Prison art support";

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.Credentials = new NetworkCredential("hebsxana.art@gmail.com", "Puwu6917");
                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMessage);
                tbEmail.Text = tbMessage.Text = tbNameSurname.Text = tbPhone.Text = "";
                ModalSuccess.LabelModalMsg.Text = "Sizin mesajınız uğurla göndərildi. Sizin sorğunuz üç iş günü ərzində cavablandırılacaq.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            }
        }
    }
}