using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.DataLayer.Interfaces
{
    public interface IDbContext<T> where T : class
    {
        #region Method
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
        /// Hàm thực thi store procedure trả về số lượng bản ghi thay đổi trong csdl
        /// </summary>
        /// <param name="procedureName">tên store</param>
        /// <param name="parameters">tham số truyền vào - mặc định là null</param>
        /// <returns>số lượng bản ghi thay đổi</returns>
        /// created by lhphong 21.02.2021
        int ExcuteStoreProcedure(string procedureName, DynamicParameters parameters = null);

        /// <summary>
        /// Hàm thực thi Sql string trả về danh sách các bản ghi
        /// </summary>
        /// <param name="queryString">sql string</param>
        /// <returns>Danh sách bản ghi trong csdl</returns>
        ///created by lhphong 21.02.2021
        IEnumerable<T> QuerySQLString(string queryString);

        /// <summary>
        /// Hàm thực thi sql string trả về 1 bản ghi
        /// </summary>
        /// <param name="queryString">sql string</param>
        /// <returns>bản ghi lấy được trong csdl</returns>
        /// created by lhphong 21.02.2021
        T QueryFirstSQLString(string queryString);

        /// <summary>
        /// Hàm thực thi sql string trả về số lượng bản ghi thay đôi
        /// </summary>
        /// <param name="queryString">sql string</param>
        /// <returns>số lượng bản ghi thay đổi trong csdl</returns>
        /// created by lhphong 21.02.2021
        int ExcuteSQLString(string queryString);

        #endregion
    }
}
