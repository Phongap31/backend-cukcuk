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


        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Gender { get; set; }
        public string IdentityCode { get; set; }
        public string IdentityPlace { get; set; }
        public DateTime? IdentityDate { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int RuleCode { get; set; }
        public int StatusWork { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        #endregion
    }
}
