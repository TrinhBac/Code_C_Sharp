using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            NhanVien nv1 = new NhanVien();
            nv1.MaNhanVien = "001";
            nv1.TenNhanVien = "Trinh Van Bac Bac";
            nv1.LuongMotGio = 1000;
            nv1.SoGioLam = 3;
            Console.WriteLine("{0}", nv1.Xuat());
            NhanVien nv2 = new NhanVien();
            nv2.Nhap("002", "Anh Bac", 2000, 5);
            Console.WriteLine("{0}\t{1}\t\t{2}\t{3}\t{4}", nv2.MaNhanVien, nv2.TenNhanVien, nv2.LuongMotGio, nv2.SoGioLam, nv2.TinhLuong());
        }
    }
}
