using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Common.Enums
{
    /// <summary>
    /// Lớp dùng cho thống báo lỗi
    /// </summary>
    /// createby lhphong 20.02.2021
    public class ErrorMsg
    {
        /// <summary>
        /// Lỗi dành cho dev
        /// </summary>
        public string DevMsg { get; set; }

        /// <summary>
        /// Lỗi dành cho user
        /// </summary>
        public string UserMsg { get; set; }

        /// <summary>
        /// Mã lỗi
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Thông tin thêm
        /// </summary>
        public string MoreInfo { get; set; }

        /// <summary>
        /// Id lỗi
        /// </summary>
        public string TraceId { get; set; }
    }
}
