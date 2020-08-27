using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCost
{
    class Program
    {

        static void swap(List<int> arr, int a, int b)
        {
            var temp =arr[ a];
            arr[a] = arr[b];
            arr[b] = temp;


        }

        static void heapify(List<int> arr, int n, int i)
        {
            var smallest = i;
            var l = 2 * i + 1;
            var r = 2 * i + 2;

            if (l < n && arr[l] < arr[smallest])
                smallest = l;
            if (r < n && arr[r] < arr[smallest])
                smallest = r;

            if(smallest != i)
            {
                swap(arr, i, smallest);
                heapify(arr, n , smallest);

            }


        }



        static void Main(string[] args)
        {

          List<int> arr = new List<int>{2,3,6,4};

            //create min heap

            for (decimal i = 0; i < Math.Floor((decimal)arr.Count / 2); i++)
            {
                heapify(arr,arr.Count,(int)i);

            }

            var count = 0;

           



            while (arr.Count != 1)
            {
                var min1 = arr[0];
                arr[0] = arr[arr.Count - 1];
                arr.RemoveAt(arr.Count-1);
                heapify(arr,arr.Count,0);
                var min2 = arr[0];
                arr[0] = min2 + min1;
                count += arr[0];
                heapify(arr,arr.Count-1,0);


            }

            Console.Write(count);
            Console.Read();

        }
    }
}
