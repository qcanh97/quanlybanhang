using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3.DAO
{
    class ThongTinDAO:DB
    {
        public DataTable ThongTin()
        {
            SqlParameter[] p =
            {

            };
            return ExecuteQuery("dsthongtin", p);
        }
        public bool Update(string TenDV, string DiaChi, string DienThoai, string fax, string web, string email, string LinhVuc, string MaSoThue, string GPKD)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@TenDV",SqlDbType.NVarChar,-1),
                new SqlParameter("@DiaChi",SqlDbType.NVarChar,-1),
                new SqlParameter("@DienThoai",SqlDbType.NVarChar,15),
                new SqlParameter("@fax",SqlDbType.NVarChar,32),
                new SqlParameter("@web",SqlDbType.NVarChar,64),
                new SqlParameter("@email",SqlDbType.NVarChar,64),
                new SqlParameter("@LinhVuc",SqlDbType.NVarChar,64),
                new SqlParameter("@MaSoThue",SqlDbType.NVarChar,32),
                new SqlParameter("@GPKD",SqlDbType.NVarChar,32),
                
            };
            p[0].Value = TenDV;
            p[1].Value = DiaChi;
            p[2].Value = DienThoai;
            p[3].Value = fax;
            p[4].Value = web;
            p[5].Value = email;
            p[6].Value = LinhVuc;
            p[7].Value = MaSoThue;
            p[8].Value = GPKD;
            return ExecuteNonQuery("updatett", p) > 0;
        }
    }
}
