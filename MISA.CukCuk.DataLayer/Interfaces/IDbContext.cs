using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.DataLayer.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDbContext<T> where T : class
    {
        /// <summary>
        /// Hàm thực thi store procedure (SELECT) trả về danh sách các bản ghi
        /// </summary>
        /// <param name="procedureName">Tên store</param>
        /// <param name="parameters">Tham số truyền vào - mặc định là null</param>
        /// <returns>List object lấy được trong csdl</returns>
        /// created by lhphong 20.02.2021
        IEnumerable<T> QueryStoreProcedure(string procedureName, DynamicParameters parameters = null);

        /// <summary>
        /// Hàm thực thi store procedure (SELECT) trả về danh sách các bản ghi
        /// </summary>
        /// <param name="procedureName">Tên store</param>
        /// <param name="parameters">Tham số truyền vào - mặc định là null</param>
        /// <returns>List object lấy được trong csdl</returns>
        /// created by lhphong 20.02.2021
        T QueryFirstStoreProcedure(string procedureName, DynamicParameters parameters = null);

        /// <summary>
        /// Hàm thực thi store procedure (SELECT) trả về một bản ghi
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        int ExcuteStoreProcedure(string procedureName, DynamicParameters parameters = null);

        IEnumerable<T> QuerySQLString(string queryString);

        T QueryFirstSQLString(string queryString);

        int ExcuteSQLString(string queryString);
    }
}
