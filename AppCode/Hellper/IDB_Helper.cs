using Dapper;
using System.Collections.Generic;

namespace DAPPER_CURD.AppCode.Hellper
{
    public interface IDB_Helper
    {
        T ExecuteProc<T>(string ProcName, DynamicParameters param);
        IEnumerable<T> ExecuteProcList<T>(string ProcName, object param);
        T ExecuteQueryFirst<T>(string ProcName, object param);
    }
}
