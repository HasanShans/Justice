using System.Data.SqlClient;

namespace Justice.App_Code
{
    public class DB
    {
        private static SqlConnection connection = new SqlConnection(@"Data Source=192.168.6.25;Initial Catalog=PrisonShop;Persist Security Info=True;User ID=sa;Password=Pr!s0n@rt");
        public static SqlConnection Connection { get { return connection; } }
    }
}

