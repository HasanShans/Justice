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

namespace Justice
{
    public partial class SiteMaster : MasterPage
    {
        public string Username;
        protected void Page_Load(object sender, EventArgs e)
        {
            BindCategories();
            
            if (Session["NAME"] == null)
            {
                linkLoginReg.Visible = true;
                linkLiked.Visible = false;
                linkMypage.Visible = false;
                linkNameEmail.Visible = false;
            }
            else
            {
                this.Username = Session["NAME"].ToString();
                linkLoginReg.Visible = false;
                linkLiked.Visible = true;
                linkMypage.Visible = true;
                linkNameEmail.Visible = true;
               
            }
        }

        private void BindCategories()
        {
            using (SqlCommand comm = new SqlCommand("CategoriesSelectAll", DB.Connection))
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
                            repeaterCategories.DataSource = data;
                            repeaterCategories.DataBind();
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

        protected void signOut_Click(object sender, EventArgs e)
        {
            Session["NAME"] = null;
            Session["EMAIL"] = null;
            Session["ID"] = null;
            Response.Redirect("Index.aspx");
        }

        protected void btnSearchMaster_Click(object sender, EventArgs e)
        {
            string n = String.Format("{0}", Request.Form["word"]);
            Response.Redirect("~/Main/Search?n=" + n);
        }
    }
}