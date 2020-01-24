using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Tree_SwapNodes
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree(GetInput());
            tree.Traverse_InOrder();
            Console.WriteLine();

            tree.Swap(GetSwaps());

            Console.ReadKey(true);
        }


        static int[] GetSwaps()
        {
            var T = Convert.ToInt32(Console.ReadLine());
            var levels = new int[T];

            for (int i = 0; i < T; i++)
            {
                levels[i] = Convert.ToInt32(Console.ReadLine());
            }

            return levels;
        }

//        static string[] GetInput()
//        {
//            return new string[]
//            {
//                "2 3",
//                "-1 -1",
//                "-1 -1"
//            };
//        }

//        static string[] GetInput()
//        {
//            return new string[]
//            {
//                "2 3",
//                "-1 4",
//                "-1 5",
//                "-1 -1",
//                "-1 -1"
//            };
//        }

//        static string[] GetInput()
//        {
//            return new string[]
//            {
//                "2 3",
//                "4 -1",
//                "5 -1",
//                "6 -1",
//                "7 8",
//                "-1 9",
//                "-1 -1",
//                "10 11",
//                "-1 -1",
//                "-1 -1",
//                "-1 -1"
//            };
//        }

            static string[] GetInput()
            {
                return new string[]
                {
                    "2 3",
                    "4 5",
                    "6 -1",
                    "-1 7",
                    "8 9",
                    "10 11",
                    "12 13",
                    "-1 14",
                    "-1 -1",
                    "15 -1",
                    "16 17",
                    "-1 -1",
                    "-1 -1",
                    "-1 -1",
                    "-1 -1",
                    "-1 -1",
                    "-1 -1"
                };
            }

//        static string[] GetInput()
//        {
//            var n = Convert.ToInt32(Console.ReadLine());
//            var array = new string[n];
//
//            for (int i = 0; i < n; i++)
//            {
//                array[i] = Console.ReadLine();
//            }
//
//            return array;
//        }

    }


    public class Tree
    {
        private class Node
        {
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Data { get; private set; }

            public Node(int data)
            {
                Data = data;
            }
        }

        private Node Head { get; set; }
        
        public Tree(string[] input)
        {
            FillTree(input);
        }

        private void FillTree(string[] input)
        {
            var queue = new Queue<Node>();

            Head = NewNode(1);

            queue.Enqueue(Head);
            foreach (var item in input)
            {
                var arr = item.Split(' ');
                var items = Array.ConvertAll(arr, Int32.Parse);

                var node = queue.Dequeue();
                if (items[0] > 0)
                {   
                    node.Left = NewNode(items[0]);
                    queue.Enqueue(node.Left);
                }

                if (items[1] > 0)
                {   
                    node.Right = NewNode(items[1]);
                    queue.Enqueue(node.Right);
                }

            }
        }

        private Node NewNode(int val)
        {   
            return new Node(val);
        }

        /// <summary>
        /// Swap Tree in level
        /// </summary>
        /// <param name="level"></param>
        public void Swap(int[] level)
        {
            for (int i = 0; i < level.Length; i++)
            {
                int prev = -1;

                for (int j = i; j < level.Length; j++)
                {
                    if (prev != level[j])
                    {
                        SwapRec(level[j], 1, Head);
                        prev = level[j];
                    }
                        
                }

                PrintInOrder(Head);

                Console.WriteLine();
            }

            
        }

        private void SwapRec(int level, int current, Node node)
        {
            if (node == null)
                return;

            if (level == current)
            {
                var left = node.Left;
                node.Left = node.Right;
                node.Right = left;
            }
            else
            {
                SwapRec(level, current+1, node.Left);
                SwapRec(level, current + 1, node.Right);
            }

        }

        public void Traverse_InOrder()
        {
            PrintInOrder(Head);
        }

        private void PrintInOrder(Node node)
        {
            if (node == null)
                return;

            PrintInOrder(node.Left);
            Console.Write(node.Data + " ");
            PrintInOrder(node.Right);

        }

    }

}
