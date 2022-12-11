using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobApi.Models;
using JobApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        public EmployeeServices _employeeservice;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="employeeservice">従業員Services</param>
        public EmployeeController(EmployeeServices employeeservice)
        {
            _employeeservice = employeeservice;
        }

        /// <summary>
        /// 従業員新規作成HTTPクエリ
        /// </summary>
        /// <param name="employee">従業員Model</param>
        /// <returns></returns>
        [HttpPost("create-employee")]
        public IActionResult CreateEmployee(Employee employee)
        {
            _employeeservice.CreateEmployee(employee);
            return Ok();
        }

        /// <summary>
        /// 全従業員データ取得するHTTPクエリ
        /// </summary>
        /// <returns>全従業員データ</returns>
        [HttpGet("read-all-employees")]
        public IActionResult ReadAllEmployees()
        {
            var allEmployees = _employeeservice.ReadAllEmployees();
            return Ok(allEmployees);
        }

        /// <summary>
        /// 対象従業員データを取得するHTTPクエリ
        /// </summary>
        /// <param name="name">従業員名</param>
        /// <returns></returns>
        [HttpGet("read-employee/{name}")]
        public IActionResult ReadEmployeeByName(string name)
        {
            var employee = _employeeservice.ReadEmployeeByName(name);
            return Ok(employee);
        }

        /// <summary>
        /// 対象従業員データを更新するHTTPクエリ
        /// </summary>
        /// <param name="employee">従業員Model</param>
        /// <returns></returns>
        [HttpPut("update-employee-by-id")]
        public IActionResult UpdateEmployeeById(Employee employee)
        {
            var updateEmployee = _employeeservice.UpdateEmployeeById(employee);
            return Ok(updateEmployee);
        }

        /// <summary>
        /// 対象従業員データを削除するHTTPクエリ
        /// </summary>
        /// <param name="id">対象従業員ID</param>
        /// <returns></returns>
        [HttpDelete("delete-employee-by-id/{id}")]
        public IActionResult DeleteEmployeeById(int id)
        {
            _employeeservice.DeleteEmployeeById(id);
            return Ok();
        }

    }
}