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
    public partial class ThemKho : DevExpress.XtraEditors.XtraForm
    {
        private bool _isAddNew;
        private static KhoDAO _KhoDAO = new KhoDAO();
        public ThemKho()
        {
            InitializeComponent();
        }
        public ThemKho(bool _isAddNew1, KhoDTO KhoDTO)
        {
            InitializeComponent();
            _isAddNew = _isAddNew1;
            txtMaKho.Text = KhoDTO.MaKho;
            txtTenKho.Text = KhoDTO.TenKho;
            txtDiaChiKho.Text = KhoDTO.DiaChiKho;
            txtDTKho.Text = KhoDTO.DTKho;
            mmGhiChu.Text = KhoDTO.ghichu;
            ckbConQuanLy.Checked = KhoDTO.ConQuanLy;
            if(!_isAddNew)
                txtMaKho.Enabled = false;
        }
        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_isAddNew)
            {
                if (_KhoDAO.Insert(txtMaKho.Text, txtTenKho.Text, txtDiaChiKho.Text, txtDTKho.Text, mmGhiChu.Text, ckbConQuanLy.Checked))
                {
                    MessageBox.Show(this, "Đã Thêm mới một Kho", "thành công");
                }
                else
                {
                    MessageBox.Show(this, "Có Lỗi xảy ra", "Lỗi");
                }
            }
            else
            {
                
                if (_KhoDAO.Update(txtMaKho.Text, txtTenKho.Text, txtDiaChiKho.Text, txtDTKho.Text, mmGhiChu.Text, ckbConQuanLy.Checked))
                {
                    MessageBox.Show(this, "Đã Chỉnh Sửa thông tin một Kho", "thành công");
                }
                else
                {
                    MessageBox.Show(this, "Có Lỗi xảy ra", "Lỗi");
                }
            }
        }
    }
}