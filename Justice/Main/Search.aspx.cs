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
    public partial class Search : System.Web.UI.Page
    {
        public int result = 0;
        public string searchedProduct = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            BindProducts();
        }

        private void BindProducts()
        {
            
            searchedProduct = Request.QueryString["n"].ToString();
            using (SqlCommand comm = new SqlCommand("ProductSearch", DB.Connection))
            {
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@name", searchedProduct);
                try
                {
                    if (DB.Connection.State == ConnectionState.Closed)
                        DB.Connection.Open();
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        DataTable data = new DataTable();
                        data.Load(reader);
                        result = data.Rows.Count;
                        if (!IsPostBack)
                        {
                            repeater.DataSource = data;
                            repeater.DataBind();
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