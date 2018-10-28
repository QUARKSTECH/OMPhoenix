using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace OMPhoenix.Data.Infrastructure
{
    public class SqlspHelper: ISqlspHelper
    {
        private OMPhoenixContext _dataContext;

        #region Properties
        /// <summary>
        /// Gets the database factory.
        /// </summary>
        /// <value>The database factory.</value>
        protected IDbFactory DbFactory
        {
            get;
        }

        /// <summary>
        /// Gets the database context.
        /// </summary>
        /// <value>The database context.</value>
        protected OMPhoenixContext DbContext => _dataContext ?? (_dataContext = DbFactory.Init());

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlspHelper"/> class.
        /// </summary>
        /// <param name="dbFactory">The database factory.</param>
        public SqlspHelper(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
        }
        #endregion


        /// <summary>
        /// Executes the stored procedure without results.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="parameters">The parameters.</param>
        public void ExecStoredProcedureWithoutResults(string name, Dictionary<string, string> parameters = null)
        {
            var addedParams = new StringBuilder();

            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    addedParams.Append($"{param.Key}='{param.Value}',");
                }
            }

            if (addedParams.Length > 0)
            {
                addedParams = addedParams.Remove(addedParams.Length - 1, 1);
            }

            DbContext.Database.ExecuteSqlCommand($"EXEC {name} {addedParams}");
        }

        /// <summary>
        /// Executes the stored procedure with results.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">The name.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public IEnumerable<T> ExecStoredProcedureWithResults<T>(string name, Dictionary<string, string> parameters = null)
        {
            var addedParams = new StringBuilder();

            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    addedParams.Append($"{param.Key}='{param.Value}',");
                }
            }

            if (addedParams.Length > 0)
            {
                addedParams = addedParams.Remove(addedParams.Length - 1, 1);
            }

            var data = DbContext.Database.SqlQuery<T>($"EXEC {name} {addedParams}");

            return data;
        }

        /// <summary>
        /// Executes the stored procedure with return value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">The name.</param>
        /// <param name="queryParams">The query parameters.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public IEnumerable<T> ExecStoredProcedureWithReturnValue<T>(string name, string queryParams, object[] parameters)
        {
            var data = DbContext.Database.SqlQuery<T>($"EXEC {name} {queryParams}", parameters);
            return data;
        }

        /// <summary>
        /// Executes the SQL with results.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">The SQL.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public IEnumerable<T> ExecSqlWithResults<T>(string sql)
        {
            return DbContext.Database.SqlQuery<T>(sql);
        }

        /// <summary>
        /// Executes the SQL without results.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <returns>System.Int32.</returns>
        public int ExecSqlWithoutResults(string sql)
        {
            return DbContext.Database.ExecuteSqlCommand(sql);
        }

        /// <summary>
        /// Bulks the insert.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="list">The list.</param>
        public void BulkInsert<T>(string connectionString, string tableName, IList<T> list)
        {
            if (list.Any())
            {
                using (var bulkCopy = new SqlBulkCopy(connectionString, SqlBulkCopyOptions.TableLock))
                {
                    bulkCopy.BatchSize = list.Count;
                    bulkCopy.DestinationTableName = tableName;

                    var table = new DataTable();
                    var props = TypeDescriptor.GetProperties(typeof(T))
                        //Dirty hack to make sure we only have system data types 
                        //i.e. filter out the relationships/collections
                                                               .Cast<PropertyDescriptor>()
                                                               .Where(
                                                                   propertyInfo => propertyInfo.PropertyType.Namespace != null && propertyInfo.PropertyType.Namespace.Equals(
                                                                       "System"))
                                                               .ToArray();

                    foreach (var propertyInfo in props)
                    {
                        bulkCopy.ColumnMappings.Add(propertyInfo.Name, propertyInfo.Name);
                        table.Columns.Add(propertyInfo.Name,
                                          Nullable.GetUnderlyingType(propertyInfo.PropertyType) ??
                                          propertyInfo.PropertyType);
                    }

                    var values = new object[props.Length];
                    foreach (var item in list)
                    {
                        for (var i = 0; i < values.Length; i++)
                        {
                            values[i] = props[i].GetValue(item);
                        }

                        table.Rows.Add(values);
                    }

                    bulkCopy.WriteToServer(table);
                }
            }
        }

        /// <summary>
        /// Bulks the update.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="list">The list.</param>
        /// <param name="primaryKeyColumnName">Name of the primary key column.</param>
        /// <param name="propertiesToUpdate">The properties to update.</param>
        public void BulkUpdate<T>(string connectionString, string tableName, IEnumerable<T> list, string primaryKeyColumnName, params string[] propertiesToUpdate)
        {
            var enumerable = list as IList<T> ?? list.ToList();
            if (enumerable.Any())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var props = TypeDescriptor.GetProperties(typeof(T))
                                                               .Cast<PropertyDescriptor>()
                                                               .Where(
                                                                   propertyInfo =>
                                                                   propertiesToUpdate.Contains(propertyInfo.Name))
                                                               .ToArray();

                    var propPk = TypeDescriptor.GetProperties(typeof(T))
                                                              .Cast<PropertyDescriptor>()
                                                              .Single(
                                                                  propertyInfo =>
                                                                  propertyInfo.Name == primaryKeyColumnName);

                    var sql = new StringBuilder();
                    var values = new object[props.Length];
                    foreach (var item in enumerable)
                    {
                        sql.AppendFormat("update {0} set ", tableName);
                        for (var i = 0; i < values.Length; i++)
                        {
                            var value = props[i].GetValue(item);
                            if (value != null)
                            {
                                sql.AppendFormat("[{0}] = '{1}',", props[i].Name, value.ToString().Replace("'", "''"));
                            }
                            else
                            {
                                sql.AppendFormat("[{0}] = NULL,", props[i].Name);
                            }
                        }
                        sql = sql.Remove(sql.Length - 1, 1);
                        sql.AppendFormat(" where {0} = '{1}'; ", primaryKeyColumnName, propPk.GetValue(item));
                    }

                    connection.Open();
                    using (var cmd = new SqlCommand(sql.ToString(), connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
