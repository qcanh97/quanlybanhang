using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp3.DAO;
using WindowsFormsApp3.DTO;

namespace WindowsFormsApp3.BUS
{
  public  class PhanQuyenBUS
    {
        PhanQuyenDAO PhanQuyenDAO = new PhanQuyenDAO();
        public List<RoleForm> GetList(int MaBPQ)
        {
            return PhanQuyenDAO.GetList(MaBPQ);
        }
    }
}
