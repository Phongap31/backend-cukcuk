using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.CukCuk.DataLayer.Interfaces;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;

namespace MISA.CukCuk.DataLayer.DbContext
{
    public class DapperDbContext<T> : IDbContext<T> where T : class
    {
        #region Properties
        /// <summary>
        /// Biến kết nối CSDL
        /// </summary>
        private readonly IDbConnection _dbConnection;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor khởi tạo kết nôi CSDL
        /// </summary>
        public DapperDbContext(IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnectionString");
            _dbConnection = new MySqlConnection(connectionString);
        }
        #endregion

        #region Method
        public int ExcuteSQLString(string queryString)
        {
            var result = _dbConnection.Execute(queryString);
            return result;
        }

        public int ExcuteStoreProcedure(string procedureName, DynamicParameters parameters = null)
        {
            var result = _dbConnection.Execute(procedureName, parameters, commandType: CommandType.StoredProcedure);
            return result;
        }

        public T QueryFirstSQLString(string queryString)
        {
            var result = _dbConnection.Query<T>(queryString).FirstOrDefault();
            return result;
        }

        public T QueryFirstStoreProcedure(string procedureName, DynamicParameters parameters = null)
        {
            var result = _dbConnection.Query<T>(procedureName, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;
        }

        public IEnumerable<T> QuerySQLString(string queryString)
        {
            var result = _dbConnection.Query<T>(queryString);
            return result;
        }

        public IEnumerable<T> QueryStoreProcedure(string procedureName, DynamicParameters parameters = null)
        {
            var result = _dbConnection.Query<T>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            return result;
        }
        #endregion
    }
}
