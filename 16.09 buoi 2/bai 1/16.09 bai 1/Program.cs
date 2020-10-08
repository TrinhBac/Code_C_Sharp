using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16._09_bai_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            double x, y, c;
            Console.Write("Nhập vào số thứ nhất: ");
            x = double.Parse(Console.ReadLine());
            Console.Write("Nhập vào số thứ hai: ");
            y = double.Parse(Console.ReadLine());
            Console.WriteLine("MAIN MENU :");
            Console.WriteLine("1. Cộng");
            Console.WriteLine("2. Trừ");
            Console.WriteLine("3. Nhân");
            Console.WriteLine("4. Chia");
            Console.Write("Nhập phép tính bạn muốn thực hiện:");
            c = double.Parse(Console.ReadLine());
            switch(c)
            {
                case 1:
                    Console.WriteLine("Kết quả của phép cộng là: {0}", x+y);
                    break;
                case 2:
                    Console.WriteLine("Kết quả của phép trừ là: {0}", x - y);
                    break;
                case 3:
                    Console.WriteLine("Kết quả của phép nhân là: {0}", x * y);
                    break;
                case 4:
                    Console.WriteLine("Kết quả của phép chia là: {0}", x / y);
                    break;
            }
        }
    }
}
