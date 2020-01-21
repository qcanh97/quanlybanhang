using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3.DAO
{
  public  class VaiTroDAO:DB
    {
        public DataTable DanhSachVT()
        {
            SqlParameter[] p =
            {

            };
            return ExecuteQuery("dsVaiTro", p);
        }
    }
}
