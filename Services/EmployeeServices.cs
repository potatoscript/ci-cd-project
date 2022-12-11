using JobApi.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobApi.Services
{
    public class EmployeeServices
    {
        private DBContext _context;

        IConfiguration _configuration;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="context">データベースオブジェクト</param>
        /// <param name="configuration">ｻｰﾊﾞｰ接続オブジェクト</param>
        public EmployeeServices(DBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        /// <summary>
        /// 従業員マスターデータを作成する
        /// </summary>
        /// <param name="employee">従業員Model</param>
        public void CreateEmployee(Employee employee)
        {
            var _employee = new Employee()
            {
                Name = employee.Name,
                Department = employee.Department,
                Position = employee.Position,
                Email = employee.Email
            };
            _context.Employees.Add(_employee);
            _context.SaveChanges();
        }


        public List<Employee> EmployeeList = new List<Employee>();
        /// <summary>
        /// 全従業員のマスターデータを取得する
        /// </summary>
        /// <returns>EmployeeList</returns>
        public List<Employee> ReadAllEmployees()
        {
            string sql = "SELECT DISTINCT ON (\"Name\") \"Name\",\"EmployeeId\", \"Department\",\"Position\"  FROM \"Employees\"";
            sql += " ORDER BY \"Name\" ";
            DataBaseServices db = new DataBaseServices(_configuration);
            db.Open(sql);
            if (db.data.HasRows)
            {
                while (db.data.Read())
                {

                    EmployeeList.Add(new Employee
                    {
                        Name = db.data[0].ToString(),
                        EmployeeId = int.Parse(db.data[1].ToString()),
                        Department = db.data[2].ToString(),
                        Position = db.data[3].ToString()
                    });
                }
            }
            db.Close();

            return EmployeeList;
        }

        /// <summary>
        /// 対象従業員のマスターデータを取得する
        /// </summary>
        /// <param name="name">従業員名</param>
        /// <returns></returns>
        public List<Employee> ReadEmployeeByName(string name)
        {
            var _data = _context.Employees
                .Where(n => n.Name == name)
                .Distinct()
                .OrderBy(d => d)
                .ToList();

            return _data;
        }

        /// <summary>
        /// 対象従業員のマスターデータを更新する
        /// </summary>
        /// <param name="employee">従業員Model</param>
        /// <returns></returns>
        public Employee UpdateEmployeeById(Employee employee)
        {
            var _employee = _context.Employees.FirstOrDefault(n => n.EmployeeId == employee.EmployeeId);
            if (_employee != null)
            {
                _employee.Name = employee.Name;
                _employee.Department = employee.Department;
                _employee.Position = employee.Position;
                _employee.Email = employee.Email;

                _context.SaveChanges();
            }
            return _employee;
        }

        /// <summary>
        /// 対象従業員のマスターデータを削除する
        /// </summary>
        /// <param name="employeeId">従業員ID</param>
        public void DeleteEmployeeById(int employeeId)
        {
            var _employee = _context.Employees.FirstOrDefault(n => n.EmployeeId == employeeId);
            if (_employee != null)
            {
                _context.Employees.Remove(_employee);
                _context.SaveChanges();
            }
        }

    }
}
