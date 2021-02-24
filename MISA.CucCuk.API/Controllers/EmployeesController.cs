using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Common.Models;
using MISA.CukCuk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        #region Constructor
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        #endregion

        #region Api
        // GET: api/v1/<EmployeesController>
        /// <summary>
        /// Lấy tất cả thông tin của nhân viên
        /// </summary>
        /// <returns>Danh sách nhân viên</returns>
        /// created by: lhphong 21.02.2021
        [HttpGet]
        public IActionResult Get()
        {
            var res = _employeeService.GetAll();

            return StatusCode(200, res.Data);
        }

        // GET api/<EmployeesController>/5
        /// <summary>
        /// Lấy thông tin của nhân viên theo ID
        /// </summary>
        /// <returns>Nhân viên theo ID</returns>
        /// created by: lhphong 21.02.2021
        [HttpGet("{employeeID}")]
        public IActionResult Get([FromRoute] Guid employeeID)
        {
            var res = _employeeService.GetById(employeeID);

            return StatusCode(200, res.Data);
        }

        // POST api/<EmployeesController>
        /// <summary>
        /// Thêm mới nhân viên
        /// </summary>
        /// <param name="employee">nhân viên cần thêm mới</param>
        /// <returns>response tương ứng</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            var res = _employeeService.CreateEntity(employee);

            if (res.Success)
            {
                return StatusCode(201, res.Data);
            }
            else
            {
                return StatusCode(400, res.Data);
            }
        }

        // PUT api/<EmployeesController>/5
        /// <summary>
        /// Sửa thông tin nhân viên theo ID
        /// </summary>
        /// <param name="employeeID">ID nhân viên</param>
        /// <param name="employee">Nhân viên cần sửa</param>
        /// <returns>200 - thành công, 400 - không thành công</returns>
        /// created by lhphong 21.20.2021
        [HttpPut("{employeeID}")]
        public IActionResult Put([FromRoute] Guid employeeID, [FromBody] Employee employee)
        {
            var res = _employeeService.EditEntity(employeeID, employee);

            if (res.Success)
            {
                return StatusCode(200, res.Data);
            }
            else
            {
                return StatusCode(400, res.Data);
            }
        }

        // DELETE api/<EmployeesController>/5
        /// <summary>
        /// Xóa nhân viên theo ID
        /// </summary>
        /// <param name="employeeID">ID nhân viên</param>
        /// <returns>200 - thành công, 400 - không thành công</returns>
        /// created by lhphong 21.02.2021
        [HttpDelete("{employeeID}")]
        public IActionResult Delete([FromRoute]Guid employeeID)
        {
            var res = _employeeService.DeleteEntity(employeeID);
            if (res.Success)
            {
                return StatusCode(200, res.Data);
            }
            else
            {
                return StatusCode(400, res.Data);
            }
        }
        #endregion
    }
}
