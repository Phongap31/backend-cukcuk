using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Common.Enums
{
    /// <summary>
    /// Lớp kết quả trả về service
    /// </summary>
    /// created by lhphong 20.02.2021
    public class ServiceResult
    {
        #region constructor
        public ServiceResult()
        {
            Success = true;
        }
        #endregion

        #region method
        #endregion

        #region Properties

        /// <summary>
        /// Trả về thành công (true - thành công, flase - không thành công)
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// Trả về dữ liệu
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Mã trả về
        /// </summary>
        public string MisaCode { get; set; }
        #endregion
    }
}
