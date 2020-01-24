using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues_ATaleofTwoStacks
{
    class Solution
    {
        private const string ENQUEUE = "1";
        private const string DEQUEUE = "2";
        private const string PRINT = "3";

        static void Main(string[] args)
        {
            var queue = new Queue<int>();

            var n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i <= n; i++)
            {
                var input = Console.ReadLine().Split(' ');
                if (input.Length > 1 && input[0] == ENQUEUE)
                {
                    queue.Enqueue(Convert.ToInt32(input[1]));
                }
                else if (input[0] == DEQUEUE)
                {
                    if (queue.hasValue())
                        queue.Dequeue();
                }
                else if (input[0] == PRINT)
                {
                    if (queue.hasValue())
                        Console.WriteLine(queue.Peek());
                }
            }


        }
    }


    public class Queue<T>
    {
        private Stack<T> newStack;
        private Stack<T> oldStack;
        public Queue()
        {
            newStack = new Stack<T>();
            oldStack = new Stack<T>();
        }

        public void Enqueue(T val)
        {
            newStack.Push(val);
        }

        public T Dequeue()
        {
            prepareDequeue();
            if (oldStack.Count > 0)
                return oldStack.Pop();
            else
                throw new KeyNotFoundException("Queue is empty");
        }

        public T Peek()
        {
            prepareDequeue();
            if (oldStack.Count > 0)
                return oldStack.Peek();
            else
                throw new KeyNotFoundException("Queue is empty");
        }

        public bool hasValue()
        {
            prepareDequeue();
            return oldStack.Count > 0;
        }

        private void prepareDequeue()
        {
            if (oldStack.Count == 0)
            {
                while(newStack.Count > 0)
                    oldStack.Push(newStack.Pop());
            }
        }
    }
}
