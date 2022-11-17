using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace ParaProg
{
    class Logic
    {
        public static int ReadNumber()
        {
            int result;
            while (!int.TryParse(Console.ReadLine(), out result) || !(result > 0))
            {
                Console.WriteLine("Число введено неверно. Попробуйте ещё раз");
            }
            return result;
        }
    }

    class Program
    {
        static int N;
        static int n;
        static int[] returns;
        static int[] a;
        static void Main(string[] args)

        {
            Console.WriteLine("Введите кол-во элементов");
            N = Logic.ReadNumber();
            Console.WriteLine("Введите кол-во потоков");
            n = Logic.ReadNumber();
            a = new int[N];

            int i;
            Thread[] thread = new Thread[n];

            int rez = 0;
            int s = 0;

            Random rng = new Random();

            for (i = 0; i < a.Length; i++)
            {
                a[i] = rng.Next(1, 100);
            }


            returns = new int[n];

            for (i = 0; i < n; i++)
            {
                int tmp = i;
                returns[tmp] = 0;
                thread[i] = new Thread(() => { returns[tmp] = ThreadFunc(tmp); });
                thread[i].Start();
            }

            for (i = 0; i < n; i++)
            {
                thread[i].Join();
                rez += returns[i];
            }

            Console.WriteLine($"Сумма чётных элементов массивов: {rez}");

            Console.ReadLine();
        }
        static int ThreadFunc(int param)
        {
                int i, nt, beg, h, end;
                int sum = 0;

                nt = param;
                h = N / n;
                beg = h * nt; end = beg + h;

                if (nt == n - 1) end = N;

                for (i = beg; i < end; i++)
                {
                    if (a[i] % 2 == 0)
                    {
                        sum += a[i];
                    }
                }

                return sum;
        }
    }
}
