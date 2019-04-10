using Justice.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Justice
{
    public partial class Index : System.Web.UI.Page
    {
        private int PageSize = 12;
        private int PageIndex = 1;
        public Dictionary<string, string> data = new Dictionary<string, string>();
        public string productsHeader = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            BindProducts();
            BindMostSoldProducts();
            BindNewProducts();
        }
        private void BindMostSoldProducts()
        {
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("ProductsSelectMostSold", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count != 0)
                {
                    data.Add("MSImagePath", dataTable.Rows[0]["ID"].ToString() + "/" + dataTable.Rows[0]["Name"].ToString() + dataTable.Rows[0]["Extention"].ToString());
                    data.Add("MSProductName", dataTable.Rows[0]["ProductName"].ToString());
                    data.Add("MSPrice", dataTable.Rows[0]["DiscountPrice"].ToString());
                }
                else
                {
                    mostSoldProducts.Visible = false;
                }
            }

        }
        private void BindNewProducts()
        {
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("ProductsSelectNew", connection);
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
        }

        private void BindProducts()
        {
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                SqlCommand sqlCommand;
                sqlCommand = new SqlCommand("ProductsSelectAllPaginate", connection);
                if (Request.QueryString.AllKeys.Contains("kateqoriya"))
                {
                    productsHeader = Request.QueryString["kateqoriya"].ToString();
                    slider.Visible = false;
                    String categoryName = Request.QueryString["kateqoriya"].ToString();
                    sqlCommand.Parameters.AddWithValue("@CategoryName", categoryName);
                }
                else
                {
                    productsHeader = "Bütün Məhsullar";
                }
                sqlCommand.Parameters.AddWithValue("@PageIndex", PageIndex);
                sqlCommand.Parameters.AddWithValue("@PageSize", PageSize);
                sqlCommand.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
                sqlCommand.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                int recordCount = Convert.ToInt32(sqlCommand.Parameters["@RecordCount"].Value);
                this.PopulatePager(recordCount, PageIndex);
                if (dataTable.Rows.Count != 0)
                {
                    productRepeater.DataSource = dataTable;
                    productRepeater.DataBind();
                }
                else
                {
                    productsHeader = "Tapılmadı";
                    notfoundProduct.Visible = true;
                }
            }
        }
        private void PopulatePager(int recordCount, int currentPage)
        {
            double dblPageCount = (double)((decimal)recordCount / Convert.ToDecimal(PageSize));
            int pageCount = (int)Math.Ceiling(dblPageCount);
            List<ListItem> pages = new List<ListItem>();
            if (pageCount > 0)
            {
                for (int i = 1; i <= pageCount; i++)
                {
                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
                }
            }
            rptPager.DataSource = pages;
            rptPager.DataBind();
        }
        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            PageIndex = pageIndex;
            this.BindProducts();
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

        
    }
}