using System;
using System.Numerics;
//using Extreme.Mathematics;

//TODO: make charset for common base system.
//TODO: Make It also have decimal points
//TODO: Rename Value to Mantissa to avoid confusion.
//TODO: Make precision changeable.

namespace HugeInt
{
    
    struct HugeInt
    {
        private const int BASE_PRECISION = 3;
        public BigInteger Mantissa { get; private set; }
        public int Exponent { get; private set; }
        public int DigitCount { get; private set; }

        public HugeInt(byte[] mantissa, int exponent)
        {
            DigitCount = 0;
            Mantissa = new BigInteger(mantissa);
            Exponent = exponent;
            Initilize();
        }
        public HugeInt(decimal mantissa, int exponent)
        {
            DigitCount = 0;
            Mantissa = new BigInteger(mantissa);
            Exponent = exponent;
            Initilize();
        }
        public HugeInt(double mantissa, int exponent)
        {
            DigitCount = 0;
            Mantissa = new BigInteger(mantissa);
            Exponent = exponent;
            Initilize();
        }
        public HugeInt(float mantissa, int exponent)
        {
            DigitCount = 0;
            Mantissa = new BigInteger(mantissa);
            Exponent = exponent;
            Initilize();
        }
        public HugeInt(ulong mantissa, int exponent)
        {
            DigitCount = 0;
            Mantissa = new BigInteger(mantissa);
            Exponent = exponent;
            Initilize();
        }
        public HugeInt(long mantissa, int exponent)
        {
            DigitCount = 0;
            Mantissa = new BigInteger(mantissa);
            Exponent = exponent;
            Initilize();
        }
        public HugeInt(uint mantissa, int exponent)
        {
            DigitCount = 0;
            Mantissa = new BigInteger(mantissa);
            Exponent = exponent;
            Initilize();
        }
        public HugeInt(int mantissa, int exponent)
        {
            DigitCount = 0;
            Mantissa = new BigInteger(mantissa);
            Exponent = exponent;
            Initilize();
        }
        public HugeInt(BigInteger mantissa, int exponent)
        {
            DigitCount = 0;
            Mantissa = mantissa;
            Exponent = exponent;
            Initilize();
        }
        
        public HugeInt(byte[] mantissa) : this(mantissa, 0)
        {

        }
        public HugeInt(decimal mantissa) : this(mantissa, 0)
        {

        }
        public HugeInt(double mantissa) : this(mantissa, 0)
        {

        }
        public HugeInt(float mantissa) : this(mantissa, 0)
        {

        }
        public HugeInt(ulong mantissa) : this(mantissa, 0)
        {

        }
        public HugeInt(long mantissa) : this(mantissa, 0)
        {

        }
        public HugeInt(uint mantissa) : this(mantissa, 0)
        {

        }
        public HugeInt(int mantissa) : this(mantissa, 0)
        {

        }
        public HugeInt(BigInteger mantissa) : this(mantissa, 0)
        {

        }


        public static HugeInt MinusOne {
            get { return new HugeInt(-1, 0); }
        }
        public static HugeInt One {
            get { return new HugeInt(1, 0); }
        }
        public static HugeInt Zero {
            get { return new HugeInt(0, 0); }
        }


        public int Sign {
            get { return Mantissa.Sign; }
        }
/*        public bool IsPowerOfTwo {
            get { return _data.IsPowerOfTwo; }
        }*/
        public bool IsZero {
            get { return Mantissa.IsZero; }
        }
        public bool IsOne {
            get { return (Mantissa.IsOne && Exponent == 0); }
        }
/*        public bool isEven {
            get { return false; }
        }*/


        public static HugeInt Abs(HugeInt value)//TODO: Finish it.
        {
            if(value.Mantissa < 0)
                value.Mantissa *= -1;
            return value;
        }
        public static HugeInt Add(HugeInt left, HugeInt right)
        {
            if(left.Exponent == right.Exponent)
                return new HugeInt(left.Mantissa + right.Mantissa, left.Exponent);
            else if(left.Exponent > right.Exponent)
                return new HugeInt(Align(right, left).Mantissa + left.Mantissa, left.Exponent);
            else
                return new HugeInt(Align(left, right).Mantissa + right.Mantissa, right.Exponent);
        }

