using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Justice.Main
{
    public partial class Product : System.Web.UI.Page
    {
        public Dictionary<string, string> data = new Dictionary<string, string>();
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PrisonShop;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(Request.QueryString["id"]);
            using (SqlCommand comm = new SqlCommand("GetProductDetails", sqlConnection))
            {
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@id", id);
                try
                {
                    sqlConnection.Open();
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            data.Add("image1", reader["Image1"].ToString());
                            data.Add("image2", reader["Image2"].ToString());
                            data.Add("image3", reader["Image3"].ToString());
                            data.Add("image4", reader["Image4"].ToString());

                            data.Add("ID", reader["ID"].ToString());
                            data.Add("mehsul_kodu", reader["Code"].ToString());
                            data.Add("mehsul_adi", reader["ProductName"].ToString());
                            data.Add("mehsul_olcu", reader["Size"].ToString());
                            data.Add("mehsul_material", reader["Material"].ToString());
                            data.Add("mehsul_kateqoriya", reader["CategoryName"].ToString());
                            data.Add("mehsul_ceki", reader["Weight"].ToString());
                            data.Add("mehsul_sayi", reader["StockAmount"].ToString());
                            data.Add("elave_melumat", reader["Description"].ToString());
                            data.Add("mehsul_qiymeti", reader["Price"].ToString());
                            data.Add("endirimli_qiymeti", reader["Discount"].ToString());

                        }
                    }
                }
                catch (SqlException ex)
                {
                    // other codes here
                    // do something with the exception
                    // don't swallow it.
                }
            }
        }

    }
 }
