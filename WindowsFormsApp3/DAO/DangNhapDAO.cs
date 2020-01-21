using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp3.DTO;

namespace WindowsFormsApp3.DAO
{
    public class DangNhapDAO:DB
    {
        //user infor
        public DangNhapDTO DangNhap(string TenTK, string MatKhauTK)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@TenTK",SqlDbType.NVarChar,50),
                new SqlParameter("@MatKhauTK",SqlDbType.NVarChar,50),
            };
            p[0].Value = TenTK;
            p[1].Value = MatKhauTK;
            var tb= ExecuteQuery("LayVaiTro", p);
            if (tb != null && tb.Rows.Count > 0)
            {
                return new DangNhapDTO()
                {
                    MaTK = int.Parse(tb.Rows[0]["MaTK"].ToString()),
                    VaiTro = int.Parse(tb.Rows[0]["VaiTro"].ToString()),
                };
            }
            else
                return null;
        }
    }
}
