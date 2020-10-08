using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_2._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string name;
            double dToan, dLy, dHoa, dTB;
            Console.Write("Nhập vào tên hs: ");
            name = Console.ReadLine();
            Console.Write("Nhập điểm toán: ");
            dToan = double.Parse(Console.ReadLine());
            Console.Write("Nhập điểm lý: ");
            dLy = double.Parse(Console.ReadLine());
            Console.Write("Nhập điểm hoá: ");
            dHoa = double.Parse(Console.ReadLine());
            Console.WriteLine("Tên hs là: {0}", name.ToUpper());
            dTB = (dToan + dLy + dHoa) / 3;
            Console.WriteLine("Điểm trung bình của hs là: {0}", dTB);
        }
    }
}
