using System.Data;

namespace Fontix.IDAL.Context;

public interface IContext
{
    public IDbConnection CreateConnection();
}