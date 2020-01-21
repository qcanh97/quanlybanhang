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
    public partial class ThemHangHoa : DevExpress.XtraEditors.XtraForm
    {
        private static NhomHangDAO NhomHangDAO = new NhomHangDAO();
        private static DonViTinhDAO DonViTinhDAO = new DonViTinhDAO();
        private static KhoDAO khoDAO = new KhoDAO();
        private static NCCDAO NCCDAO = new NCCDAO();
        private static HangHoaDAO HangHoaDAO = new HangHoaDAO();
        private bool _isAddNew;
        

        public ThemHangHoa()
        {
            InitializeComponent();
        }
       
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void loadItemsGLU()
        {
            //glu nhom hang
            var rs1 = new List<vlNhomHang>();
            var tb1 = NhomHangDAO.DanhSachNH();
            foreach (DataRow row1 in tb1.Rows)
            {
                var value1 = new vlNhomHang { ID = row1["MaNH"].ToString(), Name = row1["TenNH"].ToString() };
                rs1.Add(value1);
            }
            gluNhomHang.Properties.DataSource = rs1;
            gluNhomHang.Properties.DisplayMember = "Name";
            gluNhomHang.Properties.ValueMember = "Name";
            gluNhomHang.Properties.NullText = "Chọn Nhóm Hàng";
            gluNhomHang.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            //glu DonViTinh
            var rs2 = new List<vlDonViTinh>();
            var tb2 = DonViTinhDAO.DanhSachDVT();
            foreach (DataRow row2 in tb2.Rows)
            {
                var value2 = new vlDonViTinh { ID = row2["MaDVT"].ToString(), Name = row2["TenDVT"].ToString() };
                rs2.Add(value2);
            }
            gluDonVi.Properties.DataSource = rs2;
            gluDonVi.Properties.DisplayMember = "Name";
            gluDonVi.Properties.ValueMember = "Name";
            gluDonVi.Properties.NullText = "Chọn Đơn Vị";
            gluDonVi.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            //glu Kho
            var rs3 = new List<vlKho>();
            var tb3 = khoDAO.DanhSachKho();
            foreach (DataRow row3 in tb3.Rows)
            {
                var value3 = new vlKho { ID = row3["MaKho"].ToString(), Name = row3["TenKho"].ToString() };
                rs3.Add(value3);
            }
            gluKho.Properties.DataSource = rs3;
            gluKho.Properties.DisplayMember = "Name";
            gluKho.Properties.ValueMember = "Name";
            gluKho.Properties.NullText = "Chọn Kho";

            gluKho.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            //glu NCC
            var rs4 = new List<vlNCC>();
            var tb4 = NCCDAO.DanhSachNCC();
            foreach (DataRow row4 in tb4.Rows)
            {
                var value4 = new vlNCC { ID = row4["MaNCC"].ToString(), Name = row4["TenNCC"].ToString() };
                rs4.Add(value4);
            }
            gluNCC.Properties.DataSource = rs4;
            gluNCC.Properties.DisplayMember = "Name";
            gluNCC.Properties.ValueMember = "Name";
            gluNCC.Properties.NullText = "Chọn NCC";
            gluNCC.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
        }

        private void ThemHangHoa_Load(object sender, EventArgs e)
        {
            loadItemsGLU();
        }
        public ThemHangHoa(bool _isAddNew1, HangHoaDTO HangHoaDTO)
        {           
            InitializeComponent();
            _isAddNew = _isAddNew1;
            gluNhomHang.Text = HangHoaDTO.NhomHang;
            txtMaHang.Text = HangHoaDTO.MaHang;
            txtTenHang.Text = HangHoaDTO.TenHang;
            gluDonVi.EditValue = HangHoaDTO.DonVi;
            gluKho.EditValue = HangHoaDTO.TenKho;
            gluNCC.EditValue = HangHoaDTO.NCC;
            txtGiaMua.Text = HangHoaDTO.GiaMua.ToString();
            txtGiaBan.Text = HangHoaDTO.GiaBan.ToString();
            ckbConQuanLy.Checked = HangHoaDTO.ConQuanLy;
            if (!_isAddNew)
                txtMaHang.Enabled = false;
        }
        

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_isAddNew)
            {
                if (HangHoaDAO.Insert(txtMaHang.Text, txtTenHang.Text, gluDonVi.Text,int.Parse(txtGiaMua.Text), int.Parse(txtGiaBan.Text), gluNhomHang.Text, gluKho.Text, gluNCC.Text, ckbConQuanLy.Checked))
                {
                    MessageBox.Show(this, "Đã Thêm mới một Hàng Hoá", "thành công");
                }
                else
                {
                    MessageBox.Show(this, "Có Lỗi xảy ra", "Lỗi");
                }
            }
            else
            {

                if (HangHoaDAO.Update(txtMaHang.Text, txtTenHang.Text, gluDonVi.Text, int.Parse(txtGiaMua.Text), int.Parse(txtGiaBan.Text), gluNhomHang.Text, gluKho.Text, gluNCC.Text, ckbConQuanLy.Checked))
                {
                    MessageBox.Show(this, "Đã Chỉnh Sửa thông tin một Hàng Hoá", "thành công");
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
        // thêm dữ liệu mặc định cho GridLookup NhomHang
        class vlNhomHang
        {
            public string ID { get; set; }
            public string Name { get; set; }
        }
        // thêm dữ liệu mặc định cho GridLookup DonViTinh
        class vlDonViTinh
        {
            public string ID { get; set; }
            public string Name { get; set; }
        }
        // thêm dữ liệu mặc định cho GridLookup Kho
        class vlKho
        {
            public string ID { get; set; }
            public string Name { get; set; }
        }
        // thêm dữ liệu mặc định cho GridLookup NCC
        class vlNCC
        {
            public string ID { get; set; }
            public string Name { get; set; }
        }
    }
}