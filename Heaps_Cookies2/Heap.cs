using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps_Cookies2
{
    public class Heap //MinHeap
    {
        private Tree[] Buckets;
        private int BucketCount;
        
        public Heap(int size)
        {   
            var trees = new List<Tree>();

            //BucketCount = (size > 10000)? size / 10000 : 1;
            //BucketCount++;
            BucketCount = 100;
                        
            for (int i = 0; i < BucketCount; i++)
            {
                trees.Add(new Tree());
            }

            Buckets = trees.ToArray();

        }

        #region Heap

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

        private Tree GetBucketWithMinKey
        {
            get
            {
                if (IsEmpty)
                    throw new KeyNotFoundException("Collection is empty");

                Tree min = null;

                foreach (var tree in Buckets)
                {
                    if (tree.IsEmpty)
                        continue;

                    if (min == null || tree.Peek <= min.Peek)
                        min = tree;

                }
                
                return min;

            }
        }
                
        public void Push(int value)
        {
            GetPushBucket(value).Push(value);
            //Buckets[value % BucketCount].Push(value);
        }

        private Tree GetPushBucket(int value)
        {
            int start = (value % 10) * 10;

            Tree tree = null;

            for (int i = start; i < start + 10; i++)
            {
                if (tree == null || Buckets[i].Count <= tree.Count)
                    tree = Buckets[i];
            }

            return tree;

        }
        
        public int Pop()
        {
            return GetBucketWithMinKey.Pop();
        }

        #endregion

        #region Node

        private class Node
        {
            public Node Parent { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Key { get; private set; }
            public int Magnitud { get; set; }

            public Node(int data, Node parent)
            {
                Key = data;
                Magnitud = 1;
                Parent = parent;
            }
        }

        #endregion

        #region Tree

        private class Tree
        {
            private Node Head { get; set; }
            private Node Top { get; set; }
            public int Count { get; private set; }

            public Tree()
            {
                Count = 0;
            }

            public bool IsEmpty
            {
                get { return Count == 0; }
            }

            public int Peek
            {
                get
                {
                    if (Top == null)
                        throw new KeyNotFoundException("Collection is empty");

                    return Top.Key;
                }
            }


            public void Push(int val)
            {   
                if (Head == null)
                {
                    Head = NewNode(val, null);
                    Top = Head;
                }
                else
                {
                    Push(Head, val);

                }

            }

            private void Push(Node parent, int key)
            {
                if(parent.Key == key)
                {
                    parent.Magnitud++;

                } else if(parent.Key > key)
                {
                    //Left side
                    if(parent.Left == null)
                        parent.Left = NewNode(key, parent);
                    else
                        Push(parent.Left, key);

                }
                else
                {
                    //Right Side
                    if(parent.Right == null)                        
                        parent.Right = NewNode(key, parent);
                    else
                        Push(parent.Right, key);
                }
                    

            }

            private Node NewNode(int data, Node parent)
            {
                Count++;

                var newNode = new Node(data, parent);

                if (Top == null || newNode.Key < Top.Key)
                    Top = newNode;

                return newNode;
            }

            public int Pop()
            {
                if (Top == null)
                    throw new KeyNotFoundException("Collection is empty");

                var value = Top.Key;
                Top.Magnitud--;

                if(Top.Magnitud <= 0)
                {
                    FindTop();
                    Count--;
                }

                return value;
            }

            private void FindTop()
            {
                if(Top.Parent != null)
                {
                    if(Top.Right != null)
                    {
                        var parent = Top.Parent;
                        var right = Top.Right;

                        right.Parent = parent;
                        parent.Left = right;

                        Top = right;
                        while(Top.Left != null)
                        {
                            Top = Top.Left;
                        }
                    }
                    else
                    {
                        Top = Top.Parent;
                        Top.Left = null;
                    }
                }
                else if(Top.Right != null)
                {
                    Head = Top.Right;
                    Head.Parent = null;

                    Top = Top.Right;
                    while(Top.Left != null)
                    { Top = Top.Left; }
                }
                else
                {
                    Head = null;
                    Top = null;
                }
                
            }
        }

        

        #endregion
    }
}
