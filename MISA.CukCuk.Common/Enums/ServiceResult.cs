using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Common.Enums
{
    public class ServiceResult
    {
        public ServiceResult()
        {
            Success = true;
        }
        public bool Success { get; set; }
        public object Data { get; set; }
        public string MisaCode { get; set; }
    }
}
