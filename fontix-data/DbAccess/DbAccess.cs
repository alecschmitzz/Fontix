using System.Data;
using Dapper;
using fontix_data.Context;

namespace fontix_data.DbAccess;

public class DbAccess : IDbAccess
{
    private readonly DapperContext _context;

    public DbAccess(DapperContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<T>> LoadData<T, U>(string storedprocedure, U parameters)
    {
        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<T>(
            storedprocedure,
            parameters,
            commandType: CommandType.StoredProcedure
        );
    }

    public async Task Savedata<T>(string storedprocedure, T parameters)
    {
        using var connection = _context.CreateConnection();

        await connection.ExecuteAsync(
            storedprocedure,
            parameters,
            commandType: CommandType.StoredProcedure
        );
    }
}