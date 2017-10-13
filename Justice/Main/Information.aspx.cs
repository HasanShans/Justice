using Justice.NotariatService;
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
    public partial class Information : System.Web.UI.Page
    {

        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PrisonShop;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {

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
            
            using (SqlCommand comm = new SqlCommand("information", sqlConnection))
            {
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@first", nameTextBox.Text);
                comm.Parameters.AddWithValue("@last", surnameTextBox.Text);
                comm.Parameters.AddWithValue("@email", emailTextBox.Text);
                comm.Parameters.AddWithValue("@birth", dateTextBox.Text);
                comm.Parameters.AddWithValue("@serial", serialTextBox.Text);
                comm.Parameters.AddWithValue("@city", cityTextBox.Text);
                comm.Parameters.AddWithValue("@post", postTextBox.Text);
                comm.Parameters.AddWithValue("@mobile", mobileTextBox.Text);
                comm.Parameters.AddWithValue("@homephone", homePhoneTextBox.Text);
                try
                {
                    sqlConnection.Open();
                    comm.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    // other codes here
                    // do something with the exception
                    // don't swallow it.
                }
            }
        }
    }
}