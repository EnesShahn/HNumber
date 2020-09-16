//using Extreme.Mathematics.Calculus;
//using System;
//using System.Numerics;

////TODO: add comparisons between doubles and hugeints aswell and BigInteger Too

//namespace HNLib
//{
//    struct HInt : IComparable, IComparable<HInt>, IEquatable<HInt>
//    {
//        private const int MAX_PRECISION = 3;

//        //public int Precision { get; private set; }
//        public BigInteger Mantissa { get; private set; }
//        public int Exponent { get; private set; }
//        public int DigitCount { get; private set; }

//        public HInt(byte[] mantissa, int exponent)
//        {
//            DigitCount = 0;
//            Mantissa = new BigInteger(mantissa);
//            Exponent = exponent;
//            Initilize();
//        }
//        public HInt(decimal mantissa, int exponent)
//        {
//            DigitCount = 0;
//            Mantissa = new BigInteger(mantissa);
//            Exponent = exponent;
//            Initilize();
//        }
//        public HInt(double mantissa, int exponent)
//        {
//            DigitCount = 0;
//            Mantissa = new BigInteger(mantissa);
//            Exponent = exponent;
//            Initilize();
//        }
//        public HInt(float mantissa, int exponent)
//        {
//            DigitCount = 0;
//            Mantissa = new BigInteger(mantissa);
//            Exponent = exponent;
//            Initilize();
//        }
//        public HInt(ulong mantissa, int exponent)
//        {
//            DigitCount = 0;
//            Mantissa = new BigInteger(mantissa);
//            Exponent = exponent;
//            Initilize();
//        }
//        public HInt(long mantissa, int exponent)
//        {
//            DigitCount = 0;
//            Mantissa = new BigInteger(mantissa);
//            Exponent = exponent;
//            Initilize();
//        }
//        public HInt(uint mantissa, int exponent)
//        {
//            DigitCount = 0;
//            Mantissa = new BigInteger(mantissa);
//            Exponent = exponent;
//            Initilize();
//        }
//        public HInt(int mantissa, int exponent)
//        {
//            DigitCount = 0;
//            Mantissa = new BigInteger(mantissa);
//            Exponent = exponent;
//            Initilize();
//        }
//        public HInt(BigInteger mantissa, int exponent)
//        {
//            DigitCount = 0;
//            Mantissa = mantissa;
//            Exponent = exponent;
//            Initilize();
//        }
        
//        private HInt(BigInteger mantissa, int exponent, bool roundToPrecision)
//        {
//            DigitCount = 0;
//            Mantissa = mantissa;
//            Exponent = exponent;
//            CalculateDigitCount();
//            if (roundToPrecision)
//                RoundToPrecision();
//            CorrectNumber();
//        }
        
//        public HInt(byte[] mantissa) : this(mantissa, 0)
//        {

//        }
//        public HInt(decimal mantissa) : this(mantissa, 0)
//        {

//        }
//        public HInt(double mantissa) : this(mantissa, 0)
//        {

//        }
//        public HInt(float mantissa) : this(mantissa, 0)
//        {

//        }
//        public HInt(ulong mantissa) : this(mantissa, 0)
//        {

//        }
//        public HInt(long mantissa) : this(mantissa, 0)
//        {

//        }
//        public HInt(uint mantissa) : this(mantissa, 0)
//        {

//        }
//        public HInt(int mantissa) : this(mantissa, 0)
//        {

//        }
//        public HInt(BigInteger mantissa) : this(mantissa, 0)
//        {

//        }


//        public static HInt MinusOne {
//            get { return new HInt(-1, 0); }
//        }
//        public static HInt One {
//            get { return new HInt(1, 0); }
//        }
//        public static HInt Zero {
//            get { return new HInt(0, 0); }
//        }

//        public int Sign {
//            get { return Mantissa.Sign; }
//        }
//        public bool IsZero {
//            get { return Mantissa.IsZero; }
//        }
//        public bool IsOne {
//            get { return (Mantissa.IsOne && Exponent == 0); }
//        }
//        public bool IsEven {
//            get {
//                return this % 2 == 0;
//            }
//        }


