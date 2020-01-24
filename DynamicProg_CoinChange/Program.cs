using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProg_CoinChange
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(input[0]); //Number of dollars
            //int m = Convert.ToInt32(input[1]);

            var coins = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var coinChange = new CoinChange(n, coins);

            Console.WriteLine(coinChange.MakeChange());

            Console.ReadKey(true);
        }
    }
    
    class CoinChange
    {
        private int Money { get; set; }
        private int[] Coins { get; set; }
        private long[] Calculating { get; set; }

        public CoinChange(int money, int[] coins)
        {
            Money = money;
            Coins = coins;
            Calculating = new long[Money+1]; // O(n) space
        }

        public long MakeChange()
        {
            Calculating[0] = 1;

            for (int i = 0; i < Coins.Length; i++)
            {
                int coin = Coins[i];

                for (int j = coin; j < Calculating.Length; j++)
                {
                    Calculating[j] += Calculating[j - coin];
                }

            }

            return Calculating[Money];
        }
    }
}
