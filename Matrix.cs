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
            SquareMatrix<T> Answer = new SquareMatrix<T>(this.Values.GetUpperBound(0)+1);
            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
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
                    answer.Values[i, j] = (dynamic)(left.Values[i, j]) - (dynamic)(right.Values[i, j]);
            return answer;
        }
        public static SquareMatrix<T> operator *(SquareMatrix<T> left, int right)
        {
            SquareMatrix<T> answer = (SquareMatrix<T>)left.Clone();
            for (int i = 0; i < answer.Size; i++)
                for (int j = 0; j < answer.Size; j++)
                    answer.Values[i, j] = (dynamic)answer.Values[i, j] * right;
            return answer;
        }
        public static SquareMatrix<T> operator *(int left, SquareMatrix<T> right)
        {
            return right * left;
        }

        public static SquareMatrix<T> operator *(SquareMatrix<T> left, T right)
        {
            SquareMatrix<T> answer = (SquareMatrix<T>)left.Clone();
            for (int i = 0; i < answer.Size; i++)
                for (int j = 0; j < answer.Size; j++)
                    answer.Values[i, j] = (dynamic)answer.Values[i, j] * right;
            return answer;
        }
        public static SquareMatrix<T> operator *(T left, SquareMatrix<T> right)
        {
            return right * left;
        }

        public static SquareMatrix<T> operator *(SquareMatrix<T> left, SquareMatrix<T> right)
        {
            if (left.Size != right.Size) throw new ArgumentException("Matrices must be of the same size.");
            SquareMatrix<T> answer = new SquareMatrix<T>(left.Size);
            int n = answer.Size;
            T accum = new T();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        for (int l = 0; l < n; l++)
                        {
                            accum = accum + (dynamic) left.Values[i, k] * right.Values[l, j];
                        }
                    }
                }
            }
            return answer;
        }
    }
}
