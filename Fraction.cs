using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler84
{
    class Fraction : Object, ICloneable
    {
        private long Numerator;
        private long Denominator;
        private bool Original;

        public Fraction(long x, long y = 1)
        {
            Numerator = x;
            Denominator = y;
            Original = true;
            if (x == 0)
            {
                y = 0;
            }
            else
            {
                long gcd = GCD(x, y);
                Numerator /= gcd;
                Denominator /= gcd;
                if (gcd > 1) Original = false;
            }
        }

        public override bool Equals(Object obj)
        {
            Fraction personObj = obj as Fraction;
            if (personObj == null)
                return false;
            else
                return this == (Fraction)obj;
        }

        public override int GetHashCode()
        {
            return (int)(Numerator + Denominator);
        }

        public override string ToString()
        {
            return "[" + Numerator + "/" + Denominator + "]";
        }

        public static bool operator ==(Fraction one, Fraction two)
        {
            return one.Numerator == two.Numerator && one.Denominator == two.Denominator;
        }

        public static bool operator !=(Fraction one, Fraction two)
        {
            return one.Numerator != two.Numerator || one.Denominator != two.Denominator;
        }

        public static bool operator >(Fraction one, Fraction two)
        {
            return one.Numerator * two.Denominator > one.Denominator * two.Numerator;
        }

        public static bool operator <(Fraction one, Fraction two)
        {
            return one.Numerator * two.Denominator < one.Denominator * two.Numerator;
        }

        public static bool operator >=(Fraction one, Fraction two)
        {
            return one.Numerator * two.Denominator >= one.Denominator * two.Numerator;
        }

        public static bool operator <=(Fraction one, Fraction two)
        {
            return one.Numerator * two.Denominator <= one.Denominator * two.Numerator;
        }

        public static Fraction operator +(Fraction x, Fraction y)
        {
            if (y.Denominator == x.Denominator && x.Numerator + y.Numerator == 0) return new Fraction(0);
            return new Fraction(x.Numerator * y.Denominator + x.Denominator * y.Numerator, x.Denominator * y.Denominator);
        }

        public static Fraction operator -(Fraction x, Fraction y)
        {
            if (x == y) return new Fraction(0);
            return new Fraction(x.Numerator * y.Denominator - x.Denominator * y.Numerator, x.Denominator * y.Denominator);
        }

        public static Fraction operator *(Fraction x, Fraction y)
        {
            if (x.Numerator == 0 || y.Numerator == 0) return new Fraction(0);
            return new Fraction(x.Numerator * y.Numerator, x.Denominator * y.Denominator);
        }

        public static Fraction operator /(Fraction x, Fraction y)
        {
            if (x.Numerator == 0) return new Fraction(0);
            return new Fraction(x.Numerator * y.Denominator, x.Denominator * y.Numerator);
        }

        public long GCD(long n, long m)
        {
            if (m <= n && n % m == 0)
                return m;
            if (n < m)
                return GCD(m, n);
            return GCD(m, n % m);
        }

        public bool IsOriginal()
        {
            return Original;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }
}
