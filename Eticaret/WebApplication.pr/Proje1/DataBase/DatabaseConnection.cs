using Microsoft.Data.SqlClient;

namespace DataBase
{
    public class DatabaseConnection
    {
        public SqlConnection GetConnection
        {
            get
            {
                SqlConnection conn = new SqlConnection("Server=Duru; Database=Personel;");
                conn.Open();
                return conn;
            }
        }
    }
}
