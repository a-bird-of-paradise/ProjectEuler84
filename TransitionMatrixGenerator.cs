using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler84
{
    class TransitionMatrixGenerator : Object, ICloneable
    {
        private int Spots;

        public TransitionMatrixGenerator(int NumSpots)
        {
            Spots = NumSpots;
        }

        public object Clone()
        {
            return new TransitionMatrixGenerator(Spots);
        }

        public SquareMatrix<Fraction> GetTransitionMatrix(int SpotsOnDie)
        {
            SquareMatrix<Fraction> a1, a2, a3;
            a1 = this.InnerGetTransitionMatrix(SpotsOnDie);
            a2 = a1 * a1;
            a3 = a2 * this.InnerGetTransitionMatrix(SpotsOnDie, true);

            Fraction a1s, a2s, a3s;
            a1s = new Fraction(5, 6);
            a2s = a1s * new Fraction(1, 6);
            a3s = new Fraction(1, 6 * 6 * 6);
        }

        private SquareMatrix<Fraction> InnerGetTransitionMatrix(int SpotsOnDie, bool IncludeDoubles = false, bool PenaliseDoubles=false)
        {
            SquareMatrix<Fraction> a1 = new SquareMatrix<Fraction>(40);

            DiceRollProbabilityGenerator Prob = new DiceRollProbabilityGenerator(2, SpotsOnDie);

            List<Fraction> ProbVector;

            if (IncludeDoubles && PenaliseDoubles)
                ProbVector = Prob.GetOneThrowProbabilitiesExDouble(false);
            if (IncludeDoubles)
                ProbVector = Prob.GetOneThrowProbabilitiesExDouble();
            else
                ProbVector = Prob.GetProbabilities();

            int NumProbs = ProbVector.Count();

            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < NumProbs; j++)
                {
                    a1.Values[i, (i + j) % 40] = (Fraction)ProbVector[j].Clone();
                }
            }
            // row 30: 100% go to jail (col 10)
            for (int i = 0; i < 40; i++)
                a1.Values[30, i] = new Fraction(0);
            a1.Values[30, 10] = new Fraction(1);

            //community chests: 2, 17, 33
            // scale by 7/8; 1/16 to go, 1/16 to jail
            int[] cclist = new int[] { 2, 17, 33 };
            foreach (int i in cclist)
            {
                for (int j = 0; j < 40; j++)
                {
                    a1.Values[i, j] *= new Fraction(7, 8);
                }
                a1.Values[i, 10] += new Fraction(1, 16);
                a1.Values[i, 0] += new Fraction(1, 16);
            }

            // chance: 7,22,33
            // scale by 6/16; 1/16 to each of go, jail, c1,e3,h2,r1,R,R,U,-3
            cclist = new int[] { 7, 22, 33 };
            foreach (int i in cclist)
            {
                for (int j = 0; j < 40; j++)
                {
                    a1.Values[i, j] = new Fraction(6, 16);
                }
                //go
                a1.Values[i, 0] += new Fraction(1, 16);
                //jail
                a1.Values[i, 10] += new Fraction(1, 16);
                // c1 (11)
                a1.Values[i, 11] += new Fraction(1, 16);
                // e3 (24)
                a1.Values[i, 24] += new Fraction(1, 16);
                // h2 (38)
                a1.Values[i, 38] += new Fraction(1, 16);
                // r1 (5)
                a1.Values[i, 5] += new Fraction(1, 16);
                // U SPECIAL
                if (i == 7 || i == 33)
                    a1.Values[i, 12] += new Fraction(1, 16);
                else
                    a1.Values[i, 28] += new Fraction(1, 16);
                // R SPECIAL DOUBLED
                if (i == 7)
                    a1.Values[i, 15] += new Fraction(1, 8);
                if (i == 22)
                    a1.Values[i, 25] += new Fraction(1, 8);
                else
                    a1.Values[i, 5] += new Fraction(1, 8);
                // -3
                a1.Values[i, i - 3] += new Fraction(1, 16);
            }
            // special chance: ch3 has a 1/16 of a CC, which itself has a 1/16 of GO or J
            // so scale ch3-3 by 15/16, and add (1/16)^2 to each of Go and J
            a1.Values[36, 33] *= new Fraction(15, 16);
            a1.Values[36, 0] += new Fraction(1, 16 * 16);
            a1.Values[36, 10] += new Fraction(1, 16 * 16);

            if (PenaliseDoubles)
            {
                for (int i = 0; i < 40; i++)
                {
                    a1.Values[i, 10] += Prob.GetDoubleProbability();
                }
            }

            return a1;        
        }
    }
}
