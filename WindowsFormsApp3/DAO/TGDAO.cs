using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3.DAO
{
  public  class TGDAO:DB
    {
        public DataTable DanhSachKV()
        {
            SqlParameter[] p =
            {

            };
            return ExecuteQuery("DanhSachTG", p);
        }

        public bool Insert(string MaTG, string TenTG, int TGQuyDoi, bool ConQuanLy)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@MaTG",SqlDbType.Char,10),
                new SqlParameter("@TenTG",SqlDbType.NVarChar,128),
                new SqlParameter("@TGQuyDoi",SqlDbType.Int),
                new SqlParameter("@ConQuanLy",SqlDbType.Bit),
            };
            p[0].Value = MaTG;
            p[1].Value = TenTG;
            p[2].Value = TGQuyDoi;
            p[3].Value = ConQuanLy;
            return ExecuteNonQuery("TGInsert", p) > 0;
        }
        public bool Update(string MaTG, string TenTG, int TGQuyDoi, bool ConQuanLy)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@MaTG",SqlDbType.Char,10),
                new SqlParameter("@TenTG",SqlDbType.NVarChar,128),
                new SqlParameter("@TGQuyDoi",SqlDbType.Int),
                new SqlParameter("@ConQuanLy",SqlDbType.Bit),
            };
            p[0].Value = MaTG;
            p[1].Value = TenTG;
            p[2].Value = TGQuyDoi;
            p[3].Value = ConQuanLy; 
            return ExecuteNonQuery("TGUpdate", p) > 0;
        }
        public bool Delete(string MaTG)
        {
            SqlParameter[] p =
            {
                 new SqlParameter("@MaTG",SqlDbType.Char,10),

            };
            p[0].Value = MaTG   ;

            return ExecuteNonQuery("TGDelete", p) > 0;
        }
    }
}
