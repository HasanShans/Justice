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
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=GADIR\SQLEXPRESS;Initial Catalog=PrisonShop;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["EMAIL"] != null && Request.Cookies["PASSWORD"] != null)
            {
                tbEmail.Text = Request.Cookies["UNAME"].Value;
                tbPassword.Attributes["value"] = Request.Cookies["PASSWORD"].Value;
                tbRememberMe.Checked = true;
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("UsersCheckLogin", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Email", tbEmail.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@Password", tbPassword.Text.Trim());
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count != 0)
            {
                if (Convert.ToInt32(dataTable.Rows[0][11]) == 1)
                {
                    if (tbRememberMe.Checked == true)
                    {
                        Response.Cookies["EMAIL"].Value = tbEmail.Text;
                        Response.Cookies["PASSWORD"].Value = tbPassword.Text;

                        Response.Cookies["EMAIL"].Expires = DateTime.Now.AddDays(10);
                        Response.Cookies["PASSWORD"].Expires = DateTime.Now.AddDays(10);
                    }
                    else
                    {
                        Response.Cookies["EMAIL"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["PASSWORD"].Expires = DateTime.Now.AddDays(-1);
                    }
                    Session["NAME"] = dataTable.Rows[0][1] + " " + dataTable.Rows[0][2];
                    Session["EMAIL"] = dataTable.Rows[0][3];
                    if (Request.QueryString["rurl"] != null)
                    {
                        String page = Request.QueryString["rurl"];
                        Response.Redirect("~/Main/" + page + ".aspx");
                    }
                    else
                    {
                        Response.Redirect("~/Main/Index.aspx");
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
                lblMsg.Text = "Email və ya Şifrə Yanlışdır";
            }
        }
    }
}