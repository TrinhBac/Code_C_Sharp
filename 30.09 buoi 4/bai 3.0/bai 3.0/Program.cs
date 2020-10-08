using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace bai_3
{
    class Program
    {
        private static List<SanPham> ListProduct = new List<SanPham>();
        private static string filePath = @"D:\C sharp\30.09 buoi 4\bai 3.0\bai 3.0\Data.txt";

        static void DisplayListProduct()
        {
            Console.WriteLine("Danh sach SP:");
            string str = $"{"MaSanPham",9} {"TenSanPham",20} " +
                        $"{"MauSac",15} {"SoLuongSanPham",15} {"GiaBanSanPham",15}";
            Console.WriteLine(str);
            for (int i = 0; i < ListProduct.Count(); i++)
            {
                string strSp = $"{ListProduct[i].MaSanPham,9} {ListProduct[i].TenSanPham,20} " +
                    $"{ListProduct[i].MauSac,15} {ListProduct[i].SoLuongSanPham,15} {ListProduct[i].GiaBanSanPham,15}\n";
                Console.WriteLine(strSp);
            }
        }

        static private SanPham AddProduct()
        {
            string MaSp;
            string TenSp;
            string MauSac;
            double SoLuong;
            double GiaBan;

            Console.Write("Nhap ma Sp: ");
            MaSp = Console.ReadLine();
            Console.Write("Nhap ten Sp: ");
            TenSp = Console.ReadLine();
            Console.Write("Nhap mau sac: ");
            MauSac = Console.ReadLine();
            Console.Write("Nhap so luong: ");
            SoLuong = Double.Parse(Console.ReadLine());
            Console.Write("Nhap gia ban: ");
            GiaBan = Double.Parse(Console.ReadLine());
            SanPham SpMoi = new SanPham(MaSp, TenSp, MauSac, SoLuong, GiaBan);
            return SpMoi;
        }

        static private bool DeleteProduct()
        {
            string MaSp;
            Console.Write("Nhap ma Sp can xoa: ");
            MaSp = Console.ReadLine();
            for (int i = 0; i < ListProduct.Count(); i++)
            {
                if (ListProduct[i].MaSanPham == MaSp)
                {
                    ListProduct.Remove(ListProduct[i]);
                    Console.WriteLine($"Da xoa SP co ma: {MaSp}");
                    DisplayListProduct();
                    return true;
                }
            }
            Console.WriteLine($"Khong ton tai SP co ma: {MaSp} !");
            return false;
        }

        static private bool EditProduct()
        {
            string MaSp;
            Console.Write("Nhap ma Sp can tiem: ");
            MaSp = Console.ReadLine();
            for (int i = 0; i < ListProduct.Count(); i++)
            {
                if (ListProduct[i].MaSanPham == MaSp)
                {
                    Console.WriteLine("Nhap thong tin moi");
                    ListProduct[i] = AddProduct();
                    Console.WriteLine($"Da sua SP co ma: {MaSp}");
                    DisplayListProduct();
                    return true;
                }
            }
            Console.WriteLine($"Khong tim thay SP co ma: {MaSp}");
            return false;
        }

        static private string FindProduct()
        {
            string MaSp;
            Console.Write("Nhap ma Sp can tiem: ");
            MaSp = Console.ReadLine();
            for (int i = 0; i < ListProduct.Count(); i++)
            {
                if (ListProduct[i].MaSanPham == MaSp)
                {
                    Console.WriteLine($"Thong tin SP co ma {MaSp} la:");
                    Console.WriteLine(ListProduct[i].ToString());
                    return MaSp;
                }
            }
            Console.WriteLine($"Khong tim thay SP co ma: {MaSp}");
            return "Not found";
        }

        private static void readFile()
        {
            if (File.Exists(filePath))
            {
                string str = File.ReadAllText(filePath);
                Console.WriteLine(str);
            }
            else
            {
                Console.WriteLine("Duong dan khong ton tai trong he thong!");
            }
        }

        private static void writeData()
        {
            if(File.Exists(Program.filePath))
            {
                for (int i = 0; i < ListProduct.Count(); i++)
                {
                    string str = $"{ListProduct[i].MaSanPham,9} {ListProduct[i].TenSanPham,20} " +
                        $"{ListProduct[i].MauSac,15} {ListProduct[i].SoLuongSanPham,15} {ListProduct[i].GiaBanSanPham,15}\n";
                    File.AppendAllText(filePath, str);
                }
                Console.WriteLine("Da ghi du lieu!");
            }
            else
            {
                Console.WriteLine("Duong dan khong ton tai trong he thong!");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("MAIN MENU:");
            Console.WriteLine("1. Nhap SP moi");
            Console.WriteLine("2. Xoa SP");
            Console.WriteLine("3. Sua SP");
            Console.WriteLine("4. Tiem kiem SP");
            Console.WriteLine("5. Hien thi DS sp");
            Console.WriteLine("6. Doc du lieu trong file");
            Console.WriteLine("7. Ghi du lieu vao file");
            Console.WriteLine("8. Thoat");

            while (true)
            {
                Console.Write("\n--> Nhap lua chon: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ListProduct.Add(Program.AddProduct());
                        break;
                    case "2":
                        DeleteProduct();
                        break;
                    case "3":
                        EditProduct();
                        break;
                    case "4":
                        FindProduct();
                        break;
                    case "5":
                        DisplayListProduct();
                        break;
                    case "6":
                        readFile();
                        break;
                    case "7":
                        writeData();
                        break;
                    case "8":
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Lua chon khong hop le !");
                        Console.ResetColor();
                        break;
                }
            }
        }
    }
}
