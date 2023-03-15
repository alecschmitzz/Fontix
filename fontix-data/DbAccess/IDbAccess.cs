namespace fontix_data.DbAccess;

public interface IDbAccess
{
    Task<IEnumerable<T>> LoadData<T, U>(string storedprocedure, U parameters);
    Task Savedata<T>(string storedprocedure, T parameters);
}