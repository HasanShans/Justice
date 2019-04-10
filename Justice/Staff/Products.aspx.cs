using Justice.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace Justice.Staff
{
    public partial class Products : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ADMINSESSION"].ToString() != "Admin")
                {
                    int JailNum = Convert.ToInt32(Session["ADMINSESSION"]);
                    BindJailProducts(JailNum);
                }
                else
                {
                    BindProducts();
                }
            }
        }
        private void BindJailProducts(int JailNum)
        {
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();

                Int64 JailID = Convert.ToInt64(Session["ADMINSESSIONJAILNO"]);
                SqlCommand sqlCommand = new SqlCommand("ProductsSelectByJailIDJoinCategoriesAndJails", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@JailID", JailID);
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                rprtProducts.DataSource = dataTable;
                rprtProducts.DataBind();
            }
        }
        private void BindProducts()
        {
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("ProductsSelectAllJoinCategoriesAndJails", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                rprtProducts.DataSource = dataTable;
                rprtProducts.DataBind();
            }
        }

        protected void ProductEditClick(object sender, EventArgs e)
        {
            int ProductID = int.Parse(((sender as Button).NamingContainer.FindControl("lblProductID") as Label).Text);
            Response.Redirect("~/root/yeni-məhsul?ProductID=" + ProductID);
        }

        protected void ProductDeleteClick(object sender, EventArgs e)
        {
            int ProductID = int.Parse(((sender as Button).NamingContainer.FindControl("lblProductID") as Label).Text);
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("ProductsDeleteByID", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ID", ProductID);
                sqlCommand.ExecuteNonQuery();
                BindProducts();
            }
        }
    }
}
