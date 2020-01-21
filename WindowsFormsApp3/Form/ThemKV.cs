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
using WindowsFormsApp3.DTO;
using WindowsFormsApp3.DAO;

namespace WindowsFormsApp3.Form
{
    public partial class ThemKV : DevExpress.XtraEditors.XtraForm
    {
        private bool _isAddNew;
        private static KVDAO _KVDAO = new KVDAO();       
        public ThemKV()
        {
            InitializeComponent();
        }
        public ThemKV(bool _isAddNew1, KVDTO KVDTO)
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
                if (_KVDAO.Insert(txtMa.Text, txtTen.Text, txtGhiChu.Text, ckbConQuanLy.Checked))
                {
                    MessageBox.Show(this, "Đã Thêm mới một Khu Vực", "thành công");
                }
                else
                {
                    MessageBox.Show(this, "Có Lỗi xảy ra", "Lỗi");
                }
            }
            else
            {

                if (_KVDAO.Update(txtMa.Text, txtTen.Text, txtGhiChu.Text, ckbConQuanLy.Checked))
                {
                    MessageBox.Show(this, "Đã Chỉnh Sửa thông tin một Khu Vực" , "thành công");
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

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}