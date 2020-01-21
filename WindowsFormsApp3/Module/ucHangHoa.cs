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
    public partial class ucHangHoa : DevExpress.XtraEditors.XtraUserControl
    {
        private static HangHoaDAO _HH = new HangHoaDAO();
        private int _currentRowIndex;
        public ucHangHoa()
        {
            InitializeComponent();
        }

        private void ucHangHoa_Load(object sender, EventArgs e)
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
                gridControl1.DataSource = _HH.DanhSachHangHoa();
            }
            catch (Exception)
            {
                MessageBox.Show(this, "không Thể Lấy Danh Sách", "Lỗi");
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            HangHoaDTO HangHoaDTO = new HangHoaDTO()
            {
                ConQuanLy = true
            };
            ThemHangHoa frm = new ThemHangHoa(true, HangHoaDTO);
            frm.ShowDialog();

            hienThi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _currentRowIndex = gridView1.FocusedRowHandle;
            if (_currentRowIndex < 0) return;

            HangHoaDTO HangHoaDTO = new HangHoaDTO()
            {
                MaHang = gridView1.GetRowCellValue(_currentRowIndex, gridView1.Columns["MaHang"]).ToString(),
                TenHang = gridView1.GetRowCellValue(_currentRowIndex, gridView1.Columns["TenHang"]).ToString(),
                DonVi = gridView1.GetRowCellValue(_currentRowIndex, gridView1.Columns["DonVi"]).ToString(),
                GiaMua = int.Parse(gridView1.GetRowCellValue(_currentRowIndex, gridView1.Columns["GiaMua"]).ToString()),
                GiaBan = int.Parse(gridView1.GetRowCellValue(_currentRowIndex, gridView1.Columns["GiaBan"]).ToString()),
                NhomHang = gridView1.GetRowCellValue(_currentRowIndex, gridView1.Columns["NhomHang"]).ToString(),               
                TenKho = gridView1.GetRowCellValue(_currentRowIndex, gridView1.Columns["TenKho"]).ToString(),
                ConQuanLy = bool.Parse(gridView1.GetRowCellValue(_currentRowIndex, gridView1.Columns["ConQuanLy"]).ToString()),
            };
            ThemHangHoa frm = new ThemHangHoa(false, HangHoaDTO);
            frm.ShowDialog();
            hienThi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            _currentRowIndex = gridView1.FocusedRowHandle;
            if (_currentRowIndex < 0) return;
            var MaHang = gridView1.GetRowCellValue(_currentRowIndex, gridView1.Columns["MaHang"]).ToString();
            var dresult = XtraMessageBox.Show("bạn có muốn xoá ?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dresult == DialogResult.No) return;
            if (_HH.Delete(MaHang))
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
