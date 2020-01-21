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
    public partial class ucMuaHang : DevExpress.XtraEditors.XtraUserControl
    {
        private static NCCDAO NCCDAO = new NCCDAO();
        private static MuaHangDAO MuaHangDAO = new MuaHangDAO();
        private static KhoDAO KhoDAO = new KhoDAO();
        private static NhanVien NhanVienDAO = new NhanVien();
        private static HangHoaDAO HangHoaDAO = new HangHoaDAO();
        private static CTPhieuNhapHangDAO CTPhieuNhapHangDAO = new CTPhieuNhapHangDAO();
        QLBHEntities1 _da = new QLBHEntities1();
        private decimal SoLuong = 0;
        private decimal ThanhTien = 0;
        private decimal Gia = 0;
        public ucMuaHang()
        {
            InitializeComponent();
        }
        private void loadItemsGLU()
        {
            //glu gluNCC
            var rs1 = new List<vlLook>();
            var tb1 = NCCDAO.DanhSachNCC();
            foreach (DataRow row1 in tb1.Rows)
            {
                var value1 = new vlLook { ID = row1["MaNCC"].ToString(), Name = row1["TenNCC"].ToString() };
                rs1.Add(value1);
            }
            gluNCC.Properties.DataSource = rs1;
            gluNCC.Properties.DisplayMember = "Name";
            gluNCC.Properties.ValueMember = "Name";
            gluNCC.Properties.NullText = "Chọn NCC";
            gluNCC.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            //glu gluMaNCC
            var rs2 = new List<vlLook>();
            var tb2 = NCCDAO.DanhSachNCC();
            foreach (DataRow row2 in tb2.Rows)
            {
                var value2 = new vlLook { ID = row2["MaNCC"].ToString(), Name = row2["TenNCC"].ToString() };
                rs2.Add(value2);
            }
            gluMaNCC.Properties.DataSource = rs2;
            gluMaNCC.Properties.DisplayMember = "ID";
            gluMaNCC.Properties.ValueMember = "ID";
            gluMaNCC.Properties.NullText = "Chọn Mã NCC";
            gluMaNCC.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            //glu Kho
            var rs3 = new List<vlLook>();
            var tb3 = KhoDAO.DanhSachKho();
            foreach (DataRow row3 in tb3.Rows)
            {
                var value3 = new vlLook { ID = row3["MaKho"].ToString(), Name = row3["TenKho"].ToString() };
                rs3.Add(value3);
            }
            gluKho.Properties.DataSource = rs3;
            gluKho.Properties.DisplayMember = "Name";
            gluKho.Properties.ValueMember = "Name";
            gluKho.Properties.NullText = "Chọn Kho";

            gluKho.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            //glu nhanvien
            var rs4 = new List<vlLook>();
            var tb4 = NhanVienDAO.DanhSachNhanVien();
            foreach (DataRow row4 in tb4.Rows)
            {
                var value4 = new vlLook { ID = row4["MaNV"].ToString(), Name = row4["TenNV"].ToString() };
                rs4.Add(value4);
            }
            gluNhanVien.Properties.DataSource = rs4;
            gluNhanVien.Properties.DisplayMember = "Name";
            gluNhanVien.Properties.ValueMember = "Name";
            gluNhanVien.Properties.NullText = "Chọn NV";
            gluNhanVien.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
        }
        class vlLook
        {
            public string ID { get; set; }
            public string Name { get; set; }
        }

        private void LoadItemsGV()
        {
            var dt = _da.HangHoas.ToList();
            repositoryItemGluMaHang.DataSource = dt;
            repositoryItemGluMaHang.ValueMember = "MaHang";
            repositoryItemGluMaHang.DisplayMember = "MaHang";
            gclMaHang.ColumnEdit = repositoryItemGluMaHang;

        }
        public string PhatSinhMaPhieu()
        {
            var dt =MuaHangDAO.DanhSachPhieuMuaHang();
            int id;
            if (dt.Rows.Count == 0)
            {
                id = 1;
            }
            else
            {
                id = dt.Rows.Count + 1;
                // id = (int.Parse(dt.Rows[dt.Rows.Count - 1]["MaBH"].ToString()) + 1).ToString();
            }
            string temp = "MH"; //+ tentk;// khi đang nhập gán nó vô cái class global hoặc truyền từ trang chủ qua
            string dayso = "000";// mấy cái này cố định
            string MaPNH = temp + dayso.Substring(0, dayso.Length - id.ToString().Length) + id;
            return MaPNH;
        }
        private void ucMuaHang_Load(object sender, EventArgs e)
        {
            loadItemsGLU();
            LoadItemsGV();
            dateNgay.EditValue = DateTime.Today;
            txtPhieu.Text = PhatSinhMaPhieu();
            var dt = _da.temps.ToList();
            gridControl1.DataSource = new BindingList<temp>(dt);
        }

        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "MaHang")
            {
                var value = gridView4.GetRowCellValue(e.RowHandle, e.Column);
                var dt = _da.HangHoas.FirstOrDefault(x => x.MaHang == (string)value);
                if (dt != null)
                {
                    gridView4.SetRowCellValue(e.RowHandle, "TenHang", dt.TenHang);
                    gridView4.SetRowCellValue(e.RowHandle, "TenDVT", dt.DonVi);
                    gridView4.SetRowCellValue(e.RowHandle, "DonGia", dt.GiaMua);
                    if (gridView4.GetFocusedRowCellValue(gclSoLuong) == "")
                    {
                        SoLuong = 0;
                    }
                    else
                    {
                        SoLuong = Convert.ToDecimal(gridView4.GetFocusedRowCellValue(gclSoLuong));
                        Gia = Convert.ToDecimal(gridView4.GetFocusedRowCellValue(gclDonGia));
                        ThanhTien = SoLuong * Gia;
                        gridView4.SetFocusedRowCellValue(gclThanhTien, ThanhTien);
                    }
                }

            }
            if (e.Column == gclSoLuong)
            {
                SoLuong = Convert.ToDecimal(gridView4.GetFocusedRowCellValue(gclSoLuong));
                Gia = Convert.ToDecimal(gridView4.GetFocusedRowCellValue(gclDonGia));
                ThanhTien = SoLuong * Gia;
                gridView4.SetFocusedRowCellValue(gclThanhTien, ThanhTien);
            }
        }
        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelControlPNH.Visible = true;
            panelControlHoaDon.Visible = false;

        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelControlPNH.Visible = false;
            panelControlHoaDon.Visible = true;
            
            Module.ucHoaDonNH ucHoaDonNH = new Module.ucHoaDonNH();
            ucHoaDonNH.Dock = System.Windows.Forms.DockStyle.Fill;
            panelControlHoaDon.Controls.Add(ucHoaDonNH);
        }
        private void setnull()
        {
            txtPhieu.Text = PhatSinhMaPhieu();
            gluMaNCC.Text = string.Empty;
            gluNCC.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
            txtDienThoai.Text = string.Empty;
            gluNhanVien.Text = string.Empty;
            gluKho.Text = string.Empty;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            gridControl1.ForceInitialize();
            var summaryValue = gridView4.Columns["ThanhTien"].SummaryItem.SummaryValue;
            if (MuaHangDAO.Insert(txtPhieu.Text, gluMaNCC.Text, gluNCC.Text, gluNhanVien.Text, gluKho.Text, txtDiaChi.Text, txtGhiChu.Text, txtDienThoai.Text, dateNgay.DateTime,  int.Parse(summaryValue.ToString())))
            {
                // MessageBox.Show(this, "Đã Thêm mới một Hàng Hoá", "thành công");
            }
            else
            {
                MessageBox.Show(this, "Có Lỗi xảy ra ở thêm PBH", "Lỗi");
            }

            for (int I = 0; I < gridView4.RowCount-1; I++)
            {

                try
                {
                    var MaHang = gridView4.GetRowCellValue(I, "MaHang").ToString();
                    var TenHang = gridView4.GetRowCellValue(I, "TenHang").ToString();
                    var TenDVT = gridView4.GetRowCellValue(I, "TenDVT").ToString();
                    var SoLuong = int.Parse(gridView4.GetRowCellValue(I, "SoLuong").ToString());
                    var DonGia = int.Parse(gridView4.GetRowCellValue(I, "DonGia").ToString());
                    var ThanhTien = int.Parse(gridView4.GetRowCellValue(I, "ThanhTien").ToString());
                    if (CTPhieuNhapHangDAO.Insert(txtPhieu.Text, MaHang, TenHang, TenDVT, SoLuong, DonGia, ThanhTien))
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

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            panelControlPNH.Visible = true;
            panelControlHoaDon.Visible = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);

        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            HangHoaDTO HangHoaDTO = new HangHoaDTO()
            {
                ConQuanLy = true
            };
            ThemHangHoa frm = new ThemHangHoa(true, HangHoaDTO);
            frm.ShowDialog();
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            KhachHangDTO KhachHangDTO = new KhachHangDTO()
            {
                ConQuanLy = true
            };
            ThemKhachHang frm = new ThemKhachHang(true, KhachHangDTO);
            frm.ShowDialog();
        }

        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            KhoDTO KhoDTO = new KhoDTO()
            {
                ConQuanLy = true
            };
            ThemKho frm = new ThemKho(true, KhoDTO);
            frm.ShowDialog();
        }

        private void gluNCC_EditValueChanged(object sender, EventArgs e)
        {
            var tb = NCCDAO.DanhSachNCC();
            foreach (DataRow row in tb.Rows)
            {
                if (String.Compare(gluNCC.EditValue.ToString(), row["TenNCC"].ToString(), true) == 0)
                    gluMaNCC.EditValue = row["MaNCC"];
            }
        }

        private void gluMaNCC_EditValueChanged(object sender, EventArgs e)
        {
            var tb = NCCDAO.DanhSachNCC();
            foreach (DataRow row in tb.Rows)
            {
                if (String.Compare(gluNCC.EditValue.ToString(), row["MaNCC"].ToString(), true) == 0)
                    gluMaNCC.EditValue = row["TenNCC"];
            }
        }
    }
}
