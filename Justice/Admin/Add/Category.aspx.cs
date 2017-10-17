﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Justice.Admin.Add
{
    public partial class Product : System.Web.UI.Page
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=GADIR\SQLEXPRESS;Initial Catalog=PrisonShop;Integrated Security=True");
        int CategoryID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString.AllKeys.Contains("CategoryID"))
            {
                CategoryID = Convert.ToInt32(Request.QueryString["CategoryID"]);
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("CategoriesSelectByID", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ID", CategoryID);
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (!IsPostBack)
                {
                    txtCat.Text = dataTable.Rows[0][1].ToString();
                }
                btnEdit.Visible = true;
                btnSave.Visible = false;
            }
            else
            {
                btnSave.Visible = true;
                btnEdit.Visible = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("CategoriesCreate", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@CategoryName", txtCat.Text.ToString().Trim());
            sqlCommand.ExecuteNonQuery();
            Response.Redirect("~/Admin/Categories.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("CategoriesUpdate", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@ID", CategoryID);
            sqlCommand.Parameters.AddWithValue("@CategoryName", txtCat.Text.ToString().Trim());
            sqlCommand.ExecuteNonQuery();
            Response.Redirect("~/Admin/Categories.aspx");
        }

        
    }
}