using System.Data;
using Fontix.IDAL.Context;
using MySqlConnector;

namespace Fontix.DAL.Context;

public class DapperContext: IContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public DapperContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("Default");
    }

    public IDbConnection CreateConnection() => new MySqlConnection(_connectionString);
}