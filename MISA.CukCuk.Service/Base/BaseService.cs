using MISA.CukCuk.Common.Enums;
using MISA.CukCuk.DataLayer.Interfaces;
using MISA.CukCuk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISA.CukCuk.Service.Base
{
    /// <summary>
    /// Class Service dùng chung
    /// </summary>
    /// <typeparam name="T">Kiểu T(dùng chung)</typeparam>
    /// created by lhphong 20.02.2021
    public class BaseService<T> : IBaseService<T> where T : class
    {
        protected readonly IBaseDL<T> _baseDL;

        #region Constructor
        //Hàm khởi tạo
        public BaseService(IBaseDL<T> baseDL)
        {
            _baseDL = baseDL;
        }
        #endregion

        #region Method
        public virtual ServiceResult CreateEntity(T entity)
        {
            var serviceResult = new ServiceResult();
            var errorMsg = new ErrorMsg();

            var response = _baseDL.CreateEntity(entity);

            // thêm mới thất bại
            if (response <= 0)
            {
                errorMsg.UserMsg = MISA.CukCuk.Common.Properties.Resources.errorAddEmployee;
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }

            //thành công
            serviceResult.Data = response;

            return serviceResult;
        }

        public virtual ServiceResult DeleteEntity(Guid id)
        {
            var serviceResult = new ServiceResult();
            var errorMsg = new ErrorMsg();

            //Biến nhận kết quả trả về
            var response = _baseDL.DeleteEntity(id);

            // xóa thất bại
            if (response <= 0)
            {
                errorMsg.UserMsg = MISA.CukCuk.Common.Properties.Resources.errorDeleteEmployee;
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

            //Biến nhận kết quả trả về
            var response = _baseDL.EditEntity(entity);

            // sửa thất bại
            if (response <= 0)
            {
                errorMsg.UserMsg = MISA.CukCuk.Common.Properties.Resources.errorEditEmployee;
                serviceResult.Data = errorMsg;
                serviceResult.Success = false;
                return serviceResult;
            }

            // Sửa thành công
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
        #endregion
    }
}
