namespace Fontix.IDAL.DbAccess;

public interface IDbAccess
{
    Task<IEnumerable<T>> LoadData<T, U>(string storedprocedure, U parameters);

    Task<TOutput> LoadDataWithJoin<TMain, TJoined, TOutput, TParameters>(
        string storedProcedure,
        TParameters parameters,
        Func<TMain, TJoined, TOutput> map,
        string splitOn,
        object splitOnAdditional
    );

    Task Savedata<T>(string storedprocedure, T parameters);
}