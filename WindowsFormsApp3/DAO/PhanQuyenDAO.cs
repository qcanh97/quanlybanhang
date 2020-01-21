using DevExpress.XtraPrinting.Native;
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
    public class PhanQuyenDAO:DB
    {
        public List<RoleForm> GetList(int MAVT)
        {
            var rs = new List<RoleForm>();
            SqlParameter[] p =
            {
                new SqlParameter("@MAVT",SqlDbType.NVarChar,50),             
            };
            p[0].Value = MAVT;
            
            var tb = ExecuteQuery("LayBangPhanQuyen", p);
            foreach(DataRow row in tb.Rows)
            {
                var RoleForm = new RoleForm()
                {
                    DienGiaiVT = row["DienGiaiVT"].ToString(),
                    MaBPQ = int.Parse(row["MaBPQ"].ToString()),
                    MAVT = int.Parse(row["MAVT"].ToString()),
                    MaForm = int.Parse(row["MaForm"].ToString()),
                    TruyCap = bool.Parse(row["TruyCap"].ToString()),
                    Them = bool.Parse(row["Them"].ToString()),
                    Xoa = bool.Parse(row["Xoa"].ToString()),
                    Sua = bool.Parse(row["Sua"].ToString()),
                    Inn = bool.Parse(row["Inn"].ToString()),
                    Nhap = bool.Parse(row["Nhap"].ToString()),
                    Xuat = bool.Parse(row["Xuat"].ToString()),
                };
                rs.Add(RoleForm);
            }
            return rs;
        }
    }
}
