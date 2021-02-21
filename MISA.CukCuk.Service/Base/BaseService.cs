using MISA.CukCuk.Common.Enums;
using MISA.CukCuk.DataLayer.Interfaces;
using MISA.CukCuk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISA.CukCuk.Service.Base
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        protected readonly IBaseDL<T> _baseDL;

        public BaseService(IBaseDL<T> baseDL)
        {
            _baseDL = baseDL;
        }

        public virtual ServiceResult CreateEntity(T entity)
        {
            var serviceResult = new ServiceResult();
            var errorMsg = new ErrorMsg();

            var response = _baseDL.CreateEntity(entity);

            // them moi that bai
            if (response <= 0)
            {
                errorMsg.UserMsg = "Thêm bản ghi không thành công! Vùi lòng liên hệ Misa để giải quyết";
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }

            serviceResult.Data = response;

            return serviceResult;
        }

        public virtual ServiceResult DeleteEntity(Guid id)
        {
            var serviceResult = new ServiceResult();
            var errorMsg = new ErrorMsg();

            var response = _baseDL.DeleteEntity(id);

            // xóa thất bại
            if (response <= 0)
            {
                errorMsg.UserMsg = "Xóa bản ghi không thành công! Vùi lòng liên hệ Misa để giải quyết";
                serviceResult.Data = errorMsg;
                serviceResult.Success = false;
                return serviceResult;
            }

            serviceResult.Data = response;

            return serviceResult;
        }

        public virtual ServiceResult EditEntity(Guid id, T entity)
        {
            var serviceResult = new ServiceResult();
            var errorMsg = new ErrorMsg();

            var response = _baseDL.EditEntity(entity);

            // sửa thất bại
            if (response <= 0)
            {
                errorMsg.UserMsg = "Sửa bản ghi không thành công! Vùi lòng liên hệ Misa để giải quyết";
                serviceResult.Data = errorMsg;
                serviceResult.Success = false;
                return serviceResult;
            }

            serviceResult.Data = response;

            return serviceResult;
        }

        public virtual ServiceResult GetAll()
        {
            var serviceResult = new ServiceResult();
            var entities = _baseDL.GetAll();

            serviceResult.Data = entities;

            return serviceResult;
        }

        public virtual ServiceResult GetByFieldName(string fieldName, string value)
        {
            throw new NotImplementedException();
        }

        public virtual ServiceResult GetById(Guid id)
        {
            var serviceResult = new ServiceResult();
            var entities = _baseDL.GetById(id);

            serviceResult.Data = entities;

            return serviceResult;
        }

    }
}
