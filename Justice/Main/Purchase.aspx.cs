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
    public partial class Purchase : System.Web.UI.Page
    {
        public int sum = 0;
        public int amount = 0;
        int userID;
        DataTable data = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
 
                BindProducts();
        }

        private void BindProducts()
        {
            if (Session["NAME"] != null)
            {
                userID = Convert.ToInt32(Session["ID"]);
                if (DB.Connection.State == ConnectionState.Closed)
                    DB.Connection.Open();
                SqlCommand comm = new SqlCommand("CartSelectByUserIDJoinImagesAndProducts", DB.Connection);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@user_id", Convert.ToInt32(Session["ID"]));
                comm.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(comm);
                sqlDataAdapter.Fill(data);
                foreach (DataRow row in data.Rows)
                {
                    amount++;
                    sum += Convert.ToInt32(row["DiscountPrice"]);
                }
                if (data.Rows.Count != 0)
                {
                    repeaterPurchase.DataSource = data;
                    repeaterPurchase.DataBind();
                    btnProductBuy.Enabled = true;
                }
            }
            else
            {
                Response.Redirect("~/Main/Login.aspx?rurl=Purchase");
            }
        }

        protected void RemoveFromCart_Click(object sender, EventArgs e)
        {
            using (SqlCommand comm = new SqlCommand("CartDeleteByUserIDAndProductID", DB.Connection))
            {
                LinkButton btn = (LinkButton)(sender);
                int productID = int.Parse(btn.CommandArgument.ToString());
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@user_id", Convert.ToInt32(Session["ID"]));
                comm.Parameters.AddWithValue("@product_id", productID);
                try
                {
                if (DB.Connection.State == ConnectionState.Closed)
                    DB.Connection.Open();
                    comm.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {

                }
                DB.Connection.Close();
            }
            Response.Redirect("~/Main/Purchase.aspx");
        }

        protected void btnProductBuy_Click(object sender, EventArgs e)
        {
            if (Session["NAME"] == null)
            {
                Response.Redirect("~/Main/Login.aspx?rurl=Purchase");
            }
            else
            {
                if (DB.Connection.State == ConnectionState.Closed)
                    DB.Connection.Open();
                SqlCommand sqlCommand = new SqlCommand("UsersSelectByID", DB.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ID", userID);
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (string.IsNullOrEmpty(dataTable.Rows[0]["IDSerialNumber"].ToString())|| string.IsNullOrEmpty(dataTable.Rows[0]["City"].ToString())
                    || string.IsNullOrEmpty(dataTable.Rows[0]["PostIndex"].ToString()) || string.IsNullOrEmpty(dataTable.Rows[0]["MobilePhone"].ToString()))
                {
                    Response.Redirect("Information.aspx");
                }
                else
                {
                    //Create order

                    SqlCommand sqlCommand1 = new SqlCommand("OrdersCreate", DB.Connection);
                    sqlCommand1.CommandType = CommandType.StoredProcedure;
                    sqlCommand1.Parameters.AddWithValue("@UserID", userID);
                    sqlCommand1.Parameters.AddWithValue("@PaymentAmount", sum);
                    sqlCommand1.Parameters.AddWithValue("@ProductCount", amount);
                    sqlCommand1.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                    sqlCommand1.ExecuteNonQuery();

                    //Get Last insertion Order ID

                    SqlCommand sqlCommand2 = new SqlCommand("OrdersSelectLastInsertedID", DB.Connection);
                    sqlCommand2.CommandType = CommandType.StoredProcedure;
                    sqlCommand2.Parameters.AddWithValue("@UserID", userID);
                    Int64 LastOrderID = Convert.ToInt64(sqlCommand2.ExecuteScalar());

                    //Insert to OrderedProducts Table

                    foreach (DataRow row in data.Rows)
                    {
                        SqlCommand sqlCommand3 = new SqlCommand("OrderedProductsCreate", DB.Connection);
                        sqlCommand3.CommandType = CommandType.StoredProcedure;
                        sqlCommand3.Parameters.AddWithValue("@OrderID", LastOrderID);
                        sqlCommand3.Parameters.AddWithValue("@ProductID", row["ID"]);
                        sqlCommand3.ExecuteNonQuery();
                    }
                    Response.Redirect("ConfirmOrder.aspx?order=" + LastOrderID * 123456789);

                }
            }
        }
    }
}