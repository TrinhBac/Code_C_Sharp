using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_7
{
    class Program
    {
        private static void giaiPtBac2(double a, double b, double c)
        {
            Console.OutputEncoding = Encoding.UTF8;
            if (a==0 && b==0 && c==0)
                Console.WriteLine("==> PT có vô số nghiệm !");
            else if(a==0 && b!=0)
                Console.WriteLine("==> PT có nghiệm duy nhất là: {0}", -b/a);
            else if (a == 0 && b == 0 && c!=0)
                Console.WriteLine("==> PT vô nghiệm !");
            else
            {
                double denTa;
                denTa = b * b - 4 * a * c;
                if(denTa==0)
                    Console.WriteLine("==> PT có nghiệm kép là: {0}", -b /2*a);
                else if(denTa < 0)
                    Console.WriteLine("==> PT có vô nghiệm !");
                else //denTa >0
                {
                    Console.WriteLine("==> PT có 2 nghiệm phân biệt là:");
                    Console.WriteLine("X1 = {0}", (-b + Math.Sqrt(denTa))/(2*a));
                    Console.WriteLine("X1 = {0}", (-b - Math.Sqrt(denTa))/(2 * a));
                }
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            double a, b, c;
            string chuoiA, chuoiB, chuoiC;
            Console.WriteLine("A.X^2 + B.X + C = 0");
            Console.Write("Nhập vào a: ");
            chuoiA = Console.ReadLine();
            if (chuoiA != "")
            {
                if (Char.IsNumber(chuoiA[0]))
                {
                    try
                    {
                        a = double.Parse(chuoiA);
                        Console.Write("Nhập vào b: ");
                        chuoiB = Console.ReadLine();
                        if (chuoiB != "")
                        {
                            try
                            {
                                b = double.Parse(chuoiB);
                                Console.Write("Nhập vào c: ");
                                chuoiC = Console.ReadLine();
                                if(chuoiC != "")
                                {
                                    try
                                    {
                                        c = double.Parse(chuoiC);
                                        giaiPtBac2(a, b, c);
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Nhập hệ số c phải là số !");
                                    }
                                }  
                                else
                                    Console.WriteLine("Bạn chưa nhập c.");
                            }
                            catch
                            {
                                Console.WriteLine("Nhập hệ số b phải là số !");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Bạn chưa nhập b.");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Hệ số b phải là số!");
                    }
                }
                else
                    Console.WriteLine("Nhập hệ số a phải là số !");
            }
            else
            {
                Console.WriteLine("Bạn chưa nhập a.");
            }
            Console.ReadLine();
        }
    }
}
