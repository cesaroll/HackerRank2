using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_BalancedBrackets
{
    class Program
    {
        static void Main(String[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                string expression = Console.ReadLine();
                
                Console.WriteLine(isBalanced(expression) ? "YES" : "NO");
            }

            Console.ReadKey(true);
        }

        static bool isBalanced(string expresion)
        {
            var stack = new Stack<char>();

            foreach (var c in expresion)
            {
                switch (c)
                {
                    case '{':
                        stack.Push('}');
                        break;
                    case '[':
                        stack.Push(']');
                        break;
                    case '(':
                        stack.Push(')');
                        break;
                    case '}':
                    case ']':
                    case ')':
                        if (stack.Count == 0 || c != stack.Pop())
                            return false;
                        break;
                }
            }

            return stack.Count == 0;
        }

    }
}
