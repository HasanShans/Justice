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
    public partial class Index : System.Web.UI.Page
    {
        public Dictionary<string, string> data = new Dictionary<string, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindProducts();
            BindMostSoldProducts();
            BindNewProducts();
            BindConceptProducts();
        }
        private void BindMostSoldProducts()
        {
            if (DB.Connection.State == ConnectionState.Closed)
                DB.Connection.Open();
            SqlCommand sqlCommand = new SqlCommand("ProductsSelectMostSold", DB.Connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count != 0)
            {
                data.Add("MSImagePath", dataTable.Rows[0]["ID"].ToString()+"/"+ dataTable.Rows[0]["Name"].ToString()+ dataTable.Rows[0]["Extention"].ToString());
                data.Add("MSProductName", dataTable.Rows[0]["ProductName"].ToString());
                data.Add("MSPrice", dataTable.Rows[0]["DiscountPrice"].ToString());
            }
            else
            {
                mostSoldProducts.Visible = false;
            }
            
        }
        private void BindNewProducts()
        {
            if (DB.Connection.State == ConnectionState.Closed)
                DB.Connection.Open();
            SqlCommand sqlCommand = new SqlCommand("ProductsSelectNew", DB.Connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count != 0)
            {
                data.Add("NPImagePath", dataTable.Rows[0]["ID"].ToString() + "/" + dataTable.Rows[0]["Name"].ToString() + dataTable.Rows[0]["Extention"].ToString());
                data.Add("NPProductName", dataTable.Rows[0]["ProductName"].ToString());
                data.Add("NPPrice", dataTable.Rows[0]["DiscountPrice"].ToString());
            }
            else
            {
                newProducts.Visible = false;
            }
        }
        private void BindConceptProducts()
        {
            if (DB.Connection.State == ConnectionState.Closed)
                DB.Connection.Open();
            SqlCommand sqlCommand = new SqlCommand("ProductsSelectConcept", DB.Connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count != 0)
            {
                data.Add("CPImagePath", dataTable.Rows[0]["ID"].ToString() + "/" + dataTable.Rows[0]["Name"].ToString() + dataTable.Rows[0]["Extention"].ToString());
                data.Add("CPProductName", dataTable.Rows[0]["ProductName"].ToString());
                data.Add("CPPrice", dataTable.Rows[0]["DiscountPrice"].ToString());
            }
            else
            {
                conceptProducts.Visible = false;
            }
        }
        private void BindProducts()
        {
            if (DB.Connection.State == ConnectionState.Closed)
                DB.Connection.Open();
            SqlCommand sqlCommand;
            if (Request.QueryString.AllKeys.Contains("Category"))
            {
                slider.Visible = false;
                String categoryName = Request.QueryString["Category"].ToString();
                sqlCommand = new SqlCommand("ProductsSelectByCategoryNameJoinCategoriesImages", DB.Connection);
                sqlCommand.Parameters.AddWithValue("@CategoryName", categoryName);
            }
            else
            {
                sqlCommand = new SqlCommand("ProductsSelectAllJoinImages", DB.Connection);
            }
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

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
           
            int ProductID = int.Parse(btn.CommandArgument);
            if (Session["NAME"] != null)
            {
                int UserID = Convert.ToInt32(Session["ID"]);
                if (DB.Connection.State == ConnectionState.Closed)
                    DB.Connection.Open();
                SqlCommand comm2 = new SqlCommand("CartSelectByUserIDAndProductID", DB.Connection);
                comm2.CommandType = CommandType.StoredProcedure;
                comm2.Parameters.AddWithValue("@user_id", UserID);
                comm2.Parameters.AddWithValue("@product_id", ProductID);
                int ifExists = Convert.ToInt32(comm2.ExecuteScalar());
                if (ifExists == 0)
                {
                    SqlCommand comm = new SqlCommand("CartCreate", DB.Connection);
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@user_id", UserID);
                    comm.Parameters.AddWithValue("@product_id", ProductID);
                    comm.ExecuteNonQuery();
                }   
                Response.Redirect("Purchase.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}