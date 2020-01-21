using System;
using WindowsFormsApp3.Form;


namespace WindowsFormsApp3
{
    public partial class menu : DevExpress.XtraEditors.XtraForm
    {
        public menu()
        {
            InitializeComponent();
        }

       

        private void ucNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelMenu.Controls.Clear();
            Module.ucNhanVien ucNhanVien = new Module.ucNhanVien();
            ucNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMenu.Controls.Add(ucNhanVien);
        }

        private void ucBoPhan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelMenu.Controls.Clear();
            Module.ucBoPhan ucBoPhan = new Module.ucBoPhan();
            ucBoPhan.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMenu.Controls.Add(ucBoPhan);
        }
       
        private void btnketthuc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        public void ucBanHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelMenu.Controls.Clear();
            Module.ucBanHang ucBanHang = new Module.ucBanHang();
            ucBanHang.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMenu.Controls.Add(ucBanHang);
           
        }

        private void ucMuaHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelMenu.Controls.Clear();
            Module.ucMuaHang ucMuaHang = new Module.ucMuaHang();
            ucMuaHang.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMenu.Controls.Add(ucMuaHang);
        }

        private void menu_Load(object sender, EventArgs e)
        {
            login frm = new login();
            frm.ShowDialog();
        }

        private void ucKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelMenu.Controls.Clear();
            Module.ucKho ucKho = new Module.ucKho();
            ucKho.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMenu.Controls.Add(ucKho);
        }

        private void ucPhanQuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelMenu.Controls.Clear();
            Module.ucPhanquyen ucPhanquyen = new Module.ucPhanquyen();
            ucPhanquyen.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMenu.Controls.Add(ucPhanquyen);
        }

        private void ucKhuVuc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelMenu.Controls.Clear();
            Module.ucKV ucKV = new Module.ucKV();
            ucKV.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMenu.Controls.Add(ucKV);
        }

        private void ucDVT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelMenu.Controls.Clear();
            Module.ucDonViTinh ucDonViTinh = new Module.ucDonViTinh();
            ucDonViTinh.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMenu.Controls.Add(ucDonViTinh);
        }

        private void ucNCC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelMenu.Controls.Clear();
            Module.ucNCC ucNCC = new Module.ucNCC();
            ucNCC.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMenu.Controls.Add(ucNCC);
        }

        private void ucKhachHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelMenu.Controls.Clear();
            Module.ucKhachHang ucKhachHang = new Module.ucKhachHang();
            ucKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMenu.Controls.Add(ucKhachHang);
        }

        private void ucNhomHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelMenu.Controls.Clear();
            Module.ucNhomHang ucNhomHang = new Module.ucNhomHang();
            ucNhomHang.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMenu.Controls.Add(ucNhomHang);
        }

        private void ucHangHoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelMenu.Controls.Clear();
            Module.ucHangHoa ucHangHoa = new Module.ucHangHoa();
            ucHangHoa.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMenu.Controls.Add(ucHangHoa);
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelMenu.Controls.Clear();
            Module.ucTiGia ucTiGia = new Module.ucTiGia();
            ucTiGia.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMenu.Controls.Add(ucTiGia);
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            doimatKhau frm1 = new doimatKhau();
            frm1.Show();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            thongtin frm1 = new thongtin();
            frm1.Show();
        }
    }
}