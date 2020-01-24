using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps_Cookies3
{
    class PriorityQueue
    {
        private SortedDictionary<int, int> Items;
        
        public PriorityQueue ()
        {
            Items = new SortedDictionary<int, int>();
        }

        public int Count
        {
            get { return Items.Count; }
        }

        public bool IsEmpty
        {
            get { return Count == 0; }
        }

        public int Peek
        {
            get { return Items.Keys.First();}
        }

        public void Push(int key)
        {
            int value;
            Items.TryGetValue(key, out value);
            value++;
            Items[key] = value;
        }

        public int Pop()
        {
            var kv = Items.First();

            var value = kv.Value - 1;

            if(value <= 0)
            {
                //Remove
                Items.Remove(kv.Key);
            }
            else
            {
                //Update
                Items[kv.Key] = value;
            }

            return kv.Key;

        }

    }
}