        public static int Compare(HugeInt left, HugeInt right)
        {
            if(left.Exponent == right.Exponent)
                return BigInteger.Compare(left.Mantissa, right.Mantissa);
            else
                return BigInteger.Compare(left.Exponent, right.Exponent);
        }
        public static HugeInt Divide(HugeInt dividend, HugeInt divisor)
        {
            int digitDiff = BASE_PRECISION - (dividend.Exponent - divisor.Exponent);

            //Add trailing zeros so BigInteger division wont round the decimal point,
            //instead we will get bigger number but we will subtract from exponent
            dividend.Mantissa *= BigInteger.Pow(10, digitDiff);
            BigInteger value = BigInteger.Divide(dividend.Mantissa, divisor.Mantissa);
            int exponent = dividend.Exponent - divisor.Exponent - digitDiff;

            return new HugeInt(value, exponent);
        }
        public static HugeInt DivRem(HugeInt dividend, HugeInt divisor, out HugeInt remainder)
        {
            //Remainder = Numerator - Quotient x Denominator 
            HugeInt quotient = Divide(dividend, divisor);
            HugeInt qd = new HugeInt(-(quotient.Mantissa * divisor.Mantissa), quotient.Exponent + divisor.Exponent);
            remainder = Add(dividend, qd);
            return quotient;
        }

        //public static BigInteger GreatestCommonDivisor(BigInteger left, BigInteger right);
        //public static double Log(BigInteger value, double baseValue);
        //public static double Log(BigInteger value);
        //public static double Log10(BigInteger value);
        //public static BigInteger Max(BigInteger left, BigInteger right);
        //public static BigInteger Min(BigInteger left, BigInteger right);
        //public static BigInteger ModPow(BigInteger value, BigInteger exponent, BigInteger modulus);
        //public static BigInteger Multiply(BigInteger left, BigInteger right);
        //public static BigInteger Negate(BigInteger value);
        //public static BigInteger Parse(string value, NumberStyles style, IFormatProvider provider);
        //public static BigInteger Parse(string value, IFormatProvider provider);
        //public static BigInteger Parse(string value, NumberStyles style);
        //public static BigInteger Parse(string value);
        public static HugeInt Pow(HugeInt value, int exponent)
        {
            BigInteger mantissa = BigInteger.Pow(value.Mantissa, exponent);
            int exp = (int)Math.Pow(value.Exponent, exponent);
            return new HugeInt(mantissa, exp);
        }
        public static HugeInt Remainder(HugeInt dividend, HugeInt divisor)
        {
            //Remainder = Numerator - Quotient x Denominator 
            HugeInt quotient = Divide(dividend, divisor);
            HugeInt qd = new HugeInt(-(quotient.Mantissa * divisor.Mantissa), quotient.Exponent + divisor.Exponent);
            return Add(dividend, qd);
        }
        public static HugeInt Subtract(HugeInt left, HugeInt right)
        {
            if (left.Exponent == right.Exponent)
                return new HugeInt(left.Mantissa - right.Mantissa, left.Exponent);
            else if (left.Exponent > right.Exponent)
                return new HugeInt(Align(right, left).Mantissa - left.Mantissa, left.Exponent);
            else
                return new HugeInt(Align(left, right).Mantissa - right.Mantissa, right.Exponent);
        }
        //public static bool TryParse(string value, out BigInteger result);
        //public static bool TryParse(string value, NumberStyles style, IFormatProvider provider, out BigInteger result);
        //public int CompareTo(long other);
        //public int CompareTo(ulong other);
        //public int CompareTo(BigInteger other);
        //public int CompareTo(object obj);
        //public override bool Equals(object obj);
        //public bool Equals(long other);
        //public bool Equals(ulong other);
        //public bool Equals(BigInteger other);
        //public override int GetHashCode();
        //public byte[] ToByteArray();
        //public string ToString(string format);
        //public override string ToString();
        //public string ToString(string format, IFormatProvider provider);
        //public string ToString(IFormatProvider provider);
        //public static BigInteger operator +(BigInteger value);
        //public static BigInteger operator +(BigInteger left, BigInteger right);
        //public static BigInteger operator -(BigInteger value);
        //public static BigInteger operator -(BigInteger left, BigInteger right);
        //public static BigInteger operator ~(BigInteger value);
        //public static BigInteger operator ++(BigInteger value);
        //public static BigInteger operator --(BigInteger value);
        //public static BigInteger operator *(BigInteger left, BigInteger right);
        //public static BigInteger operator /(BigInteger dividend, BigInteger divisor);
        //public static BigInteger operator %(BigInteger dividend, BigInteger divisor);
        //public static BigInteger operator &(BigInteger left, BigInteger right);
        //public static BigInteger operator |(BigInteger left, BigInteger right);
        //public static BigInteger operator ^(BigInteger left, BigInteger right);
        //public static BigInteger operator <<(BigInteger value, int shift);
        //public static BigInteger operator >>(BigInteger value, int shift);
        //public static bool operator ==(BigInteger left, BigInteger right);
        //public static bool operator ==(BigInteger left, long right);
        //public static bool operator ==(long left, BigInteger right);
        //public static bool operator ==(ulong left, BigInteger right);
        //public static bool operator ==(BigInteger left, ulong right);
        //public static bool operator !=(BigInteger left, BigInteger right);
        //public static bool operator !=(BigInteger left, long right);
        //public static bool operator !=(BigInteger left, ulong right);
        //public static bool operator !=(long left, BigInteger right);
        //public static bool operator !=(ulong left, BigInteger right);
        //public static bool operator <(BigInteger left, ulong right);
        //public static bool operator <(ulong left, BigInteger right);
        //public static bool operator <(BigInteger left, long right);
        //public static bool operator <(BigInteger left, BigInteger right);
        //public static bool operator <(long left, BigInteger right);
        //public static bool operator >(long left, BigInteger right);
        //public static bool operator >(BigInteger left, long right);
        //public static bool operator >(BigInteger left, ulong right);
        //public static bool operator >(BigInteger left, BigInteger right);
        //public static bool operator >(ulong left, BigInteger right);
        //public static bool operator <=(BigInteger left, BigInteger right);
        //public static bool operator <=(BigInteger left, long right);
        //public static bool operator <=(BigInteger left, ulong right);
        //public static bool operator <=(ulong left, BigInteger right);
        //public static bool operator <=(long left, BigInteger right);
        //public static bool operator >=(BigInteger left, ulong right);
        //public static bool operator >=(long left, BigInteger right);
        //public static bool operator >=(BigInteger left, BigInteger right);
        //public static bool operator >=(BigInteger left, long right);
        //public static bool operator >=(ulong left, BigInteger right);
        //public static implicit operator BigInteger(ushort value);
        //public static implicit operator BigInteger(short value);
        //public static implicit operator BigInteger(sbyte value);
        //public static implicit operator BigInteger(ulong value);
        //public static implicit operator BigInteger(byte value);
        //public static implicit operator BigInteger(long value);
        //public static implicit operator BigInteger(uint value);
        //public static implicit operator BigInteger(int value);
        //public static explicit operator ulong(BigInteger value);
        //public static explicit operator BigInteger(float value);
        //public static explicit operator BigInteger(double value);
        //public static explicit operator BigInteger(decimal value);
        //public static explicit operator byte(BigInteger value);
        //public static explicit operator sbyte(BigInteger value);
        //public static explicit operator short(BigInteger value);
        //public static explicit operator int(BigInteger value);
        //public static explicit operator uint(BigInteger value);
        //public static explicit operator decimal(BigInteger value);
        //public static explicit operator double(BigInteger value);
        //public static explicit operator float(BigInteger value);
        //public static explicit operator long(BigInteger value);
        //public static explicit operator ushort(BigInteger value);

