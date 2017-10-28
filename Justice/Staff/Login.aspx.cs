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
                Response.Redirect("Products.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (DB.Connection.State == ConnectionState.Closed)
                DB.Connection.Open();
            SqlCommand sqlCommand = new SqlCommand("AdminsLogin", DB.Connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@UserName", tbLogin.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@Password", tbPassword.Text.Trim());
            int adminCheck = Convert.ToInt32(sqlCommand.ExecuteScalar());
            if (adminCheck != 0)
            {
                Session["ADMINSESSION"] = tbLogin.Text.Trim();
                Response.Redirect("Products.aspx");
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Login və yaxud parol səhvdir";
            }
        }
    }
}