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
        /// <returns>danh sách các bản ghi</returns>
        /// created by lhphong 21.02.2021
        ServiceResult GetAll();

        /// <summary>
        /// Service lấy bản ghi theo ID
        /// </summary>
        /// <param name="id">ID bản ghi cần lấy</param>
        /// <returns>bản ghi theo ID</returns>
        /// created by lhphong 21.02.2021
        ServiceResult GetById(Guid id);

        /// <summary>
        /// Service thêm mới bản ghi vào CSDL
        /// </summary>
        /// <param name="entity">bản ghi cần thêm mới</param>
        /// <returns>thành công - không thành công</returns>
        /// created by lhphong 21.02.2021
        ServiceResult CreateEntity(T entity);

        /// <summary>
        /// Service sửa thông tin bản ghi lấy theo ID có trong CSDL
        /// </summary>
        /// <param name="id">ID bản ghi có trong CSDL</param>
        /// <param name="entity">Bản ghi cần sửa</param>
        /// <returns>thành công - không thành công</returns>
        /// created by lhphong 21.02.2021
        ServiceResult EditEntity(Guid id, T entity);

        /// <summary>
        /// Service xóa bản ghi theo ID có trong CSDL
        /// </summary>
        /// <param name="id">ID bản ghi cần xóa trong CSDL</param>
        /// <returns>thành công - không thành công</returns>
        /// created by lhphong 21.02.2021
        ServiceResult DeleteEntity(Guid id);

        /// <summary>
        /// Service Lấy bản ghi theo property name và value trong CSDL
        /// </summary>
        /// <param name="fieldName">tên thuộc tính</param>
        /// <param name="value">giá trị thuộc tính</param>
        /// <returns>Bản ghi có trong CSDL</returns>
        /// created by lhphong 21.02.2021
        ServiceResult GetByFieldName(string fieldName, string value);
    }
}
