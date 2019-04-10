using Justice.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;


namespace Justice
{
    public partial class ProductsSoon : System.Web.UI.Page
    {
        public string producstHeader = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["filter"] == "ProductsSoon")
            {
                BindProductsSoon();
            }else if (Request.QueryString["filter"] == "MostSoldProducts")
            {
                BindMostSoldProducts();
            }else if (Request.QueryString["filter"] == "NewProducts")
            {
                BindNewProducts();
            }else if (Request.QueryString["filter"] == "ConceptProducts")
            {
                BindConceptProducts();
            } else if (Request.QueryString.AllKeys.Contains("search"))
            {
                BindSearchResults();
            }else if(Request.QueryString["filter"] == "DiscountProducts")
            {
                BindDiscountProducts();
            }
        }
        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            int ProductID = int.Parse(btn.CommandArgument);
            if (Session["NAME"] != null)
            {
                int UserID = Convert.ToInt32(Session["ID"]);
                using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
                {
                    connection.Open();
                    SqlCommand comm2 = new SqlCommand("CartSelectByUserIDAndProductID", connection);
                    comm2.CommandType = CommandType.StoredProcedure;
                    comm2.Parameters.AddWithValue("@user_id", UserID);
                    comm2.Parameters.AddWithValue("@product_id", ProductID);
                    int ifExists = Convert.ToInt32(comm2.ExecuteScalar());
                    if (ifExists == 0)
                    {
                        SqlCommand comm = new SqlCommand("CartCreate", connection);
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@user_id", UserID);
                        comm.Parameters.AddWithValue("@product_id", ProductID);
                        comm.ExecuteNonQuery();
                        Response.Redirect("~/səbət");
                    }
                    else
                    {
                        ModalSuccess.LabelModalMsg.Text = "Hörmətli istifadəçi, bu məhsul artıq kartınıza əlavə olunub";
                        ModalSuccess.BtnCancel.Text = "Alış-Verişə Davam";
                        ModalSuccess.HlPurchase.Visible = true;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    }
                }
            }
            else
            {
                Response.Redirect("~/login");
            }
        }
        private void BindDiscountProducts()
        {
            producstHeader = "Endirimdə Olan Məhsullar";
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("ProductsSelectDiscounted", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count != 0)
                {
                    productRepeater.DataSource = dataTable;
                    productRepeater.DataBind();
                }
                else
                {
                    notfoundProduct.Visible = true;
                }
            }
        }
        private void BindMostSoldProducts()
        {
            producstHeader = "Ən Çox Satılan Məhsullar";
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("ProductsSelectMostSoldAll", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count != 0)
                {
                    productRepeater.DataSource = dataTable;
                    productRepeater.DataBind();
                }
                else
                {
                    notfoundProduct.Visible = true;
                }
            }
        }
        private void BindNewProducts()
        {
            producstHeader = "Yeni Məhsullar";
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("ProductsSelectNewAll", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count != 0)
                {
                    productRepeater.DataSource = dataTable;
                    productRepeater.DataBind();
                }
                else
                {
                    notfoundProduct.Visible = true;
                }
            }
        }
        private void BindConceptProducts()
        {
            producstHeader = "Konsept Məhsullar";
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("ProductsSelectByCategoryNameJoinCategoriesImages", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@CategoryName", "Konsept");
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count != 0)
                {
                    productRepeater.DataSource = dataTable;
                    productRepeater.DataBind();
                }
                else
                {
                    notfoundProduct.Visible = true;
                }
            }
        }
        private void BindProductsSoon()
        {
            producstHeader = "Tezliklə Satışda Olacaq Məhsullar";
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("ProductsSelectAllByAvailability", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count != 0)
                {
                    productRepeater.DataSource = dataTable;
                    productRepeater.DataBind();
                }
                else
                {
                    notfoundProduct.Visible = true;
                }
            }
        }
        private void BindSearchResults()
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                String searchParam = Request.QueryString["search"].ToString();
                if (searchParam != "" || searchParam != null)
                {
                    SqlCommand sqlCommand = new SqlCommand("ProductSearch", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@name", searchParam.Trim());
                    sqlCommand.ExecuteNonQuery();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    result = dataTable.Rows.Count;
                    if (result != 0)
                    {
                        productRepeater.DataSource = dataTable;
                        productRepeater.DataBind();
                        producstHeader = "Axtarılan: " + searchParam + " | Status: Tapıldı | Nəticə: " + result;

                    }
                    else
                    {
                        producstHeader = "Axtarılan: " + searchParam + " | Status: Tapılmadı | Nəticə: " + result;
                        notfoundProduct.Visible = true;
                    }
                }
            }
        }
    }
}