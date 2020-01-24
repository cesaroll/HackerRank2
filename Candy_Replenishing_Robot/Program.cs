using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candy_Replenishing_Robot
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            int n = input[0];
            int t = input[1];

            var c = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            //var refill = new int[t];
            int refill = 0;

            //var bowl = new int[t + 1];
            var bowl = new int[2];
            bowl[0] = n;

            for(int i=0, j=1; j < t; i++, j=i+1)
            {
                bowl[1] = bowl[0] - c[i];

                if(bowl[1] < c[j]) //Refill
                {
                    //refill[i] = n - bowl[j];
                    refill += n - bowl[1];
                    bowl[1] = n;
                }

                bowl[0] = bowl[1];
            }

            /*
            var printout = refill.Select(x => x.ToString()).Aggregate((x, y) => x + " " + y);
            var tot = refill.Sum();
            Console.WriteLine($"\n{printout}\nTotal: {tot}");
            */

            Console.WriteLine(refill);

        }
    }
}
