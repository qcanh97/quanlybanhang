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

namespace WindowsFormsApp3.Form
{
    public partial class doimatKhau : DevExpress.XtraEditors.XtraForm
    {
        private static TaiKhoanDAO _dmkDAO = new TaiKhoanDAO();
        public doimatKhau()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_dmkDAO.Doimk(Globalvar.TK.MaTK, txtMatKhauCu.Text, txtMatKhauMoi.Text))
            {
                MessageBox.Show(this, "Đổi Mật Khẩu Thành Công", "thành công");
            }
            else
            {
                MessageBox.Show(this, "Có Lỗi xảy ra", "Lỗi");
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}