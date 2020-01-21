using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    public class NhanVien:DB
    {

        public DataTable DanhSachNhanVien()
        {
            SqlParameter[] p =
            {

            };
            return ExecuteQuery("DanhSachNhanVien", p);
        }
        //thêm mới
        public bool Insert(string TenNV, string DiaChiNV,string DTNV,string EmailNV,bool ConQuanLy)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@TenNV",SqlDbType.NVarChar,128),
                new SqlParameter("@DiaChiNV",SqlDbType.NVarChar,128),
                new SqlParameter("@DTNV",SqlDbType.Char,15),
                new SqlParameter("@EmailNV",SqlDbType.Char,64),
                new SqlParameter("@ConQuanLy",SqlDbType.Bit),
            };
            p[0].Value = TenNV;
            p[1].Value = DiaChiNV;
            p[2].Value = DTNV;
            p[3].Value = EmailNV;
            p[4].Value = ConQuanLy;
            return ExecuteNonQuery("NhanVienInsert", p)>0;
        }

        public bool Update(string MaNV, string TenNV, string DiaChiNV, string DTNV, string EmailNV, bool ConQuanLy)
        {
            SqlParameter[] p =
            {
                 new SqlParameter("@MaNV",SqlDbType.Int),
                new SqlParameter("@TenNV",SqlDbType.NVarChar,128),
                new SqlParameter("@DiaChiNV",SqlDbType.NVarChar,-1),
                new SqlParameter("@DTNV",SqlDbType.Char,15),
                new SqlParameter("@EmailNV",SqlDbType.Char,64),
                new SqlParameter("@ConQuanLy",SqlDbType.Bit),
            };
            p[0].Value = MaNV;
            p[1].Value = TenNV;
            p[2].Value = DiaChiNV;
            p[3].Value = DTNV;
            p[4].Value = EmailNV;
            p[5].Value = ConQuanLy;
            return ExecuteNonQuery("NhanVienUpdate", p) > 0;
        }
        public bool Delete(string MaNV)
        {
            SqlParameter[] p =
            {
                 new SqlParameter("@MaNV",SqlDbType.Int),
              
            };
            p[0].Value = MaNV;
           
            return ExecuteNonQuery("NhanVienDelete", p) > 0;
        }
    }
}
