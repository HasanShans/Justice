using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Justice.App_Code;

namespace Justice.Main
{
    public partial class Product : System.Web.UI.Page
    {
        public Dictionary<string, string> data = new Dictionary<string, string>();

        protected void Page_Load(object sender, EventArgs e)
        {    
            BindProduct();
        }

        private void BindProduct()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            using (SqlCommand comm = new SqlCommand("ProductsSelectByIDJoinCategoriesImages", DB.Connection))
            {
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@id", id);
                try
                {
                    if (DB.Connection.State == ConnectionState.Closed)
                        DB.Connection.Open();
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            data.Add("image1", reader["Image1"].ToString());
                            data.Add("image2", reader["Image2"].ToString());
                            data.Add("image3", reader["Image3"].ToString());
                            data.Add("image4", reader["Image4"].ToString());

                            data.Add("mehsul_ID", reader["ID"].ToString());
                            data.Add("mehsul_kod", reader["Code"].ToString());
                            data.Add("mehsul_ad", reader["ProductName"].ToString());
                            data.Add("mehsul_olcu", reader["Size"].ToString());
                            data.Add("mehsul_material", reader["Material"].ToString());
                            data.Add("kateqoriya_ID", reader["CategoryID"].ToString());
                            data.Add("mehsul_kateqoriya", reader["CategoryName"].ToString());
                            data.Add("mehsul_ceki", reader["Weight"].ToString());
                            data.Add("mehsul_say", reader["StockAmount"].ToString());
                            data.Add("elave_melumat", reader["Description"].ToString());
                            data.Add("mehsul_qiymet", reader["Price"].ToString());
                            data.Add("endirimli_qiymet", reader["Discount"].ToString());
                        }
                    }
                }
                catch (SqlException ex)
                {
                    // other codes here
                    // do something with the exception
                    // don't swallow it.
                }
                DB.Connection.Close();
            }
        }

        protected void AddToCart_Click(object sender, EventArgs e)
        {
            if (Session["ID"] != null)
            {
                int userID = Convert.ToInt32(Session["ID"]);
                if (DB.Connection.State == ConnectionState.Closed)
                    DB.Connection.Open();

                using (SqlCommand comm2 = new SqlCommand("CartSelectByUserIDAndProductID", DB.Connection))
                {
                    comm2.CommandType = CommandType.StoredProcedure;
                    comm2.Parameters.AddWithValue("@user_id", userID);
                    comm2.Parameters.AddWithValue("@product_id", data["mehsul_ID"]);
                    SqlDataReader reader = comm2.ExecuteReader();
                     if (reader.Read() == false)
                     {
                        reader.Close();
                        using (SqlCommand comm = new SqlCommand("CartCreate", DB.Connection))
                        {
                            comm.CommandType = CommandType.StoredProcedure;
                            comm.Parameters.AddWithValue("@user_id", userID);
                            comm.Parameters.AddWithValue("@product_id", data["mehsul_ID"]);
                            comm.ExecuteNonQuery();
                        }
                     }
                }
                DB.Connection.Close();
            }
            else
            {
                Response.Redirect("~/Main/Login.aspx");
            }
        }
    }
 }
