using System.Data;
using Microsoft.Data.SqlClient;

namespace BookStoreManagerService.Infrastructure.DataContext.Common;

public class DbConnector(string connectionString)
{
    private const string DefaultConnectionString = "default";
    private readonly string ConnectionStringName = connectionString ?? DefaultConnectionString;

    public IDbConnection CreateConnection()
    {
        return new SqlConnection(ConnectionStringName);
    }
}