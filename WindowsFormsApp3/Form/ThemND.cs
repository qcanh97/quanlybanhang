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
    public partial class ThemND : DevExpress.XtraEditors.XtraForm
    {
        VaiTroDAO vaiTroDAO = new VaiTroDAO();
        private bool _isAddNew;
        TaiKhoanDAO _taiKhoanDAO = new TaiKhoanDAO();

        public ThemND()
        {
            InitializeComponent();
        }

        public ThemND(bool _isAddNew1, TaiKhoanDTO TKDTO)
        {
            InitializeComponent();
            _isAddNew = _isAddNew1;
            txttk.Text = TKDTO.TenTK;
            txtmk.Text = TKDTO.MatKhauTK;
            txtten.Text = TKDTO.Ten;
            gluVaiTro.EditValue = TKDTO.VaiTro;
        }

        private void loadItemsGLU()
        {
            //glu gluNCC
            var rs1 = new List<vlvt>();
            var tb1 = vaiTroDAO.DanhSachVT();
            foreach (DataRow row1 in tb1.Rows)
            {
                var value1 = new vlvt { ID = row1["MaVT"].ToString(), Name = row1["TenVT"].ToString() };
                rs1.Add(value1);
            }
            gluVaiTro.Properties.DataSource = rs1;
            gluVaiTro.Properties.DisplayMember = "Name";
            gluVaiTro.Properties.ValueMember = "ID";
            gluVaiTro.Properties.NullText = "Chọn Vai Trò";
            gluVaiTro.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
        }
        class vlvt
        {
            public string ID { get; set; }
            public string Name { get; set; }
        }
        private void ThemND_Load(object sender, EventArgs e)
        {
            loadItemsGLU();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_taiKhoanDAO.Insert(txttk.Text, txtmk.Text, txtten.Text, int.Parse(gluVaiTro.EditValue.ToString())))
            {
                MessageBox.Show(this, "Đã Thêm mới một Tài Khoản", "thành công");
            }
            else
            {
                MessageBox.Show(this, "Có Lỗi xảy ra", "Lỗi");
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}