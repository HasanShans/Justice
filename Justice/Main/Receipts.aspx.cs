using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Justice.App_Code;
using System;

namespace Justice.Main
{
    public partial class Receipts : System.Web.UI.Page
    {
        public int totalSum = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["NAME"] == null)
            {
                Response.Redirect("Login.aspx?rurl=Receipts");
            }
            else
            {
                BindReceipts();
            }
        }
        private void BindReceipts()
        {
            int userID = Convert.ToInt32(Session["ID"]);
            if (DB.Connection.State == ConnectionState.Closed)
                DB.Connection.Open();
            SqlCommand sqlCommand = new SqlCommand("OrdersSelectAllByUserIDJoinProducts", DB.Connection);
            sqlCommand.Parameters.AddWithValue("@UserID", userID);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            DataColumn number = dataTable.Columns.Add("Number", typeof(Int32));
            int NumberOfRows = 1;
            foreach (DataRow row in dataTable.Rows)
            {
                row["Number"] = NumberOfRows;
                NumberOfRows++;
                totalSum += Convert.ToInt32(row["DiscountPrice"]);
            }
            if (dataTable.Rows.Count != 0)
            {
                rprtReceipts.DataSource = dataTable;
                rprtReceipts.DataBind();
            }
            else
            {
                tdRow.Visible = true;
            }
        }
    }
}