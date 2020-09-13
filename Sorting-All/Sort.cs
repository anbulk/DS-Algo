using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_All
{
    public abstract class Sort
    {
        abstract public string Description { get; }
        abstract public string Name { get; }
        abstract public string TimeComplexity { get; }
        abstract public string AuxillarySpace { get; }

        public void ExecuteSort(bool isReccur = false)
        {
            Console.WriteLine("----------------------------------------");
            var array = new int[] { 64, 25, 12, 22, 11 };

            Console.WriteLine(this.Name);
            PrintArray(array);
            Console.WriteLine();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine(this.Description);
            Console.WriteLine("AuxillarySpace Complexity:" + this.AuxillarySpace);
            Console.WriteLine("Time Complexity:" + this.TimeComplexity);
            if (!isReccur)
                SortArray(array);
            else
                ReccursiveSortArray(array, array.Length);
            PrintArray(array);
            Console.WriteLine();
            Console.WriteLine("----------------------------------------");
        }

        public void PrintArray(int[] array)
        {
            foreach (int a in array)
            {
                Console.Write(a + ";");
            }
        }

        public void Swap(int i, int j, int[] a)
        {
            var temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }

        public abstract void SortArray(int[] array);
        public abstract void ReccursiveSortArray(int[] array,int n);

    }
}
