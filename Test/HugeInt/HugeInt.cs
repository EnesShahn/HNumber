using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HugeInt
{
    class HugeInt
    {
        public sbyte Sign { get; private set; }
        public byte[] Value { get; private set; }
        public long Exponent { get; private set; }
        public int DigitPricision { get; private set; }

        public HugeInt(long value, long exponent, int digitPrecision)
        {
            if (value < 0)
                Sign = -1;
            else if (value == 0)
                Sign = 0;
            else
                Sign = 1;


        }
        public HugeInt(double value, long exponent, int digitPrecision)
        {
            DigitPricision = digitPrecision;
            SetupValues();

            double maxPrecision = Math.Pow(10, ULONG_PRICISION * Value.Length);
            

            if (value < 1)
            {
                while (value < 1)
                {
                    value *= 10;
                    exponent--;
                }
            }
            else
            {
                while (value >= maxPrecision)
                {
                    value /= 10;
                    exponent++;
                }
            }

            int count = 0;
            int digits = (int)Math.Floor(Math.Log10(value)) + 1;
            double divisor = 1;
            /*for (int i = 0; i < digits; i++)
            {
                value = Math.Round(value / divisor);
                Console.WriteLine(lastDigit);
                double lastDigit = value % 10;
                Console.WriteLine(lastDigit);
                Value[count] += (long)(lastDigit * divisor);
                
                divisor *= 10;
                if (i != 0 && i % 19 == 0)
                    count++;
            }*/

            Exponent = exponent;
        }
        public HugeInt(long value, long exponent)
        {

        }
        public HugeInt(double value, long exponent)
        {

        }
        public HugeInt(long value)
        {

        }
        public HugeInt(double value)
        {

        }


        private void SetupValues()
        {
            int valueLength = (int)Math.Ceiling(DigitPricision / (double)ULONG_PRICISION);
            Console.WriteLine(valueLength);
            //Value = new long[valueLength];
        }

        public static HugeInt operator + (HugeInt a, HugeInt b)
        {
            /*
            double aValue = a.Value;
            double bValue = b.Value;

            long exponentDiff = Math.Abs(a.Exponent - b.Exponent);
            double divideBy = Math.Pow(10, exponentDiff);

            double finalValue;
            long finalExponent = Math.Max(a.Exponent, b.Exponent);

            if(a.Exponent > b.Exponent)
                bValue /= divideBy;
            else if(b.Exponent > a.Exponent)
                aValue /= divideBy;

            finalValue = aValue + bValue;
            Round(ref finalValue, ref finalExponent);
            return new HugeInt((long)finalValue, finalExponent);*/
            return null;
        }

        public static HugeInt operator * (HugeInt a, HugeInt b)
        {
            /*
            double aValue = a.Value;
            double bValue = b.Value;

            double finalValue = aValue * bValue;
            long finalExponent = a.Exponent + b.Exponent;

            Round(ref finalValue, ref finalExponent);
            return new HugeInt((long)finalValue, finalExponent);*/
            return null;
        }

        private static void Round(ref double value, ref long exponent)
        {
            if(value < 1)
            {
                while (value < 1)
                {
                    value *= 10;
                    exponent--;
                }
            }
            else
            {
                while (value >= ULONG_PRICISION)
                {
                    value /= 10;
                    exponent++;
                }
            }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override string ToString()
        {
            string valuesContaneted = "";

            for (int i = Value.Length-1; i >= 0; i--)
            {
                valuesContaneted += Value[i].ToString();
            }

            if(Exponent == 0)
            {
                return valuesContaneted;
            }
            else
            {
                return valuesContaneted + "+E" + Exponent;
            }
        }
    }
}
