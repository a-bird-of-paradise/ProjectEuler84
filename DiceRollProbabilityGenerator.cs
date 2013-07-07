using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler84
{
    class DiceRollProbabilityGenerator
    {
        private int NumDice_;
        private int NumSpots_;

        public DiceRollProbabilityGenerator(int NumDice, int NumSpots) 
        {
            if (NumDice < 1) throw new ArgumentOutOfRangeException("Must have at least one die.");
            if (NumSpots < 1) throw new ArgumentOutOfRangeException("Must have at least one spot.");
            NumDice_ = NumDice;
            NumSpots_ = NumSpots;
        }

        public List<Fraction> GetProbabilities()
        {
            int i = NumDice_;
            List<Fraction> Answer = new List<Fraction>(NumSpots_ * NumDice_ + 1);
            List<Fraction> Current = new List<Fraction>(NumSpots_ * NumDice_ + 1);

            Answer.Add(new Fraction(0));

            for (int j = 1; j <= NumSpots_; j++) Answer.Add(new Fraction(1, NumSpots_));
            for (int j = NumSpots_ + 1; j <= NumSpots_ * NumDice_; j++) Answer.Add(new Fraction(0));
            Fraction Scale = new Fraction(1, NumSpots_);
            i--;            
            while (i > 0)
            {
                Current = Answer.Clone();
                for (int j = 1; j <= NumDice_ * NumSpots_; j++)
                {
                    Fraction x = new Fraction(0);
                    for (int k = 1; k <= NumSpots_; k++)
                    {
                        if (j - k <= 0) break;
                        x += Answer[j - k] * Scale;                        
                    }
                    Current[j] = (Fraction)x.Clone();
                }
                Answer = Current.Clone();
                i--;
            }
            return Answer;
        }


    }
}
