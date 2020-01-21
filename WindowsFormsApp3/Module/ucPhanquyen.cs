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
using DevExpress.XtraEditors.Controls;
using WindowsFormsApp3.DAO;
using WindowsFormsApp3.Form;

namespace WindowsFormsApp3.Module
{
    public partial class ucPhanquyen : DevExpress.XtraEditors.XtraUserControl
    {
        VaiTroDAO vaiTroDAO = new VaiTroDAO();
        TaiKhoanDAO TaiKhoanDAO = new TaiKhoanDAO();
        PhanQuyenDAO PhanQuyenDAO = new PhanQuyenDAO();
        private int _currentRowIndex;

        public ucPhanquyen()
        {
            InitializeComponent();
            
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

        private void ucPhanquyen_Load(object sender, EventArgs e)
        {
            loadItemsGLU();
        }

        private void gluVaiTro_EditValueChanged(object sender, EventArgs e)
        {
            var tb = TaiKhoanDAO.DanhSachTK();
            listView1.Clear();

            listView1.View = View.Details;


            listView1.Columns.Add("Tên Tài Khoản");
            
            listView1.Columns[0].Width = 145;
            
            listView1.GridLines = true;

            listView1.FullRowSelect = true;
            foreach (DataRow row in tb.Rows)
            {
                if (String.Compare(gluVaiTro.EditValue.ToString(), row["VaiTro"].ToString(), true) == 0)
                    listView1.Items.Add(row["TenTK"].ToString());
            }
            var ls= PhanQuyenDAO.GetList(int.Parse(gluVaiTro.EditValue.ToString()));
            gridControl1.DataSource = ls;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void btnThemND_Click(object sender, EventArgs e)
        {
            ThemND frm = new ThemND();
            frm.ShowDialog();

    
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
        }
    }
}
