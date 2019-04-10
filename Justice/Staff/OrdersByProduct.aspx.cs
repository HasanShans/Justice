using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Justice.App_Code;

namespace Justice.Staff
{
    public partial class OrdersByProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ddlYear.SelectedValue = DateTime.Now.Year.ToString();
                BindOrders();
            }
        }
        private void BindOrders()
        {
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("OrdersJoinJailsUsersProducts", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Month", ddlMonthFilter.SelectedIndex);
                sqlCommand.Parameters.AddWithValue("@Year", ddlYear.SelectedValue);
                if (Session["ADMINSESSION"].ToString() != "Admin")
                {
                    sqlCommand.Parameters.AddWithValue("@JailID", Convert.ToInt64(Session["ADMINSESSIONJAILNO"]));
                }
                else
                {
                    sqlCommand.Parameters.AddWithValue("@JailID", DBNull.Value);
                }
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                rprtOrdersByProduct.DataSource = dataTable;
                rprtOrdersByProduct.DataBind();
            }
        }

        protected void ddlMonthFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindOrders();
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindOrders();
        }
    }
}