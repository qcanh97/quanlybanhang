using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;
using WindowsFormsApp3.DAO;
using WindowsFormsApp3.DTO;
using WindowsFormsApp3.Form;

namespace WindowsFormsApp3.Module
{
    public partial class ucNhomHang : DevExpress.XtraEditors.XtraUserControl
    {
        private static NhomHangDAO _nh = new NhomHangDAO();
        private int _currentRowIndex;
        public ucNhomHang()
        {
            InitializeComponent();
        }

        private void ucNhomHang_Load(object sender, EventArgs e)
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
                gridControl1.DataSource = _nh.DanhSachNH();
            }
            catch (Exception)
            {
                MessageBox.Show(this, "không Thể Lấy Danh Sách", "Lỗi");
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            NhomHangDTO NHDTO = new NhomHangDTO()
            {
                ConQuanLy = true
            };
            ThemNhomHang frm = new ThemNhomHang(true, NHDTO);
            frm.ShowDialog();

            hienThi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _currentRowIndex = gridView1.FocusedRowHandle;
            if (_currentRowIndex < 0) return;

            NhomHangDTO NHDTO = new NhomHangDTO()
            {
                MaNH = gridView1.GetRowCellValue(_currentRowIndex, gridView1.Columns["MaNH"]).ToString(),
                TenNH = gridView1.GetRowCellValue(_currentRowIndex, gridView1.Columns["TenNH"]).ToString(),
                ghichu = gridView1.GetRowCellValue(_currentRowIndex, gridView1.Columns["ghichu"]).ToString(),
                ConQuanLy = bool.Parse(gridView1.GetRowCellValue(_currentRowIndex, gridView1.Columns["ConQuanLy"]).ToString()),
            };
            ThemNhomHang frm = new ThemNhomHang(false, NHDTO);
            frm.ShowDialog();
            hienThi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            _currentRowIndex = gridView1.FocusedRowHandle;
            if (_currentRowIndex < 0) return;
            var MaNH = gridView1.GetRowCellValue(_currentRowIndex, gridView1.Columns["MaNH"]).ToString();
            var dresult = XtraMessageBox.Show("bạn có muốn xoá ?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dresult == DialogResult.No) return;
            if (_nh.Delete(MaNH))
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
    }
}
