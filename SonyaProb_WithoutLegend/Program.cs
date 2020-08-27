using System;
using System.Collections.Generic;

namespace SonyaProb_WithoutLegend
{

   

    class Program
    {

        public static int MinimalOperations(List<int> arr)
        {
            var result = 0;
            PriorityQueue<int> pq = new PriorityQueue<int>();

            for (var i = 0; i < arr.Count; i++)
            {
                var x = arr[i] - i;
                pq.Enqueue(x);
                if (pq.Peek() > x)
                {
                    result += pq.Peek() - x;
                    pq.Dequeue();
                    pq.Enqueue(x);
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            var r = MinimalOperations(new List<int>()
            {
                2,1,5,11,5,9,11


            });

            Console.WriteLine(r);
            Console.Read();
        }
    }
}
