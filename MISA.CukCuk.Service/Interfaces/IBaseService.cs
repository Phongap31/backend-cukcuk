using MISA.CukCuk.Common.Enums;
using System;
using System.Collections.Generic;

namespace MISA.CukCuk.Service.Interfaces
{
    public interface IBaseService<T> where T: class
    {
        /// <summary>
        /// Service lấy ra danh sách các bản ghi có trong CSDL
        /// </summary>
        /// <returns></returns>
        ServiceResult GetAll();

        ServiceResult GetById(Guid id);

        ServiceResult CreateEntity(T entity);

        ServiceResult EditEntity(Guid id, T entity);

        ServiceResult DeleteEntity(Guid id);

        ServiceResult GetByFieldName(string fieldName, string value);
    }
}
