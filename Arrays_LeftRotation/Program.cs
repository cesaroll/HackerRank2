using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_LeftRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            string[] tokens_n = Console.ReadLine().Split(' ');
            int k = Convert.ToInt32(tokens_n[1]);
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);
            

            var result = a.Skip(k).ToList();

            result.AddRange(a.Take(k));
            */

            var input = Console.ReadLine().Split(' ');
            int size = int.Parse(input[0]);
            int shift = int.Parse(input[1]);
            input = Console.ReadLine().Split(' ');
            var result = new string[size];

            int hop = size - shift;

            for (int currPosition = 0; currPosition < input.Length; currPosition++)
            {
                int newPosition = (currPosition + hop) % size;
                result[newPosition] = input[currPosition];
            }

            foreach (var i in result)
                Console.Write(i + " ");

            Console.ReadKey(true);
        }
    }
}
