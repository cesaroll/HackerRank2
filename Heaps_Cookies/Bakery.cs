using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps_Cookies
{
    public class Bakery
    {

        private int sweetness;
        private DoubleMinHeap heap;
        private int BreakPoint;

        public Bakery(int sweetness, List<int> cookies)
        {
            this.sweetness = sweetness;

            heap = new DoubleMinHeap(sweetness, cookies);
        }

        
        public int SweetenCookies()
        {
            int op = 0;

            while(heap.Count > 0 && heap.Peek < sweetness)
            {
                var newCookie = heap.Pop();

                if (heap.IsEmpty)
                    return -1;

                newCookie += (heap.Pop() * 2);
                op++;

                if(newCookie < sweetness || newCookie < BreakPoint)
                {
                    heap.Push(newCookie);

                }
            }

            return op;
        }

        
    }
}
