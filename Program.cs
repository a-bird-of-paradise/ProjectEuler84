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

        static SquareMatrix<Fraction> Ones(int n)
        {
            SquareMatrix<Fraction> Answer = new SquareMatrix<Fraction>(n);
            for (int i = 0; i < n; i++)
                Answer.Values[i, i] = new Fraction(1);
            return Answer;
        }

        static SquareMatrix<Fraction> f(SquareMatrix<Fraction> x)
        {
            SquareMatrix<Fraction> answer = (SquareMatrix<Fraction>) x.Clone();
            int n = answer.Values.GetUpperBound(0);
            for (int i = 0; i < n; i++)
                answer.Values[i, n - 1] = new Fraction(1);
            return answer;
        }

        static void Main(string[] args)
        {
            DiceRollProbabilityGenerator Gen = new DiceRollProbabilityGenerator(2, 4);
            List<Fraction> Probs = Gen.GetProbabilities();
            foreach (Fraction x in Probs) Console.WriteLine(x);
            Console.WriteLine("sum is: "+Probs.Aggregate((x, y) => x + y));
            SquareMatrix<Fraction> z = Ones(40);
        }
    }
}
