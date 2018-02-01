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

            int a_sokr = this.Reduce().Numerator;
            int b_sokr = this.Reduce().Denominator;

            if(a<0) this.Numerator = - a_sokr;
            else this.Numerator = a_sokr;

            if(b<0) this.Denominator = - b_sokr;
            else this.Denominator = b_sokr;
            //comment
        }

        public Rational(int a)
        {
            this.Numerator = a;
            this.Denominator = 1;

            if (this.Denominator != 0) IsNan = true;
            else IsNan = false;

            this.Reduce();
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

        public static implicit operator double(Rational a)
        {
            return (double)a.Numerator / a.Denominator;
        }

        // Возвращает наибольший общий делитель (Алгоритм Евклида)
        private static int getGreatestCommonDivisor(int c, int d)
        {
            int a = Math.Abs(c);
            int b = Math.Abs(d);

            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        // Возвращает наименьшее общее кратное
        private static int getLeastCommonMultiple(int c, int d)
        {
            int a = Math.Abs(c);
            int b = Math.Abs(d);
            // В формуле опушен модуль, так как в классе
            // числитель всегда неотрицательный, а знаменатель -- положительный
            // ...
            // Деление здесь -- челочисленное, что не искажает результат, так как
            // числитель и знаменатель делятся на свои делители,
            // т.е. при делении не будет остатка

            return a * b / getGreatestCommonDivisor(a, b);
        }

        //возвращает сокращённую дробь
        public Rational Reduce()
        {
            Rational result = this;
            int greatestCommonDivisor = getGreatestCommonDivisor(this.Numerator, this.Denominator);
            result.Numerator /= greatestCommonDivisor;
            result.Denominator /= greatestCommonDivisor;
            return result;
        }
    }
}