//        public static HInt Abs(HInt value)
//        {
//            if (value.Mantissa < 0)
//                value.Mantissa *= -1;
//            return value;
//        }
//        private static HInt Add(HInt left, HInt right, bool roundPrecision = true)
//        {
//            if (left.DigitCount > right.DigitCount)
//                right.Truncate(left.DigitCount);
//            else if (left.DigitCount < right.DigitCount)
//                left.Truncate(right.DigitCount);

//            if (left.Exponent < right.Exponent)
//                left = AlignTo(left, right.Exponent);
//            else if (left.Exponent > right.Exponent)
//                right = AlignTo(right, left.Exponent);

//            return new HInt(left.Mantissa + right.Mantissa, Math.Max(left.Exponent, right.Exponent), roundPrecision);
//        }
//        private static HInt Subtract(HInt left, HInt right, bool roundPrecision = true)
//        {
//            if (left.DigitCount > right.DigitCount)
//                right.Truncate(left.DigitCount);
//            else if (left.DigitCount < right.DigitCount)
//                left.Truncate(right.DigitCount);

//            if (left.Exponent < right.Exponent)
//                left = AlignTo(left, right.Exponent);
//            else if (left.Exponent > right.Exponent)
//                right = AlignTo(right, left.Exponent);

//            return new HInt(left.Mantissa - right.Mantissa, Math.Max(left.Exponent, right.Exponent), roundPrecision);
//        }
//        private static HInt Divide(HInt dividend, HInt divisor, bool roundPrecision = true)
//        {
//            if (divisor.IsZero)
//                throw new DivideByZeroException("The Divisor is zero");

//            int digitDiff = MAX_PRECISION - (dividend.DigitCount - divisor.DigitCount);
//            digitDiff = Math.Max(0, digitDiff);
//            dividend.Mantissa *= BigInteger.Pow(10, digitDiff);
//            BigInteger mantissa = BigInteger.Divide(dividend.Mantissa, divisor.Mantissa);
//            int exponent = dividend.Exponent - divisor.Exponent - digitDiff;
//            return new HInt(mantissa, exponent, roundPrecision);
//        }
//        private static HInt Multiply(HInt left, HInt right, bool roundPrecision = true)
//        {
//            return new HInt(left.Mantissa * right.Mantissa, left.Exponent + right.Exponent, roundPrecision);
//        }
//        public static HInt Remainder(HInt dividend, HInt divisor)
//        {
//            //Remainder = Numerator - Quotient x Denominator 
//            HInt quotient = Divide(dividend, divisor, false);
//            HInt qd = Multiply(quotient, divisor, false);
//            return Subtract(dividend, qd);
//        }
//        public static HInt DivRem(HInt dividend, HInt divisor, out HInt remainder)
//        {
//            //Remainder = Numerator - Quotient x Denominator 
//            HInt quotient = Divide(dividend, divisor, false);
//            HInt qd = Multiply(quotient, divisor, false);
//            remainder = Subtract(dividend, qd);
//            return quotient;
//        }
//        public static HInt Pow(HInt value, int  exponent)
//        {
//            if (exponent < 0)
//                throw new ArgumentOutOfRangeException();
//            BigInteger mantissa = BigInteger.Pow(value.Mantissa, exponent);
//            int exp = value.Exponent * exponent;
//            return new HInt(mantissa, exp);
//        }
//        public static HInt Negate(HInt value)
//        {
//            return new HInt(-value.Mantissa, value.Exponent);
//        }
//        public static HInt Max(HInt left, HInt right)
//        {
//            return Compare(left, right) == 1 ? left : right;
//        }
//        public static HInt Min(HInt left, HInt right)
//        {
//            return Compare(left, right) == -1 ? left : right;
//        }
//        public static double Log(HInt value, double baseValue)
//        {
//            return BigInteger.Log(value.Mantissa, baseValue) + (value.Exponent * Math.Log(10, baseValue));
//        }
//        public static double Log(HInt value)
//        {
//            return BigInteger.Log(value.Mantissa) + (value.Exponent * Math.Log(10));
//        }
//        public static double Log10(HInt value)
//        {
//            return BigInteger.Log10(value.Mantissa) + (value.Exponent * Math.Log10(10));
//        }
//        public static HInt GreatestCommonDivisor(HInt left, HInt right)
//        {
//            left = Abs(left);
//            right = Abs(right);
//            HInt a = Max(left, right);
//            HInt b = Min(left, right);
//            HInt rem;
//            while (true)
//            {
//                rem = Remainder(a, b);
//                if (rem == 0)
//                    return b;
//                a = b;
//                b = rem;
//            }
//        }
//        public static HInt ModPow(HInt value, HInt exponent, HInt modulus)
//        {
//            if (modulus == 1)
//                return 0;
//            HInt curPow = value % modulus;
//            HInt res = 1;
//            while (exponent > 0)
//            {
//                if (exponent % 2 == 1)
//                    res = (res * curPow) % modulus;
//                exponent = exponent / 2;
//                curPow = (curPow * curPow) % modulus;
//            }
//            return res;
//        }
//        public static HInt Parse(string value)
//        {
//            string[] values = value.Split('E', 'e');
//            int exponent = 0;
//            BigInteger mantissa;

