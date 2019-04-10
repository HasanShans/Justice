using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Justice.App_Code;

namespace Justice
{
    public partial class Product : System.Web.UI.Page
    {
        public Dictionary<string, string> data = new Dictionary<string, string>();
        int ProductID;
        protected void Page_Load(object sender, EventArgs e)
        {
            BindProduct();
            BindSimilarProducts();
        }
        private void BindProduct()
        {
            ProductID = Convert.ToInt32(Request.QueryString["id"]);
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                SqlCommand comm = new SqlCommand("ProductsSelectByIDJoinCategoriesImages", connection);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@id", ProductID);
                comm.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(comm);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count != 0)
                {
                    data.Add("mehsul_ID", dataTable.Rows[0]["ID"].ToString());
                    data.Add("mehsul_kod", dataTable.Rows[0]["Code"].ToString());
                    data.Add("mehsul_hebsxana", dataTable.Rows[0]["JailName"].ToString());
                    data.Add("mehsul_ad", dataTable.Rows[0]["ProductName"].ToString());
                    data.Add("mehsul_olcu", dataTable.Rows[0]["Size"].ToString());
                    data.Add("mehsul_material", dataTable.Rows[0]["Material"].ToString());
                    data.Add("kateqoriya_ID", dataTable.Rows[0]["CategoryID"].ToString());
                    data.Add("mehsul_kateqoriya", dataTable.Rows[0]["CategoryName"].ToString());
                    data.Add("mehsul_ceki", dataTable.Rows[0]["Weight"].ToString());
                    data.Add("mehsul_say", dataTable.Rows[0]["StockAmount"].ToString());
                    data.Add("elave_melumat", dataTable.Rows[0]["Description"].ToString());
                    data.Add("mehsul_qiymet", dataTable.Rows[0]["Price"].ToString());
                    data.Add("endirimli_qiymet", dataTable.Rows[0]["DiscountPrice"].ToString());
                }
                SqlCommand comm1 = new SqlCommand("ImagesSelectByProductID", connection);
                comm1.CommandType = CommandType.StoredProcedure;
                comm1.Parameters.AddWithValue("@ProductID", ProductID);
                comm1.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(comm1);
                DataTable dataTable1 = new DataTable();
                sqlDataAdapter1.Fill(dataTable1);
                if (dataTable1.Rows.Count != 0)
                {
                    rprtImages.DataSource = dataTable1;
                    rprtImages.DataBind();
                }
            }
        }
        private void BindSimilarProducts()
        {
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                SqlCommand comm1 = new SqlCommand("ProductSelectSimilar", connection);
                comm1.CommandType = CommandType.StoredProcedure;
                comm1.Parameters.AddWithValue("@CategoryID", data["kateqoriya_ID"]);
                comm1.Parameters.AddWithValue("@ProductID", ProductID);
                comm1.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(comm1);
                DataTable dataTable1 = new DataTable();
                sqlDataAdapter1.Fill(dataTable1);
                if (dataTable1.Rows.Count != 0)
                {
                    productRepeater.DataSource = dataTable1;
                    productRepeater.DataBind();
                }
                else
                {
                    notfoundProduct.Visible = true;
                }
            }
        }
        protected void btnAddToCart_Click(object sender, EventArgs e)
        {

        }
        protected void AddToCart_Click(object sender, EventArgs e)
        {
            if (Session["ID"] != null)
            {
                int UserID = Convert.ToInt32(Session["ID"]);
                using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
                {
                    connection.Open();
                    SqlCommand comm2 = new SqlCommand("CartSelectByUserIDAndProductID", connection);
                    comm2.CommandType = CommandType.StoredProcedure;
                    comm2.Parameters.AddWithValue("@user_id", UserID);
                    comm2.Parameters.AddWithValue("@product_id", data["mehsul_ID"]);
                    int ifExists = Convert.ToInt32(comm2.ExecuteScalar());
                    if (ifExists == 0)
                    {
                        //Check if product is in stock

                        SqlCommand comm1 = new SqlCommand("ProductCheckIfInStock", connection);
                        comm1.CommandType = CommandType.StoredProcedure;
                        comm1.Parameters.AddWithValue("@ID", data["mehsul_ID"]);
                        int ifAvailable = Convert.ToInt32(comm1.ExecuteScalar());

                        if (ifAvailable == 1)
                        {
                            SqlCommand comm = new SqlCommand("CartCreate", connection);
                            comm.CommandType = CommandType.StoredProcedure;
                            comm.Parameters.AddWithValue("@user_id", UserID);
                            comm.Parameters.AddWithValue("@product_id", data["mehsul_ID"]);
                            comm.ExecuteNonQuery();
                            Response.Redirect("~/səbət");
                        }
                        else
                        {
                            ModalSuccess.LabelModalMsg.Text = "Hörmətli istifadəçi, hal-hazırda bu məhsul satışda olmadığı üçün, sifariş verə bilməzsiniz. Nəzərinizə çatdıraq ki, bu məhsul tezlikə satışda olacaq.";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("~/login");
            }
        }
    }
}
