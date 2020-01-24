using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataStructures_Tries_Contacts
{
    class Program
    {
        public const string OP_ADD = "add";
        public const string OP_FIND = "find";

        static void Main(String[] args)
        {
            Node root = new Node('*');
            
            int n = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < n; a0++)
            {
                string[] tokens_op = Console.ReadLine().Split(' ');
                string op = tokens_op[0];
                string contact = tokens_op[1];

                if (op == OP_ADD)
                    root.add(contact);

                if (op == OP_FIND)
                    Console.WriteLine(root.find(contact));

            }
            
            Console.ReadKey(true);
        }
    }

    public class Node {
        public ConcurrentDictionary<char, Node> children;
        public char data;
        public volatile int wordCount;
    
        public Node(char d){
            data = d;
            children = new ConcurrentDictionary<char, Node>();
            wordCount = 0;
        }
    
        public void add(string word)
        {
            //Interlocked.Increment(ref wordCount);
            wordCount++;

            if (string.IsNullOrWhiteSpace(word))
                return;

            Node child = null;

            lock (children)
            {
                children.TryGetValue(word[0], out child);

                if (child == null)
                {
                    child = new Node(word[0]);
                    children[word[0]] = child;
                }
            }

            child.add(word.Substring(1));

        }

        public int find(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
                //return (int)Interlocked.Read(ref wordCount);
                return wordCount;

            Node child = null;
            children.TryGetValue(word[0], out child);

            if (child != null)
                return child.find(word.Substring(1));

            return 0;
        }
    
    }
}
