
// C# program for implementation of Heap Sort 
using System;

public class HeapSort
{
    //public void sort(int[] arr)
    //{
    //    int n = arr.Length;

    //    // Build heap (rearrange array) 
    //    for (int i = n / 2 - 1; i >= 0; i--)
    //        heapify(arr, n, i);

    //    // One by one extract an element from heap 
    //    for (int i = n - 1; i >= 0; i--)
    //    {
    //        // Move current root to end 
    //        int temp = arr[0];
    //        arr[0] = arr[i];
    //        arr[i] = temp;

    //        // call max heapify on the reduced heap 
    //        heapify(arr, i, 0);
    //    }
    //}

    //  To heapify a subtree rooted with node i which is 
    // an index in arr[]. n is size of heap 
     static void heapify(HeapNode[] arr, int n, int i)
    {
        int smallest = i; // Initialize largest as root 
        int l = 2 * i + 1; // left = 2*i + 1 
        int r = 2 * i + 2; // right = 2*i + 2 

        // If left child is larger than root 
        if (l < n && arr[l].Data < arr[smallest].Data)
            smallest = l;

        // If right child is larger than largest so far 
        if (r < n && arr[r].Data < arr[smallest].Data)
            smallest = r;

        // If largest is not root 
        if (smallest != i)
        {
            HeapNode swap = arr[i];
            arr[i] = arr[smallest];
            arr[smallest] = swap;

            // Recursively heapify the affected sub-tree 
            heapify(arr, n, smallest);
        }
    }

    /* A utility function to print array of size n */
    static void printArray(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n; ++i)
            Console.Write(arr[i] + " ");
        Console.Read();
    }

    // Driver program 
    public static void Main()
    {
        int[][] arrList = new int[3][]
        {
           new int[] { 2,5,7,9,10 },
           new int[] { 1,3,4,18,20 },
            new int[] { 6,8,13,16,22}

        };

        int n = arrList[0].Length;
        int k = arrList.Length;

       

        HeapNode[] heapArr = new HeapNode[k];

        var i = 0;
        foreach (var arr in arrList)
        {
            heapArr[i] = new HeapNode() {Data = arrList[i][0], ListIndex = i, ListPos = 1};
            i++;
        }

        int[] output = new int[n * k];
        
        //Construct Min heap
        for (int j =k/2; j >= 0; j--)
        {
            heapify(heapArr, heapArr.Length, j);
        }


        for (int j = 0; j < n*k; j++)
        {

            output[j] = heapArr[0].Data;

            //replace the heapArr[0] with right heapnode
            if (heapArr[0].ListPos < arrList[heapArr[0].ListIndex].Length)
            {
                heapArr[0] = new HeapNode()
                {
                    Data = arrList[heapArr[0].ListIndex][heapArr[0].ListPos], ListIndex = heapArr[0].ListIndex,
                    ListPos = heapArr[0].ListPos + 1
                };
            }
            else
            {
                heapArr[0] = new HeapNode()
                {
                    Data = int.MaxValue,
                    ListIndex = heapArr[0].ListIndex,
                    ListPos = heapArr[0].ListPos + 1
                };

            }

            heapify(heapArr,heapArr.Length,0);

        }

        Console.Read();

        //int[] arr = { 12, 11, 13, 5, 6, 7, 40, 1, 3 };


        //HeapSort ob = new HeapSort();
        //ob.sort(arr);

        //Console.WriteLine("Sorted array is");
        //printArray(arr);
    }
}

class HeapNode
{
    public int  Data { get; set; }
    public int ListIndex { get; set; }
    public int ListPos { get; set; }
}