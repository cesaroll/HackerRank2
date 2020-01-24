using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube_Rotation_InPlace
{
    class Program
    {
        static void Main(string[] args)
        {
            var cube = new int[,]
            {
                { 1, 2, 3, 4, 5},
                {16, 0, 0, 0, 6},
                {15, 0, 0, 0, 7},
                {14, 0, 0, 0, 8},
                {13,12,11,10, 9}
            };

            new Cube(5, cube);
           
            Console.ReadKey(true);

        }
    }

    public class Cube
    {
        private int size;
        private int[,] cube;

        public Cube(int size, int[,] cube)
        {
            this.size = size;
            this.cube = cube;

            Print();
            Rotate();
            Print();
        }

        public void Rotate()
        {
            int moving = cube[0, 0];

            // Top row
            for (int curr = 1; curr < size; curr++)
            {
                moving = Move(moving, 0, curr);
            }

            //Right Col
            for (int curr = 1; curr < size; curr++)
            {
                moving = Move(moving, curr, size - 1);
            }

            //Bottom Row
            for (int curr = size - 2; curr >= 0; curr--)
            {
                moving = Move(moving, size - 1, curr);
            }

            //Left Col
            for (int curr = size - 2; curr >= 0; curr--)
            {
                moving = Move(moving, curr, 0);
            }
        }

        private int Move(int val, int x, int y)
        {
            int tmp = cube[x, y];
            cube[x, y] = val;
            return tmp;
        }

        public void Print()
        {
            Console.WriteLine("\n");

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write("{0,3}", cube[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n");
        }
    }

}
