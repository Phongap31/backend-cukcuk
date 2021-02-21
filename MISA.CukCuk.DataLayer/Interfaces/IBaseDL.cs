using System;
using System.Collections.Generic;

namespace MISA.CukCuk.DataLayer.Interfaces
{
    public interface IBaseDL<T> where T: class
    {
        IEnumerable<T> GetAll();

        T GetById(Guid id);

        int CreateEntity(T entity);

        int EditEntity(T entity);

        int DeleteEntity(Guid id);

        IEnumerable<T> GetByFieldName(string fieldName, string value);
    }
}
