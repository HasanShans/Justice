﻿using System;
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
            if (DB.Connection.State == ConnectionState.Closed)
                DB.Connection.Open();
            SqlCommand comm = new SqlCommand("ProductsSelectByIDJoinCategoriesImages", DB.Connection);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@id", id);
            comm.ExecuteNonQuery();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(comm);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count != 0)
            {
                data.Add("mehsul_ID", dataTable.Rows[0]["ID"].ToString());
                data.Add("mehsul_kod", dataTable.Rows[0]["Code"].ToString());
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
            SqlCommand comm1 = new SqlCommand("ImagesSelectByProductID", DB.Connection);
            comm1.CommandType = CommandType.StoredProcedure;
            comm1.Parameters.AddWithValue("@ProductID", id);
            comm1.ExecuteNonQuery();
            SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(comm1);
            DataTable dataTable1 = new DataTable();
            sqlDataAdapter1.Fill(dataTable1);
            if (dataTable1.Rows.Count != 0)
            {
                rprtImages.DataSource = dataTable1;
                rprtImages.DataBind();
            }
            DB.Connection.Close();
            
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
                Response.Redirect("~/Main/Product.aspx?id="+data["mehsul_ID"]);
            }
            else
            {
                Response.Redirect("~/Main/Login.aspx");
            }
        }
    }
 }
