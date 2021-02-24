using MISA.CukCuk.Common.Enums;
using MISA.CukCuk.Common.Models;
using MISA.CukCuk.DataLayer.Interfaces;
using MISA.CukCuk.Service.Base;
using MISA.CukCuk.Service.Interfaces;
using System;
using System.Collections;
using System.Linq;

namespace MISA.CukCuk.Service.Entities
{
    public class EmployeeService: BaseService<Employee>, IEmployeeService
    {
        /// <summary>
        /// Lớp nghiệp vụ của nhân viên 
        /// </summary>
        /// <param name="baseDL"></param>
        /// created by lhphong 20.02.2021
        public EmployeeService(IBaseDL<Employee> baseDL): base(baseDL)
        {

        }

        #region Method
        public override ServiceResult CreateEntity(Employee employee)
        {
            var errorMsg = new ErrorMsg();
            var serviceResult = new ServiceResult();

            var employeeExistsCode = _baseDL.GetByFieldName("EmployeeCode", employee.EmployeeCode);
            
            //Check trùng mã nhân viên
            if (employeeExistsCode != null && employeeExistsCode.Any())
            {
                errorMsg.UserMsg = MISA.CukCuk.Common.Properties.Resources.errorDuplicateEmployeeCode;
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }

            var identityExitsCode = _baseDL.GetByFieldName("IdentityCode", employee.IdentityCode);
            //Check trùng số CMND
            if (identityExitsCode != null && identityExitsCode.Any())
            {
                errorMsg.UserMsg = MISA.CukCuk.Common.Properties.Resources.errorDublicateIdentityCode;
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }

            //tạo mới ID cho nhân viên
            employee.EmployeeID = Guid.NewGuid();

            return base.CreateEntity(employee);
        }

        public override ServiceResult EditEntity(Guid employeID, Employee entity)
        {
            var errorMsg = new ErrorMsg();
            var serviceResult = new ServiceResult();

            var employee = _baseDL.GetById(employeID);

            //Kiểm tra ID nhân viên có tồn tại hay không
            if (employee !=null)
            {
                //Kiểm tra mã nhân viên (không được sửa đổi)
                if(employee.EmployeeCode == entity.EmployeeCode)
                {
                    return base.EditEntity(employeID, entity);
                }
                else
                {
                    errorMsg.UserMsg = Common.Properties.Resources.errorEmployeeCodeFixed;
                    serviceResult.Success = false;
                    serviceResult.Data = errorMsg;
                    return serviceResult;
                }
            }
            else
            {
                errorMsg.UserMsg = Common.Properties.Resources.errorEmployeeNotFound;
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }
        }

        public override ServiceResult DeleteEntity(Guid employeID)
        {
            var errorMsg = new ErrorMsg();
            var serviceResult = new ServiceResult();

            var employee = _baseDL.GetById(employeID);
            //Kiểm tra ID nhân viên có tồn tại hay không
            if (employee == null)
            {
                errorMsg.UserMsg = Common.Properties.Resources.errorEmployeeNotFound;
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }
            return base.DeleteEntity(employeID);
        }
        #endregion
    }
}
