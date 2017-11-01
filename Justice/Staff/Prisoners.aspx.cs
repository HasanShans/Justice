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


namespace Justice.Staff
{
    public partial class Prisoners : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPrisoners();
            }
        }

        private void BindPrisoners()
        {
            if (DB.Connection.State == ConnectionState.Closed)
                DB.Connection.Open();
            SqlCommand sqlCommand = new SqlCommand("PrisonersSelectAlll", DB.Connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            rprtPrisoners.DataSource = dataTable;
            rprtPrisoners.DataBind();
            DB.Connection.Close();
        }

        protected void PrisonerEditClick(object sender, EventArgs e)
        {
            int PrisonerID = int.Parse(((sender as Button).NamingContainer.FindControl("lblPrisonerID") as Label).Text);
            Response.Redirect("~/Staff/Add/Prisoner?PrisonerID=" + PrisonerID);
        }

        protected void PrisonerDeleteClick(object sender, EventArgs e)
        {
            int PriosonerID = int.Parse(((sender as Button).NamingContainer.FindControl("lblPriosonerID") as Label).Text);
            if (DB.Connection.State == ConnectionState.Closed)
                DB.Connection.Open();
            SqlCommand sqlCommand = new SqlCommand("PrisonersDeleteByID", DB.Connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("ID", PriosonerID);
            sqlCommand.ExecuteNonQuery();
            BindPrisoners();
            DB.Connection.Close();
        }
    }
}
