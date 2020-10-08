using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16._09_bai_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string name;
            double diem;
            Console.Write("Nhập vào tên hs: ");
            name = Console.ReadLine();
            diem = double.Parse(Console.ReadLine());
            Console.WriteLine("Tên hs là: {0}", name.ToUpper());
            if(diem>=0)
            {
                Console.WriteLine("Đại hs giỏi.");
            }
            else if(diem >= 6.5 && diem<8)
            {
                Console.WriteLine("Đại hs khá.");
            }
            else if (diem >= 5 && diem < 6.5)
            {
                Console.WriteLine("Đại hs tb.");
            }
            else if(diem < 5)
            {
                Console.WriteLine("Đạt hs yếu.");
            }
        }
    }
}
