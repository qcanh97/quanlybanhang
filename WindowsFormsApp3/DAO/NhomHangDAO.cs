using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp3.DAO
{
    public class NhomHangDAO:DB
    {
        public DataTable DanhSachNH()
        {
            SqlParameter[] p =
            {

            };
            return ExecuteQuery("DanhSachNH", p);
        }

        public bool Insert(string MaNH, string TenNH, string ghichu, bool ConQuanLy)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@MaNH",SqlDbType.Char,10),
                new SqlParameter("@TenNH",SqlDbType.NVarChar,128),
                new SqlParameter("@ghichu",SqlDbType.Char,-1),
                new SqlParameter("@ConQuanLy",SqlDbType.Bit),
            };
            p[0].Value = MaNH;
            p[1].Value = TenNH;
            p[2].Value = ghichu;
            p[3].Value = ConQuanLy;
            return ExecuteNonQuery("NHInsert", p) > 0;
        }
        public bool Update(string MaNH, string TenNH, string ghichu, bool ConQuanLy)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@MaNH",SqlDbType.Char,10),
                new SqlParameter("@TenNH",SqlDbType.NVarChar,128),
                new SqlParameter("@ghichu",SqlDbType.Char,-1),
                new SqlParameter("@ConQuanLy",SqlDbType.Bit),
            };
            p[0].Value = MaNH;
            p[1].Value = TenNH;
            p[2].Value = ghichu;
            p[3].Value = ConQuanLy;
            return ExecuteNonQuery("NHUpdate", p) > 0;
        }
        public bool Delete(string MaNH)
        {
            SqlParameter[] p =
            {
                 new SqlParameter("@MaNH",SqlDbType.Char,10),

            };
            p[0].Value = MaNH;

            return ExecuteNonQuery("NHDelete", p) > 0;
        }

    }
}
