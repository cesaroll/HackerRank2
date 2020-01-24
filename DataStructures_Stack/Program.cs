using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_Stack
{
    public class Stack
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

        private Node top;

        public Boolean IsEmpty()
        {
            return top == null;
        }

        public int Peek()
        {
            if (top != null)
                return top.data;

            throw new KeyNotFoundException("Stack is empty");
        }

        public void Push(int data)
        {
            var node = new Node(data);

            node.next = top;
            top = node;
        }

        public int Pop()
        {
            if (top != null)
            {
                var data = top.data;

                top = top.next;

                return data;
            }

            throw new KeyNotFoundException("Stack is Empty");
        }


        static void Main(string[] args)
        {
            var q = new Stack();

            q.Push(1);
            q.Push(2);
            q.Push(3);
            q.Push(4);

            Console.WriteLine(q.Peek());
            Console.WriteLine(q.Pop());
            Console.WriteLine(q.Pop());
            Console.WriteLine(q.Pop());
            Console.WriteLine(q.Pop());

            Console.ReadKey(true);
        }

    }
}
