using Dapper;
using MISA.CukCuk.Common.Enums;
using MISA.CukCuk.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.DataLayer.Base
{
    /// <summary>
    /// Lớp dùng chung DL
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// created by lhphong  20.02.2021
    public class BaseDL<T> : IBaseDL<T> where T : class
    {
        #region Constructor
        private readonly IDbContext<T> _dBContext;

        //Hàm khởi tạo
        public BaseDL(IDbContext<T> dBContext)
        {
            _dBContext = dBContext;
        }
        #endregion

        #region Method
        public int CreateEntity(T entity)
        {
            //Khai báo biến chứa đối tượng cần tạo
            var parameter = new DynamicParameters(entity);

            //Lấy tên store
            var procName = PreProcName.ProcInsert + typeof(T).Name;

            //Biến kết quả (số lượng bản ghi thay đổi)
            var result = _dBContext.ExcuteStoreProcedure(procName, parameter);

            return result;
        }

        public int DeleteEntity(Guid id)
        {
            //Sql string lấy bản ghi theo ID
            var sqlString = $"DELETE FROM {typeof(T).Name} WHERE {typeof(T).Name}ID = '{id}'";

            //Biến kết quả (số lượng bản ghi thay đổi)
            var result = _dBContext.ExcuteSQLString(sqlString);

            return result;
        }

        public int EditEntity(T entity)
        {
            //Khai báo biến chứa đối tượn
            var parameter = new DynamicParameters(entity);

            //Lấy tên store
            var procName = PreProcName.ProcUpdate + typeof(T).Name;

            //Kết quả trả về (số lượng bản ghi thay đổi)
            var result = _dBContext.ExcuteStoreProcedure(procName, parameter);

            return result;
        }

        public IEnumerable<T> GetAll()
        {
            // lấy tên store
            var procName = PreProcName.ProcGetAll + typeof(T).Name;

            // Dữ liệu trả về
            var entities = _dBContext.QueryStoreProcedure(procName);

            return entities;
        }


        public IEnumerable<T> GetByFieldName(string fieldName, string value)
        {
            //sql string (SELECT) lấy dữ liệu theo tên trường
            var sqlString = $"SELECT * FROM {typeof(T).Name} WHERE {fieldName} = '{value}'";

            //Dữ liệu trả về
            var entities = _dBContext.QuerySQLString(sqlString);
            return entities;
        }

        public T GetById(Guid id)
        {
            //sql string (SELECT) lấy dữ liệu theo ID
            var sqlString = $"SELECT * FROM {typeof(T).Name} WHERE {typeof(T).Name}ID = '{id.ToString()}'";

            //Biến kết quả nhận dữ liệu
            var entities = _dBContext.QueryFirstSQLString(sqlString);
            return entities;
        }
        #endregion
    }
}
