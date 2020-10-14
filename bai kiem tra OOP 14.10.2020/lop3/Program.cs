using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lop3
{
    class Program
    {
        private static List<HangHoa> a = new List<HangHoa>();

        private static HangHoa AddProduct()
        {
            Console.Write("Nhap ten hang: ");
            string ten = Console.ReadLine();
            Console.Write("Nhap so luong: ");
            double soluong = double.Parse(Console.ReadLine());
            Console.Write("Nhap gia: ");
            double gia = double.Parse(Console.ReadLine());
            HangHoa tam = new HangHoa(ten, soluong, gia);
            return tam;
        }
        private static void DisplayAll()
        {
            Console.WriteLine($"{"TEN HANG",15}{"SO LUONG",15}{"GIA",15}{"TONG TIEN",15}");
            for (int i = 0; i < a.Count; i++)
                Console.WriteLine(a[i].ToString());
        }

        private static bool EditProduct()
        {
            Console.Write("Nhap ten hang can sua: ");
            string ten = Console.ReadLine();
            for (int i = 0; i < a.Count; i++)
            {
                if(a[i].Ten == ten)
                {
                    HangHoa tam = new HangHoa();
                    tam = AddProduct();
                    a[i] = tam;
                    Console.WriteLine($"Da cap nhat hang hoa co ten {ten}");
                    return true;
                }
            }
            Console.WriteLine($"Khong ton tai hang hoa co ten {ten}");
            return false;
        }

        private static bool DeleteProduct()
        {
            Console.Write("Nhap ten hang can xoa: ");
            string ten = Console.ReadLine();
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i].Ten == ten)
                {
                    a.Remove(a[i]);
                    Console.WriteLine($"Da xoa hang hoa co ten {ten}");
                    return true;
                }
            }
            Console.WriteLine($"Khong ton tai hang hoa co ten {ten}");
            return false;
        }

        static int Main(string[] args)
        {
            Console.WriteLine("MENU");
            Console.WriteLine("1. Nhap thong tin hang");
            Console.WriteLine("2. Hien thi danh sach");
            Console.WriteLine("3. Cap nhat thong tin hang");
            Console.WriteLine("4. Xoa mot mat hang");
            Console.WriteLine("5. Thoat");

            while(true)
            {
                Console.Write("\nNhap lua chon: ");
                string chon = Console.ReadLine();
                switch (chon)
                {
                    case "1":
                        a.Add(AddProduct());
                        break;
                    case "2":
                        DisplayAll();
                        break;
                    case "3":
                        EditProduct();
                        break;
                    case "4":
                        DeleteProduct();
                        break;
                    case "5":
                        return 0;
                    default:
                        Console.WriteLine("Khong hop le");
                        break;
                }
            }
        }
    }
}
