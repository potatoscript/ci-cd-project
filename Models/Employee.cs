using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobApi.Models
{
    public class Employee
    {
        /// <summary>
        /// 主キー
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// 従業員名
        /// </summary>
        [Column(TypeName = "character varying(30)")]
        public string Name { get; set; }

        /// <summary>
        /// 従業員役
        /// </summary>
        [Column(TypeName = "character varying(30)")]
        public string Position { get; set; }

        /// <summary>
        /// 従業員部署
        /// </summary>
        [Column(TypeName = "character varying(30)")]
        public string Department { get; set; }

        /// <summary>
        /// 従業員メール
        /// </summary>
        [Column(TypeName = "character varying(30)")]
        public string Email { get; set; }

    }
}
