using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace bai_2._5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            double bacLuong, ngayCong, phuCap, tienLanh, NCTL;
            Console.Write("Nhập vào bậc lương: ");
            bacLuong = double.Parse(Console.ReadLine());
            Console.Write("Nhập vào ngày công: ");
            ngayCong = double.Parse(Console.ReadLine());
            Console.Write("Nhập vào phụ cấp: ");
            phuCap = double.Parse(Console.ReadLine());
            if (ngayCong < 25)
            {
                NCTL = ngayCong;
                tienLanh = bacLuong * 650000 + NCTL + phuCap;
                Console.WriteLine("==> Tiền lãnh là: {0}", tienLanh);
            }    
            else if (ngayCong >= 25)
            {
                NCTL = (ngayCong - 25) * 2 + 25;
                tienLanh = bacLuong * 650000 + NCTL + phuCap;
                Console.WriteLine("==> Tiền lãnh là: {0}", tienLanh);
            }    
        }
    }
}
