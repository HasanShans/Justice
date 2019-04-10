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
using System.Drawing;

namespace Justice
{
    public partial class Login : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["NAME"] == null)
            {
                if (Request.QueryString.AllKeys.Contains("VerifyAccount"))
                {
                    using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
                    {
                        connection.Open();
                        int UserID = Convert.ToInt32(Request.QueryString["VerifyAccount"]) / 7654321;
                        if (Request.QueryString["VerifyAccount"] != null)
                        {
                            SqlCommand sqlCommand1 = new SqlCommand("UsersSelectByID", connection);
                            sqlCommand1.CommandType = CommandType.StoredProcedure;
                            sqlCommand1.Parameters.AddWithValue("@ID", UserID);
                            sqlCommand1.ExecuteNonQuery();
                            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand1);
                            DataTable dataTable = new DataTable();
                            sqlDataAdapter.Fill(dataTable);
                            if (dataTable.Rows.Count != 0)
                            {
                                if (Convert.ToInt32(dataTable.Rows[0]["Verified"]) == 1)
                                {
                                    lblMsgVerify.ForeColor = System.Drawing.Color.Red;
                                    lblMsgVerify.Text = "Error";
                                }
                                else
                                {
                                    SqlCommand sqlCommand = new SqlCommand("UsersVerifyAccount", connection);
                                    sqlCommand.CommandType = CommandType.StoredProcedure;
                                    sqlCommand.Parameters.AddWithValue("@ID", UserID);
                                    sqlCommand.ExecuteNonQuery();
                                    lblMsgVerify.ForeColor = System.Drawing.Color.Green;
                                    lblMsgVerify.Text = "Hörmətli istifadəçi, sizin hesabınız təsdiq olunmuşdur.";
                                }
                            }
                            else
                            {
                                lblMsgVerify.ForeColor = System.Drawing.Color.Red;
                                lblMsgVerify.Text = "Belə bir hesab bazamızda mövcud deyil";
                            }
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("~/ana-səhifə");
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            DataTable dataTable;
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("UsersCheckLogin", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Email", tbEmail.Text.Trim());
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
            }
            
            bool isHuman = Captcha.Validate(txtCaptcha.Text);
            txtCaptcha.Text = null;
            if (!isHuman)
            {
                CaptchaErrorLabel.ForeColor = Color.Red;
                CaptchaErrorLabel.Text = "Kaptça düzgün daxil edilməyib!";
            }
            else
            {
                CaptchaErrorLabel.Text = "";
            }
            if (dataTable.Rows.Count != 0)
            {
                String userSalt = dataTable.Rows[0]["Salt"].ToString();
                String userEnteredHashPassword = HashPassword.GenerateSHA256Hash(tbPassword.Text, userSalt);
                if (userEnteredHashPassword == dataTable.Rows[0]["Password"].ToString())
                {
                    if (Convert.ToInt32(dataTable.Rows[0]["Verified"]) == 1)
                    {
                        if (isHuman)
                        {
                            Session["NAME"] = dataTable.Rows[0]["FirstName"].ToString() + " " + dataTable.Rows[0]["LastName"].ToString();
                            Session["EMAIL"] = dataTable.Rows[0]["Email"].ToString();
                            Session["ID"] = dataTable.Rows[0]["ID"];

                            if (Request.QueryString["rurl"] != null)
                            {
                                String page = Request.QueryString["rurl"];
                                Response.Redirect("~/" + page);
                            }
                            else
                            {

                                Response.Redirect("~/ana-səhifə");

                            }
                        }
                    }
                    else
                    {
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        lblMsg.Text = "Hörmətli İstifadəçi, Zəhmət Olmasa Hesabınızı Təsdiqlədikdən Sonra Yenidən Cəhd Edin.";
                    }
                }
                else
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Yanlış Parol";
                }
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Yanlış Email";
            }
        }
    }
}