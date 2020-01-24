using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_MergeSort
{
    class Program
    {
        public static void Main(string[] args)
        {
            //var array = new int[] {10,5,2,7,4,9,12,1,8,6,11,3};
            var array = new int[] { 2,1,3,1,2 };

            foreach (var i in array)
            {
                Console.Write(i + ", ");
            }

            MergeSort(array);

            Console.WriteLine("\n");
            foreach (var i in array)
            {
                Console.Write(i + ", ");
            }

            Console.ReadKey(true);

        }

        public static void MergeSort(int[] array)
        {
            MergeSort(array, new int[array.Length], 0, array.Length - 1);
        }

        public static void MergeSort(int[] array, int[] tmp, int leftStart, int rightEnd)
        {
            if(leftStart >= rightEnd)
                return;

            int midIdx = (leftStart + rightEnd)/2;
            MergeSort(array, tmp, leftStart, midIdx);
            MergeSort(array, tmp, midIdx+1, rightEnd);

            MergeHalves(array, tmp, leftStart, rightEnd);
        }

        public static void MergeHalves(int[] array, int[] tmp, int leftStart, int rightEnd)
        {
            int leftEnd = (leftStart + rightEnd)/2;
            int rightStart = leftEnd + 1;

            int size = rightEnd - leftStart + 1;

            int left = leftStart;
            int right = rightStart;
            int tmpIdx = leftStart;

            while (left <= leftEnd && right <= rightEnd)
            {
                if (array[left] <= array[right])
                {
                    tmp[tmpIdx] = array[left];
                    left++;
                }
                else
                {
                    tmp[tmpIdx] = array[right];
                    right++;
                }

                tmpIdx++;
            }

            if(left <= leftEnd)
                Array.Copy(array, left, tmp, tmpIdx, leftEnd-left+1);
            else
                Array.Copy(array, right, tmp, tmpIdx, rightEnd-right+1);

            Array.Copy(tmp, leftStart, array, leftStart, size);

        }
    }
}
