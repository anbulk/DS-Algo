using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace DynamicPRogramming
{
    class Program
    {
        public static int[] m;

        static void Main(string[] args)
        {
            //fib(9);
            int n = 10;
            m = new int[n + 1];
            for (var i = 0; i < n + 1; i++)
                m[i] = -1;
            //Console.WriteLine(getMinsteps(n));
            Console.WriteLine(getMinStepsBU(10));
            //Console.WriteLine(Catalan_N(5));
            Console.Read();
        }

        static int Catalan_N(int n)
        {

            var temp = BinomialCoff(2 * n, n);

            return temp / (n + 1);


        }
        static int BinomialCoff(int n, int k)
        {

            if (k > n - k)
                k = n - k;


            var res = 1;
            for (var i = 0; i < k; i++)
            {
                res *= (n - i);
                res /= (i + 1);



            }

            return res;
        }
        static void swap(List<int> a, int x, int y)
        {
            var temp = a[x];
            a[x] = a[y];
            a[y] = temp;


        }
        static void heapify(List<int> a, int n, int i)
        {

            int largest = i;
            int left = 2 * i + 1, right = 2 * i + 2;

            if (left < n && a[left] > a[largest])
                largest = left;

            if (right < n && a[right] > a[largest])
                largest = right;

            if (largest != i)
            {
                swap(a, largest, i);

                heapify(a, n, largest);
            }

        }
        static void heapsort(List<int> a)
        {

            for (int i = (int)Math.Floor((double)a.Count / 2); i >= 0; i--)
                heapify(a, a.Count, i);


            for (int j = a.Count - 1; j >= 0; j--)
            {
                swap(a, j, 0);
                heapify(a, j, 0);

            }


        }
        static int CatlanNumber(int n)
        {
            int[] C = new int[n + 1];

            if (n <= 1)
                return 1;

            else
            {
                C[0] = C[1] = 1;
                for (int i = 2; i <= n; i++)
                {
                    C[i] = 0;
                    for (int j = 0; j < i; j++)
                    {
                        C[i] += C[j] * C[i - j - 1];
                    }


                }

                return C[n];
            }



        }
        static void fib(int n)
        {
            int a = 0, b = 1;
            if (n == 0 || n == 1)
                Console.WriteLine(0);


            Console.Write(a + ", " + b + ", ");

            for (var i = 2; i <= n; i++)
            {
                var temp = a + b;
                a = b;
                b = temp;

                Console.WriteLine(b);

            }
        }


        //Minimum number of operations on an interger to obtain 1
        //by memoization

        static int getMin(int a, int b)
        {
            return a < b ? a : b;
        }



        public static int getMinsteps(int n)
        {

            if (n == 1 || n == 0)
                return 0;

            if (m[n] != -1)
                return m[n];

            int r = getMinsteps(n - 1);
            if (n % 2 == 0)
                r = getMin(r, getMinsteps(n / 2));
            if (n % 3 == 0)
                r = getMin(r, getMinsteps(n / 3));

            m[n] = r + 1;

            return r + 1;


        }

        //by dynamic programming bottom up
        public static int getMinStepsBU(int n)
        {

            int[] dp = new int[n + 1];
            dp[1] = 0;

            for (var i = 2; i <= n; i++)
            {
                dp[i] = 1 + dp[i - 1];
                if (i % 2 == 0)
                    dp[i] = getMin(  dp[i],1+ dp[i / 2]);
                if (i % 3 == 0)
                    dp[i] = getMin( dp[i],1+ dp[i / 3]);

                
                
            }

            return dp[n];

        }


    }
}
