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
    public partial class ThemBoPhan : DevExpress.XtraEditors.XtraForm
    {
        private bool _isAddNew;
        private static BoPhanDAO _BPDAO = new BoPhanDAO();
        public ThemBoPhan()
        {
            InitializeComponent();
        }

        public ThemBoPhan(bool _isAddNew1, BoPhanDTO BoPhanDTO)
        {
            InitializeComponent();
            _isAddNew = _isAddNew1;
            txtMa.Text = BoPhanDTO.MaBP;
            txtTen.Text = BoPhanDTO.TenBP;
            txtGhiChu.Text = BoPhanDTO.ghichu;
            ckbConQuanLy.Checked = BoPhanDTO.ConQuanLy;
            if (!_isAddNew)
                txtMa.Enabled = false;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_isAddNew)
            {
                if (_BPDAO.Insert(txtMa.Text, txtTen.Text, txtGhiChu.Text, ckbConQuanLy.Checked))
                {
                    MessageBox.Show(this, "Đã Thêm mới một Bộ Phận", "thành công");
                }
                else
                {
                    MessageBox.Show(this, "Có Lỗi xảy ra", "Lỗi");
                }
            }
            else
            {

                if (_BPDAO.Update(txtMa.Text, txtTen.Text, txtGhiChu.Text, ckbConQuanLy.Checked))
                {
                    MessageBox.Show(this, "Đã Chỉnh Sửa thông tin một  Bộ Phận", "thành công");
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