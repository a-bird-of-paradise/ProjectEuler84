using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler84
{
    class CommunityChestSquare : Square
    {
        private Random Generator;

        public CommunityChestSquare(string Tag_, int Num_, Random Generator_)
            : base(Tag_, Num_)
        {
            Generator = Generator_;
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
                default:
                    break;
            }
            return Answer;
        }

        public override object Clone()
        {
            return new CommunityChestSquare(Tag, Num, Generator);
        }

    }
}
