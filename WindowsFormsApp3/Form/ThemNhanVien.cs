using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace WindowsFormsApp3
{
    public partial class ThemNhanVien : DevExpress.XtraEditors.XtraForm
    {
        private bool _isAddNew;
        private static NhanVien _nhanVien = new NhanVien();
        public ThemNhanVien()
        {
            InitializeComponent();
        }
        public ThemNhanVien(bool _isAddNew1,infoNhanVien infoNhanVien)
        {
            InitializeComponent();
            _isAddNew = _isAddNew1;
            txtMa.Text = infoNhanVien.MaNV.ToString();
            txtTenNV.Text = infoNhanVien.TenNV;
            txtDiaChi.Text = infoNhanVien.DiaChiNV;
            txtSDT.Text = infoNhanVien.DTNV;
            txtEmail.Text = infoNhanVien.EmailNV;
            ckQuanLy.Checked = infoNhanVien.ConQuanLy;
        }
        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (_isAddNew)
            {
                if (_nhanVien.Insert(txtTenNV.Text, txtDiaChi.Text, txtSDT.Text, txtEmail.Text, ckQuanLy.Checked))
                {
                    MessageBox.Show(this,"Đã Thêm mới một Nhân Viên", "thành công");                    
                }
                else
                {
                    MessageBox.Show(this, "Có Lỗi xảy ra", "Lỗi");
                }
            }
            else
            {
                if (_nhanVien.Update(txtMa.Text, txtTenNV.Text, txtDiaChi.Text, txtSDT.Text, txtEmail.Text, ckQuanLy.Checked))
                {
                    MessageBox.Show(this, "Đã Chỉnh Sửa thông tin một Nhân Viên", "thành công");
                }
                else
                {
                    MessageBox.Show(this, "Có Lỗi xảy ra", "Lỗi");
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}