using System.Data.SqlClient;

namespace Justice.App_Code
{
    public class DB
    {
        private static SqlConnection connection = new SqlConnection(@"Data Source=192.168.6.25;Initial Catalog=PrisonShop;Persist Security Info=True;User ID=428yZZcN9p;Password=sQl123!@#");
        public static SqlConnection Connection { get { return connection; } }

        private static string connString = "Data Source=192.168.6.25;Initial Catalog=PrisonShop;Persist Security Info=True;User ID=428yZZcN9p;Password=sQl123!@#";
        public static string ConnectionString { get { return connString; } }
    }
}

