using System.Data;
using Dapper;
using Fontix.DAL.Context;
using Fontix.IDAL.DbAccess;

namespace Fontix.DAL.DbAccess;

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

    public async Task<TOutput> LoadDataWithJoin<TMain, TJoined, TOutput, TParameters>(
        string storedProcedure,
        TParameters parameters,
        Func<TMain, TJoined, TOutput> map,
        string splitOn,
        object splitOnAdditional
    )
    {
        using var connection = _context.CreateConnection();
        var results = await connection.QueryAsync<TMain, TJoined, TOutput>(
            storedProcedure,
            map,
            parameters,
            splitOn: splitOn,
            commandType: CommandType.StoredProcedure
        );

        return results.FirstOrDefault();
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