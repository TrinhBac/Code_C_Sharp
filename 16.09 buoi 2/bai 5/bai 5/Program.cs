using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_5
{
    class Program
    {
		private static string ChuyenDiemChu(double diemHocPhan)
		{   
			string diemChu;
			if (diemHocPhan < 4 && diemHocPhan >= 0)
				diemChu = "F";
			else if (diemHocPhan < 5)
				diemChu = "D";
			else if (diemHocPhan < 7)
				diemChu = "C";
			else if (diemHocPhan < 8.5)
				diemChu = "B";
			else if (diemHocPhan < 10)
				diemChu = "A";
			else
				diemChu = "Diem khong hop le";
			return diemChu;
		}

		static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
			double diem;
            Console.Write("Nhập vào diểm số: ");
			diem = double.Parse(Console.ReadLine());
			string diemChu = ChuyenDiemChu(diem);
			Console.WriteLine("Điểm chữ là: {0}", diemChu);
		}
    }
}
