using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps_Cookies
{
    //Min Heap
    public class DoubleMinHeap
    {
        private SortedDictionary<int, int> ListA { get; set; }
        private SortedDictionary<int, int> ListB { get; set; }

        private int Max;
        private int BreakPoint;

        public DoubleMinHeap(int breakpoint, List<int> list)
        {            
            Max = Int32.MaxValue;
            BreakPoint = breakpoint;
            ListA = new SortedDictionary<int, int>();
            ListB = new SortedDictionary<int, int>();

            FillListA(list);

        }

        private void FillListA(List<int> list)
        {
            foreach (var item in list)
            {
                if (item < BreakPoint)
                {
                    Add(ListA, item);
                }
                else if(item < Max)
                {
                    BreakPoint = item;
                }
                    
            }

            Add(ListA, BreakPoint);

        }

        private void Add(SortedDictionary<int, int> dict, int key)
        {
            int val;
            dict.TryGetValue(key, out val);
            dict[key] = ++val;
        }

        private void Remove(SortedDictionary<int, int> dict, int key)
        {
            int val;
            dict.TryGetValue(key, out val);

            if(val == 1)
            {
                dict.Remove(key);
            }
            else if(val > 1)
            {
                dict[key] = --val;
            }
        }
                
        public void Push(int value)
        {
            Add(ListB, value);
        }

        public int Peek
        {
            get
            {
                if (IsEmpty)
                    throw new KeyNotFoundException("Heap is empty");

                if (ListA.Count > 0 && ListB.Count > 0)
                    return (ListA[ListA.Keys.Min()] <= ListB[0]) ? ListA[0] : ListB[0];

                if(ListA.Count > 0)
                    return ListA[0];

                return ListB[0];

            }
        }

        public int Pop()
        {
            if (IsEmpty)
                throw new KeyNotFoundException("Heap is empty");

            int value;

            if (ListA.Count > 0 && ListB.Count > 0)
            {
                if(ListA[0] <= ListB[0])
                {
                    value = ListA[0];
                    ListA.RemoveAt(0);
                }
                else
                {
                    value = ListB[0];
                    ListB.RemoveAt(0);
                }
                
            } else if(ListA.Count > 0)
            {
                value = ListA[0];
                ListA.RemoveAt(0);
            }
            else
            {
                value = ListB[0];
                ListB.RemoveAt(0);
            }

            return value;
        }

        public bool IsEmpty
        {
            get { return ListA.Count == 0 && ListB.Count == 0; }
        }

        public int Count
        {
            get { return ListA.Count + ListB.Count; }
        }
    }
}
