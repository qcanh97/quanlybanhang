using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WindowsFormsApp3.DAO;
using WindowsFormsApp3.DTO;
using DevExpress.XtraEditors.Controls;
using WindowsFormsApp3.Form;

namespace WindowsFormsApp3.Module
{
    public partial class ucBanHang : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBanHang()
        {
            InitializeComponent();
        }
        private static KhachHangDAO khachHangDAO = new KhachHangDAO();
        private static BanHangDAO BanHangDAO = new BanHangDAO();
        private static KhoDAO KhoDAO = new KhoDAO();
        private static NhanVien NhanVienDAO = new NhanVien();
        private static HangHoaDAO HangHoaDAO = new HangHoaDAO();
        private static CTPhieuBanHangDAO CTPhieuMuaHangDAO = new CTPhieuBanHangDAO();
        QLBHEntities1 _da = new QLBHEntities1();
        private void loadItemsGLU()
        {
            //glu Khach Hang
            var rs1 = new List<vlKhachHang>();
            var tb1 = khachHangDAO.DanhSacKH();
            foreach (DataRow row1 in tb1.Rows)
            {
                var value1 = new vlKhachHang { ID = row1["MaKH"].ToString(), Name = row1["TenKH"].ToString() };
                rs1.Add(value1);
            }
            gluKhachHang.Properties.DataSource = rs1;
            gluKhachHang.Properties.DisplayMember = "Name";
            gluKhachHang.Properties.ValueMember = "Name";
            gluKhachHang.Properties.NullText = "Chọn Khách Hàng";
            gluKhachHang.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            //glu ma Kh
            var rs2 = new List<vlKhachHang>();
            var tb2 = khachHangDAO.DanhSacKH();
            foreach (DataRow row2 in tb2.Rows)
            {
                var value2 = new vlKhachHang { ID = row2["MaKH"].ToString(), Name = row2["TenKH"].ToString() };
                rs2.Add(value2);
            }
            gluMaKH.Properties.DataSource = rs2;
            gluMaKH.Properties.DisplayMember = "ID";
            gluMaKH.Properties.ValueMember = "ID";
            gluMaKH.Properties.NullText = "Chọn Mã KH";
            gluMaKH.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            //glu Kho
            var rs3 = new List<vlKho>();
            var tb3 = KhoDAO.DanhSachKho();
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
            //glu nhanvien
            var rs4 = new List<vlNhanVien>();
            var tb4 = NhanVienDAO.DanhSachNhanVien();
            foreach (DataRow row4 in tb4.Rows)
            {
                var value4 = new vlNhanVien { ID = row4["MaNV"].ToString(), Name = row4["TenNV"].ToString() };
                rs4.Add(value4);
            }
            gluNhanVien.Properties.DataSource = rs4;
            gluNhanVien.Properties.DisplayMember = "Name";
            gluNhanVien.Properties.ValueMember = "Name";
            gluNhanVien.Properties.NullText = "Chọn NV";
            gluNhanVien.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
        }
        private decimal SoLuong = 0;
        private decimal ThanhTien = 0;
        private decimal Gia = 0;
        // thêm dữ liệu mặc định cho GridLookup khachhang
        class vlKhachHang
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
        class vlNhanVien
        {
            public string ID { get; set; }
            public string Name { get; set; }
        }
        
        private void ucBanHang_Load(object sender, EventArgs e)
        {
            loadItemsGLU();
            LoadItemsGV();
            dateNgayLap.EditValue = DateTime.Today;
            txtMaPBH.Text = PhatSinhMaPhieu();
            var dt = _da.temps.ToList();
            gridControl1.DataSource = new BindingList<temp>(dt);
        }

        private void gluKhachHang_EditValueChanged(object sender, EventArgs e)
        {
            var tb = khachHangDAO.DanhSacKH();
            foreach (DataRow row in tb.Rows)
            {                
                if (String.Compare(gluKhachHang.EditValue.ToString(), row["TenKH"].ToString(), true) == 0)
                    gluMaKH.EditValue = row["MaKH"];
            }
        }

        private void gluMaKH_EditValueChanged(object sender, EventArgs e)
        {
            var tb = khachHangDAO.DanhSacKH();
            foreach (DataRow row in tb.Rows)
            {
                if (String.Compare(gluMaKH.EditValue.ToString(), row["MaKH"].ToString(), true) == 0)
                    gluKhachHang.EditValue = row["TenKH"];
            }           
        }

