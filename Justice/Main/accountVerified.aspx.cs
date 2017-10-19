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
    public partial class AccountVerified : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DB.Connection.State == ConnectionState.Closed)
                DB.Connection.Open();
            int UserID = Convert.ToInt32(Request.QueryString["UserID"]) / 5432;
            if (Request.QueryString["UserID"] != null)
            {
                SqlCommand sqlCommand = new SqlCommand("UsersVerifyAccount", DB.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ID", UserID);
                sqlCommand.ExecuteNonQuery();
                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Text = "Hörmətli istifadəçi, sizin hesabınız təsdiq olunmuşdur.";
            }
            DB.Connection.Close();
        }
    }
}