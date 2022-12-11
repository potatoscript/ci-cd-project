using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobApi.Services
{
    public class DataBaseServices
    {
        IConfiguration _configuration;

        public NpgsqlConnection conn;

        public NpgsqlDataReader data;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="configuration">ｻｰﾊﾞｰ接続オブジェクト</param>
        public DataBaseServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// NpgSqlデータベースに接続してクエリを行う
        /// </summary>
        /// <param name="sql">クエリコード</param>
        public void Open(string sql)
        {
            conn = new NpgsqlConnection(_configuration.GetConnectionString("DbContextConnection"));
            conn.Open();

            NpgsqlCommand query = new NpgsqlCommand(sql, conn);
            data = query.ExecuteReader();
        }

        public void Close()
        {
            conn.Close();
        }

    }

}
