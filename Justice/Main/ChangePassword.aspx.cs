using Justice.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Justice.Main
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["NAME"] == null)
            {
                Response.Redirect("~/Main/Login.aspx?rurl=ChangePassword");
            }
        }

        protected void saveNewPassword(object sender, EventArgs e)
        {
            if (DB.Connection.State == ConnectionState.Closed)
                DB.Connection.Open();
            Int32 UserID = Convert.ToInt32(Session["ID"]);
            SqlCommand sqlCommand = new SqlCommand("UsersSelectByID", DB.Connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@ID", UserID);
            sqlCommand.ExecuteNonQuery();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count != 0)
            {
                if (dataTable.Rows[0]["Password"].ToString() == txtOldPass.Text.ToString().Trim())
                {
                    SqlCommand sqlCommand1 = new SqlCommand("UsersUpdatePassword", DB.Connection);
                    sqlCommand1.CommandType = CommandType.StoredProcedure;
                    sqlCommand1.Parameters.AddWithValue("@ID", UserID);
                    sqlCommand1.Parameters.AddWithValue("@Password", txtNewPass.Text.ToString().Trim());
                    sqlCommand1.ExecuteNonQuery();
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    lblMsg.Text = "Şifrəniz uğurla yeniləndi";
                }
                else
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Köhnə şifrəniz yanlışdır. Yenidən cəhd edin.";
                    txtOldPass.Focus();
                }
            }
            else
            {
                Response.Redirect("~/Main/Login.aspx?rurl=ChangePassword");
            }
        }
    }
}