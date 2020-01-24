using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap_QHEAP1
{
    class Program
    {
        private const int ADD = 1;
        private const int DELETE = 2;
        private const int PRINT = 3;
        static void Main(string[] args)
        {
            var heap = new Heap();

            var n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var arr = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);


                switch (arr[0])
                {
                    case ADD:
                        heap.Push(arr[1]);
                        break;
                    case DELETE:
                        heap.Remove(arr[1]);
                        break;
                    case PRINT:
                        Console.WriteLine(heap.Peek);
                        break;
                }

            }

            Console.ReadKey(true);
        }
    }
}
