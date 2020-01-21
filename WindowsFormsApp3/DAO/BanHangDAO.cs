using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3.DAO
{
   public class BanHangDAO:DB
    {
        public DataTable DanhSachPhieuBanHang()
        {
            SqlParameter[] p =
            {

            };
            return ExecuteQuery("DanhSachPhieuBanHang", p);
        }

        public bool Insert(string MaBH, string MaKH, string TenKH, string DiaChi, string GhiChu, string DienThoai,DateTime NgayLap, string TenNV, string TenKho,int TongTien)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@MaBH",SqlDbType.Char,10),
                new SqlParameter("@MaKH",SqlDbType.Char,10),
                new SqlParameter("@TenKH",SqlDbType.NVarChar,128),
                new SqlParameter("@DiaChi",SqlDbType.NVarChar,-1),
                new SqlParameter("@GhiChu",SqlDbType.NVarChar,-1),
                new SqlParameter("@DienThoai",SqlDbType.Char,15),
                new SqlParameter("@NgayLap",SqlDbType.DateTime),
                new SqlParameter("@TenNV",SqlDbType.NVarChar,128),
                new SqlParameter("@TenKho",SqlDbType.NVarChar,128),
                new SqlParameter("@TongTien",SqlDbType.Int)


            };
            p[0].Value = MaBH;
            p[1].Value = MaKH;
            p[2].Value = TenKH;
            p[3].Value = DiaChi;
            p[4].Value = GhiChu;
            p[5].Value = DienThoai;
            p[6].Value = NgayLap;
            p[7].Value = TenNV;
            p[8].Value = TenKho;
            p[9].Value = TongTien;
            return ExecuteNonQuery("PhieuBanHangInsert", p) > 0;
        }
        
    }
}
