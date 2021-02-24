using System;

namespace MISA.CukCuk.Common.Models
{
    /// <summary>
    /// Lớp nhân viên
    /// </summary>
    /// created by lhphong 20.02.2021
    public class Employee
    {
        #region Properties
        /// <summary>
        /// ID nhân viên (khóa chính)
        /// </summary>
        public Guid EmployeeID { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Họ và tên nhân viên
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// email nhân viên
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// Số CMND
        /// </summary>
        public string IdentityCode { get; set; }

        /// <summary>
        /// Nơi cấp CMND
        /// </summary>
        public string IdentityPlace { get; set; }

        /// <summary>
        /// Ngày cấp CMND
        /// </summary>
        public DateTime? IdentityDate { get; set; }

        /// <summary>
        /// Ngày sinh nhân viên
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Phân quyền
        /// </summary>
        public int RuleCode { get; set; }

        /// <summary>
        /// Tình trạng làm việc
        /// </summary>
        public int StatusWork { get; set; }

        /// <summary>
        /// Mật khẩu
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Xác nhận mật khẩu
        /// </summary>
        public string ConfirmPassword { get; set; }

        #endregion
        #region other

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Ngày sửa đổi
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
        #endregion
    }
}
