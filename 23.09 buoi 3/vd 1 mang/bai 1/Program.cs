using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Nhap vao so phan tu cua mang: ");
            int n = int.Parse(Console.ReadLine());
            int[] arr = NhapMang(n);
            hienThi(arr);
            Console.Write("==> Gia tri trung binh la: {0}", TinhTrungBinh(arr));
            Console.WriteLine();
        }

        private static int[] NhapMang(int n)
        {
            int[] mang = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Nhap a[{0}] = ", i);
                mang[i] = int.Parse(Console.ReadLine());
            }
            return mang;
        }

        private static void hienThi(int[] arr)
        {
            Console.WriteLine("\nMang da nhap: \n");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("{0}\t", arr[i]);
            }
            Console.WriteLine();
        }

        private static float TinhTrungBinh(int[] arr)
        {
            float sum =0;
            for(int i=0;i<arr.Length;i++)
            {
                sum += arr[i];
            }
            float tb = (float)sum /(float) arr.Length;
            return tb;
        }
    }
}
