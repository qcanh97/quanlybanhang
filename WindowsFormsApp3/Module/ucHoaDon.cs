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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout.Customization;

namespace WindowsFormsApp3.Module
{
    public partial class ucHoaDon : DevExpress.XtraEditors.XtraUserControl
    {
        QLBHEntities1 _da = new QLBHEntities1();
        List<PhieuBanHang> phieu;
        List<CT_PhieuBanHang> CT_phieu;
        public ucHoaDon()
        {
            InitializeComponent();
        }
        private void loadDate()
        {
            phieu = new List<PhieuBanHang>();
            CT_phieu = new List<CT_PhieuBanHang>();
            phieu = _da.PhieuBanHangs.ToList();
            CT_phieu = _da.CT_PhieuBanHang.ToList();
            gridControl1.DataSource = phieu;
        }

        private void ucHoaDon_Load(object sender, EventArgs e)
        {
            loadDate();
        }

        private void gridView1_MasterRowEmpty(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs e)
        {
            GridView view = sender as GridView;
            PhieuBanHang Phieu = view.GetRow(e.RowHandle) as PhieuBanHang;
            if (Phieu != null)
            {
                e.IsEmpty = !CT_phieu.Any(x => x.MaPBH == Phieu.MaBH);
            }
        }

        private void gridView1_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            GridView view = sender as GridView;
            PhieuBanHang Phieu = view.GetRow(e.RowHandle) as PhieuBanHang;
            if (Phieu != null)
            {
                e.ChildList= CT_phieu.Where(x => x.MaPBH == Phieu.MaBH).ToList();
            }
        }

        private void gridView1_MasterRowGetRelationCount(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs e)
        {
           e.RelationCount = 1;
        }

        private void gridView1_MasterRowGetRelationName(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "Chi Tiết Phiếu";
        }
    }
}
