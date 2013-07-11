using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler84
{
    class Square : Object, ICloneable
    {
        public string Tag { get; protected set; }
        public int Num { get; protected set; }

        public Square(string Tag_, int Num_)
        {
            Tag = (string)Tag_.Clone();
            Num = Num_;
        }

        public virtual Action GetAction()
        {
            return new Action();
        }

        public virtual object Clone()
        {
            return new Square(this.Tag, this.Num);
        }

    }
}
