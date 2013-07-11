using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler84
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch Timer = new System.Diagnostics.Stopwatch();
            Timer.Start();

            Random Generator = new Random();
            Die One = new Die(4, Generator);
            Die Two = new Die(4, Generator);

            Board Game = new Board(Generator, One, Two);

            long[] Answer = Game.Simulate(100000000);
            int[] Indicies = Answer.Select((v, i) => new { v, i }).OrderByDescending(item => item.v).Take(3).Select(item => item.i).ToArray();
            foreach (int i in Indicies) Console.Write(i.ToString().PadLeft(2,'0'));
            Console.WriteLine("");
            Console.WriteLine(Timer.ElapsedMilliseconds);
        }
    }
}
