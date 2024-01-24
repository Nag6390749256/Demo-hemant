using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using static Dapper.SqlMapper;

namespace DAPPER_CURD.AppCode.Hellper
{
    public class DB_Helper: IDB_Helper
    {
        public T ExecuteProc<T>(string ProcName, DynamicParameters param)
        {
            using (SqlConnection sqlcon = new SqlConnection(Config.ConStr))
            {
                return (T)Convert.ChangeType(sqlcon.Execute(ProcName, param, commandType:System.Data.CommandType.StoredProcedure), typeof(T));
            }
        }
        public IEnumerable<T> ExecuteProcList<T>(string ProcName, object param)
        {
            using (SqlConnection sqlcon = new SqlConnection(Config.ConStr))
            {
                return sqlcon.Query<T>(ProcName, param, commandType:System.Data.CommandType.StoredProcedure);
            }
        }
        public T ExecuteQueryFirst<T>(string ProcName, object param)
        {
            using (SqlConnection sqlcon = new SqlConnection(Config.ConStr))
            {
                return sqlcon.QueryFirst<T>(ProcName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
