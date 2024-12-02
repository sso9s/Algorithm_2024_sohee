using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _009_FibonacciDP
{
    internal class Program
    {
        static long[] d = new long[51];
        static void Main(string[] args)
        {
            for(int i=1; i<=45; i++)
                Console.WriteLine("R_"+ i + ": " + Fibonacci(i));
            for (int i = 1; i <= 50; i++)
                Console.WriteLine("D_" + i + ": " + FibonacciDP(i));
        }
        
        private static long Fibonacci(int n)
        {
            if (n == 1 || n == 2)
                return 1;
            else
                return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        private static long FibonacciDP(int n)
        {
            if (n == 1 || n == 2)
                return 1;
            else if (d[n] == 0)
            {
                d[n] = FibonacciDP(n - 1) + FibonacciDP(n - 2);
                return d[n];
            }
            else
                return d[n];
        }
    }
}