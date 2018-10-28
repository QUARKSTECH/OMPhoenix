using System.Collections.Generic;

namespace OMPhoenix.Data.Infrastructure
{
    public interface ISqlspHelper
    {
        void BulkInsert<T>(string connectionString, string tableName, IList<T> list);
        void BulkUpdate<T>(string connectionString, string tableName, IEnumerable<T> list, string primaryKeyColumnName, params string[] propertiesToUpdate);
        void ExecStoredProcedureWithoutResults(string name, Dictionary<string, string> parameters);
        IEnumerable<T> ExecStoredProcedureWithResults<T>(string name, Dictionary<string, string> parameters = null);
        IEnumerable<T> ExecStoredProcedureWithReturnValue<T>(string name, string queryParams, object[] parameters);
        IEnumerable<T> ExecSqlWithResults<T>(string sql);
        int ExecSqlWithoutResults(string sql);
    }
}
