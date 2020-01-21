using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3.DAO
{
   public class CTPhieuBanHangDAO:DB
    {
        public DataTable DanhSachKho()
        {
            SqlParameter[] p =
            {

            };
            return ExecuteQuery("DanhSachCT_PhieuBanHang", p);
        }
        public bool Insert(string MaPBH, string MaHang, string TenHang, string TenDVT,int SoLuong,int DonGia,int ThanhTien)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@MaPBH",SqlDbType.Char,10),
                new SqlParameter("@MaHang",SqlDbType.Char,10),
                new SqlParameter("@TenHang",SqlDbType.NVarChar,128),
                new SqlParameter("@TenDVT",SqlDbType.NVarChar,128),
                new SqlParameter("@SoLuong",SqlDbType.Int),
                new SqlParameter("@DonGia",SqlDbType.Int),
                new SqlParameter("@ThanhTien",SqlDbType.Int),
            };
            p[0].Value = MaPBH;
            p[1].Value = MaHang;
            p[2].Value = TenHang;
            p[3].Value = TenDVT;
            p[4].Value = SoLuong;
            p[5].Value = DonGia;
            p[6].Value = ThanhTien;
            return ExecuteNonQuery("CT_PhieuInsert", p) > 0;
        }
        //public bool Update(string MaKho, string TenKho, string DiaChiKho, string DTKho, string ghichu, bool ConQuanLy)
        //{
        //    SqlParameter[] p =
        //    {
        //        new SqlParameter("@MaKho",SqlDbType.Char,10),
        //        new SqlParameter("@TenKho",SqlDbType.NVarChar,128),
        //        new SqlParameter("@DiaChiKho",SqlDbType.NVarChar,-1),
        //        new SqlParameter("@DTKho",SqlDbType.Char,15),
        //        new SqlParameter("@ghichu",SqlDbType.Char,-1),
        //        new SqlParameter("@ConQuanLy",SqlDbType.Bit),
        //    };
        //    p[0].Value = MaKho;
        //    p[1].Value = TenKho;
        //    p[2].Value = DiaChiKho;
        //    p[3].Value = DTKho;
        //    p[4].Value = ghichu;
        //    p[5].Value = ConQuanLy;
        //    return ExecuteNonQuery("KhoUpdate", p) > 0;
        //}
        //public bool Delete(string MaKho)
        //{
        //    SqlParameter[] p =
        //    {
        //         new SqlParameter("@MaKho",SqlDbType.Char,10),

        //    };
        //    p[0].Value = MaKho;

        //    return ExecuteNonQuery("KhoVienDelete", p) > 0;
        //}
    }
}