//            if (values.Length > 0)
//            {
//                if (values.Length >= 3)
//                {
//                    //TODO: THROW ERROR OR SOMETHING
//                }
//                if (values.Length >= 2)
//                {
//                    exponent = int.Parse(values[1]);
//                }
//                mantissa = BigInteger.Parse(values[0]);
//            }
//            else
//            {
//                mantissa = BigInteger.Parse(value);
//            }
//            return new HInt(mantissa, exponent);
//        }
//        public static bool TryParse(string value, out HInt result)
//        {
//            try
//            {
//                result = Parse(value);
//            }
//            catch (Exception)
//            {
//                result = HInt.Zero;
//                return false;
//            }
//            return true;
//        }
//        public static int Compare(HInt left, HInt right)
//        {
//            if (left.Sign > right.Sign)
//                return 1;
//            else if (left.Sign < right.Sign)
//                return -1;

//            if (left.Exponent == right.Exponent)
//                return BigInteger.Compare(left.Mantissa, right.Mantissa);
//            else
//                return (left.Exponent * left.Sign) > (right.Exponent * right.Sign) ? 1 : -1;
//        }
//        public int CompareTo(long other)
//        {
//            return Compare(this, new HInt(other));
//        }
//        public int CompareTo(ulong other)
//        {
//            return Compare(this, new HInt(other));
//        }
//        public int CompareTo(HInt other)
//        {
//            return Compare(this, other);
//        }
//        public int CompareTo(object obj)
//        {
//            HInt other = (HInt)obj;
//            return Compare(this, other);
//        }
//        public override bool Equals(object obj)
//        {
//            HInt other = (HInt)obj;
//            return Compare(this, other) == 0;
//        }
//        public bool Equals(long other)
//        {
//            return Compare(this, new HInt(other)) == 0;
//        }
//        public bool Equals(ulong other)
//        {
//            return Compare(this, new HInt(other)) == 0;
//        }
//        public bool Equals(HInt other)
//        {
//            return Compare(this, other) == 0;
//        }
//        public override int GetHashCode()
//        {
//            return Mantissa.GetHashCode() * 7 + Exponent.GetHashCode() * 17;
//        }
//        public override string ToString()
//        {
//            if (Exponent == 0)
//            {
//                return string.Format("{0}", Mantissa);
//            }
//            else
//            {
//                return string.Format("{0}E{1}", Mantissa, Exponent);
//            }
//        }

//        #region Arithmatic Operators
//        public static HInt operator +(HInt value)
//        {
//            return value;
//        }
//        public static HInt operator +(HInt left, HInt right)
//        {
//            return Add(left, right);
//        }
//        public static HInt operator -(HInt value)
//        {
//            return new HInt(-value.Mantissa, value.Exponent);
//        }
//        public static HInt operator -(HInt left, HInt right)
//        {
//            return Subtract(left, right);
//        }
//        public static HInt operator ++(HInt value)
//        {
//            return value + 1;
//        }
//        public static HInt operator --(HInt value)
//        {
//            return value - 1;
//        }
//        public static HInt operator *(HInt left, HInt right)
//        {
//            return Multiply(left, right);
//        }
//        public static HInt operator /(HInt dividend, HInt divisor)
//        {
//            return Divide(dividend, divisor);
//        }
//        public static HInt operator %(HInt dividend, HInt divisor)
//        {
//            return Remainder(dividend, divisor);
//        }
//        #endregion