        public string PhatSinhMaPhieu()
        {
            var dt = BanHangDAO.DanhSachPhieuBanHang();
            int id;
            if (dt.Rows.Count == 0)
            {
                id = 1;
            }
            else
            {
                id = dt.Rows.Count+1;
               // id = (int.Parse(dt.Rows[dt.Rows.Count - 1]["MaBH"].ToString()) + 1).ToString();
            }
            string temp = "BH"; //+ tentk;// khi đang nhập gán nó vô cái class global hoặc truyền từ trang chủ qua
            string dayso = "000";// mấy cái này cố định
            string MaPNH = temp + dayso.Substring(0, dayso.Length - id.ToString().Length) + id;
            return MaPNH;
        }
        private void LoadItemsGV()
        {            
            var dt = _da.HangHoas.ToList();
            repositoryItemGluMaHang.DataSource = dt;
            repositoryItemGluMaHang.ValueMember = "MaHang";
            repositoryItemGluMaHang.DisplayMember = "MaHang";
            colMa.ColumnEdit = repositoryItemGluMaHang;

        }
        // thêm dữ liệu mặc định cho GridLookup NCC
        class vlHangHoa
        {
            public string MaHang { get; set; }
            public string TenHang { get; set; }
            public int TonKho { get; set; }
            public string TenKho { get; set; }
            public int GiaMua { get; set; }
            public int GiaBan { get; set; }

        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if(e.Column.FieldName== "MaHang")
            {
                var value = gridView1.GetRowCellValue(e.RowHandle, e.Column);
                var dt = _da.HangHoas.FirstOrDefault(x => x.MaHang ==(string) value);
                if (dt != null)
                {
                    gridView1.SetRowCellValue(e.RowHandle, "TenHang", dt.TenHang);
                    gridView1.SetRowCellValue(e.RowHandle, "TenDVT", dt.DonVi);
                    gridView1.SetRowCellValue(e.RowHandle, "DonGia", dt.GiaBan);
                    if (gridView1.GetFocusedRowCellValue(gclSoLuong)=="")
                    {
                        SoLuong = 0;
                    }
                    else
                    {
                        SoLuong = Convert.ToDecimal(gridView1.GetFocusedRowCellValue(gclSoLuong));
                        Gia = Convert.ToDecimal(gridView1.GetFocusedRowCellValue(gclDonGia));
                        ThanhTien = SoLuong * Gia;
                        gridView1.SetFocusedRowCellValue(gclThanhTien, ThanhTien);
                    }
                }
                
            }
            if (e.Column == gclSoLuong)
            {
                SoLuong = Convert.ToDecimal(gridView1.GetFocusedRowCellValue(gclSoLuong));
                Gia = Convert.ToDecimal(gridView1.GetFocusedRowCellValue(gclDonGia));
                ThanhTien = SoLuong * Gia;
                gridView1.SetFocusedRowCellValue(gclThanhTien, ThanhTien);
            }
        }
        /// <summary>
        /// //////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelControlPBH.Visible = true;
            panelControlHoaDon.Visible = false;

            // dockPanel1.Visibility= DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // panelControl.Visible=


        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelControlPBH.Visible = false;
            panelControlHoaDon.Visible = true;
            Module.ucHoaDon ucHoaDon = new Module.ucHoaDon();
            ucHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            panelControlHoaDon.Controls.Add(ucHoaDon);
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            panelControlPBH.Visible = true;
            panelControlHoaDon.Visible = false;
        }
        private void setnull()
        {
            txtMaPBH.Text = PhatSinhMaPhieu();
            gluKhachHang.Text = string.Empty;
            gluMaKH.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
            txtDienThoai.Text = string.Empty;
            gluNhanVien.Text = string.Empty;
            gluKho.Text = string.Empty;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            gridControl1.ForceInitialize();
            var summaryValue = gridView1.Columns["ThanhTien"].SummaryItem.SummaryValue;
            if (BanHangDAO.Insert(txtMaPBH.Text, gluMaKH.Text, gluKhachHang.Text,txtDiaChi.Text, txtGhiChu.Text, txtDienThoai.Text, dateNgayLap.DateTime, gluNhanVien.Text, gluKho.Text,int.Parse(summaryValue.ToString())))
            {
               // MessageBox.Show(this, "Đã Thêm mới một Hàng Hoá", "thành công");
            }
            else
            {
                MessageBox.Show(this, "Có Lỗi xảy ra ở thêm PBH", "Lỗi");
            }

            for (int I = 0; I < gridView1.RowCount-1; I++)
            {     
                try
                {
                    var MaHang = gridView1.GetRowCellValue(I, "MaHang").ToString();
                    var TenHang = gridView1.GetRowCellValue(I, "TenHang").ToString();
                    var TenDVT = gridView1.GetRowCellValue(I, "TenDVT").ToString();
                    var SoLuong = int.Parse(gridView1.GetRowCellValue(I, "SoLuong").ToString());
                    var DonGia = int.Parse(gridView1.GetRowCellValue(I, "DonGia").ToString());
                    var ThanhTien = int.Parse(gridView1.GetRowCellValue(I, "ThanhTien").ToString());
                    if (CTPhieuMuaHangDAO.Insert(txtMaPBH.Text, MaHang, TenHang, TenDVT, SoLuong, DonGia, ThanhTien))
                    {
                        //MessageBox.Show(this, "Đã Thêm mới một Hàng Hoá", "thành công");
                    }
                    else
                    {
                        MessageBox.Show(this, "Có Lỗi xảy raở thêm CT_PBH", "Lỗi");
                    }
                }
                catch (Exception)
                {
                    throw;
                }

            }
            MessageBox.Show("Thành Công", "Thông Báo");
            setnull();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
        //thêm hàng hoá
        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            HangHoaDTO HangHoaDTO = new HangHoaDTO()
            {
                ConQuanLy = true
            };
            ThemHangHoa frm = new ThemHangHoa(true, HangHoaDTO);
            frm.ShowDialog();
        }
        //thêm khách  hàng

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            KhachHangDTO KhachHangDTO = new KhachHangDTO()
            {
                ConQuanLy = true
            };
            ThemKhachHang frm = new ThemKhachHang(true, KhachHangDTO);
            frm.ShowDialog();
        }
        //thêm kho

        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            KhoDTO KhoDTO = new KhoDTO()
            {
                ConQuanLy = true
            };
            ThemKho frm = new ThemKho(true, KhoDTO);
            frm.ShowDialog();
        }
    }
}