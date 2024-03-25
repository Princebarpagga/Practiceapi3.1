using System.Data;
using System;
using System.Data.SqlClient;

namespace Practiceapi3._1.Model
{
    public class WrapperContext : IDisposable
    {
        private readonly IDbConnection _dbConnection;

        public WrapperContext(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }

        public IDbConnection Connection => _dbConnection;

        public void Open()
        {
            if (_dbConnection.State != ConnectionState.Open)
            {
                _dbConnection.Open();
            }
        }

        public void Close()
        {
            if (_dbConnection.State != ConnectionState.Closed)
            {
                _dbConnection.Close();
            }
        }

        public void Dispose()
        {
            _dbConnection.Dispose();
        }
    }
}

