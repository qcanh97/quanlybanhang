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

namespace WindowsFormsApp3.Module
{
    public partial class ucHoaDonNH : DevExpress.XtraEditors.XtraUserControl
    {
        public ucHoaDonNH()
        {
            InitializeComponent();
        }
        QLBHEntities1 _da = new QLBHEntities1();
        List<PhieuMuaHang> phieu;
        List<CT_PhieuNhapHang> CT_phieu;
        private void loadDate()
        {
            phieu = new List<PhieuMuaHang>();
            CT_phieu = new List<CT_PhieuNhapHang>();
            phieu = _da.PhieuMuaHangs.ToList();
            CT_phieu = _da.CT_PhieuNhapHang.ToList();
            gridControl1.DataSource = phieu;
        }

        private void ucHoaDonNH_Load(object sender, EventArgs e)
        {
            loadDate();

        }

        private void gridView1_MasterRowEmpty(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs e)
        {
            GridView view = sender as GridView;
            PhieuMuaHang Phieu = view.GetRow(e.RowHandle) as PhieuMuaHang;
            if (Phieu != null)
            {
                e.IsEmpty = !CT_phieu.Any(x => x.MaMH == Phieu.MaMH);
            }
        }

        private void gridView1_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            GridView view = sender as GridView;
            PhieuMuaHang Phieu = view.GetRow(e.RowHandle) as PhieuMuaHang;
            if (Phieu != null)
            {
                e.ChildList = CT_phieu.Where(x => x.MaMH == Phieu.MaMH).ToList();
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
