using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Justice.App_Code;

namespace Justice
{
    public partial class Orders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["NAME"] == null)
            {
                Response.Redirect("~/login?rurl=sifarişlərim");
            }
            else
            {
                BindOrders();
            }
        }
        private void BindOrders()
        {
            int userID = Convert.ToInt32(Session["ID"]);
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("OrdersSelectAllByUserID", connection);
                sqlCommand.Parameters.AddWithValue("@UserID", userID);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count != 0)
                {
                    rprtOrders.DataSource = dataTable;
                    rprtOrders.DataBind();
                }
                else
                {
                    tdRow.Visible = true;
                }
            }
        }
    }
}