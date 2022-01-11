using cau1.BUS;
using cau1.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace cau1
{
    public partial class Form1 : Form
    {
        DepartmentBUS cvBUS = new DepartmentBUS();
        EmployeeBUS empBUS = new EmployeeBUS();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<EmployeeDAO> lstEmp = empBUS.ReadEmployee();
            foreach (EmployeeDAO emp in lstEmp)
            {
                dvgNhanVien.Rows.Add(emp.Ma, emp.HoTen, emp.NoiSinh, emp.NgaySinh, emp.GioiTinh, emp.TenChucVu);

            }
            List<DepartmentDAO> lstDepartment_2119110266 = cvBUS.ReadDepartmentList();
            foreach (DepartmentDAO cv in lstDepartment_2119110266)
            {
                cbbCV.Items.Add(cv);
                cbbCV.DisplayMember = "Ten";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            EmployeeDAO emp = new EmployeeDAO();
            if (tbIdNV.Text.Equals("") || tbName.Text.Equals("") || tbNoiSinh.Text.Equals(""))
            {
                MessageBox.Show("Không đc bỏ trống", "Thông báo");
            }
            else
            {
                emp.Ma = tbIdNV.Text;
                emp.HoTen = tbName.Text;
                emp.NoiSinh = tbNoiSinh.Text;
                emp.ChucVu = (DepartmentDAO)cbbCV.SelectedItem;
                emp.NgaySinh = dtNgaySinh.Value;
                if (cbGioiTinh.Checked)
                {
                    emp.GioiTinh = 1;
                }
                else
                {
                    emp.GioiTinh = 0;
                }
                empBUS.NewEmployee(emp);
                dvgNhanVien.Rows.Add(emp.Ma, emp.HoTen, emp.NoiSinh, emp.NgaySinh, emp.GioiTinh, emp.TenChucVu);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            EmployeeDAO emp = new EmployeeDAO();
            if (tbIdNV.Text.Equals("") || tbName.Text.Equals("") || tbNoiSinh.Text.Equals(""))
            {
            }
            else
            {
                emp.Ma = tbIdNV.Text;
                emp.HoTen = tbName.Text;
                emp.NoiSinh = tbNoiSinh.Text;
                emp.ChucVu = (DepartmentDAO)cbbCV.SelectedItem;
                emp.NgaySinh = dtNgaySinh.Value;
                if (cbGioiTinh.Checked)
                {
                    emp.GioiTinh = 1;
                }
                else
                {
                    emp.GioiTinh = 0;
                }
                empBUS.DeleteEmployee(emp);
                int idx = dvgNhanVien.CurrentCell.RowIndex;
                dvgNhanVien.Rows.RemoveAt(idx);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            EmployeeDAO emp = new EmployeeDAO();
            if (tbIdNV.Text.Equals("") || tbName.Text.Equals("") || tbNoiSinh.Text.Equals(""))
            {
                MessageBox.Show("Không đc bỏ trống", "Thông báo");
            }
            else
            {
                emp.Ma = tbIdNV.Text;
                emp.HoTen = tbName.Text;
                emp.NoiSinh = tbNoiSinh.Text;
                emp.ChucVu = (DepartmentDAO)cbbCV.SelectedItem;
                emp.NgaySinh = dtNgaySinh.Value;
                if (cbGioiTinh.Checked)
                {
                    emp.GioiTinh = 1;
                }
                else
                {
                    emp.GioiTinh = 0;
                }
                empBUS.EditEmployee(emp);
                using DataGridViewRow row = dvgNhanVien.CurrentRow;
                row.Cells[0].Value = emp.Ma;
                row.Cells[1].Value = emp.HoTen;
                row.Cells[2].Value = emp.NoiSinh;
                row.Cells[3].Value = emp.NgaySinh;
                row.Cells[4].Value = emp.GioiTinh;
                row.Cells[5].Value = emp.ChucVu;
            }
        }
        private void dgvCustomer_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            DataGridViewRow row = dvgNhanVien.Rows[idx];
            if (row.Cells[0].Value != null)
            {
                tbIdNV.Text = dvgNhanVien.Rows[idx].Cells[0].Value.ToString();
                tbName.Text = dvgNhanVien.Rows[idx].Cells[1].Value.ToString();
                tbNoiSinh.Text = dvgNhanVien.Rows[idx].Cells[2].Value.ToString();
                dtNgaySinh.Text = dvgNhanVien.Rows[idx].Cells[3].Value.ToString();
                string cb = dvgNhanVien.Rows[idx].Cells[4].Value.ToString();
                if (cb == "True")
                {
                    cbGioiTinh.Checked = true;
                }
                else
                {
                    cbGioiTinh.Checked = false;
                }

                cbbCV.Text = dvgNhanVien.Rows[idx].Cells[5].Value.ToString();

            }
        }
    }
}

