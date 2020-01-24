using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[]{9,2,6,4,3,5,1 };
            QuickSort(array, 0, array.Length-1);
            Console.ReadKey(true);
        }

        public static void QuickSort(int[] array, int left, int right)
        {
            var str = array.Select(x => x.ToString() + ", ").Aggregate((x, y) => x + y);
            
            Console.WriteLine(str);

            if (left >= right)
                return;

            int pivot = array[(left + right)/2];
            int index = Partitioner(array, left, right, pivot);

            QuickSort(array, left, index-1);
            QuickSort(array, index, right);
        }

        public static int Partitioner(int[] array, int left, int right, int pivot)
        {
            while (left <= right)
            {
                while (array[left] < pivot)
                    left++;

                while (array[right] > pivot)
                    right--;

                if (left <= right)
                {
                    Swap(array, left, right);
                    left++;
                    right--;
                }

            }

            return left;
        }

        public static void Swap(int[] array, int left, int right)
        {
            int tmp = array[left];
            array[left] = array[right];
            array[right] = tmp;
        }
    }
}
