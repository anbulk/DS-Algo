using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array.Manipulation
{
   class Program
    {
        //1.find array after d left rotation O(n) n is the lenght of the array
        static int[] rotLeft(int[] a, int d)
        {
            int l = a.Length;
            var result = new int[l];
            for (int i = 0; i < l; i++)
            {
                var index = l - d + i;

                if (index >= l)
                    index = index - l;

                result[index] = a[i];
            }

            return result;

        }

        //2.Find Max element in the array after performing m incremental opertaions
        // O(m + n) where m is the number of operations and n is the lenght of the array
        static long arrayOperations(int n, int[][] queries)
        {

            long[] arr = new long[n + 1];
            int m = queries.GetLength(0);
            // Start performing 'm' operations 
            for (int i = 0; i < m; i++)
            {
                // Store lower and upper index i.e. range 
                int lowerbound = queries[i][0]; ;
                int upperbound = queries[i][1]; ;

                // Add k to the lower_bound 
                arr[lowerbound - 1] += queries[i][2];

                // Reduce upper_bound+1 indexed value by k 
                arr[upperbound] -= queries[i][2];
            }

            // Find maximum sum possible from all values 
            long sum = 0; var res = long.MinValue;
            for (int i = 0; i < n; ++i)
            {
                sum += arr[i];
                if (sum > res)
                    res = sum;
            }

            // return maximum value 
            return res;

        }

        static void Main(string[] args)
        {

            Dictionary<int, int> maxValues = new Dictionary<int, int>();
            int[] a = new int[] {1, 2, 3, 4, 5};

            rotLeft(a, 4);

            Console.ReadLine();

        }
    }
}
