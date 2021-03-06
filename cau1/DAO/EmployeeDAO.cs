using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cau1.DAO
{
    class EmployeeDAO
    {
        public string Ma { get; set; }
        public string HoTen { get; set; }
        public string NoiSinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public int GioiTinh { get; set; }
        public DepartmentDAO ChucVu { get; set; }
        public string TenChucVu
        {
            get { return ChucVu.Ten; }
        }

    }
}
