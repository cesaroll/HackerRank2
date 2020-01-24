using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps_Cookies3
{
    class Kitchen
    {
        private MultiPriorityQueue MPQ;
        private int Sweetness;

        public Kitchen(string[] cookies, int sweetness)
        {
            Sweetness = sweetness;

            MPQ = new MultiPriorityQueue(cookies, sweetness);
        }

        public int SweetenCookies()
        {
            int op = 0;

            while (!MPQ.IsEmpty && MPQ.Peek < Sweetness)
            {
                var newCookie = MPQ.Pop();

                if (MPQ.IsEmpty)
                    return -1;

                newCookie += (MPQ.Pop() * 2);
                op++;

                MPQ.Push(newCookie);
            }

            return op;
        }

    }
}
