using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3.DAO
{
   public class KhachHangDAO:DB
    {
        public DataTable DanhSacKH()
        {
            SqlParameter[] p =
            {

            };
            return ExecuteQuery("DanhSachKH", p);
        }
        public bool Insert(string MaKH, string TenKH, string TenKV, string diachiKH, string DTKH, string EmailKH, bool ConQuanLy)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@MaKH",SqlDbType.Char,10),
                new SqlParameter("@TenKH",SqlDbType.NVarChar,128),
                new SqlParameter("@TenKV",SqlDbType.NVarChar,128),
                new SqlParameter("@diachiKH",SqlDbType.NVarChar,-1),
                new SqlParameter("@DTKH",SqlDbType.Char,15),
                new SqlParameter("@EmailKH",SqlDbType.Char,64),
                new SqlParameter("@ConQuanLy",SqlDbType.Bit),
            };
            p[0].Value = MaKH;
            p[1].Value = TenKH;
            p[2].Value = TenKV;
            p[3].Value = diachiKH;
            p[4].Value = DTKH;
            p[5].Value = EmailKH;
            p[6].Value = ConQuanLy;
            return ExecuteNonQuery("KHInsert", p) > 0;
        }
        public bool Update(string MaKH, string TenKH, string TenKV, string diachiKH, string DTKH, string EmailKH, bool ConQuanLy)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@MaKH",SqlDbType.Char,10),
                new SqlParameter("@TenKH",SqlDbType.NVarChar,128),
                new SqlParameter("@TenKV",SqlDbType.NVarChar,128),
                new SqlParameter("@diachiKH",SqlDbType.NVarChar,-1),
                new SqlParameter("@DTKH",SqlDbType.Char,15),
                new SqlParameter("@EmailKH",SqlDbType.Char,64),
                new SqlParameter("@ConQuanLy",SqlDbType.Bit),
            };
            p[0].Value = MaKH;
            p[1].Value = TenKH;
            p[2].Value = TenKV;
            p[3].Value = diachiKH;
            p[4].Value = DTKH;
            p[5].Value = EmailKH;
            p[6].Value = ConQuanLy;
            return ExecuteNonQuery("KHUpdate", p) > 0;
        }
        public bool Delete(string MaKH)
        {
            SqlParameter[] p =
            {
                 new SqlParameter("@MaKH",SqlDbType.Char,10),

            };
            p[0].Value = MaKH;

            return ExecuteNonQuery("KHDelete", p) > 0;
        }
    }
}
