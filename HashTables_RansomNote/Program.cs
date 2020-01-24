using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace HashTables_RansomNote
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens_m = Console.ReadLine().Split(' ');
            int m = Convert.ToInt32(tokens_m[0]);
            int n = Convert.ToInt32(tokens_m[1]);
            string[] magazine = Console.ReadLine().Split(' ');
            string[] ransom = Console.ReadLine().Split(' ');

            Console.WriteLine(Ransom.isWritable(magazine, ransom)? "Yes" : "No");

            Console.ReadKey(true);
        }
    }


    public static class Ransom
    {
        public static bool isWritable(string[] magazine, string[] ransome)
        {
            var hash = new SortedDictionary<string, int>();

            foreach (var s in magazine)
            {
                int count;
                hash.TryGetValue(s, out count);
                hash[s] = ++count;
            }

            foreach (var s in ransome)
            {
                int count;
                if (hash.TryGetValue(s, out count) && count > 0)
                {
                    hash[s] = --count;    
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }

}
