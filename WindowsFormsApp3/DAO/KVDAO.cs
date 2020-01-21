using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3.DAO
{
   public class KVDAO:DB
    {
        public DataTable DanhSachKV()
        {
            SqlParameter[] p =
            {

            };
            return ExecuteQuery("DanhSachKV", p);
        }

        public bool Insert(string MaKV, string TenKV, string ghichu, bool ConQuanLy)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@MaKV",SqlDbType.Char,10),
                new SqlParameter("@TenKV",SqlDbType.NVarChar,128),
                new SqlParameter("@ghichu",SqlDbType.Char,-1),
                new SqlParameter("@ConQuanLy",SqlDbType.Bit),
            };
            p[0].Value = MaKV;
            p[1].Value = TenKV;           
            p[2].Value = ghichu;
            p[3].Value = ConQuanLy;
            return ExecuteNonQuery("KVInsert", p) > 0;
        }
        public bool Update(string MaKV, string TenKV, string ghichu, bool ConQuanLy)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@MaKV",SqlDbType.Char,10),
                new SqlParameter("@TenKV",SqlDbType.NVarChar,128),
                new SqlParameter("@ghichu",SqlDbType.Char,-1),
                new SqlParameter("@ConQuanLy",SqlDbType.Bit),
            };
            p[0].Value = MaKV;
            p[1].Value = TenKV;
            p[2].Value = ghichu;
            p[3].Value = ConQuanLy;
            return ExecuteNonQuery("KVUpdate", p) > 0;
        }
        public bool Delete(string MaKV)
        {
            SqlParameter[] p =
            {
                 new SqlParameter("@MaKV",SqlDbType.Char,10),

            };
            p[0].Value = MaKV;

            return ExecuteNonQuery("KVDelete", p) > 0;
        }
    }
}
