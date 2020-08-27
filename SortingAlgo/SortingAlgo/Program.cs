using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;


namespace SortingAlgo
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = RandomList(5);
            //PrintList(list);
            //selectionsort(list);
            Console.WriteLine(1%5);

            //Console.WriteLine(Fact(5));
            //InsertionSort(list);

            //QuickSortBasic(list, 0, list.Count);

            // QuickSort(list, 0, list.Count);
            //PrintList(list);
            Console.Read();




        }

        static void QuickSort(List<int> list, int start, int end)
        {

            if (list == null || list.Count <= 1)
                return;

            if (start < end)
            {
                int pivotIdx = Partition(list, start, end);
                //Console.WriteLine("MQS " + left + " " + right);
                //DumpList(list);
                QuickSort(list, start, pivotIdx - 1);
                QuickSort(list, pivotIdx, end);
            }




        }


        static void QuickSortBasic(List<int> arr, int first, int last)
        {
            if (first < last)
            {
                int p = first;
                // int start = first;
                int i = first;
                int j = last - 1;

                while (i < j)
                {

                    while (arr[first] <= arr[p] && i < last)
                        i++;

                    while (arr[j] > arr[p])
                        j--;

                    if (i < j)
                    {
                        var temp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = temp;

                    }

                }

                var temp1 = arr[j];
                arr[j] = arr[p];
                arr[p] = temp1;

                QuickSort(arr, first, j - 1);
                QuickSort(arr, j + 1, last);

            }

        }




        static int Partition(List<int> arr, int start, int end)
        {
            int temp = start;
            int pivot = arr[start];
            start++;
            end--;

            while (true)
            {

                while (start <= end && arr[start] <= pivot)
                    start++;

                while (start <= end && arr[end] > pivot)
                    end--;

                if (start > end)
                {
                    arr[temp] = arr[start - 1];
                    arr[start - 1] = pivot;

                    return start;

                }

                int t = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;


            }


        }

        static List<int> RandomList(int size)
        {
            List<int> ret = new List<int>();
            Random r = new Random();
            for (var i = 0; i < size; i++)
                ret.Add((r.Next(100)));

            return ret;
        }

        static void PrintList<T>(List<T> list)
        {
            list.ForEach(delegate (T val)
            {
                Console.Write(val + ", ");

            });
            Console.WriteLine("");

        }


        static void selectionsort(List<int> arr)
        {
            for (var i = 0; i < arr.Count; i++)
            {
                var minIndex = findMin(arr, i);
                swap(arr, minIndex, i);

            }
        }

        static int findMin(List<int> arr, int start)
        {
            var minValue = arr[start];
            var minIndex = start;

            for (var j = start + 1; j < arr.Count; j++)
            {
                if (minValue > arr[j])
                {
                    minIndex = j;
                    minValue = arr[j];
                }

            }

            return minIndex;


        }

        static void swap(List<int> arr, int i, int j)
        {

            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;


        }
        static int Fact(int n)
        {
            var result = 1;
            for (var i = n; i > 0; i--)
            {
                result = result * i;
            }

            return result;
        }

        static void InsertionSort(List<int> arr)
        {

            for (var i = 1; i < arr.Count; i++)
            {
                var key = arr[i];
                var j = i - 1;
                while (j >= 0 && key < arr[j])
                {

                    arr[j + 1] = arr[j];
                    j--;

                }
                arr[j + 1] = key;

            }



        }
    }



}
