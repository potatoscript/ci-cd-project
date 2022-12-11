using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobApi.Models;
using JobApi.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JobApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobController : ControllerBase
    {
        public JobServices _jobservice;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="jobservice">業務Services</param>
        public JobController(JobServices jobservice)
        {
            _jobservice = jobservice;
        }

        /// <summary>
        /// 新規業務データを作成するHTTPクエリ
        /// </summary>
        /// <param name="job">業務Model</param>
        /// <returns></returns>
        [HttpPost("create-job")]
        public IActionResult CreateJob(Job job)
        {
            _jobservice.CreateJob(job);
            return Ok();
        }

        /// <summary>
        /// 各従業員の業務データを取得するHTTPクエリ
        /// </summary>
        /// <param name="employee">従業員Model</param>
        /// <returns></returns>
        [HttpGet("read-all-employee-jobs/{employee}")]
        public IActionResult ReadAllJobs(string employee)
        {
            var allJobs = _jobservice.ReadAllEmployeeJobs(employee);

            return Ok(allJobs);
        }

        /// <summary>
        /// 業務総合件数を取得するHTTPクエリ
        /// </summary>
        /// <returns>業務総合件数纏めたデータ</returns>
        [HttpGet("read-total-jobs-employee")]
        public IActionResult ReadTotalJobsOfEmployee()
        {
            var allJobs = _jobservice.ReadTotalJobsOfEmployee();

            return Ok(allJobs);
        }

        /// <summary>
        /// 対象業務データを更新するHTTPクエリ
        /// </summary>
        /// <param name="job">業務Model</param>
        /// <returns></returns>
        [HttpPut("update-job-by-id")]
        public IActionResult UpdateJobById(Job job)
        {
            var updateJob = _jobservice.UpdateJobById(job);
            return Ok(updateJob);
        }

        /// <summary>
        /// 対象業務データを削除するHTTPクエリ
        /// </summary>
        /// <param name="id">対象業務ID</param>
        /// <returns></returns>
        [HttpDelete("delete-job-by-id/{id}")]
        public IActionResult DeleteJobById(int id)
        {
            _jobservice.DeleteJobById(id);
            return Ok();
        }
    }
}