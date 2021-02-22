using System;
using System.Collections.Generic;

namespace MISA.CukCuk.DataLayer.Interfaces
{
    public interface IBaseDL<T> where T: class
    {
        /// <summary>
        /// Thực thi lấy toàn bộ dữ liệu trong bảng CSDL
        /// </summary>
        /// <returns>tất cả dữ liệu trong bảng</returns>
        ///created by lhphong 21.02.2021
        IEnumerable<T> GetAll();

        /// <summary>
        /// Lấy dữ liệu trong bảng CSDL theo ID
        /// </summary>
        /// <param name="id">ID bản ghi</param>
        /// <returns>bản ghi cần lấy</returns>
        T GetById(Guid id);

        /// <summary>
        /// Thực thi thêm mới bản ghi vào CSDL 
        /// </summary>
        /// <param name="entity">bản ghi cần thêm mới</param>
        /// <returns>1</returns>
        /// created by lhphong 21.02.2021
        int CreateEntity(T entity);

        /// <summary>
        /// Thực thi sửa bản ghi trong CSDL
        /// </summary>
        /// <param name="entity">bản ghi cần sửa đổi</param>
        /// <returns>1</returns>
        /// created by lhphong 21.02.2021
        int EditEntity(T entity);

        /// <summary>
        /// Xóa bản ghi trong CSDL
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1</returns>
        /// created by lhphong 21.02.2021
        int DeleteEntity(Guid id);

        /// <summary>
        /// Thực thi lấy bản ghi theo tên thuộc tính và giá trị
        /// </summary>
        /// <param name="fieldName">tên thuộc tính</param>
        /// <param name="value">giá trị</param>
        /// <returns>bản ghi cần lấy</returns>
        ///created by lhphong 21.02.2021
        IEnumerable<T> GetByFieldName(string fieldName, string value);
    }
}
