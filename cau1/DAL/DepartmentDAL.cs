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
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "spSelectDepartment_2119110266";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            List<DepartmentDAO> lstDepartment_2119110266 = new List<DepartmentDAO>();
            while (reader.Read())
            {
                DepartmentDAO donvi = new DepartmentDAO();
                donvi.Ma = reader["Ma"].ToString();
                donvi.Department_2119110266 = reader["Department_2119110266"].ToString();
                lstDepartment_2119110266.Add(donvi);
            }
            conn.Close();
            return lstDepartment_2119110266;
        }

        public DepartmentDAO ReadDepartment(string id)
        {
            DepartmentDAO emp = new DepartmentDAO();
            SqlConnection conn = CreateConnection();
            conn.Open();

            try
            {
                //khỏi tạo instance của class SqlCommand
                SqlCommand cmd = new SqlCommand();
                //sử dụng thuộc tính CommandText để chỉ định tên Proc
                cmd.CommandText = "spGetDepartment_2119110266";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                //khai báo các thông tin của tham số truyền vào
                cmd.Parameters.Add("@Ma", SqlDbType.NVarChar).Value = emp.Ma;
                //mở chuỗi kết nối
                conn.Open();
                //sử dụng ExecuteNonQuery để thực thi
                cmd.ExecuteNonQuery();
                //đóng chuỗi kết nối.
                conn.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            // dóng chuỗi kết nối
            finally
            {
                conn.Close();
            }
            return emp;
        }
    }
}