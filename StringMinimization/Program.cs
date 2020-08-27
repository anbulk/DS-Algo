using System;
using System.Collections.Generic;
using System.Linq;

namespace StringMinimization
{
    class Program
    {



        //public static string MinimizeString(string input)
        //{
        //    var l = input.Length;

        //    Queue lp = new Queue();
        //    Stack rp = new Stack();

        //    for (var i = 0; i < l; i++)
        //    {
        //        if (i >= l / 2)
        //            rp.Push(input[i]);
        //        else
        //            lp.Enqueue(input[i]);
        //    }

        //    while ((char)rp.Peek() == (char)lp.Peek())
        //    {
        //        var temp = rp.Peek();

        //        rp.Pop();
        //        lp.Dequeue();

        //        while ((char)rp.Peek() == (char)temp)
        //        {
        //            rp.Pop();
        //        }

        //        while ((char)lp.Peek() == (char)temp)
        //        {
        //            lp.Dequeue();
        //        }

        //    }

        //    var res = string.Empty;

        //    while (rp.Count > 0)
        //        res += rp.Pop();

        //    res = ReverseString3b(res);

        //    while (lp.Count > 0)
        //        res += lp.Dequeue();

        //    return res;

        //}

        public static long StrictlyIncreasing(List<int> arr)
        {
            var cost = 0;


            for (var i = 0; i < arr.Count; i++)
            {
                if(arr[i] > arr[i+1])
                {

                }
                //else already correct
            }


            return cost;


        }

        public static long modifyArray(List<int> arr)
        {

            var asc = false;
            var asc1 = false;

            if (arr[0] < arr[1])
                asc = true;
            else
                asc = false;

            if (arr[arr.Count - 1] < arr[arr.Count - 2])
                asc1 = true;
            else
                asc1 = false;


            long cost = 0;
            long revcost = 0;

            for (var i = 0; i < arr.Count; i++)
            {
                if (i < arr.Count - 1 && asc && arr[i] > arr[i + 1])
                {
                    cost += Math.Abs(arr[i] - arr[i + 1]);
                    arr[i + 1] = arr[i];
                }

                if (i < arr.Count - 1 && !asc && arr[i] < arr[i + 1])
                {
                    cost += Math.Abs(arr[i] - arr[i + 1]);
                    arr[i + 1] = arr[i];

                }

            }

            for (var j = arr.Count - 1; j > 0; j--)
            {
                if (asc1 && arr[j] < arr[j - 1]) { }
                revcost += Math.Abs(arr[j] - arr[j - 1]);

                if (!asc1 && arr[j] > arr[j - 1]) { }
                revcost += Math.Abs(arr[j] - arr[j - 1]);

            }

            if (asc1)
            {

                if (arr[0] > arr[1])
                    revcost += Math.Abs(arr[0] - arr[1]);

            }
            else
            {

                if (arr[0] < arr[1])
                    revcost += Math.Abs(arr[0] - arr[1]);
            }

            if (asc)
            {
                if (arr[arr.Count - 1] < arr[arr.Count - 2])
                    cost += Math.Abs(arr[arr.Count - 1] - arr[arr.Count - 2]);

            }
            else
            {
                if (arr[arr.Count - 1] > arr[arr.Count - 2])
                    cost += Math.Abs(arr[arr.Count - 1] - arr[arr.Count - 2]);


            }

            return cost < revcost ? cost : revcost;
        }

        static void Main(string[] args)
        {

            var arrLength = Convert.ToInt64(Console.ReadLine());

            var numbers = Convert.ToString(Console.ReadLine()).Split(' ').ToList();

            var arr = numbers.Select(int.Parse).ToList();


        }
    }
}
