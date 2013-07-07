using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler84
{
    class SquareMatrix<T> : Object , ICloneable where T: ICloneable, new()
    {
        public T[,] Values;
        public int Size { get; private set; }

        public SquareMatrix(int n)
        {
            if (n < 1) throw new ArgumentOutOfRangeException("Must be at least 1x1");
            Values = new T[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    Values[i, j] = new T();
            Size = n;
        }

        public override bool Equals(Object obj)
        {
            SquareMatrix<T> personObj = obj as SquareMatrix<T>;
            if (personObj == null)
                return false;
            else
                return this == (SquareMatrix<T>)obj;
        }

        public override int GetHashCode()
        {
            int answer = 0;
            for (int i = 0; i < Values.GetUpperBound(0); i++)
            {
                for (int j = 0; j < Values.GetUpperBound(1); j++)
                {
                    answer += Values[i, j].GetHashCode();
                }
            }
            return answer;
        }

        public object Clone()
        {
            SquareMatrix<T> Answer = new SquareMatrix<T>(this.Values.GetUpperBound(0));
            for (int i = 0; i < this.Values.GetUpperBound(0); i++)
            {
                for (int j = 0; j < this.Values.GetUpperBound(1); j++)
                {
                    Answer.Values[i, j] = (T)this.Values[i, j].Clone();
                }
            }
            return Answer;
        }

        public static SquareMatrix<T> operator -(SquareMatrix<T> left, SquareMatrix<T> right)
        {
            if (left.Size != right.Size) throw new ArgumentException("Matrices must be of same size");
            SquareMatrix<T> answer = new SquareMatrix<T>(left.Size);
            for (int i = 0; i < answer.Size; i++)
                for (int j = 0; j < answer.Size; j++)
                    answer.Values[i, j] = left.Values[i, j] - right.Values[i, j];
        }
    }
}
