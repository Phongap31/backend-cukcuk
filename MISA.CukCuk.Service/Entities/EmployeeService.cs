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

        public EmployeeService(IBaseDL<Employee> baseDL): base(baseDL)
        {

        }

        public override ServiceResult CreateEntity(Employee employee)
        {
            var errorMsg = new ErrorMsg();
            var serviceResult = new ServiceResult();

            var employeeExistsCode = _baseDL.GetByFieldName("EmployeeCode", employee.EmployeeCode);
            
            //Check trùng mã nhân viên
            if (employeeExistsCode != null && employeeExistsCode.Any())
            {
                errorMsg.UserMsg = "Có lỗi xảy ra, vui lòng liên hệ Misa giải quyết";
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }

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
                    errorMsg.UserMsg = "Mã nhân viên không được sửa đổi!";
                    serviceResult.Success = false;
                    serviceResult.Data = errorMsg;
                    return serviceResult;
                }
            }
            else
            {
                errorMsg.UserMsg = "Không tìm thấy thông tin nhân viên cần sửa!";
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
                errorMsg.UserMsg = "Không tìm thấy thông tin nhân viên cần xóa!";
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }
            return base.DeleteEntity(employeID);
        }

    }
}
