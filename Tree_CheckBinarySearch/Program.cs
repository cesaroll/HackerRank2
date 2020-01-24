using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree_CheckBinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree(GetValues());
            Console.WriteLine(tree.IsBinarySearch());
            Console.ReadKey(true);
        }

        static int[] GetValues()
        {
            return new int[] {3,2,6,1,4,5,7};
        }
    }

    public class Tree
    {
        private Node Head { get; set; }
        private class Node
        {
            public int Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(int data)
            {
                Data = data;
            }
        }

        public Tree(int[] values)
        {
            FillTree(values);
        }

        public bool IsBinarySearch()
        {
            if (Head == null)
                return true;

            var list = new List<int>();

            TraverseInOrder(Head, list);

            int prev = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                if (prev >= list[i])
                    return false;

                prev = list[i];

            }

            return true;
        }

        private void TraverseInOrder(Node node, List<int> list)
        {
            if(node == null)
                return;

            TraverseInOrder(node.Left, list);
            list.Add(node.Data);
            TraverseInOrder(node.Right, list);

        }

        

        private void FillTree(int[] values)
        {
            if (values.Length == 0)
                return;

            var queue = new Queue<Node>();

            Head = new Node(values[0]);
            queue.Enqueue(Head);

            
            for (int i = 1; i < values.Length; i++)
            {
                var node = queue.Dequeue();

                if (values[i] > 0)
                {
                    var newNode = new Node(values[i]);
                    queue.Enqueue(newNode);
                    node.Left = newNode;
                }

                i++;
                if (i < values.Length && values[i] > 0)
                {
                    var newNode = new Node(values[i]);
                    queue.Enqueue(newNode);
                    node.Right = newNode;   
                }


            }

        }

    }
}
