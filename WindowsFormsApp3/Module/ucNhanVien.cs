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

namespace WindowsFormsApp3.Module
{
    public partial class ucNhanVien : DevExpress.XtraEditors.XtraUserControl
    {
        private static NhanVien _nhanVien = new NhanVien();
        private int _currentRowIndex;
        
        public ucNhanVien()
        {
            InitializeComponent();
        }
        //phân quyền
        private void EnableButton()
        {
            int formID = int.Parse(this.Tag.ToString());
            var roleForm = Globalvar.DictMyRoleForm[formID];
            if (roleForm != null) {
                btnThem.Enabled = roleForm.Them;
                btnSua.Enabled = roleForm.Sua;
                btnXoa.Enabled = roleForm.Xoa;
            }
                   
        }
        
        private void ucNhanVien_Load(object sender, EventArgs e)
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
            hienThi();
        }
       
        private void hienThi()
        {
            try
            {
                gridControl1.DataSource = null;
                gridControl1.DataSource = _nhanVien.DanhSachNhanVien();
            }
            catch (Exception)
            {
                MessageBox.Show(this, "không Thể Lấy Danh Sách", "Lỗi");
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {

            infoNhanVien infoNhanVien = new infoNhanVien()
            {
                ConQuanLy = true
            };
            ThemNhanVien frm = new ThemNhanVien(true, infoNhanVien);
            frm.ShowDialog();

            hienThi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
           
            _currentRowIndex = gridView1.FocusedRowHandle;
            if (_currentRowIndex < 0) return;

            infoNhanVien infoNhanVien = new infoNhanVien()
            {
                MaNV = int.Parse(gridView1.GetRowCellValue(_currentRowIndex, gridView1.Columns["MaNV"]).ToString()),
                TenNV = gridView1.GetRowCellValue(_currentRowIndex, gridView1.Columns["TenNV"]).ToString(),
                DiaChiNV = gridView1.GetRowCellValue(_currentRowIndex, gridView1.Columns["DiaChiNV"]).ToString(),
                DTNV = gridView1.GetRowCellValue(_currentRowIndex, gridView1.Columns["DTNV"]).ToString(),
                EmailNV = gridView1.GetRowCellValue(_currentRowIndex, gridView1.Columns["EmailNV"]).ToString(),
                ConQuanLy = bool.Parse(gridView1.GetRowCellValue(_currentRowIndex, gridView1.Columns["ConQuanLy"]).ToString()),
            };
            ThemNhanVien frm = new ThemNhanVien(false,infoNhanVien);
            frm.ShowDialog();
            hienThi();
        }
        // kiểm soát xoá và sửa
        
        private void btnXoa_Click(object sender, EventArgs e)
        {
            _currentRowIndex = gridView1.FocusedRowHandle;
            if (_currentRowIndex < 0) return;
            var MaNV = gridView1.GetRowCellValue(_currentRowIndex, gridView1.Columns["MaNV"]).ToString();
            var dresult = XtraMessageBox.Show("bạn có muốn xoá ?", "thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dresult == DialogResult.No) return;
            if (_nhanVien.Delete(MaNV))
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

        private void gridView1_Click(object sender, EventArgs e)
        {
           
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            
        }

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            //lay vi tri dong duoc chon
            _currentRowIndex = gridView1.FocusedRowHandle;
            if (_currentRowIndex < 0) return;
            EnableButton();
        }
    }
}
