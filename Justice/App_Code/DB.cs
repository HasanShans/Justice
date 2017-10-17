using System.Data.SqlClient;

namespace Justice.App_Code
{
    public class DB
    {
        private static SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PrisonShop;Integrated Security=True");
        public static SqlConnection Connection { get { return connection; } }
    }
}