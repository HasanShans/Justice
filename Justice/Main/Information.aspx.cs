using Justice.NotariatService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using Justice.App_Code;

namespace Justice.Main
{
    public partial class Information : System.Web.UI.Page
    {
        int UserID;
        CultureInfo provider = CultureInfo.InvariantCulture;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["NAME"] != null)
            {
                BindUserInfo();
            }
            else
            {
                Response.Redirect("~/Main/Login?rurl=Information");
            }
            
        }
        private void BindUserInfo()
        {
            UserID = Convert.ToInt32(Session["ID"].ToString());
            nameTextBox.Enabled = false;
            surnameTextBox.Enabled = false;
            dateTextBox.Enabled = false;
            if (DB.Connection.State == ConnectionState.Closed)
                DB.Connection.Open();
            SqlCommand sqlCommand = new SqlCommand("UsersSelectByID", DB.Connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@ID", UserID);
            sqlCommand.ExecuteNonQuery();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count != 0)
            {
                if (dataTable.Rows[0]["IDSerialNumber"].ToString() == "0")
                {
                    nameTextBox.Text = "Şəxsiyyət Vəsiqəsindəki Adınız";
                    surnameTextBox.Text = "Şəxsiyyət Vəsiqəsindəki Soyadınız";
                    emailTextBox.Text = dataTable.Rows[0][3].ToString();
                }
                else
                {
                    nameTextBox.Text = dataTable.Rows[0]["FirstName"].ToString();
                    surnameTextBox.Text = dataTable.Rows[0]["LastName"].ToString();
                    emailTextBox.Text = dataTable.Rows[0]["Email"].ToString();
                    serialTextBox.Text = dataTable.Rows[0]["IDSerialNumber"].ToString();
                    serialTextBox.Enabled = false;
                }
            }
        }
        protected void submitClick(object sender, EventArgs e)
        {
            NotariatServiceClient service = new NotariatServiceClient();
            service.ClientCredentials.UserName.UserName = "notariat";
            service.ClientCredentials.UserName.Password = "932N0+aR4";
            
            SearchParam param = new SearchParam();
            param.SearchType = SearchType.DocumentByNumber;

            param.Document = new SearchDocument();
            SearchDocument document = param.Document;
            document = param.Document;
            document.Series = "aze";
            document.Number = serialTextBox.Text;
            document.IsAddressSpecified = false;
            document.IsPhotoSpecified = false;

            FullDocSearchResult result = service.GetOneDocument(param);
            FullPerson person = result.Document.Person;
            nameTextBox.Text = person.FirstName;
            surnameTextBox.Text = person.LastName;
            dateTextBox.Text = person.DateOfBirthStr;

            service.Close();
            if (DB.Connection.State == ConnectionState.Closed)
                DB.Connection.Open();
            SqlCommand sqlCommand = new SqlCommand("UsersUpdateInfoWithService", DB.Connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@ID", UserID);
            sqlCommand.Parameters.AddWithValue("@FirstName", nameTextBox.Text.ToString().Trim());
            sqlCommand.Parameters.AddWithValue("@LastName", surnameTextBox.Text.ToString().Trim());
            sqlCommand.Parameters.AddWithValue("@BirthDate", dateTextBox.Text.ToString().Trim());
            sqlCommand.Parameters.AddWithValue("@IDSerialNumber", serialTextBox.Text.ToString().Trim());
            sqlCommand.Parameters.AddWithValue("@City", cityTextBox.Text.ToString().Trim());
            sqlCommand.Parameters.AddWithValue("@PostIndex", PostIndexTextBox.Text.ToString().Trim());
            sqlCommand.Parameters.AddWithValue("@MobilePhone", MobilePhoneTextBox.Text.ToString().Trim());
            sqlCommand.Parameters.AddWithValue("@HomePhone", HomePhoneTextBox.Text.ToString().Trim());
            sqlCommand.ExecuteNonQuery();
            DB.Connection.Close();
        }
    }
}