using JobApi.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace JobApi.Services
{
    public class JobServices
    {
        private DBContext _context;

        IConfiguration _configuration;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="context">データベースオブジェクト</param>
        /// <param name="configuration">ｻｰﾊﾞｰ接続オブジェクト</param>
        public JobServices(DBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        /// <summary>
        /// 業務データを作成する
        /// </summary>
        /// <param name="job">業務Model</param>
        public void CreateJob(Job job)
        {
            var _job = new Job()
            {
                EmployeeName = job.EmployeeName,
                EmployeeDepartment = job.EmployeeDepartment,
                JobContent = job.JobContent,
                DueDate = job.DueDate,
                Status = job.Status
            };
            _context.Jobs.Add(_job);
            _context.SaveChanges();
        }


        public List<Job> JobList = new List<Job>();

        /// <summary>
        ///　従業員の全業務を取得する
        /// </summary>
        /// <param name="employee">従業員名</param>
        /// <returns></returns>
        public List<Job> ReadAllEmployeeJobs(string employee)
        {
            string sql = "SELECT \"JobId\", \"EmployeeName\", \"EmployeeDepartment\", \"JobContent\", \"DueDate\", \"Status\" FROM \"Jobs\"";
            sql += " WHERE \"EmployeeName\" = '"+employee+"' ";
            DataBaseServices db = new DataBaseServices(_configuration);
            db.Open(sql);
            if (db.data.HasRows)
            {
                while (db.data.Read())
                {

                    JobList.Add(new Job
                     {
                         JobId = Int32.Parse(db.data[0].ToString()),
                         EmployeeName = db.data[1].ToString(),
                         EmployeeDepartment = db.data[2].ToString(),
                         JobContent = db.data[3].ToString(),
                         DueDate = db.data[4].ToString(),
                         Status = db.data[5].ToString()
                     });
                }
            }
            db.Close();

            return JobList;
        }

        /// <summary>
        /// 各従業員の総合業務件数を取得する
        /// </summary>
        /// <returns></returns>
        public List<Job> ReadTotalJobsOfEmployee()
        {
            string sql = "SELECT \"EmployeeName\",\"EmployeeDepartment\", Count(\"JobContent\") FROM \"Jobs\"";
            sql += " GROUP BY \"EmployeeName\",\"EmployeeDepartment\" ";
            sql += " ORDER BY \"EmployeeName\",\"EmployeeDepartment\" ";
            DataBaseServices db = new DataBaseServices(_configuration);
            db.Open(sql);
            if (db.data.HasRows)
            {
                while (db.data.Read())
                {

                    JobList.Add(new Job
                    {
                        EmployeeName = db.data[0].ToString(),
                        EmployeeDepartment = db.data[1].ToString(),
                        JobContent = db.data[2].ToString()
                    });
                }
            }
            db.Close();

            return JobList;
        }

        /// <summary>
        /// 業務データを更新する
        /// </summary>
        /// <param name="job">業務Model</param>
        /// <returns></returns>
        public Job UpdateJobById(Job job)
        {
            var _job = _context.Jobs.FirstOrDefault(n => n.JobId == job.JobId);
            if (_job != null)
            {
                _job.EmployeeName = job.EmployeeName;
                _job.EmployeeDepartment = job.EmployeeDepartment;
                _job.JobContent = job.JobContent;
                _job.DueDate = job.DueDate;
                _job.Status = job.Status;

                _context.SaveChanges();
            }
            return _job;
        }

        /// <summary>
        /// 業務データを削除する
        /// </summary>
        /// <param name="jobId">業務データID</param>
        public void DeleteJobById(int jobId)
        {
            var _job = _context.Jobs.FirstOrDefault(n => n.JobId == jobId);
            if (_job != null)
            {
                _context.Jobs.Remove(_job);
                _context.SaveChanges();
            }
        }
    }
}
