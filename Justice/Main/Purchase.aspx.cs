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
        protected void Page_Load(object sender, EventArgs e)
        {
            BindProducts();
        }

        private void BindProducts()
        {
            if (Session["ID"] != null)
            {
                using (SqlCommand comm = new SqlCommand("CartSelectByUserIDJoinImagesAndProducts", DB.Connection))
                {
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@user_id", Convert.ToInt32(Session["ID"]));
                    try
                    {
                        if (DB.Connection.State == ConnectionState.Closed)
                            DB.Connection.Open();
                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            DataTable data = new DataTable();
                            data.Load(reader);
                            foreach (DataRow row in data.Rows)
                            {
                                amount++;
                                sum += Convert.ToInt32(row["Price"]);
                            }
                            if (!IsPostBack)
                            {
                                repeater.DataSource = data;
                                repeater.DataBind();
                            }
                        }
                    }
                    catch (SqlException ex)
                    {

                    }
                    DB.Connection.Close();
                }
            } else
            {
                Response.Redirect("~/Main/Login.aspx");
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
    }
}