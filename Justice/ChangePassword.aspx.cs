using Justice.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Justice
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["NAME"] == null)
            {
                Response.Redirect("~/login?rurl=yeni-şifrə");
            }
        }

        protected void saveNewPassword(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                Int32 UserID = Convert.ToInt32(Session["ID"]);
                SqlCommand sqlCommand = new SqlCommand("UsersSelectByID", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ID", UserID);
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count != 0)
                {
                    String userSalt = dataTable.Rows[0]["Salt"].ToString();
                    String userEnteredHashPassword = HashPassword.GenerateSHA256Hash(txtOldPass.Text, userSalt);
                    if (dataTable.Rows[0]["Password"].ToString() == userEnteredHashPassword)
                    {
                        String newSalt = HashPassword.CreateSalt(10);
                        String newHashedPassword = HashPassword.GenerateSHA256Hash(txtNewPass.Text, newSalt);
                        SqlCommand sqlCommand1 = new SqlCommand("UsersUpdatePassword", connection);
                        sqlCommand1.CommandType = CommandType.StoredProcedure;
                        sqlCommand1.Parameters.AddWithValue("@ID", UserID);
                        sqlCommand1.Parameters.AddWithValue("@Password", newHashedPassword);
                        sqlCommand1.Parameters.AddWithValue("@Salt", newSalt);
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
                    Response.Redirect("~/login?rurl=yeni-şifrə");
                }
            }
        }
    }
}