using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3.DAO
{
    class TaiKhoanDAO:DB
    {
        public bool Doimk(int MaTK, string MatKhauCu, string MatKhauMoi)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@MaTK",SqlDbType.Int),
                new SqlParameter("@MatKhauCu",SqlDbType.NVarChar,50),
                new SqlParameter("@MatKhauMoi",SqlDbType.NVarChar,50),                
            };
            p[0].Value = MaTK;
            p[1].Value = MatKhauCu;
            p[2].Value = MatKhauMoi;
          
            return ExecuteNonQuery("DoiMK", p) > 0;
        }
        public DataTable DanhSachTK()
        {
            SqlParameter[] p =
            {

            };
            return ExecuteQuery("dsTaiKhoan", p);
        }

        public bool Insert(string TenTK, string MatKhauTK, string Ten, int VaiTro)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@TenTK",SqlDbType.NVarChar,50),
                new SqlParameter("@MatKhauTK",SqlDbType.NVarChar,5),
                new SqlParameter("@Ten",SqlDbType.NVarChar,100),
                new SqlParameter("@VaiTro",SqlDbType.Int),
            };
            p[0].Value = TenTK;
            p[1].Value = MatKhauTK;
            p[2].Value = Ten;
            p[3].Value = VaiTro;
            return ExecuteNonQuery("TaoTaiKhoan", p) > 0;
        }
    }
}
