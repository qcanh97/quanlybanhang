using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3.DAO
{
  public  class CTPhieuNhapHangDAO : DB
    {
        public bool Insert(string MaMH, string MaHang, string TenHang, string TenDVT, int SoLuong, int DonGia, int ThanhTien)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@MaMH",SqlDbType.Char,10),
                new SqlParameter("@MaHang",SqlDbType.Char,10),
                new SqlParameter("@TenHang",SqlDbType.NVarChar,128),
                new SqlParameter("@TenDVT",SqlDbType.NVarChar,128),
                new SqlParameter("@SoLuong",SqlDbType.Int),
                new SqlParameter("@DonGia",SqlDbType.Int),
                new SqlParameter("@ThanhTien",SqlDbType.Int),
            };
            p[0].Value = MaMH;
            p[1].Value = MaHang;
            p[2].Value = TenHang;
            p[3].Value = TenDVT;
            p[4].Value = SoLuong;
            p[5].Value = DonGia;
            p[6].Value = ThanhTien;
            return ExecuteNonQuery("PhieuNhapHangInsert", p) > 0;
        }
    }
}
