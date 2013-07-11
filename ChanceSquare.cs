using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler84
{
    class ChanceSquare : Square
    {
        private Random Generator;
        public string NextR { get; protected set; }
        public string NextU { get; protected set; }

        public ChanceSquare(string Tag_, int Num_, Random Generator_, string NextR_, string NextU_)
            : base(Tag_, Num_)
        {
            Generator = Generator_;
            NextR = (string)NextR_.Clone();
            NextU = (string)NextU_.Clone();
        }

        public override Action GetAction()
        {
            Action Answer = new Action();
            int Number = Generator.Next(1, 16+1);
            switch (Number)
            {
                case 1:
                    Answer.MoveToSquare("GO");
                    break;
                case 2:
                    Answer.MoveToSquare("JAIL");
                    break;
                case 3:
                    Answer.MoveToSquare("C1");
                    break;
                case 4:
                    Answer.MoveToSquare("E3");
                    break;
                case 5:
                    Answer.MoveToSquare("H2");
                    break;
                case 6:
                    Answer.MoveToSquare("R1");
                    break;
                case 7:
                    Answer.MoveToSquare(NextR);
                    break;
                case 8:
                    Answer.MoveToSquare(NextR);
                    break;
                case 9:
                    Answer.MoveToSquare(NextU);
                    break;
                case 10:
                    Answer.MoveNumberOfSquares("-3");
                    break;
                default:
                    break;
            }
            return Answer;
        }

        public override object Clone()
        {
            return new ChanceSquare(Tag, Num, Generator, NextR, NextU);
        }

    }
}
