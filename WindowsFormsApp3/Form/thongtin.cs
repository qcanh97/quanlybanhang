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
    public partial class thongtin : DevExpress.XtraEditors.XtraForm
    {
        ThongTinDAO ThongTinDAO = new ThongTinDAO();
        
        public thongtin()
        {
            InitializeComponent();
           

                       
        }

        private void thongtin_Load(object sender, EventArgs e)
        {
            DataTable tb = ThongTinDAO.ThongTin();

            ThongTinDTO tt = new ThongTinDTO()
            {
                TenDV = tb.Rows[0]["TenDV"].ToString(),
                DiaChi = tb.Rows[0]["DiaChi"].ToString(),
                DienThoai = tb.Rows[0]["DienThoai"].ToString(),
                fax = tb.Rows[0]["fax"].ToString(),
                web = tb.Rows[0]["web"].ToString(),
                email = tb.Rows[0]["email"].ToString(),
                LinhVuc = tb.Rows[0]["LinhVuc"].ToString(),
                MaSoThue = tb.Rows[0]["MaSoThue"].ToString(),
                GPKD = tb.Rows[0]["GPKD"].ToString(),
            };
            txtTen.Text = tt.TenDV;
            txtDiaChi.Text = tt.DiaChi;
            txtDT.Text = tt.DienThoai;
            txtFax.Text = tt.fax;
            txtWeb.Text = tt.web;
            txtEmail.Text = tt.email;
            txtLinhVuc.Text = tt.LinhVuc;
            txtMST.Text = tt.MaSoThue;
            txtGPKD.Text = tt.GPKD;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (ThongTinDAO.Update(txtTen.Text, txtDiaChi.Text, txtDT.Text, txtFax.Text, txtWeb.Text, txtEmail.Text, txtLinhVuc.Text, txtMST.Text, txtGPKD.Text))
            {
                MessageBox.Show(this, "cập nhật thông tin Thành công", "thành công");
            }
            else
            {
                MessageBox.Show(this, "Có Lỗi xảy ra", "Lỗi");
            }
        }
    }
}