using Microsoft.Data.SqlClient;

namespace Warehouse.WebApi.DbConnection;

public class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly IConfiguration _configuration;

    public SqlConnectionFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public SqlConnection GetOpenConnection()
    {
        // read connection string from configuration appsettings.json
        var connection = new SqlConnection(_configuration.GetConnectionString("Warehouse"));
        
        connection.Open();

        return connection;
    }
}