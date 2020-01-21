using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3.DAO
{
    public  class BoPhanDAO:DB    
    {
        public DataTable DanhSachBP()
        {
            SqlParameter[] p =
            {

            };
            return ExecuteQuery("DanhSachBP", p);
        }
        //thêm mới
        public bool Insert(string MaBP,string TenNV, string GhiChu, bool ConQuanLy)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@MaBP",SqlDbType.Char,10),
                new SqlParameter("@TenBP",SqlDbType.NVarChar,128),
                new SqlParameter("@GhiChu",SqlDbType.NVarChar,-1),            
                new SqlParameter("@ConQuanLy",SqlDbType.Bit),
            };
            p[0].Value = MaBP;
            p[1].Value = TenNV;
            p[2].Value = GhiChu;            
            p[3].Value = ConQuanLy;
            return ExecuteNonQuery("BPInsert", p) > 0;
        }

        public bool Update(string MaBP, string TenNV, string GhiChu, bool ConQuanLy)
        {
            SqlParameter[] p =
            {
                 new SqlParameter("@MaBP",SqlDbType.Char,10),
                new SqlParameter("@TenBP",SqlDbType.NVarChar,128),
                new SqlParameter("@GhiChu",SqlDbType.NVarChar,-1),
                new SqlParameter("@ConQuanLy",SqlDbType.Bit),
            };
            p[0].Value = MaBP;
            p[1].Value = TenNV;
            p[2].Value = GhiChu;
            p[3].Value = ConQuanLy;
            return ExecuteNonQuery("BPUpdate", p) > 0;
        }
        public bool Delete(string MaBP)
        {
            SqlParameter[] p =
            {
                 new SqlParameter("@MaBP",SqlDbType.Char,10),

            };
            p[0].Value = MaBP;

            return ExecuteNonQuery("BPDelete", p) > 0;
        }
    }
}
