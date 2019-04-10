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


namespace Justice.Staff
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ADMINSESSION"] != null)
            {
                Response.Redirect("~/root/məhsullar");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            bool isHuman = Captcha.Validate(txtCaptcha.Text);
            txtCaptcha.Text = null;
            if (!isHuman)
            {
                CaptchaErrorLabel.ForeColor = System.Drawing.Color.Red;
                CaptchaErrorLabel.Text = "Kaptça düzgün daxil edilməyib!";
            }
            else
            {
                CaptchaErrorLabel.Text = "";
                using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand("AdminsLogin", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@UserName", tbLogin.Text.Trim());
                    sqlCommand.ExecuteNonQuery();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    String userSalt = dataTable.Rows[0]["Salt"].ToString();
                    String userEnteredHashPassword = HashPassword.GenerateSHA256Hash(tbPassword.Text, userSalt);
                    if (dataTable.Rows.Count != 0 && userEnteredHashPassword == dataTable.Rows[0]["Password"].ToString())
                    {
                        if (tbLogin.Text == "Admin")
                        {
                            Session["ADMINSESSION"] = tbLogin.Text;
                        }
                        else
                        {
                            SqlCommand sqlCommand2 = new SqlCommand("JailsSelectJailID", connection);
                            sqlCommand2.CommandType = CommandType.StoredProcedure;
                            sqlCommand2.Parameters.AddWithValue("@JailNo", Convert.ToInt32(dataTable.Rows[0]["JailNum"]));
                            Int64 JailID = Convert.ToInt64(sqlCommand2.ExecuteScalar());
                            Session["ADMINSESSION"] = dataTable.Rows[0]["JailNum"].ToString();
                            Session["ADMINSESSIONJAILNO"] = JailID.ToString();
                        }
                        Response.Redirect("~/root/məhsullar");
                    }
                    else
                    {
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        lblMsg.Text = "Login və yaxud parol səhvdir";
                    }
                }
            }
        }
    }
}