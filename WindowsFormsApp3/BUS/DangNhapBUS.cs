using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp3.DAO;
using WindowsFormsApp3.DTO;

namespace WindowsFormsApp3.BUS
{
    class DangNhapBUS
    {
        DangNhapDAO dangNhapDAO = new DangNhapDAO();
        public DangNhapDTO dangNhap(string userName,string PassWord)
        {
            if (PassWord.Length <= 2) return null;
            return dangNhapDAO.DangNhap(userName, PassWord);
        }
    }
} 
