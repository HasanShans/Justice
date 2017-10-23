using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Justice.App_Code;


namespace Justice.Staff.Add
{
    public partial class Product : System.Web.UI.Page
    {
        int CategoryID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString.AllKeys.Contains("CategoryID"))
            {
                BindCategoryDetails();
            }
            else
            {
                btnSave.Visible = true;
                btnEdit.Visible = false;
            }
        }
        private void BindCategoryDetails()
        {
            CategoryID = Convert.ToInt32(Request.QueryString["CategoryID"]);
            if (DB.Connection.State == ConnectionState.Closed)
                DB.Connection.Open();
            SqlCommand sqlCommand = new SqlCommand("CategoriesSelectByID", DB.Connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@ID", CategoryID);
            sqlCommand.ExecuteNonQuery();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (!IsPostBack)
            {
                txtCat.Text = dataTable.Rows[0]["CategoryName"].ToString();
            }
            btnEdit.Visible = true;
            btnSave.Visible = false;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (DB.Connection.State == ConnectionState.Closed)
                DB.Connection.Open();
            SqlCommand sqlCommand;
            if (Request.QueryString.AllKeys.Contains("CategoryID"))
            {
                sqlCommand = new SqlCommand("CategoriesUpdate", DB.Connection);
                sqlCommand.Parameters.AddWithValue("@ID", CategoryID);
            }
            else
            {
                sqlCommand = new SqlCommand("CategoriesCreate", DB.Connection);
            }
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@CategoryName", txtCat.Text.ToString().Trim());
            sqlCommand.ExecuteNonQuery();
            Response.Redirect("~/Staff/Categories.aspx");
        }

      

        
    }
}