using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3.DTO
{
   public class HangHoaDTO
    {
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string DonVi { get; set; }
        public int GiaMua { get; set; }
        public int GiaBan { get; set; }
        public string NhomHang { get; set; }
        public string TenKho { get; set; }
        public string NCC { get; set; }
        public bool ConQuanLy { get; set; }
        public int TonKho { get; set; }
    }
}
