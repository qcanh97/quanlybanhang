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
    public partial class ucKho : DevExpress.XtraEditors.XtraUserControl
    {
        private static KhoDAO _kho = new KhoDAO();
        private int _currentRowIndex;
        public ucKho()
        {
            InitializeComponent();
        }

        private void ucKho_Load(object sender, EventArgs e)
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
                gridControl1.DataSource = _kho.DanhSachKho();
            }
            catch (Exception)
            {
                MessageBox.Show(this, "không Thể Lấy Danh Sách", "Lỗi");
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            //lay vi tri dong duoc chon
            _currentRowIndex = gridView1.FocusedRowHandle;
            if (_currentRowIndex < 0) return;
            EnableButton();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            KhoDTO KhoDTO = new KhoDTO()
            {
                ConQuanLy = true
            };
            ThemKho frm = new ThemKho(true, KhoDTO);
            frm.ShowDialog();

            hienThi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            _currentRowIndex = gridView1.FocusedRowHandle;
            if (_currentRowIndex < 0) return;
            var MaKho = gridView1.GetRowCellValue(_currentRowIndex, gridView1.Columns["MaKho"]).ToString();
            var dresult = XtraMessageBox.Show("bạn có muốn xoá ?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dresult == DialogResult.No) return;
            if (_kho.Delete(MaKho))
            {
                MessageBox.Show(this, "Xoá Thành Công", "thông báo");
                _currentRowIndex = 0;
                hienThi();
            }
            else
                MessageBox.Show(this, "Xoá không Thành Công", "Lỗi");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _currentRowIndex = gridView1.FocusedRowHandle;
            if (_currentRowIndex < 0) return;

            KhoDTO KhoDTO = new KhoDTO()
            {
                MaKho = gridView1.GetRowCellValue(_currentRowIndex, gridView1.Columns["MaKho"]).ToString(),
                TenKho = gridView1.GetRowCellValue(_currentRowIndex, gridView1.Columns["TenKho"]).ToString(),
                DiaChiKho = gridView1.GetRowCellValue(_currentRowIndex, gridView1.Columns["DiaChiKho"]).ToString(),
                DTKho = gridView1.GetRowCellValue(_currentRowIndex, gridView1.Columns["DTKho"]).ToString(),
                ghichu = gridView1.GetRowCellValue(_currentRowIndex, gridView1.Columns["ghichu"]).ToString(),
                ConQuanLy = bool.Parse(gridView1.GetRowCellValue(_currentRowIndex, gridView1.Columns["ConQuanLy"]).ToString()),
            };
            ThemKho frm = new ThemKho(false, KhoDTO);
            frm.ShowDialog();
            hienThi();
        }
    }
}
