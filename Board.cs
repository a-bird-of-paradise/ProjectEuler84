using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler84
{
    class Board
    {
        protected List<Square> Squares;
        protected Dictionary<string, int> TagLookup;

        protected Die One, Two;

        public Board(Random Generator, Die One_, Die Two_)
        {
            Squares = new List<Square>();

            One = One_;
            Two = Two_;

            Squares.Add(new Square("GO", 0));
            Squares.Add(new Square("A1", 1));
            Squares.Add(new CommunityChestSquare("CC1", 2, Generator));
            Squares.Add(new Square("A2", 3));
            Squares.Add(new Square("T1", 4));
            Squares.Add(new Square("R1", 5));
            Squares.Add(new Square("B1", 6));
            Squares.Add(new ChanceSquare("CH1", 7, Generator, "R2", "U1"));
            Squares.Add(new Square("B2", 8));
            Squares.Add(new Square("B3", 9));

            Squares.Add(new Square("JAIL", 10));
            Squares.Add(new Square("C1", 11));
            Squares.Add(new Square("U1", 12));
            Squares.Add(new Square("C2", 13));
            Squares.Add(new Square("C3", 14));
            Squares.Add(new Square("R2", 15));
            Squares.Add(new Square("D1", 16));
            Squares.Add(new CommunityChestSquare("CC2", 17, Generator));
            Squares.Add(new Square("D2", 18));
            Squares.Add(new Square("D3", 19));

            Squares.Add(new Square("FP", 20));
            Squares.Add(new Square("E1", 21));
            Squares.Add(new ChanceSquare("CH2", 22, Generator, "R3", "U2"));
            Squares.Add(new Square("E2", 23));
            Squares.Add(new Square("E3", 24));
            Squares.Add(new Square("R3", 25));
            Squares.Add(new Square("F1", 26));
            Squares.Add(new Square("F2", 27));
            Squares.Add(new Square("U2", 28));
            Squares.Add(new Square("F3", 29));

            Squares.Add(new GoToJailSquare("G2J", 30));
            Squares.Add(new Square("G1", 31));
            Squares.Add(new Square("G2", 32));
            Squares.Add(new CommunityChestSquare("CC3", 33, Generator));
            Squares.Add(new Square("G3", 34));
            Squares.Add(new Square("R4", 35));
            Squares.Add(new ChanceSquare("CH3", 36,Generator,"R1","U1"));
            Squares.Add(new Square("H1", 37));
            Squares.Add(new Square("T2", 38));
            Squares.Add(new Square("H2", 39));

            TagLookup = new Dictionary<string, int>();
            for (int i = 0; i < 40; i++)
                TagLookup.Add(Squares[i].Tag, i);

        }

        public long[] Simulate(long NumIterations)
        {
            long[] Answer = new long[40];
            int RollOne, RollTwo, NumDoubles = 0;
            string Current = "GO";
            Action DoNext;
            long i = 0;
            while (i++ <= NumIterations)
            {
                RollOne = One.Roll();
                RollTwo = Two.Roll();
                if (RollOne == RollTwo) NumDoubles++;
                if (NumDoubles == 3)
                {
                    Current = "JAIL";
                    NumDoubles = 0;
                }
                else
                {
                    NumDoubles = 0;
                    Current = Squares[(TagLookup[Current] + RollOne + RollTwo) % 40].Tag;
                    DoNext = Squares[TagLookup[Current]].GetAction();
                    while (DoNext.Type != 0)
                    {
                        if (DoNext.Type == 1)
                        {
                            Current = DoNext.Value;
                            DoNext = Squares[TagLookup[Current]].GetAction();
                        }
                        else // type2
                        {
                            Current = Squares[(TagLookup[Current] + int.Parse(DoNext.Value)) % 40].Tag;
                            DoNext = Squares[TagLookup[Current]].GetAction();
                        }
                    }
                }
                Answer[TagLookup[Current] % 40]++;
            }

            return Answer;
        }
    }
}
