using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler84
{
    class Die
    {
        protected Random Generator;
        public int NumSpots {get; protected set;}

        public Die(int NumSpots_, Random Generator_)
        {
            if (NumSpots_ < 1) throw new ArgumentOutOfRangeException("Must have at least one spot");
            NumSpots = NumSpots_;
            Generator = Generator_;
        }

        public int Roll()
        {
            return Generator.Next(1, NumSpots+1);
        }
    }
}
