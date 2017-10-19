using System;
using System.Data;
using System.Data.SqlClient;
using Justice.App_Code;

namespace Justice.Main
{
    public partial class Category : System.Web.UI.Page
    {
        public String categoryName = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            BindProducts();
        }

        private void BindProducts()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            
            using (SqlCommand comm = new SqlCommand("ProductsSelectByCategoryIDJoinCategoriesImages", DB.Connection))
            {
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@category_id", id);
                try
                {
                    if(DB.Connection.State==ConnectionState.Closed)
                        DB.Connection.Open();
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        DataTable data = new DataTable();
                        data.Load(reader);
                        categoryName = data.Rows[0]["CategoryName"].ToString();
                        if (!IsPostBack)
                        {
                            productRepeater.DataSource = data;
                            productRepeater.DataBind();
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
    }
}