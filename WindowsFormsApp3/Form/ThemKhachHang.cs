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
using DevExpress.XtraEditors.Controls;
using WindowsFormsApp3.DTO;

namespace WindowsFormsApp3.Form
{
    public partial class ThemKhachHang : DevExpress.XtraEditors.XtraForm
    {
        private static KVDAO _kv = new KVDAO();
        private static KhachHangDAO _kh = new KhachHangDAO();
        private bool _isAddNew;
        public ThemKhachHang()
        {
            InitializeComponent();
        }
        class valueglu
        {
            public string ID { get; set; }
            public string Name { get; set; }

        }
        private void ThemKhachHang_Load(object sender, EventArgs e)
        {
            var rs = new List<valueglu>();
            var tb = _kv.DanhSachKV();
            foreach (DataRow row in tb.Rows)
            {
                var value = new valueglu { ID = row["MaKV"].ToString(), Name = row["TenKV"].ToString() };
                rs.Add(value);
            }
            gluKhuVuc.Properties.DataSource = rs;
            gluKhuVuc.Properties.DisplayMember = "Name";
            gluKhuVuc.Properties.ValueMember = "ID";
            gluKhuVuc.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
        }
        public ThemKhachHang(bool _isAddNew1, KhachHangDTO KhachHangDTO)
        {
            InitializeComponent();
            _isAddNew = _isAddNew1;
            txtMa.Text = KhachHangDTO.MaKH;
            txtTen.Text = KhachHangDTO.TenKH;
            gluKhuVuc.Text = KhachHangDTO.TenkvKH;
            txtDiaChi.Text = KhachHangDTO.diachiKH;
            txtDT.Text = KhachHangDTO.DTKH;
            txtEmail.Text = KhachHangDTO.EmailKH;
            ckbConQuanLy.Checked = KhachHangDTO.ConQuanLy;
            if (!_isAddNew)
                txtMa.Enabled = false;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_isAddNew)
            {
                if (_kh.Insert(txtMa.Text, txtTen.Text, gluKhuVuc.Text, txtDiaChi.Text, txtDT.Text, txtEmail.Text, ckbConQuanLy.Checked))
                {
                    MessageBox.Show(this, "Đã Thêm mới một Khách Hàng", "thành công");
                }
                else
                {
                    MessageBox.Show(this, "Có Lỗi xảy ra", "Lỗi");
                }
            }
            else
            {

                if (_kh.Update(txtMa.Text, txtTen.Text, gluKhuVuc.Text, txtDiaChi.Text, txtDT.Text, txtEmail.Text, ckbConQuanLy.Checked))
                {
                    MessageBox.Show(this, "Đã Chỉnh Sửa thông tin một Khách Hàng", "thành công");
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