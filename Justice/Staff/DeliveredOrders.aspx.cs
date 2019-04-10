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
    public partial class DeliveredOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ddlYear.SelectedValue = DateTime.Now.Year.ToString();
                BindDeliveredOrders();
            }
        }
        private void BindDeliveredOrders()
        {
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("OrdersSelectDelivered", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Year", ddlYear.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@Month", ddlMonthFilter.SelectedIndex);
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                rprtDeliveredOrders.DataSource = dataTable;
                rprtDeliveredOrders.DataBind();
            }
        }
        protected void ddlMonthFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDeliveredOrders();
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDeliveredOrders();
        }
    }
}