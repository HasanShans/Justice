using Justice.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Justice
{
    public partial class getStatus : System.Web.UI.Page
    {   
        [WebMethod]
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();

                Int32 action = Convert.ToInt32(Request.Form["ACTION"]);
                //Int32 amount = Convert.ToInt32(Request.Form["AMOUNT"]);
                Int32 order = Convert.ToInt32(Request.Form["ORDER"]);
                SqlCommand comm = new SqlCommand("OrdersUpdatePaymentStatusID", connection);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@id", order);
                comm.Parameters.AddWithValue("@paymentStatusID", action + 1);
                //comm.Parameters.AddWithValue("@amount", 10);
                comm.ExecuteNonQuery();
                if (action == 0)
                {
                    SqlCommand comm1 = new SqlCommand("OrderedProductsSelect", connection);
                    comm1.CommandType = CommandType.StoredProcedure;
                    comm1.Parameters.AddWithValue("@OrderID", order);
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
            }
        }
    }
}