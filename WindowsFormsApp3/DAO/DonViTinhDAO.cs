using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3.DAO
{
   public class DonViTinhDAO:DB
    {
        public DataTable DanhSachDVT()
        {
            SqlParameter[] p =
            {

            };
            return ExecuteQuery("DanhSachDVT", p);
        }

        public bool Insert(string MaDVT, string TenDVT, string ghichu, bool ConQuanLy)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@MaDVT",SqlDbType.Char,10),
                new SqlParameter("@TenDVT",SqlDbType.NVarChar,128),
                new SqlParameter("@ghichu",SqlDbType.Char,-1),
                new SqlParameter("@ConQuanLy",SqlDbType.Bit),
            };
            p[0].Value = MaDVT;
            p[1].Value = TenDVT;
            p[2].Value = ghichu;
            p[3].Value = ConQuanLy;
            return ExecuteNonQuery("DVTInsert", p) > 0;
        }
        public bool Update(string MaDVT, string TenDVT, string ghichu, bool ConQuanLy)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@MaDVT",SqlDbType.Char,10),
                new SqlParameter("@TenDVT",SqlDbType.NVarChar,128),
                new SqlParameter("@ghichu",SqlDbType.Char,-1),
                new SqlParameter("@ConQuanLy",SqlDbType.Bit),
            };
            p[0].Value = MaDVT;
            p[1].Value = TenDVT;
            p[2].Value = ghichu;
            p[3].Value = ConQuanLy;
            return ExecuteNonQuery("DVTUpdate", p) > 0;
        }
        public bool Delete(string MaDVT)
        {
            SqlParameter[] p =
            {
                 new SqlParameter("@MaDVT",SqlDbType.Char,10),

            };
            p[0].Value = MaDVT;

            return ExecuteNonQuery("DVTDelete", p) > 0;
        }
    }
}
