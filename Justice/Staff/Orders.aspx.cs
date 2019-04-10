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
    public partial class Orders : System.Web.UI.Page
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
                SqlCommand sqlCommand = new SqlCommand("OrdersSelectAllPaid", connection);
                sqlCommand.Parameters.AddWithValue("@Year", ddlYear.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@Month", ddlMonthFilter.SelectedIndex);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                rprtOrders.DataSource = dataTable;
                rprtOrders.DataBind();
            }
        }
        protected void orderDeliveredClick(object sender, EventArgs e)
        {
            int orderID = int.Parse(((sender as Button).NamingContainer.FindControl("lblOrderID") as Label).Text);
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("OrdersUpdateDeliveryStatus", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@OrderID", orderID);
                sqlCommand.Parameters.AddWithValue("@DeliveryDate", System.DateTime.Now);
                sqlCommand.ExecuteNonQuery();
            }
            BindOrders();
        }
        protected void orderDeleteClick(object sender, EventArgs e)
        {
            int orderID = int.Parse(((sender as Button).NamingContainer.FindControl("lblOrderID") as Label).Text);
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("OrdersDeleteByID", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@OrderID", orderID);
                sqlCommand.ExecuteNonQuery();
            }
            BindOrders();
        }
        protected void orderConfirmedClick(object sender, EventArgs e)
        {
            int orderID = int.Parse(((sender as Button).NamingContainer.FindControl("lblOrderID") as Label).Text);
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                SqlCommand comm = new SqlCommand("OrdersUpdatePaymentStatusID", connection);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@id", orderID);
                comm.Parameters.AddWithValue("@paymentStatusID", 1);
                comm.ExecuteNonQuery();
                SqlCommand comm1 = new SqlCommand("OrderedProductsSelect", connection);
                comm1.CommandType = CommandType.StoredProcedure;
                comm1.Parameters.AddWithValue("@OrderID", orderID);
                comm1.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(comm1);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count != 0)
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        SqlCommand comm2 = new SqlCommand("ProductsDecreaseStockamountByOne", connection);
                        comm2.CommandType = CommandType.StoredProcedure;
                        comm2.Parameters.AddWithValue("@ProductID", dataTable.Rows[i]["ProductID"]);
                        comm2.ExecuteNonQuery();
                    }
                    SqlCommand comm3 = new SqlCommand("ProductsUpdateStockAvailability", connection);
                    comm3.CommandType = CommandType.StoredProcedure;
                    comm3.ExecuteNonQuery();
                }
            }
            BindOrders();
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