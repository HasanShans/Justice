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
    public partial class ConfirmOrder : System.Web.UI.Page
    {
        DataTable dataTable = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["NAME"] == null)
            {
                Response.Redirect("Login.aspx?rurl=Purchase");
            }
            else
            {
                BindPaymentDetails();
            }
        }
        private void BindPaymentDetails()
        {
            Int64 OrderID = Convert.ToInt64(Request.QueryString["order"]) / 123456789;
            if (DB.Connection.State == ConnectionState.Closed)
                DB.Connection.Open();
            SqlCommand comm = new SqlCommand("OrdersSelectByID", DB.Connection);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@ID", OrderID);
            comm.ExecuteNonQuery();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(comm);
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count != 0)
            {
                lblProductCount.Text = dataTable.Rows[0]["ProductCount"].ToString();
                lblTotalPayment.Text = dataTable.Rows[0]["PaymentAmount"].ToString();
                lbltotaPrice.Text = dataTable.Rows[0]["PaymentAmount"].ToString();
            }
            else
            {

            }
        }
    }
}