//        #region Comparison Operators

//        public static bool operator ==(HInt left, HInt right)
//        {
//            int comp = Compare(left, right);
//            return comp == 0 ? true : false;
//        }
//        public static bool operator !=(HInt left, HInt right)
//        {
//            int comp = Compare(left, right);
//            return comp != 0 ? true : false;
//        }
//        public static bool operator <(HInt left, HInt right)
//        {
//            int comp = Compare(left, right);
//            return comp == -1 ? true : false;
//        }
//        public static bool operator >(HInt left, HInt right)
//        {
//            int comp = Compare(left, right);
//            return comp == 1 ? true : false;
//        }
//        public static bool operator <=(HInt left, HInt right)
//        {
//            int comp = Compare(left, right);
//            return comp == -1 || comp == 0 ? true : false;
//        }
//        public static bool operator >=(HInt left, HInt right)
//        {
//            int comp = Compare(left, right);
//            return comp == 1 || comp == 0 ? true : false;
//        }

//        #endregion

//        #region Implicit/Explicit Operators
//        public static implicit operator HInt(ushort value)
//        {
//            return new HInt(value);
//        }
//        public static implicit operator HInt(short value)
//        {
//            return new HInt(value);
//        }
//        public static implicit operator HInt(sbyte value)
//        {
//            return new HInt(value);
//        }
//        public static implicit operator HInt(ulong value)
//        {
//            return new HInt(value);
//        }
//        public static implicit operator HInt(byte value)
//        {
//            return new HInt(value);
//        }
//        public static implicit operator HInt(long value)
//        {
//            return new HInt(value);
//        }
//        public static implicit operator HInt(uint value)
//        {
//            return new HInt(value);
//        }
//        public static implicit operator HInt(int value)
//        {
//            return new HInt(value);
//        }
//        public static implicit operator HInt(float value)
//        {
//            return new HInt(value);
//        }
//        public static implicit operator HInt(double value)
//        {
//            return new HInt(value);
//        }
//        public static implicit operator HInt(decimal value)
//        {
//            return new HInt(value);
//        }
//        #endregion

//        private void Initilize()
//        {
//            CalculateDigitCount();
//            RoundToPrecision();
//            CorrectNumber();
//        }
//        private void CalculateDigitCount()
//        {
//            if (Mantissa.IsZero)
//                return;
//            double log10 = BigInteger.Log10(BigInteger.Abs(Mantissa));
//            DigitCount = (int)Math.Floor(log10 + 1);
//        }
//        private void RoundToInt()
//        {
//            int exp = Math.Min(0, Exponent);
//            Truncate(DigitCount + exp);
//        }
//        private void RoundToPrecision()
//        {
//            int prec = MAX_PRECISION - DigitCount;
//            prec = Math.Min(prec, Exponent);
//            Truncate(DigitCount + prec);
//        }
//        private void Truncate(int precision)
//        {
//            if (Mantissa.IsZero)
//                return;

//            while (DigitCount > precision)
//            {
//                Mantissa /= 10;
//                Exponent++;
//                DigitCount--;
//            }

//            while (DigitCount < precision)
//            {
//                Mantissa *= 10;
//                Exponent--;
//                DigitCount++;
//            }
//        }
//        private void CorrectNumber()
//        {
//            if (Mantissa.IsZero)
//            {
//                DigitCount = 0;
//                Exponent = 0;
//            }
//        }
//        private static HInt AlignTo(HInt value, int toExponent)
//        {
//            int expDiff = Math.Abs(value.Exponent - toExponent);
//            for (int i = 0; i < expDiff; i++)
//            {
//                value.Mantissa /= 10;
//                value.Exponent++;
//            }
//            return value;
//        }
//    }
//}