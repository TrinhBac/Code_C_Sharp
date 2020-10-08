using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_OOP
{
    //public static string Indent(string text ,int count)
    //{
    //    return PadRight(count - text.Length);
    //}
    class Program
    {
        static void Main(string[] args)
        {
            NhanVien nv1 = new NhanVien();
            Console.Write("Nhap ma NV: ");
            nv1.MaNhanVien = Console.ReadLine();
            Console.Write("Nhap ten NV: ");
            nv1.TenNhanVien = Console.ReadLine();
            Console.Write("Nhap luong NV: ");
            nv1.LuongMotGio = double.Parse(Console.ReadLine());
            Console.Write("Nhap so gio NV: ");
            nv1.SoGioLam = double.Parse(Console.ReadLine());
            Console.WriteLine("{0}", nv1.Xuat());
            NhanVien nv2 = new NhanVien("002", "Anh Bac", 2000, 5);
            Console.WriteLine("{0}\t{1}\t\t{2}\t{3}\t{4}", nv2.MaNhanVien, nv2.TenNhanVien, nv2.LuongMotGio, nv2.SoGioLam, nv2.TinhLuong());
        }
    }
}
