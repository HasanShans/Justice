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
        
        protected void Page_Load(object sender, EventArgs e)
        {
            BindProducts();
        }

        private void BindProducts()
        {
            using (SqlCommand comm = new SqlCommand("ProductsSelectAllJoinImages", DB.Connection))
            {
                comm.CommandType = CommandType.StoredProcedure;
                try
                {
                    if (DB.Connection.State == ConnectionState.Closed)
                        DB.Connection.Open();
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        DataTable data = new DataTable();
                        data.Load(reader);
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