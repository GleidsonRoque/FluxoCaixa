using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.DataBase
{
    public class DbContext
    {
        public static IDbConnection GetConnection()
        {
            IDbConnection OpenConnection = new SqlConnection(Connection.connectionString);
            OpenConnection.Open();
            return OpenConnection;

        }
    }
}
