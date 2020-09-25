using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array.Manipulation
{
    class Program
    {

        // Simple binary search algorithm 
        static int binarySearch(int[] arr, int l,
                                    int r, int x)
        {
            if (r >= l)
            {
                int mid = l + (r - l) / 2;

                if (arr[mid] == x)
                    return mid;
                if (arr[mid] > x)
                    return binarySearch(arr, l,
                                       mid - 1, x);

                return binarySearch(arr, mid + 1,
                                           r, x);
            }

            return -1;
        }
        public IList<IList<int>> ThreeSumOptimized(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();

            return result;
        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {

            List<IList<int>> result = new List<IList<int>>();

            for (var i = 0; i < nums.Length - 2; i++)
            {
                HashSet<int> hSet = new HashSet<int>();
                int currSum = -nums[i];
                for (var j = i + 1; j < nums.Length; j++)
                {
                    if (hSet.Contains(currSum - nums[j]))
                    {
                        var c = new List<int> { nums[i], nums[j], currSum - nums[j] };

                        if (!result.Any(x => x.OrderBy(y => y).SequenceEqual(c.OrderBy(z => z))))
                        {
                            result.Add(c);
                        }
                    }
                    hSet.Add(nums[j]);
                }

            }

            return result;


        }

        public int[] TwoSumSorted(int[] nums, int target)
        {
            for (var i = 0; i < nums.Length; i++)
            {

                var find = target - nums[i];

                var r = binarySearch(nums, 0, nums.Length, find);
                if (r != -1)
                {
                    return new int[] { r, i };
                }
            }

            return new int[] { };
        }

        //two sum problem
        public int[] TwoSum(int[] nums, int target)
        {

            Dictionary<int, int> s = new Dictionary<int, int>();

            for (var i = 0; i < nums.Length; i++)
            {

                var find = target - nums[i];

                if (s.ContainsValue(find))
                {
                    return new int[] { s.Where(y => y.Value.Equals(find)).FirstOrDefault().Key, i };
                }
                s.Add(i, nums[i]);


            }

            return new int[] { };
        }

        public static  void SetZeroes(int[][] matrix)
        {

            var iscol = false;

            for (var i = 0; i < matrix.Length; i++)
            {


                if (matrix[i][0] == 0)
                {
                    iscol = true;
                }

                for (var j = 1; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[0][j] = 0;
                        matrix[i][0] = 0;
                    }

                }

            }

            for (var i = 1; i < matrix.Length; i++)
                for (var j = 1; j < matrix[0].Length; j++)
                {
                    if (matrix[i][0] == 0 || matrix[0][j] == 0)
                    {
                        matrix[i][j] = 0;
                    }

                }

            if (matrix[0][0] == 0)
            {
                for (var i = 0; i < matrix[0].Length; i++)
                {
                    matrix[0][i] = 0;
                }
            }
            if (iscol)
            {
                for (var i = 0; i < matrix.Length; i++)
                {
                    matrix[i][0] = 0;
                }

            }

        }



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

            //Dictionary<int, int> maxValues = new Dictionary<int, int>();
            //int[] a = new int[] {1, 2, 3, 4, 5};

            //rotLeft(a, 4);

            //Console.ReadLine();

            int[][] a = new int[3][];

            a[0] = new int[4] { 0, 1, 2, 3 };
            a[1] = new int[4] { 4, 5, 6, 7 };
            a[2] = new int[4] { 8, 9, 10, 11 };

            Console.WriteLine(a.Length);

            Console.WriteLine(a[0].Length);

            SetZeroes(a);

            Console.Read();


        }
    }
}
