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
using WindowsFormsApp3.DAO;
using WindowsFormsApp3.DTO;

namespace WindowsFormsApp3.Form
{
    public partial class ThemDVT : DevExpress.XtraEditors.XtraForm
    {
        private bool _isAddNew;
        private static DonViTinhDAO _DonViTinhDAO = new DonViTinhDAO();
        public ThemDVT()
        {
            InitializeComponent();
        }
        public ThemDVT(bool _isAddNew1, KVDTO KVDTO)
        {
            InitializeComponent();
            _isAddNew = _isAddNew1;
            txtMa.Text = KVDTO.MaKV;
            txtTen.Text = KVDTO.TenKV;
            txtGhiChu.Text = KVDTO.ghichu;
            ckbConQuanLy.Checked = KVDTO.ConQuanLy;
            if (!_isAddNew)
                txtMa.Enabled = false;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_isAddNew)
            {
                if (_DonViTinhDAO.Insert(txtMa.Text, txtTen.Text, txtGhiChu.Text, ckbConQuanLy.Checked))
                {
                    MessageBox.Show(this, "Đã Thêm mới một Đơn Vị Tính", "thành công");
                }
                else
                {
                    MessageBox.Show(this, "Có Lỗi xảy ra", "Lỗi");
                }
            }
            else
            {

                if (_DonViTinhDAO.Update(txtMa.Text, txtTen.Text, txtGhiChu.Text, ckbConQuanLy.Checked))
                {
                    MessageBox.Show(this, "Đã Chỉnh Sửa thông tin một Đơn Vị Tính", "thành công");
                }
                else
                {
                    MessageBox.Show(this, "Có Lỗi xảy ra", "Lỗi");
                }
            }

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}