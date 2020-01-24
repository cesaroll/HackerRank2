using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace Strings_Anagrams
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            string b = Console.ReadLine();

            Console.WriteLine(Anagram.getDeleteCount(a, b));

            Console.ReadKey(true);
        }

        
       
    }

    public static class Anagram
    {
        private const int ABC_SIZE = 26;
        public static int getDeleteCount(string x, string y)
        {
            var vector = new int[ABC_SIZE];

            foreach (var c in x)
            {
                vector[c - 'a']++;
            }

            foreach (var c in y)
            {
                vector[c - 'a']--;
            }

            var count = 0;

            foreach (var i in vector)
            {
                count += Math.Abs(i);
            }

            return count;
        }

    }

    
}
