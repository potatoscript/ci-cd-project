using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobApi.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        /// <summary>
        /// 従業員テーブルを設定する（テーブル項目定義はEmployee Modelで取得する）
        /// </summary>
        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// 業務テーブルを設定する（テーブル項目定義はJobs Modelで取得する）
        /// </summary>
        public DbSet<Job> Jobs { get; set; }


    }
}
