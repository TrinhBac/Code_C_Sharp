using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace vd_2_ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList ds = new ArrayList();
            Nhap(ds);
            Xuat(ds);
            Console.Write("\n==> Max = {0}\n", FindMax(ds));
            Console.Write("\n==> Min = {0}\n", FindMin(ds));
            Console.WriteLine();
        }

        private static void Nhap(ArrayList ds)
        {
            string question = "";
            while(question !="n")
            {
                Console.Write("Nhap vao 1 phan tu: ");
                ds.Add(Console.ReadLine());
                Console.Write("Nhap n de ket thuc! : ");
                question = Console.ReadLine().ToLower();
            }
        }

        private static void Xuat(ArrayList ds)
        {
            Console.WriteLine("+) D/s da nhap la:");
            for(int i=0;i<ds.Count;i++)
            {
                Console.Write("{0}\t", ds[i]);
            }
        }

        private static double FindMax(ArrayList ds)
        {
            double Max = Convert.ToDouble(ds[0]);
            for(int i=1;i<ds.Count;i++)
            {
                if (Max < Convert.ToDouble(ds[i]))
                    Max = Convert.ToDouble(ds[i]);
            }
            return Max;
        }

        private static double FindMin(ArrayList ds)
        {
            double Min = Convert.ToDouble(ds[0]);
            for (int i = 1; i < ds.Count; i++)
            {
                if (Min > Convert.ToDouble(ds[i]))
                    Min = Convert.ToDouble(ds[i]);
            }
            return Min;
        }
    }
}
