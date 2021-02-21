using Dapper;
using MISA.CukCuk.Common.Enums;
using MISA.CukCuk.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.DataLayer.Base
{
    public class BaseDL<T> : IBaseDL<T> where T : class
    {
        private readonly IDbContext<T> _dBContext;

        public BaseDL(IDbContext<T> dBContext)
        {
            _dBContext = dBContext;
        }

        public int CreateEntity(T entity)
        {
            var parameter = new DynamicParameters(entity);
            var procName = PreProcName.ProcInsert + typeof(T).Name;

            var result = _dBContext.ExcuteStoreProcedure(procName, parameter);

            return result;
        }

        public int DeleteEntity(Guid id)
        {
            var sqlString = $"DELETE FROM {typeof(T).Name} WHERE {typeof(T).Name}ID = '{id}'";

            var result = _dBContext.ExcuteSQLString(sqlString);

            return result;
        }

        public int EditEntity(T entity)
        {
            var parameter = new DynamicParameters(entity);
            var procName = PreProcName.ProcUpdate + typeof(T).Name;

            var result = _dBContext.ExcuteStoreProcedure(procName, parameter);

            return result;
        }

        public IEnumerable<T> GetAll()
        {
            // lấy tên store
            var procName = PreProcName.ProcGetAll + typeof(T).Name;

            var entities = _dBContext.QueryStoreProcedure(procName);

            return entities;
        }

        public IEnumerable<T> GetByFieldName(string fieldName, string value)
        {
            var sqlString = $"SELECT * FROM {typeof(T).Name} WHERE {fieldName} = '{value}'";

            var entities = _dBContext.QuerySQLString(sqlString);
            return entities;
        }

        public T GetById(Guid id)
        {
            var sqlString = $"SELECT * FROM {typeof(T).Name} WHERE {typeof(T).Name}ID = '{id.ToString()}'";

            var entities = _dBContext.QueryFirstSQLString(sqlString);
            return entities;
        }
    }
}
