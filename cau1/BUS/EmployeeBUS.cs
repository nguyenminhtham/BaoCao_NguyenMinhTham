using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cau1.DAO;
using cau1.DAL;


namespace cau1.BUS
{
    class EmployeeBUS
    {
        EmployeeDAL dal = new EmployeeDAL();
        public List<EmployeeDAO> ReadEmployee()
        {
            List<EmployeeDAO> lstEmp = dal.ReadEmployee();
            return lstEmp;
        }
        public void NewEmployee(EmployeeDAO emp)
        {
            dal.NewEmployee(emp);
        }
        public void DeleteEmployee(EmployeeDAO emp)
        {
            dal.DeleteEmployee(emp);
        }
        public void EditEmployee(EmployeeDAO emp)
        {
            dal.EditEmployee(emp);
        }
    }
}
