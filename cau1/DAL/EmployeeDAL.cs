using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cau1.DAO;

namespace cau1.DAL
{
    class EmployeeDAL : DBConnection
    {
        public EmployeeDAL() : base()
        {

        }
        public List<EmployeeDAO> ReadEmployee()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Employee_2119110266", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<EmployeeDAO> lstEmp = new List<EmployeeDAO>();
            DepartmentDAL dep = new DepartmentDAL();
            while (reader.Read())
            {
                EmployeeDAO emp = new EmployeeDAO();
                emp.Ma = reader["Ma"].ToString();
                emp.HoTen = reader["HoTen"].ToString();
                emp.ChucVu = dep.ReadDepartment(reader["MaCV"].ToString());
                emp.NoiSinh = reader["NoiSinh"].ToString();
                emp.NgaySinh = reader["NgaySinh"].ToString();
                emp.GioiTinh = int.Parse(reader["GioiTinh"].ToString());
                lstEmp.Add(emp);
            }
            conn.Close();
            return lstEmp;
        }
        public void DeleteEmployee(EmployeeDAO emp)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from Employee_2119110266 where Ma=@Ma", conn);
            cmd.Parameters.Add(new SqlParameter("@Ma", emp.Ma));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void NewEmployee(EmployeeDAO emp)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(
                "insert into Employee_2119110266(Ma,HoTen,ChucVu,NoiSinh,NgaySinh,GioiTinh) values(@Ma,@HoTen,@MaCV,@NoiSinh,@NgaySinh,@GioiTinh)", conn);
            cmd.Parameters.Add(new SqlParameter("@Ma", emp.Ma));
            cmd.Parameters.Add(new SqlParameter("@HoTen", emp.HoTen));
            cmd.Parameters.Add(new SqlParameter("@MaCV", emp.ChucVu.MaChucVu));
            cmd.Parameters.Add(new SqlParameter("@NoiSinh", emp.NoiSinh));
            cmd.Parameters.Add(new SqlParameter("@NgaySinh", emp.NgaySinh));
            cmd.Parameters.Add(new SqlParameter("@GioiTinh", emp.GioiTinh));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void EditEmployee(EmployeeDAO emp)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(
                "update Employee_2119110266 set HoTen = @HoTen, Ma = @Ma," +
                "ChucVu=@MaCV, NoiSinh=@NoiSinh," +
                "NgaySinh=@NgaySinh, GioiTinh=@GioiTinh where @MaCV = ChucVu", conn);
            cmd.Parameters.Add(new SqlParameter("@Ma", emp.Ma));
            cmd.Parameters.Add(new SqlParameter("@HoTen", emp.HoTen));
            cmd.Parameters.Add(new SqlParameter("@MaCV", emp.ChucVu.MaChucVu));
            cmd.Parameters.Add(new SqlParameter("@NoiSinh", emp.NoiSinh));
            cmd.Parameters.Add(new SqlParameter("@NgaySinh", emp.NgaySinh));
            cmd.Parameters.Add(new SqlParameter("@GioiTinh", emp.GioiTinh));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}