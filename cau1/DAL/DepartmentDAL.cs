using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using cau1.DAO;

namespace cau1.DAL
{
    class DepartmentDAL : DBConnection
    {
        public List<DepartmentDAO> ReadDepartmentList()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Department_2119110266", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<DepartmentDAO> lstDonVi = new List<DepartmentDAO>();
            while (reader.Read())
            {
                DepartmentDAO donvi = new DepartmentDAO();
                donvi.MaChucVu = reader["Ma"].ToString();
                donvi.Ten = reader["HoTen"].ToString();
                lstDonVi.Add(donvi);
            }
            conn.Close();
            return lstDonVi;
        }

        public DepartmentDAO ReadDepartment(string id)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(
                "select * from Department_2119110266 where Ma = " + "'" + id + "'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DepartmentDAO donvi = new DepartmentDAO();
            if (reader.HasRows && reader.Read())
            {
                donvi.MaChucVu = reader["Ma"].ToString();
                donvi.Ten = reader["HoTen"].ToString();
            }
            conn.Close();
            return donvi;
        }
    }
}