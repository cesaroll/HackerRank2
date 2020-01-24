using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps_Cookies
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(Int32.Parse).ToList();
            //var n = input[0];
            var k = input[1]; // cookie sweetness

            var bakery = new Bakery(k, GetInput());

            Console.WriteLine("{0}", bakery.SweetenCookies());
        }

        
        static List<int> GetInput()
        {
            return (new int[] { 1, 2, 3, 9, 10, 12 }).ToList();
            //return (new int[] { 13, 47, 74, 12, 89, 74, 18, 38 }).ToList();
            //return Console.ReadLine().Split(' ').Select(Int32.Parse).ToList();
        }
        
        
    }
}
