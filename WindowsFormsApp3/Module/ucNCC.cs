using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WindowsFormsApp3.DAO;
using WindowsFormsApp3.DTO;
using WindowsFormsApp3.Form;

namespace WindowsFormsApp3.Module
{
    public partial class ucNCC : DevExpress.XtraEditors.XtraUserControl
    {
        private static NCCDAO _NCC = new NCCDAO();
        private int _currentRowIndex;
        public ucNCC()
        {
            InitializeComponent();
        }

        private void ucNCC_Load(object sender, EventArgs e)
        {
            int formID = int.Parse(this.Tag.ToString());
            var roleForm = Globalvar.DictMyRoleForm[formID];
            if (!roleForm.TruyCap)
            {
                MessageBox.Show("không có quyền truy cập", "lỗi");
                return;
            }

            EnableButton();
            // mặc định
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnXuat.Enabled = false;
            hienThi();
        }
        private void EnableButton()
        {
            int formID = int.Parse(this.Tag.ToString());
            var roleForm = Globalvar.DictMyRoleForm[formID];
            if (roleForm != null)
            {
                btnThem.Enabled = roleForm.Them;
                btnSua.Enabled = roleForm.Sua;
                btnXoa.Enabled = roleForm.Xoa;
                btnNhap.Enabled = roleForm.Nhap;
                btnXuat.Enabled = roleForm.Xuat;
            }
        }
        private void hienThi()
        {
            try
            {
                gridControl1.DataSource = null;
                gridControl1.DataSource = _NCC.DanhSachNCC();
            }
            catch (Exception)
            {
                MessageBox.Show(this, "không Thể Lấy Danh Sách", "Lỗi");
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            NCCDTO NCCDTO = new NCCDTO()
            {
                ConQuanLy = true
            };
            ThemNCC frm = new ThemNCC(true, NCCDTO);
            frm.ShowDialog();

            hienThi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _currentRowIndex = gridView1.FocusedRowHandle;
            if (_currentRowIndex < 0) return;

            NCCDTO NCCDTO = new NCCDTO()
            {
                MaNCC = gridView1.GetRowCellValue(_currentRowIndex, gridView1.Columns["MaNCC"]).ToString(),
                TenNCC = gridView1.GetRowCellValue(_currentRowIndex, gridView1.Columns["TenNCC"]).ToString(),
                Tenkvncc = gridView1.GetRowCellValue(_currentRowIndex, gridView1.Columns["TenKV"]).ToString(),
                diachiNCC = gridView1.GetRowCellValue(_currentRowIndex, gridView1.Columns["diachiNCC"]).ToString(),
                DTNCC = gridView1.GetRowCellValue(_currentRowIndex, gridView1.Columns["DTNCC"]).ToString(),
                EmailNCC = gridView1.GetRowCellValue(_currentRowIndex, gridView1.Columns["EmailNCC"]).ToString(),
                ConQuanLy = bool.Parse(gridView1.GetRowCellValue(_currentRowIndex, gridView1.Columns["ConQuanLy"]).ToString()),
            };
            ThemNCC frm = new ThemNCC(false, NCCDTO);
            frm.ShowDialog();
            hienThi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            _currentRowIndex = gridView1.FocusedRowHandle;
            if (_currentRowIndex < 0) return;
            var MaNCC = gridView1.GetRowCellValue(_currentRowIndex, gridView1.Columns["MaNCC"]).ToString();
            var dresult = XtraMessageBox.Show("bạn có muốn xoá ?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dresult == DialogResult.No) return;
            if (_NCC.Delete(MaNCC))
            {
                MessageBox.Show(this, "Xoá Thành Công", "thông báo");
                _currentRowIndex = 0;
                hienThi();
            }
            else
                MessageBox.Show(this, "Xoá không Thành Công", "Lỗi");
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void gridControl1_MouseDown(object sender, MouseEventArgs e)
        {
            //lay vi tri dong duoc chon
            _currentRowIndex = gridView1.FocusedRowHandle;
            if (_currentRowIndex < 0) return;
            EnableButton();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
