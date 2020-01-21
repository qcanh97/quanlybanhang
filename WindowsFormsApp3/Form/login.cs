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
using WindowsFormsApp3.BUS;

namespace WindowsFormsApp3.Form
{
    public partial class login : DevExpress.XtraEditors.XtraForm
    {
        DangNhapBUS dangNhapBUS = new DangNhapBUS();
        PhanQuyenBUS PhanQuyenBUS = new PhanQuyenBUS();
        public login()
        {
            InitializeComponent();

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        




























































        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string taikhoan = txtTaiKhoan.Text.Trim();
            string matkhau = txtMatKhau.Text;
            var rs = dangNhapBUS.dangNhap(taikhoan, matkhau);
           
            if (rs != null)
            {
                this.Close();
                var lst = PhanQuyenBUS.GetList(rs.VaiTro);
                foreach(var roleForm in lst){
                    Globalvar.DictMyRoleForm.Add(roleForm.MaForm, roleForm);
                }
                Globalvar.TK.MaTK = rs.MaTK;
                Globalvar.TK.VaiTro = rs.VaiTro;
            }
            else {
                this.Close();
                login frm = new login();
                MessageBox.Show("sai tài khoản hoặc mật khẩu");
                frm.ShowDialog();
            }
        }

       
    }
}