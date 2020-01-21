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
    public partial class ThemTG : DevExpress.XtraEditors.XtraForm
    {
        private bool _isAddNew;
        private static TGDAO _TGDAO = new TGDAO();
        public ThemTG()
        {
            InitializeComponent();
        }
        public ThemTG(bool _isAddNew1, TGDTO TGDTO)
        {
            InitializeComponent();
            _isAddNew = _isAddNew1;
            txtMa.Text = TGDTO.MaTG;
            txtTen.Text = TGDTO.TenTG;
            txtTGQuyDoi.Text = TGDTO.TGQuyDoi.ToString();
            ckbConQuanLy.Checked = TGDTO.ConQuanLy;
            if (!_isAddNew)
                txtMa.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_isAddNew)
            {
                if (_TGDAO.Insert(txtMa.Text, txtTen.Text,int.Parse(txtTGQuyDoi.Text), ckbConQuanLy.Checked))
                {
                    MessageBox.Show(this, "Đã Thêm mới một Tỉ Giá", "thành công");
                }
                else
                {
                    MessageBox.Show(this, "Có Lỗi xảy ra", "Lỗi");
                }
            }
            else
            {

                if (_TGDAO.Update(txtMa.Text, txtTen.Text, int.Parse(txtTGQuyDoi.Text), ckbConQuanLy.Checked))
                {
                    MessageBox.Show(this, "Đã Chỉnh Sửa thông tin một Tỉ Giá", "thành công");
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