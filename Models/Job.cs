using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobApi.Models
{
    public class Job
    {
        /// <summary>
        /// 主キー
        /// </summary>
        public int JobId { get; set; }

        /// <summary>
        /// 従業員名
        /// </summary>
        [Column(TypeName = "character varying(30)")]
        public string EmployeeName { get; set; }

        /// <summary>
        /// 従業員部署
        /// </summary>
        [Column(TypeName = "character varying(30)")]
        public string EmployeeDepartment { get; set; }

        /// <summary>
        /// 業務内容
        /// </summary>
        [Column(TypeName = "character varying(100)")]
        public string JobContent { get; set; }

        /// <summary>
        /// 納期
        /// </summary>
        [Column(TypeName = "character varying(30)")]
        public string DueDate { get; set; }

        /// <summary>
        /// 状況
        /// </summary>
        [Column(TypeName = "character varying(30)")]
        public string Status { get; set; }

    }
}
