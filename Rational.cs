using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incapsulation.RationalNumbers
{
    public class Rational
    {
        public int Numerator;
        public int Denominator;
        public bool IsNan;
        
        public Rational(int a, int b)
        {
            this.Numerator = a;
            this.Denominator = b;

            if (this.Denominator != 0) IsNan= true;
            else IsNan = false;
        }

        public Rational(int a)
        {
            this.Numerator = a;
            this.Denominator = 1;

            if (this.Denominator != 0) IsNan = true;
            else IsNan = false;
        }

        

        public static Rational operator +(Rational a, Rational b)
        {
            Rational result = new Rational(1, 1);
            result.Numerator = result.Numerator / a.Denominator + result.Numerator / b.Denominator;
            result.Denominator = a.Denominator * b.Denominator;

            return result;
        }

        public static Rational operator -(Rational a, Rational b)
        {
            Rational result = new Rational(1, 1);
            result.Numerator = result.Numerator / a.Denominator - result.Numerator / b.Denominator;
            result.Denominator = a.Denominator * b.Denominator;

            return result;
        }

        public static Rational operator *(Rational a, Rational b)
        {
            Rational result = new Rational(1, 1);
            result.Numerator = a.Numerator * b.Numerator;
            result.Denominator = a.Denominator * b.Denominator;

            return result;
        }

        public static Rational operator /(Rational a, Rational b)
        {
            Rational result = new Rational(1, 1);
            result.Numerator = a.Numerator * b.Denominator;
            result.Denominator = a.Denominator * b.Numerator;

            return result;
        }

        public static implicit operator Rational(int a)
        {
            Rational result = new Rational(1, 1);
            result.Numerator = a;            

            return result;
        }

        //public static explicit operator int(Rational a)
        //{
        //    return (int)a.Numerator/a.Denominator;
        //}

        public static implicit operator int(Rational a)
        {
            return (int)a.Numerator / a.Denominator;
        }

        public static explicit operator double(Rational a)
        {
            return (double)a.Numerator / a.Denominator;
        }

        
    }
}
