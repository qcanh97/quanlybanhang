using System.Windows.Forms;
using WindowsFormsApp3.DAO;
using WindowsFormsApp3.DTO;

namespace WindowsFormsApp3.Form
{
    public partial class ThemNhomHang : DevExpress.XtraEditors.XtraForm
    {
        private bool _isAddNew;
        private static NhomHangDAO _NhDAO = new NhomHangDAO();
        public ThemNhomHang()
        {
            InitializeComponent();
        }
        public ThemNhomHang(bool _isAddNew1, NhomHangDTO NHDTO)
        {
            InitializeComponent();
            _isAddNew = _isAddNew1;
            txtMa.Text = NHDTO.MaNH;
            txtTen.Text = NHDTO.TenNH;
            txtGhiChu.Text = NHDTO.ghichu;
            ckbConQuanLy.Checked = NHDTO.ConQuanLy;
            if (!_isAddNew)
                txtMa.Enabled = false;
        }

        private void btnLuu_Click(object sender, System.EventArgs e)
        {
            if (_isAddNew)
            {
                if (_NhDAO.Insert(txtMa.Text, txtTen.Text, txtGhiChu.Text, ckbConQuanLy.Checked))
                {
                    MessageBox.Show(this, "Đã Thêm mới một Nhóm Hàng", "thành công");
                }
                else
                {
                    MessageBox.Show(this, "Có Lỗi xảy ra", "Lỗi");
                }
            }
            else
            {

                if (_NhDAO.Update(txtMa.Text, txtTen.Text, txtGhiChu.Text, ckbConQuanLy.Checked))
                {
                    MessageBox.Show(this, "Đã Chỉnh Sửa thông tin một Nhóm Hàng", "thành công");
                }
                else
                {
                    MessageBox.Show(this, "Có Lỗi xảy ra", "Lỗi");
                }
            }
        }

        private void btnDong_Click(object sender, System.EventArgs e)
        {
            this.Close();

        }
    }
}