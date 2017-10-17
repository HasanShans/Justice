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
    public partial class Purchase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindProducts();
        }

        private void BindProducts()
        {
            if (Session.SessionID != null)
            {
                using (SqlCommand comm = new SqlCommand("CartSelectByUserID", DB.Connection))
                {
                    comm.Parameters.AddWithValue("@user_id", Convert.ToInt32(Session.SessionID));
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
                                repeater.DataSource = data;
                                repeater.DataBind();
                            }
                        }
                    }
                    catch (SqlException ex)
                    {

                    }
                    DB.Connection.Close();
                }
            } else
            {
                Response.Redirect("~/Main/Login.aspx");
            }
        }
    }
}