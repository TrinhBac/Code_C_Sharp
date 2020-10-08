using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_6
{
    class Program
    {
		private static int tinhGT(int n)
		{
            int gt = 1;
			for(int i=1;i<=n;i++)
            {
                gt *= i;
            }    
			return gt;
		}
		static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int n;
            Console.Write("Nhập vào n: ");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("==> {0}! = {1}", n, tinhGT(n));
        }
    }
}
