using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3.DAO
{
   public class HangHoaDAO:DB
    {
        public DataTable DanhSachHangHoa()
        {
            SqlParameter[] p =
            {

            };
            return ExecuteQuery("DanhSachHang", p);
        }
        public bool Insert(string MaHang, string TenHang, string DonVi,int GiaMua,int GiaBan,string NhomHang, string TenKho,string NCC, bool ConQuanLy)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@MaHang",SqlDbType.Char,10),
                new SqlParameter("@TenHang",SqlDbType.NVarChar,128),
                new SqlParameter("@DonVi",SqlDbType.NVarChar,32),
                new SqlParameter("@GiaMua",SqlDbType.Int),
                new SqlParameter("@GiaBan",SqlDbType.Int),
                new SqlParameter("@NhomHang",SqlDbType.NVarChar,128),
                new SqlParameter("@TenKho",SqlDbType.NVarChar,128),
                new SqlParameter("@NCC",SqlDbType.NVarChar,128),
                new SqlParameter("@ConQuanLy",SqlDbType.Bit),
            };
            p[0].Value = MaHang;
            p[1].Value = TenHang;
            p[2].Value = DonVi;
            p[3].Value = GiaMua;
            p[4].Value = GiaBan;
            p[5].Value = NhomHang;
            p[6].Value = TenKho;
            p[7].Value = NCC;
            p[8].Value = ConQuanLy;
            return ExecuteNonQuery("HangInsert", p) > 0;
        }
        public bool Update(string MaHang, string TenHang, string DonVi, int GiaMua, int GiaBan, string NhomHang, string TenKho, string NCC, bool ConQuanLy)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@MaHang",SqlDbType.Char,10),
                new SqlParameter("@TenHang",SqlDbType.NVarChar,128),
                new SqlParameter("@DonVi",SqlDbType.NVarChar,32),
                new SqlParameter("@GiaMua",SqlDbType.Int),
                new SqlParameter("@GiaBan",SqlDbType.Int),
                new SqlParameter("@NhomHang",SqlDbType.NVarChar,128),
                new SqlParameter("@TenKho",SqlDbType.NVarChar,128),
                new SqlParameter("@NCC",SqlDbType.NVarChar,128),
                new SqlParameter("@ConQuanLy",SqlDbType.Bit),
            };
            p[0].Value = MaHang;
            p[1].Value = TenHang;
            p[2].Value = DonVi;
            p[3].Value = GiaMua;
            p[4].Value = GiaBan;
            p[5].Value = NhomHang;
            p[6].Value = TenKho;
            p[7].Value = NCC;
            p[8].Value = ConQuanLy;
            return ExecuteNonQuery("HangUpdate", p) > 0;
        }
        public bool Delete(string MaHang)
        {
            SqlParameter[] p =
            {
                 new SqlParameter("@MaHang",SqlDbType.Char,10),

            };
            p[0].Value = MaHang;

            return ExecuteNonQuery("HangDelete", p) > 0;
        }
    }
}
