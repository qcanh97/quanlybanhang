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
    public partial class ThemNCC : DevExpress.XtraEditors.XtraForm
    {
        private static KVDAO _kv = new KVDAO();
        private static NCCDAO _ncc = new NCCDAO();
        
        private bool _isAddNew;
        
        public ThemNCC()
        {
            InitializeComponent();
        }
        // thêm dữ liệu mặc định cho GridLookupEdit
        class valueglu
        {
            public string ID { get; set; }
            public string Name { get; set; }

        }
        private void ThemNCC_Load(object sender, EventArgs e)
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
            gluKhuVuc.Properties.ValueMember = "Name";
            gluKhuVuc.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
        }
        public ThemNCC(bool _isAddNew1, NCCDTO NCCDTO)
        {
            InitializeComponent();
            _isAddNew = _isAddNew1;
            txtMa.Text = NCCDTO.MaNCC;
            txtTen.Text = NCCDTO.TenNCC;
            gluKhuVuc.EditValue = NCCDTO.Tenkvncc;
            txtDiaChi.Text = NCCDTO.diachiNCC;
            txtDT.Text = NCCDTO.DTNCC;
            txtEmail.Text = NCCDTO.EmailNCC;
            ckbConQuanLy.Checked = NCCDTO.ConQuanLy;
            if (!_isAddNew)
                txtMa.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_isAddNew)
            {
                if (_ncc.Insert(txtMa.Text, txtTen.Text, gluKhuVuc.Text, txtDiaChi.Text, txtDT.Text, txtEmail.Text, ckbConQuanLy.Checked))
                {
                    MessageBox.Show(this, "Đã Thêm mới một Nhà Cung Cấp", "thành công");
                }
                else
                {
                    MessageBox.Show(this, "Có Lỗi xảy ra", "Lỗi");
                }
            }
            else
            {

                if (_ncc.Update(txtMa.Text, txtTen.Text, gluKhuVuc.Text, txtDiaChi.Text, txtDT.Text, txtEmail.Text, ckbConQuanLy.Checked))
                {
                    MessageBox.Show(this, "Đã Chỉnh Sửa thông tin một Nhà Cung Cấp", "thành công");
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