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
    public partial class accountVerified : System.Web.UI.Page
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=GADIR\SQLEXPRESS;Initial Catalog=PrisonShop;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();
            int UserID = Convert.ToInt32(Request.QueryString["UserID"])/5432;
            if (Request.QueryString["UserID"] != null)
            {
                SqlCommand sqlCommand = new SqlCommand("UsersVerifyAccount", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ID", UserID);
                sqlCommand.ExecuteNonQuery();
                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Text = "Hörmətli istifadəçi, sizin hesabınız təsdiq olunmuşdur.";
            }
        }
    }
}