        private void Initilize()
        {
            CorrectNumber();
            RoundDigits();
            CalculateDigitCount();
        }

        private void CalculateDigitCount()
        {
            double log10 = BigInteger.Log10(BigInteger.Abs(Mantissa));
            //I Have no idea why does flooring double reduces the number by one 1 (e.g. floor 9.000000000 makes it 8 WTF) 
            //TMP solution add very small amount (Not good practice ik)
            double log10PlusOne = log10 + 1 + 0.000000000000001D;
            DigitCount = (int)Math.Floor(log10PlusOne);
        }
        private void RoundDigits()
        {
            if(Mantissa == 0)
                return;

            CalculateDigitCount();

            if(Exponent < 0)
            {
                while (Exponent < 0)
                {
                    Mantissa /= 10;
                    Exponent++;
                    DigitCount--;
                }
            }
            else if (Exponent > 0)
            {
                while (Exponent > 0 && DigitCount < BASE_PRECISION)
                {
                    Mantissa *= 10;
                    Exponent--;
                    DigitCount++;
                }
            }
        }
        private void CorrectNumber()
        {
            if (Mantissa.IsZero)
                Exponent = 0;
        }
        private static HugeInt Align(HugeInt left, HugeInt right)
        {
            int expDiff = Math.Abs(left.Exponent - right.Exponent);
            for (int i = 0; i < expDiff; i++)
            {
                left.Mantissa /= 10;
                left.Exponent++;
            }
            return left;
        }
        public string ToString(int systemBase)
        {
            if(Exponent == 0)
            {
                return string.Format("{0}", Mantissa);
            }
            else
            {
                char sign = Mantissa < 0 ? '-' : '+';
                return string.Format("{0}E{1}{2}", Mantissa, sign, Exponent);
            }
        }
        public override string ToString()
        {
            return ToString(10);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

    }
}
