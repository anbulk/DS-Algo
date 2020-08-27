using System;
using System.Collections;

namespace SortingPractise
{
    class Program
    {
        public static void Swap(int[] arr, int a, int b)
        {
            var temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }

        public static void BubbleSort(int[] arr)
        {
            for (var i = 0; i < arr.Length - 1; i++)
            {
                var swapped = false;
                for (var j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(arr, j, j + 1);
                        swapped = true;
                    }
                }
                if (swapped == false)
                    break;

            }


        }

        public static void RecBubbleSort(int[] arr, int n)
        {
            bool swapped = false;
            if (n == 1)
                return;

            else
            {

                for (var i = 0; i < n - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        Swap(arr, i, 1 + i);
                        swapped = true;
                    }

                }
            }

            if (swapped == true)
                RecBubbleSort(arr, n - 1);
            else
                RecBubbleSort(arr, 1);
        }

        public static void BubbleSortUsingStack(int[] arr)
        {
            Stack a = new Stack();
            Stack b = new Stack();
            for (var i = 0; i < arr.Length; i++)
            {
                a.Push(arr[i]);
            }

            for (var i = 0; i < arr.Length; i++)
            {

                if (i % 2 == 0)
                {

                    while (a.Count > 0)
                    {
                        var s1 = (int)a.Pop();

                        if (b.Count == 0)
                            b.Push(s1);
                        else
                        {
                            if ((int)b.Peek() > s1)
                            {
                                var t = b.Pop();
                                b.Push(s1);
                                b.Push(t);
                            }
                            else
                                b.Push(s1);
                        }
                    }
                    arr[arr.Length - i - 1] = (int)b.Pop();

                }
                else
                {
                    while (b.Count > 0)
                    {
                        var s1 = (int)b.Pop();

                        if (a.Count == 0)
                            a.Push(s1);
                        else
                        {
                            if ((int)a.Peek() > s1)
                            {
                                var t = a.Pop();
                                a.Push(s1);
                                a.Push(t);
                            }
                            else
                                a.Push(s1);
                        }
                    }
                    arr[arr.Length - i - 1] = (int)a.Pop();
                }

            }


        }

        public static void PrintArr(int[] arr)
        {
            for (var i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + ", ");

        }

        public static void QuickSort(int[] arr, int p, int q)
        {
            if (p < q)
            {

                int pivot = PartitionRight(arr, p, q);

                QuickSort(arr, p, pivot - 1);
                QuickSort(arr, pivot + 1, q);

            }
        }


        public static int PartitionLastElement(int[] arr, int p, int q)
        {
            int pivot = arr[q];
            int i = p - 1;

            for (var j = p; j <= q - 1; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    Swap(arr, i, j);

                }
            }

            Swap(arr, q, i + 1);

            return i + 1;


        }

        public static int PartitionRight(int[] arr, int p, int q)
        {
            int pivot = arr[q];
            int i = q - 1;

            for (int j = i; j >= 0; j--)
            {
                if (pivot < arr[j])
                {
                    Swap(arr, i, j);
                    i--;
                }
            }

            Swap(arr, q, i + 1);

            return i + 1;

        }

        public static int Partition(int[] arr, int p, int q)
        {
            int pivot = arr[p];
            int i = p + 1;

            for (var j = i; j <= q; j++)
            {
                if (arr[j] < pivot)
                {
                    Swap(arr, i, j);
                    i++;
                }
            }

            Swap(arr, p, i - 1);

            return i - 1;


        }

        public static void Merge(int[] arr, int l, int m, int h)
        {
            int n1 = m - l + 1;
            int n2 = h - m;

            int[] left = new int[n1];
            int[] right = new int[n2];

            var i = 0;
            var j = 0;
            for ( i = 0; i < n1; i++)
                left[i] = arr[l + i];

            for ( j = 0; j < n2; j++)
                right[j] = arr[m + 1 + j];

             i = 0;
             j = 0;
            var k = l;
            while(i<n1 && j<n2)
            {
                if (left[i] > right[j])
                    arr[k++] = right[j++];
                else
                    arr[k++] = left[i++];
            }

            while(i<n1)
            {
                arr[k++] = left[i++];
            }

            while(j<n2)
            {
                arr[k++] = right[j++];
            }
        }

        public static void MergeSort(int[] arr, int l, int h)
        {
            if (l < h)
            {
                var m = (l + (h - 1) )/ 2;

                MergeSort(arr, l, m);
                MergeSort(arr, m + 1, h);

                Merge(arr, l, m, h);               
            }
        }

        public static int Max(int[] arr)
        {
            var max = int.MinValue;

            for(var i=0;i<arr.Length;i++)
            {
                if (arr[i] > max)
                    max = arr[i];
            }
            return max;

        }

        public static void CountingSort(int[] arr)
        {
            var max = Max(arr);
            int[] count = new int[256];
            for (var i=0;i<arr.Length;i++)
            {
                
                ++count[arr[i]];

            }
            int k = 1;
            for ( k = 1; k < 256; k++)
                count[k] += count[k - 1];

            int[] outArr = new int[arr.Length];
            for(var j =arr.Length-1 ;j>=0;j--)
            {
                outArr[count[arr[j]] - 1] = arr[j];
                --count[arr[j]];
            }

            for (k = 0; k < arr.Length; k++)
                arr[k] = outArr[k];
        }

        public static void CountingSortExp(int[] arr,int exp)
        {
            int[] count = new int[11];
            int i = 0;
            for(i=0;i<arr.Length;i++)
            {
                ++count[(arr[i] / exp) % 10];
            }

            for(i=1;i<11;i++)
            {
                count[i] += count[i - 1];
            }

            int[] output = new int[arr.Length];

            for(i=0;i<arr.Length;i++)
            {
                output[count[(arr[i]/exp)%10] - 1] = arr[i];
                count[(arr[i] / exp) % 10]--;
            }

            for (i = 0; i < arr.Length; i++)
                arr[i] = output[i];
        }

        public static void RadixSort(int[] arr)
        {

            var max = Max(arr);

            for (var j = 1; max / j > 0; j *= 10)
                CountingSortExp(arr, j);

        }

        static void Main(string[] args)
        {
            int[] arr = new int[]
            {
                10,80,30,90,40,50,70
            };

            //BubbleSortUsingStack(arr);
            //BubbleSort(arr);
            //RecBubbleSort(arr, arr.Length);
            //QuickSort(arr, 0, arr.Length - 1);
            //MergeSort(arr, 0, arr.Length - 1);
            //CountingSort(arr);
            RadixSort(arr);

            PrintArr(arr);
            Console.Read();
        }
    }
}
