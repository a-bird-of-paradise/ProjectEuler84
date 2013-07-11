using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler84
{
    class Action : Object, ICloneable
    {
        public int Type { get; private set; }
        public string Value { get; private set; }

        public Action()
        {
            Type = 0;
            Value = "";
        }

        public void MoveToSquare(string MoveTo)
        {
            Type=1;
            Value = (string) MoveTo.Clone();
        }

        public void MoveNumberOfSquares(string NumToMove)
        {
            Type = 2;
            Value = (string)NumToMove.Clone();
        }

        public void Reset()
        {
            Type = 0;
            Value = "";
        }

        public virtual object Clone()
        {
            Action answer = new Action();
            if (this.Type == 1)
                answer.MoveToSquare(this.Value);
            else if (this.Type == 2)
                answer.MoveNumberOfSquares(this.Value);
            return (object)answer;
        }

    }
}
