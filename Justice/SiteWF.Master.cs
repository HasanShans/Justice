﻿using Justice.App_Code;
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
    public partial class SiteWF : MasterPage
    {
        public string Username1;
        protected void Page_Load(object sender, EventArgs e)
        {

            BindCategories();

            if (Session["NAME"] == null)
            {
                linkLoginReg.Visible = true;
                linkMypage.Visible = false;
                linkNameEmail.Visible = false;
                lblCartCount.Text = "0";
            }
            else
            {
                this.Username1 = Session["NAME"].ToString();
                linkLoginReg.Visible = false;
                linkMypage.Visible = true;
                linkNameEmail.Visible = true;
                BindCountOfCartProducts();
            }
        }
        private void BindCountOfCartProducts()
        {
            if (DB.Connection.State == ConnectionState.Closed)
                DB.Connection.Open();
            SqlCommand sqlCommand = new SqlCommand("CartCount", DB.Connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["ID"]));
            String count = sqlCommand.ExecuteScalar().ToString();
            lblCartCount.Text = count;
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
                catch
                {

                }
                DB.Connection.Close();
            }
        }

        protected void signOut_Click(object sender, EventArgs e)
        {
            Session["NAME"] = null;
            Session["EMAIL"] = null;
            Session["ID"] = null;
            Response.Redirect("~/ana-səhifə");
        }

        protected void btnSearchMaster_Click(object sender, EventArgs e)
        {
            string n = String.Format("{0}", Request.Form["word"]);
            Response.Redirect("~/məhsul-filter?search=" + n);
        }
    }
}