using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PhotoSharingAppJessieDomingo.DataAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private string GetConnectionString(string ConnectionString)
        {
            return GetConfiguration.GetConnectionString(ConnectionString);
        }
        public async Task<List<T>> LoadData<T, U>(
            string storedProcedure,
            U parameters,
            string connectionId)
        {

            using (IDbConnection connection = new SqlConnection(GetConnectionString(connectionId)))
            {
                return (List<T>)await connection.QueryAsync<T>(storedProcedure, parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> SaveData<T>(
            string storedProcedure,
            T parameters,
            string connectionId)
        {
            using (IDbConnection connection = new SqlConnection(GetConnectionString(connectionId)))
            {
                return await connection.ExecuteAsync(storedProcedure, parameters,
                    commandType: CommandType.StoredProcedure);
            }

        }
    }
}
