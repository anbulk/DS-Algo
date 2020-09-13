using System;

namespace Sorting_All
{
    class Program
    {
        static void Main(string[] args)
        {
            //SelectionSort s = new SelectionSort();
            //s.ExecuteSort();
            //Console.Read();

            BubbleSort b = new BubbleSort();
            b.ExecuteSort(true);
            Console.Read();
        }
    }
}
