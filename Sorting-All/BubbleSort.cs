using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_All
{
    public class BubbleSort : Sort
    {

        public override string Name => "Bubble Sort";
        public override string Description { get; } = "Compares the adjacent element and bubbles the max/min to the end of every iteration";
        public override string TimeComplexity => "O(n^2)";
        public override string AuxillarySpace => "O(1)";

        public override void SortArray(int[] array)
        {

            for (var i = 0; i < array.Length - 1; i++)
            {
                var swapped = false;
                for (var j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(j, j + 1, array);
                        swapped = true;
                    }
                    
                }
                if (!swapped)
                    break;

            }

        }

        public override void ReccursiveSortArray(int[] array, int n)
        {
            if (n == 1)
                return;

            var swapped = false;
            for (var j = 0; j < n - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    Swap(j, j + 1, array);
                    swapped = true;
                }
            }
            if (!swapped)
                return;

            ReccursiveSortArray(array, n - 1);
        }

    }
}
