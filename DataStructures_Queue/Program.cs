using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_Queue
{
    public class Queue
    {
        private class Node
        {
            public int data;
            public Node next;

            public Node(int data)
            {
                this.data = data;
            }
        }

        private Node head; // Dequeue from head (remove)
        private Node tail; // Enqueue  in tail (Add)

        public Boolean IsEmpty()
        {
            return head == null;
        }
        public int Peek()
        {
            if (head != null)
                return head.data;

            throw new KeyNotFoundException("Nothing to peek");
        }

        public void Enqueue(int data) // Add
        {
            var node = new Node(data);

            if (tail != null)
                tail.next = node;

            tail = node;

            if (head == null)
                head = node;
        }

        public int Dequeue() // Remove
        {
            if (head != null)
            {
                var data = head.data;

                head = head.next;

                if (head == null)
                    tail = null;

                
                return data;
            }

            throw new KeyNotFoundException("Nothing to Dequeue");
        }

        static void Main(string[] args)
        {
            var q = new Queue();

            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue(4);

            Console.WriteLine(q.Peek());
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Dequeue());

            Console.ReadKey(true);
        }
    }
}
