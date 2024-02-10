using Microsoft.Data.SqlClient;

namespace Warehouse.WebApi.DbConnection;

public interface ISqlConnectionFactory
{
    SqlConnection GetOpenConnection();
}