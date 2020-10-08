using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_2
{
    class Program
    {
        //Danh sách mà mỗi p/tử có kiểu Nhân viên, có phạm vi sử dụng trong toàn class
        private static List<NhanVien> dsNhanVien = new List<NhanVien>();

        static void Main(string[] arg)
        {
            do
            {
                //Tạo menu
                Console.Clear();
                Console.WriteLine("\nMAIN MENU:");
                Console.WriteLine("\n1. Nhap nhan vien moi");
                Console.WriteLine("\n2. Hien thi danh sach");
                Console.WriteLine("\n3. Tinh luong trung binh");
                Console.WriteLine("\n4. Thoat");
                Console.Write("\nNhap vao lua chon cua ban:");
                string luaChon = Console.ReadLine();
                switch (luaChon)//kiểm tra các lựa chọn của user
                {
                    case "1":
                        Program.NhapKhachHangMoi();
                        break;
                    case "2":
                        Console.WriteLine("\n{0,-15}{1,-20}{2,-15}{3,-18}{4,-15}{5,-20}", "Ma nhan vien", "Ho ten", "Luong 1 gio", "So gio lam viec", "He so phu cap", "Tien luong");
                        XuatDanhSachNhanVien();
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.WriteLine("\nLuong trung binh= {0}",
                            TinhLuongTrungBinh());
                        Console.ReadLine();
                        break;
                    case "4":
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nBan da nhap sai lua chon. Nhan Enter de tiep tuc!");
                        Console.ReadLine();
                        Console.ResetColor();
                        break;
                }
            } while (true);
        }

        //Phương thức nhập thông tin nhân viên mới
        static private void NhapKhachHangMoi()
        {
            string maNhanVien, hoTen;
            int luong1Gio;
            double soGioLamViec, heSoPhuCap;
            //menu con cho phép chọn loại nhân viên
            Console.WriteLine("\n1. Nhan vien");
            Console.WriteLine("\n2. Quan ly");
            Console.Write("\nNhap vao lua chon cua ban:");
            string chon = Console.ReadLine();
            switch (chon)
            {
                case "1":
                    Console.Write("\nNhap ma nhan vien: ");
                    maNhanVien = Console.ReadLine();
                    Console.Write("\nNhap ten nhan vien: ");
                    hoTen = Console.ReadLine();
                    Console.Write("\nNhap luong 1 gio: ");
                    luong1Gio = int.Parse(Console.ReadLine());
                    Console.Write("\nNhap so gio lam viec: ");
                    soGioLamViec = int.Parse(Console.ReadLine());
                    //tạo đối tượng của lớp Nhân viên
                    NhanVien nhanVienMoi = new NhanVien(maNhanVien, hoTen, luong1Gio, soGioLamViec);
                    //thêm vào danh sách
                    dsNhanVien.Add(nhanVienMoi);
                    break;
                case "2":
                    Console.Write("\nNhap ma quan ly: ");
                    maNhanVien = Console.ReadLine();
                    Console.Write("\nNhap ten nhan vien: ");
                    hoTen = Console.ReadLine();
                    Console.Write("\nNhap luong 1 gio: ");
                    luong1Gio = int.Parse(Console.ReadLine());
                    Console.Write("\nNhap so gio lam viec: ");
                    soGioLamViec = double.Parse(Console.ReadLine());
                    Console.Write("\nNhap he so phu cap: ");
                    heSoPhuCap = double.Parse(Console.ReadLine());
                    //tạo đối tượng của lớp Nhân viên
                    NhanVienQuanLy quanLyMoi = new NhanVienQuanLy(maNhanVien, hoTen, luong1Gio, soGioLamViec, heSoPhuCap);
                    //thêm vào danh sách
                    dsNhanVien.Add(quanLyMoi);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nBan da nhap sai lua chon. Nhan Enter de tiep tuc!");
                    Console.ReadLine();
                    Console.ResetColor();
                    break;
            }

            Console.ReadLine();
        }
        //phương thức xuất danh sách nhân viên
        static private void XuatDanhSachNhanVien()
        {
            foreach (NhanVien item in dsNhanVien)
            {
                Console.WriteLine(item.ToString());
            }
        }
        //phương thức tính lương trung bình
        static private double TinhLuongTrungBinh()
        {
            double tong = 0;
            foreach (NhanVien item in dsNhanVien)
            {
                tong += item.TinhLuong();
            }
            return tong / dsNhanVien.Count;
        }
    }
}
