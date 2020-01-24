using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps_Cookies3
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(Int32.Parse).ToList();
            var n = input[0];
            var k = input[1]; // k : cookie sweetness


            var kitchen = new Kitchen(GetInput(), k);

            Console.WriteLine(kitchen.SweetenCookies());
        }

        static string[] GetInput()
        {
            //return new int[] { 1, 2, 3, 9, 10, 12 };            
            return new string[] { "13", "47", "74", "12", "89", "74", "18", "38" };
            //return Console.ReadLine().Split(' ');
        }
        
    }
}
