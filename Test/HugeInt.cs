using System;
using System.Numerics;

//TODO: make charset for common base system.
//TODO: Make It also have decimal points
//TODO: Rename Value to Mantissa to avoid confusion.
//TODO: Make precision changeable.
//TODO: Division by zero check
//TODO: Calculate Digit Count after operation if needed
//TODO: Make sure class is immutable

namespace INLib
{
    struct HugeInt : IComparable, IComparable<HugeInt>, IEquatable<HugeInt>
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
        public bool IsZero {
            get { return Mantissa.IsZero; }
        }
        public bool IsOne {
            get { return (Mantissa.IsOne && Exponent == 0); }
        }
        public bool isEven {
            get {
                if (Exponent > 0)
                    return true;
                else if (Exponent == 0)
                    return Mantissa.IsEven;
                else
                    return false;
            }
        }

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
                return new HugeInt(left.Mantissa + Align(right, left).Mantissa, left.Exponent);
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
            int digitDiff = BASE_PRECISION - (dividend.DigitCount - divisor.DigitCount);
            digitDiff = Math.Max(0, digitDiff);
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
            HugeInt qd = Multiply(quotient, divisor);
            remainder = Subtract(dividend, qd);
            return quotient;
        }
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
            HugeInt qd = Multiply(quotient, divisor);
            return Subtract(dividend, qd);
        }
        public static HugeInt Subtract(HugeInt left, HugeInt right)
        {
            if (left.Exponent == right.Exponent)
                return new HugeInt(left.Mantissa - right.Mantissa, left.Exponent);
            else if (left.Exponent > right.Exponent)
                return new HugeInt(left.Mantissa - Align(right, left).Mantissa, left.Exponent);
            else
                return new HugeInt(Align(left, right).Mantissa - right.Mantissa, right.Exponent);
        }
        public static HugeInt Multiply(HugeInt left, HugeInt right)
        {
            return new HugeInt(left.Mantissa * right.Mantissa, left.Exponent + right.Exponent);
        }
        public static HugeInt Negate(HugeInt value)
        {
            return new HugeInt(-value.Mantissa, value.Exponent);
        }
        public static HugeInt Max(HugeInt left, HugeInt right)
        {
            return left > right ? left : right;
        }
        public static HugeInt Min(HugeInt left, HugeInt right)
        {
            return left < right ? left : right;
        }

        public static double Log(HugeInt value, double baseValue)
        {
            return BigInteger.Log(value.Mantissa, baseValue) + (value.Exponent * Math.Log(10, baseValue));
        }
        public static double Log(HugeInt value)
        {
            return BigInteger.Log(value.Mantissa) + (value.Exponent * Math.Log(10));
        }
        public static double Log10(HugeInt value)
        {
            return BigInteger.Log10(value.Mantissa) + (value.Exponent * Math.Log10(10));
        }


        public static HugeInt GreatestCommonDivisor(HugeInt left, HugeInt right)
        {
            HugeInt a = Max(left, right);
            HugeInt b = Min(left, right);
            HugeInt rem;

            while (true)
            {
                rem = Remainder(a, b);
                if (rem == 0)
                    return b;
                a = b;
                b = rem;
            }
        }
        public static HugeInt ModPow(HugeInt value, int exponent, HugeInt modulus)
        {
            return Remainder(Pow(value, exponent), modulus);
        }
        public static HugeInt Parse(string value)
        {
            string[] values = value.Split('E', 'e');
            int exponent = 0;
            BigInteger mantissa;

            if (values.Length > 0)
            {
                if (values.Length >= 3)
                {
                    //THROW ERROR OR SOMETHING
                }
                if (values.Length >= 2)
                {
                    exponent = int.Parse(values[1]);
                }
                mantissa = BigInteger.Parse(values[0]);
            }
            else
            {
                mantissa = BigInteger.Parse(value);
            }
            return new HugeInt(mantissa, exponent);
        }
        public static bool TryParse(string value, out HugeInt result)
        {
            HugeInt parsedValue;
            try
            {
                parsedValue = Parse(value);
            }
            catch (Exception)
            {
                result = HugeInt.Zero;
                return false;
            }

            result = parsedValue;
            return true;
        }

        public int CompareTo(long other)
        {
            return Compare(this, new HugeInt(other));
        }
        public int CompareTo(ulong other)
        {
            return Compare(this, new HugeInt(other));
        }
        public int CompareTo(HugeInt other)
        {
            return Compare(this, other);
        }
        public int CompareTo(object obj)
        {
            HugeInt other = (HugeInt)obj;
            return Compare(this, other);
        }
        public override bool Equals(object obj)
        {
            HugeInt other = (HugeInt)obj;
            return Compare(this, other) == 0;
        }
        public bool Equals(long other)
        {
            return Compare(this, new HugeInt(other)) == 0;
        }
        public bool Equals(ulong other)
        {
            return Compare(this, new HugeInt(other)) == 0;
        }
        public bool Equals(HugeInt other)
        {
            return Compare(this, other) == 0;
        }
        public override int GetHashCode()
        {
            return Mantissa.GetHashCode() * 7 + Exponent.GetHashCode() * 17;
        }
        public override string ToString()
        {
            if (Exponent == 0)
            {
                return string.Format("{0}", Mantissa);
            }
            else
            {
                return string.Format("{0}E{1}", Mantissa, Exponent);
            }
        }

        #region Arithmatic Operators
        public static HugeInt operator +(HugeInt value)
        {
            return value; 
        }
        public static HugeInt operator +(HugeInt left, HugeInt right)
        {
            return Add(left, right);
        }
        public static HugeInt operator -(HugeInt value)
        {
            return new HugeInt(-value.Mantissa, value.Exponent);
        }
        public static HugeInt operator -(HugeInt left, HugeInt right)
        {
            return Subtract(left, right);
        }
        public static HugeInt operator ++(HugeInt value)
        {
            return value + 1;
        }
        public static HugeInt operator --(HugeInt value)
        {
            return value - 1;
        }
        public static HugeInt operator *(HugeInt left, HugeInt right)
        {
            return Multiply(left, right);
        }
        public static HugeInt operator /(HugeInt dividend, HugeInt divisor)
        {
            return Divide(dividend, divisor);
        }
        public static HugeInt operator %(HugeInt dividend, HugeInt divisor)
        {
            return Remainder(dividend, divisor);
        }
        #endregion

        #region Bitwise Operators
        //public static HugeInt operator ~(HugeInt value);
        //public static BigInteger operator &(BigInteger left, BigInteger right);
        //public static BigInteger operator |(BigInteger left, BigInteger right);
        //public static BigInteger operator ^(BigInteger left, BigInteger right);
        //public static BigInteger operator <<(BigInteger value, int shift);
        //public static BigInteger operator >>(BigInteger value, int shift);
        #endregion

        #region Comparison Operators
        //TODO: add comparisons between doubles and hugeints aswell and BigInteger Too

        public static bool operator ==(HugeInt left, HugeInt right)
        {
            int comp = Compare(left, right);
            return comp == 0 ? true : false;
        }
        public static bool operator ==(HugeInt left, ulong right)
        {
            return left == new HugeInt(right);
        }
        public static bool operator ==(HugeInt left, long right)
        {
            return left == new HugeInt(right);
        }
        public static bool operator ==(long left, HugeInt right)
        {
            return new HugeInt(left) == right;
        }
        public static bool operator ==(ulong left, HugeInt right)
        {
            return new HugeInt(left) == right;
        }
        public static bool operator !=(HugeInt left, HugeInt right)
        {
            int comp = Compare(left, right);
            return comp != 0 ? true : false;
        }
        public static bool operator !=(HugeInt left, ulong right)
        {
            return left != new HugeInt(right);
        }
        public static bool operator !=(HugeInt left, long right)
        {
            return left != new HugeInt(right);
        }
        public static bool operator !=(long left, HugeInt right)
        {
            return new HugeInt(left) != right;
        }
        public static bool operator !=(ulong left, HugeInt right)
        {
            return new HugeInt(left) != right;
        }
        public static bool operator <(HugeInt left, HugeInt right)
        {
            int comp = Compare(left, right);
            return comp == -1 ? true : false;
        }
        public static bool operator <(HugeInt left, ulong right)
        {
            return left < new HugeInt(right);
        }
        public static bool operator <(HugeInt left, long right)
        {
            return left < new HugeInt(right);
        }
        public static bool operator <(ulong left, HugeInt right)
        {
            return new HugeInt(left) < right;
        }
        public static bool operator <(long left, HugeInt right)
        {
            return new HugeInt(left) < right;
        }
        public static bool operator >(HugeInt left, HugeInt right)
        {
            int comp = Compare(left, right);
            return comp == 1 ? true : false;
        }
        public static bool operator >(HugeInt left, ulong right)
        {
            return left > new HugeInt(right);
        }
        public static bool operator >(HugeInt left, long right)
        {
            return left > new HugeInt(right);
        }
        public static bool operator >(ulong left, HugeInt right)
        {
            return new HugeInt(left) > right;
        }
        public static bool operator >(long left, HugeInt right)
        {
            return new HugeInt(left) > right;
        }
        public static bool operator <=(HugeInt left, HugeInt right)
        {
            int comp = Compare(left, right);
            return comp == -1 || comp == 0 ? true : false;
        }
        public static bool operator <=(HugeInt left, ulong right)
        {
            return left <= new HugeInt(right);
        }
        public static bool operator <=(HugeInt left, long right)
        {
            return left <= new HugeInt(right);
        }
        public static bool operator <=(ulong left, HugeInt right)
        {
            return new HugeInt(left) <= right;
        }
        public static bool operator <=(long left, HugeInt right)
        {
            return new HugeInt(left) <= right;
        }
        public static bool operator >=(HugeInt left, HugeInt right)
        {
            int comp = Compare(left, right);
            return comp == 1 || comp == 0 ? true : false;
        }
        public static bool operator >=(HugeInt left, ulong right)
        {
            return left >= new HugeInt(right);
        }
        public static bool operator >=(HugeInt left, long right)
        {
            return left >= new HugeInt(right);
        }
        public static bool operator >=(long left, HugeInt right)
        {
            return new HugeInt(left) >= right;
        }
        public static bool operator >=(ulong left, HugeInt right)
        {
            return new HugeInt(left) >= right;
        }

        public static implicit operator HugeInt(ushort value)
        {
            return new HugeInt(value);
        }
        public static implicit operator HugeInt(short value)
        {
            return new HugeInt(value);
        }
        public static implicit operator HugeInt(sbyte value)
        {
            return new HugeInt(value);
        }
        public static implicit operator HugeInt(ulong value)
        {
            return new HugeInt(value);
        }
        public static implicit operator HugeInt(byte value)
        {
            return new HugeInt(value);
        }
        public static implicit operator HugeInt(long value)
        {
            return new HugeInt(value);
        }
        public static implicit operator HugeInt(uint value)
        {
            return new HugeInt(value);
        }
        public static implicit operator HugeInt(int value)
        {
            return new HugeInt(value);
        }
        public static implicit operator HugeInt(float value)
        {
            return new HugeInt(value);
        }
        public static implicit operator HugeInt(double value)
        {
            return new HugeInt(value);
        }
        public static implicit operator HugeInt(decimal value)
        {
            return new HugeInt(value);
        }

        #endregion


        private void Initilize()
        {
            CalculateDigitCount();
            RoundDigits();
            CorrectNumber();
        }
        private void CalculateDigitCount()
        {
            if (Mantissa.IsZero)
            {
                DigitCount = 0;
                return;
            }
            double log10 = BigInteger.Log10(BigInteger.Abs(Mantissa));
            DigitCount = (int)Math.Floor(log10 + 1);
        }
        private void RoundDigits()
        {
            if(Mantissa.IsZero)
                return;

            while (DigitCount > BASE_PRECISION || Exponent < 0 )
            {
                Mantissa /= 10;
                Exponent++;
                DigitCount--;
            }

            while (DigitCount < BASE_PRECISION && Exponent > 0)
            {
                Mantissa *= 10;
                Exponent--;
                DigitCount++;
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

    }
}