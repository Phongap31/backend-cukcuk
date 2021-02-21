using Dapper;
using MISA.CukCuk.DataLayer.Interfaces;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MISA.CukCuk.DataLayer.DbContext
{
    public class DapperDbContext<T> : IDbContext<T> where T : class
    {
        /// <summary>
        /// Chuỗi kết nối liên kết CSDL
        /// </summary>
        private string _connectionString = "Host = 47.241.69.179;" +
                "Port = 3306;" +
                "Database = MS1_12_LHPhong_CukCuk;" +
                "User Id = dev;" +
                "Password = 12345678;";

        /// <summary>
        /// Biến DB connect
        /// </summary>
        private readonly IDbConnection _dbConnection;

        public DapperDbContext()
        {
            _dbConnection = new MySqlConnection(_connectionString);
        }

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
    }
}
