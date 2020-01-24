using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps_Cookies2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(Int32.Parse).ToList();
            var n = input[0];
            var k = input[1]; // k : cookie sweetness

            var heap = new Heap(n);

            foreach (var item in GetInput())
            {
                heap.Push(Int32.Parse(item));
            }

            Console.WriteLine(SweetenCookies(heap, k));
        }

        static string[] GetInput()
        {
            //return new int[] { 1, 2, 3, 9, 10, 12 };            
            return new string[] { "13", "47", "74", "12", "89", "74", "18", "38" };
            //return Console.ReadLine().Split(' ');
        }

        private static int SweetenCookies(Heap heap, int sweetness)
        {
            int op = 0;

            while (!heap.IsEmpty && heap.Peek < sweetness)
            {
                var newCookie = heap.Pop();

                if (heap.IsEmpty)
                    return -1;

                newCookie += (heap.Pop() * 2);
                op++;

                heap.Push(newCookie);
            }

            return op;
        }
    }
}
