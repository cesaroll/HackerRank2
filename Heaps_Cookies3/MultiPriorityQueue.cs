using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps_Cookies3
{

    public class MultiPriorityQueue
    {
        private PriorityQueue[] Buckets;
        private const int BucketCount = 2;
        private readonly int Max;
        private int Bigger;

        public MultiPriorityQueue(string[] items, int max)
        {
            var buckets = new List<PriorityQueue>();

            Max = max;
            Bigger = 0;

            for (int i = 0; i < BucketCount; i++)
            {
                buckets.Add(new PriorityQueue());
            }

            Buckets = buckets.ToArray();

            int value;
            for(int i = 0; i < items.Length; i++)
            {
                //this.Push(Int32.Parse(items[i]));
                value = Int32.Parse(items[i]);

                if(Pushable(value))
                    Buckets[0].Push(value);
            }

        }

        private bool Pushable(int value)
        {
            bool ret = false;

            if(Bigger < Max)
            {
                ret = true;

                if (Bigger < value)
                    Bigger = value;

            }
            else if(value < Max)
            {
                ret = true;
            }


            return ret;
        }

        public int Count
        {
            get
            {
                int count = 0;

                foreach (var item in Buckets)
                {
                    count += item.Count;
                }
                return count;
            }
        }
        public bool IsEmpty
        {
            get { return Count == 0; }
        }

        public int Peek
        {
            get
            {
                return GetBucketWithMinKey.Peek;
            }
        }

        private PriorityQueue GetBucketWithMinKey
        {
            get
            {
                if (IsEmpty)
                    throw new KeyNotFoundException("Collection is empty");

                PriorityQueue queue = null;

                for (int i=0; i < Buckets.Length; i++)
                {
                    if (Buckets[i].IsEmpty)
                        continue;

                    if (queue == null || Buckets[i].Peek < queue.Peek)
                        queue = Buckets[i];

                }

                return queue;

            }
        }

        public void Push(int value)
        {
            if(Pushable(value))
                GetPushBucket(value).Push(value);
        }

        private PriorityQueue GetPushBucket(int value)
        {
            /*PriorityQueue queue = null;
                        
            for (int i = 0; i < BucketCount; i++)
            {
                if (queue == null || Buckets[i].Count < queue.Count)
                    queue = Buckets[i];
            }
            

            return queue;*/

            return Buckets[1];

        }

        public int Pop()
        {
            return GetBucketWithMinKey.Pop();
        }
    }
}
