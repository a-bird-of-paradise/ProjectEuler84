using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler84
{
    static class Extensions
    {
        public static List<T> Clone<T>(this List<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DiceRollProbabilityGenerator Gen = new DiceRollProbabilityGenerator(2, 4);
            List<Fraction> Probs = Gen.GetProbabilities();
            foreach (Fraction x in Probs) Console.WriteLine(x);
            Console.WriteLine("sum is: "+Probs.Aggregate((x, y) => x + y));
        }
    }
}
