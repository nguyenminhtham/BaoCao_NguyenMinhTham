using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace cau1.DAL
{
    class DBConnection
    {
        public DBConnection()
        {
        }
        public SqlConnection CreateConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source =ADMIN\MSSQLSERVER01; Initial Catalog = HR; User Id = sa; Password = 12345";
            return conn;
        }
    }
}
