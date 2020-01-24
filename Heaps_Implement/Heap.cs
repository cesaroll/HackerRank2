using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;

namespace Heaps
{
    public class Heap<T> where T : IComparable<T>
    {
        public int Count { get; private set; }
        public bool IsEmpty {
            get { return Count == 0; }
        }

        private Node<T> head;
        private Node<T> last;
        private IComparer<T> comparer;

        /// <summary>
        /// Creates a Min Heap
        /// </summary>
        private Heap()
        {
        }

        private Heap(IComparer<T> comparer)
        {
            this.comparer = comparer;
            head = null;
        }

        /// <summary>
        /// Get Ascending Heap
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Heap<T> GetMinHeap<T>() where T : IComparable<T>
        {
            bool asc = true;
            return new Heap<T>(new DataComparer<T>(asc));
        }

        /// <summary>
        /// Get Descending Heap
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Heap<T> GetMaxHeap<T>() where T : IComparable<T>
        {
            bool asc = false;
            return new Heap<T>(new DataComparer<T>(asc));
        }

        private class Node<T>
        {
            public T Value { get; set; }

            public Node<T> Parent { get; set; }
            public Node<T> Left { get; set; }
            public Node<T> Rigth { get; set; }
           
            public Node(T value, Node<T> parent )
            {
                Value = value;
                Parent = parent;
            }
        }

        private class DataComparer<T> : IComparer<T> where T : IComparable<T>
        {
            private bool asc;

            public DataComparer(bool asc)
            {
                this.asc = asc;
            }

            public int Compare(T x, T y)
            {
                return (asc) ? x.CompareTo(y) : y.CompareTo(x);
            }
        }


        public void Push(T value)
        {
            if (head == null)
            {
                head = CreateNode(value, null);
                last = head;
                return;
            }

            var node = head;
            while (node != null)
            {
                if (comparer.Compare(node.Value, value) >= 0)
                {
                    if (node.Left != null)
                    {
                        node = node.Left;
                        continue;
                    }
                    else
                    {
                        node.Left = CreateNode(value, node);

//                        if (last.Value.CompareTo(value) >= 0)
                        if(comparer.Compare(last.Value, value) >= 0)
                            last = node.Left;

                        break;
                    }
                }
                else
                {
                    if (node.Rigth != null)
                    {
                        node = node.Rigth;
                        continue;
                    }
                    else
                    {
                        node.Rigth = CreateNode(value, node);



                        break;
                    }
                }

            }

        }

        private Node<T> CreateNode(T value, Node<T> parent)
        {
            Count++;
            return new Node<T>(value, parent);
        }

        public T Peek
        {
            get
            {
                if(last == null)
                    throw new KeyNotFoundException("Collection is Empty");

                return last.Value;
            }
        }

        public T Pop()
        {
            if (last == null)
                throw new KeyNotFoundException("Collection is Empty");


            var value = last.Value;

            if (last.Parent != null)
            {
                if (last.Rigth != null)
                {
                    last.Parent.Left = last.Rigth;
                    last.Rigth.Parent = last.Parent;
                    
                    last = last.Rigth;
                    while (last.Left != null)
                    {
                        last = last.Left;
                    }
                }
                else
                {
                    last = last.Parent;
                    last.Left = null;
                }

                
            }
            else if(last.Rigth != null)
            {
                head = last.Rigth;
                head.Parent = null;


                last = last.Rigth;
                while (last.Left != null)
                {
                    last = last.Left;
                }
            }
            else
            {
                last = null;
                head = null;
            }

            Count--;
            return value;

        }
    }
}