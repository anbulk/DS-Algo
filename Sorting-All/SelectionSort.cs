using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting_All
{
    class SelectionSort : Sort
    {
        public override string Name => "Selection Sort";
        public override string Description { get; } = "Selects the max/min repeatedly until array is sorted, maintains a sorted and unsorted array";
        public override string TimeComplexity => "O(n^2)";
        public override string AuxillarySpace => "O(1)";

        public override void ReccursiveSortArray(int[] array, int n)
        {
            throw new NotImplementedException();
        }

        public override void SortArray(int[] array)
        {
            for (var i = 0; i < array.Length - 1; i++)
            {
                var min = i;
                for (var j = i + 1; j < array.Length; j++)
                {
                    if (array[min] > array[j])
                    {
                        min = j;
                    }
                }
                Swap(min, i, array);
            }

        }

    }
}
