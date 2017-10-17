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
    public partial class Login : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["NAME"] == null)
            {
                if (Request.Cookies["EMAIL"] != null && Request.Cookies["PASSWORD"] != null)
                {
                    tbEmail.Text = Request.Cookies["EMAIL"].Value;
                    tbPassword.Attributes["value"] = Request.Cookies["PASSWORD"].Value;
                    tbRememberMe.Checked = true;
                }
            }
            else
            {
                Response.Redirect("Index.aspx");
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (DB.Connection.State == ConnectionState.Closed)
                DB.Connection.Open();
            SqlCommand sqlCommand = new SqlCommand("UsersCheckLogin", DB.Connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Email", tbEmail.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@Password", tbPassword.Text.Trim());
            sqlCommand.ExecuteNonQuery();
            DB.Connection.Close();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count != 0)
            {
                if (Convert.ToInt32(dataTable.Rows[0][7]) == 1)
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
                    Session["NAME"] = dataTable.Rows[0][1].ToString() + " " + dataTable.Rows[0][2].ToString();
                    Session["EMAIL"] = dataTable.Rows[0][3].ToString();
                    Session["ID"] = dataTable.Rows[0][0];
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
                lblMsg.Text = "Email və ya Parol Yanlışdır";
            }
            DB.Connection.Close();
        }
    }
}