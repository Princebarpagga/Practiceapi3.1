using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System;
using Dapper;

namespace Practiceapi3._1.Model
{
    public class DataAccess
    {
        private readonly IDbConnection _dbConnection;

        public DataAccess(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null)
        {
            try
            {
                return await _dbConnection.QueryAsync<T>(sql, param);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null)
        {
            try
            {
                return await _dbConnection.QueryFirstOrDefaultAsync<T>(sql, param);
            }
            catch (Exception ex)
            {
                // Handle exceptions or logging here
                throw;
            }
        }

        public async Task ExecuteAsync(string sql, object param = null)
        {
            try
            {
                await _dbConnection.ExecuteAsync(sql, param);
            }
            catch (Exception ex)
            {
                // Handle exceptions or logging here
                throw;
            }
        }
    }
}
