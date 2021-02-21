using MISA.CukCuk.Common.Models;
using MISA.CukCuk.DataLayer.Base;
using MISA.CukCuk.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.DataLayer.Entities
{
    public class EmployeeDL: BaseDL<Employee>, IEmployeeDL
    {
        public EmployeeDL(IDbContext<Employee> dBContext) : base(dBContext)
        {
        }
    }
}
