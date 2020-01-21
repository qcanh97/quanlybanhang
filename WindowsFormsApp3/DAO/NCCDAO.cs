using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3.DAO
{
   public class NCCDAO:DB
    {
        public DataTable DanhSachNCC()
        {
            SqlParameter[] p =
            {

            };
            return ExecuteQuery("DanhSachNCC", p);
        }

        public bool Insert(string MaNCC,string TenNCC,string TenKV,string diachiNCC,string DTNCC,string EmailNCC,bool ConQuanLy)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@MaNCC",SqlDbType.Char,10),
                new SqlParameter("@TenNCC",SqlDbType.NVarChar,128),
                new SqlParameter("@TenKV",SqlDbType.NVarChar,128),
                new SqlParameter("@diachiNCC",SqlDbType.NVarChar,-1),
                new SqlParameter("@DTNCC",SqlDbType.Char,15),
                new SqlParameter("@EmailNCC",SqlDbType.Char,64),
                new SqlParameter("@ConQuanLy",SqlDbType.Bit),
            };
            p[0].Value = MaNCC;
            p[1].Value = TenNCC;
            p[2].Value = TenKV;
            p[3].Value = diachiNCC;
            p[4].Value = DTNCC;
            p[5].Value = EmailNCC;
            p[6].Value = ConQuanLy;
            return ExecuteNonQuery("NCCInsert", p) > 0;
        }
        public bool Update(string MaNCC, string TenNCC, string TenKV, string diachiNCC, string DTNCC, string EmailNCC, bool ConQuanLy)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@MaNCC",SqlDbType.Char,10),
                new SqlParameter("@TenNCC",SqlDbType.NVarChar,128),
                new SqlParameter("@TenKV",SqlDbType.NVarChar,128),
                new SqlParameter("@diachiNCC",SqlDbType.NVarChar,-1),
                new SqlParameter("@DTNCC",SqlDbType.Char,15),
                new SqlParameter("@EmailNCC",SqlDbType.Char,64),
                new SqlParameter("@ConQuanLy",SqlDbType.Bit),
            };
            p[0].Value = MaNCC;
            p[1].Value = TenNCC;
            p[2].Value = TenKV;
            p[3].Value = diachiNCC;
            p[4].Value = DTNCC;
            p[5].Value = EmailNCC;
            p[6].Value = ConQuanLy;
            return ExecuteNonQuery("NCCUpdate", p) > 0;
        }
        public bool Delete(string MaNCC)
        {
            SqlParameter[] p =
            {
                 new SqlParameter("@MaNCC",SqlDbType.Char,10),

            };
            p[0].Value = MaNCC;

            return ExecuteNonQuery("NCCDelete", p) > 0;
        }
    }
}
