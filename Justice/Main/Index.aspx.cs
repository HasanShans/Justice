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
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PrisonShop;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            BindProducts();
        }
        private void BindProducts()
        {
            using (SqlCommand comm = new SqlCommand("ProductsSelectAllJoinImages", sqlConnection))
            {
                try
                {
                    sqlConnection.Open();
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        DataTable data = new DataTable();
                        data.Load(reader);
                        if (!IsPostBack)
                        {
                            productRepeater.DataSource = data;
                            productRepeater.DataBind();
                        }
                        sqlConnection.Close();
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