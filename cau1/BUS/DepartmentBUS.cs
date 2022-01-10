using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cau1.DAL;
using cau1.DAO;

namespace cau1.BUS
{
    class DepartmentBUS
    {
        DepartmentDAL dal = new DepartmentDAL();
        public List<DepartmentDAO> ReadDepartmentList()
        {
            List<DepartmentDAO> lstDepartment_2119110266 = dal.ReadDepartmentList();
            return lstDepartment_2119110266;
        }
    }
}
