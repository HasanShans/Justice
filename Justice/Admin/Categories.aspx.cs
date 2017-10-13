using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Justice.Admin
{
    public partial class Categories : System.Web.UI.Page
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PrisonShop;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlCommand comm = new SqlCommand("SELECT * FROM Categories", sqlConnection))
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
                            repeater.DataSource = data;
                            repeater.DataBind();
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

        protected void EditButton_Click(object sender, EventArgs e)
        {

        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {

        }
    }
}