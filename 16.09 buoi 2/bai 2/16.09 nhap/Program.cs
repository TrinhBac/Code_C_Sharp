﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16._09_nhap
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int n, sum=0;
            Console.Write("Nhập vào n: ");
            n = int.Parse(Console.ReadLine());
            for(int i=1;i<=n;i++)
            {
                sum += i;
            }
            Console.WriteLine("Tổng từ 1 đến {0} là: {1}", n, sum);
        }
    }
}
