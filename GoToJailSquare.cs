using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler84
{
    class GoToJailSquare : Square
    {

        public GoToJailSquare(string Tag_, int Num_)
            : base(Tag_, Num_)
        {
        }

        public override Action GetAction()
        {
            Action Answer = new Action();
            Answer.MoveToSquare("JAIL");
            return Answer;
        }

        public override object Clone()
        {
            return new GoToJailSquare(Tag, Num);
        }
    }
}
