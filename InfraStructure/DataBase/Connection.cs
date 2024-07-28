using System.Data.Common;

namespace Infrastructure.DataBase
{
    
    public sealed class Connection
    {
        public static string connectionString { get; private set; }

        static Connection()
        {
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\FluxoCaixa-master\FluxoCaixa-master\DataBase\.Local\DbFluxoCaixa.mdf;Integrated Security=True";
        }        
    }
}
