using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3.DAO
{
  public class MuaHangDAO:DB
    {
        public DataTable DanhSachPhieuMuaHang()
        {
            SqlParameter[] p =
            {

            };
            return ExecuteQuery("DanhSachPhieuMuaHang", p);
        }
        public bool Insert(string MaMH, string MaNCC, string TenNCC, string TenNV, string TenKho, string DiaChi, string GhiChu, string DienThoai, DateTime NgayLap,   int TongTien)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@MaMH",SqlDbType.Char,10),
                new SqlParameter("@MaNCC",SqlDbType.Char,10),
                new SqlParameter("@TenNCC",SqlDbType.NVarChar,128),
                new SqlParameter("@TenNV",SqlDbType.NVarChar,128),
                new SqlParameter("@TenKho",SqlDbType.NVarChar,128),
                new SqlParameter("@DiaChi",SqlDbType.NVarChar,-1),
                new SqlParameter("@GhiChu",SqlDbType.NVarChar,-1),
                new SqlParameter("@DienThoai",SqlDbType.Char,15),
                new SqlParameter("@NgayLap",SqlDbType.DateTime),   
                new SqlParameter("@TongTien",SqlDbType.Int)


            };
            p[0].Value = MaMH;
            p[1].Value = MaNCC;
            p[2].Value = TenNCC;
            p[3].Value = TenNV;
            p[4].Value = TenKho;
            p[5].Value = DiaChi;
            p[6].Value = GhiChu;
            p[7].Value = DienThoai;
            p[8].Value = NgayLap;
            p[9].Value = TongTien;
            return ExecuteNonQuery("PhieuMuaHangInsert", p) > 0;
        }

    }
}
