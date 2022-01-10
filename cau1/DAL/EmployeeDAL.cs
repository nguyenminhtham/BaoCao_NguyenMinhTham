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
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "spSelectEmployee_2119110266";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            List<EmployeeDAO> lstEmployee_2119110266 = new List<EmployeeDAO>();
            DepartmentDAL donvi = new DepartmentDAL();
            while (reader.Read())
            {
                EmployeeDAO Employee_2119110266 = new EmployeeDAO();
                Employee_2119110266.Ma = reader["Ma"].ToString();
                Employee_2119110266.HoTen = reader["HoTen"].ToString();
                Employee_2119110266.MaCV = donvi.ReadDepartment(reader["MaCV"].ToString());
                Employee_2119110266.NoiSinh = reader["NoiSinh"].ToString();
                Employee_2119110266.NgaySinh = reader["NgaySinh"].ToString();
                Employee_2119110266.GioiTinh = int.Parse(reader["GioiTinh"].ToString());
                lstEmployee_2119110266.Add(Employee_2119110266);
            }
            conn.Close();
            return lstEmployee_2119110266;
        }

        public void DeleteEmployee(EmployeeDAO emp)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();

            try
            {
                //khỏi tạo instance của class SqlCommand
                SqlCommand cmd = new SqlCommand();
                //sử dụng thuộc tính CommandText để chỉ định tên Proc
                cmd.CommandText = "spDeleteEmployee";
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

                Console.WriteLine("Xoa hoc sinh thanh cong !!!");
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

        }
        public void NewEmployee(EmployeeDAO emp)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            try
            {
                //khỏi tạo instance của class SqlCommand
                SqlCommand cmd = new SqlCommand();
                //sử dụng thuộc tính CommandText để chỉ định tên Proc
                cmd.CommandText = "spInsertEmployee";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                //khai báo các thông tin của tham số truyền vào
                cmd.Parameters.Add("@Ma", SqlDbType.NVarChar).Value = emp.Ma;
                cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = emp.HoTen;
                cmd.Parameters.Add("@MaCV", SqlDbType.NVarChar).Value = emp.MaCV;
                cmd.Parameters.Add("@NoiSinh", SqlDbType.NVarChar).Value = emp.NoiSinh;
                cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = emp.NgaySinh;
                cmd.Parameters.Add("@GioiTinh", SqlDbType.Int).Value = emp.GioiTinh;
                //mở chuỗi kết nối
                conn.Open();
                //sử dụng ExecuteNonQuery để thực thi
                cmd.ExecuteNonQuery();
                //đóng chuỗi kết nối.
                conn.Close();
                Console.WriteLine("Them thanh cong !!!");
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
        }
        public void EditEmployee(EmployeeDAO emp)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            try
            {
                //khỏi tạo instance của class SqlCommand
                SqlCommand cmd = new SqlCommand();
                //sử dụng thuộc tính CommandText để chỉ định tên Proc
                cmd.CommandText = " spEditEmployee";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                //khai báo các thông tin của tham số truyền vào
                cmd.Parameters.Add("@Ma", SqlDbType.NVarChar).Value = emp.Ma;
                cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = emp.HoTen;
                cmd.Parameters.Add("@MaCV", SqlDbType.NVarChar).Value = emp.MaCV;
                cmd.Parameters.Add("@NoiSinh", SqlDbType.NVarChar).Value = emp.NoiSinh;
                cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = emp.NgaySinh;
                cmd.Parameters.Add("@GioiTinh", SqlDbType.Int).Value = emp.GioiTinh;
                //mở chuỗi kết nối
                conn.Open();
                //sử dụng ExecuteNonQuery để thực thi
                cmd.ExecuteNonQuery();
                //đóng chuỗi kết nối.
                conn.Close();

                Console.WriteLine("Sua thanh cong !!!");
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
        }
    }
}