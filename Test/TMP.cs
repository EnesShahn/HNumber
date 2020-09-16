//using System;
//using System.Numerics;

////TODO: add comparisons between doubles and hugeints aswell and BigInteger Too

//namespace HNLib
//{
//    struct HNumber
//    {
//        private const int DEFAULT_PRECISION = 3;

//        public BigInteger Mantissa { get; private set; }
//        public int Exponent { get; private set; }
//        public int DigitCount { get; private set; }
//        public int Precision { get; private set; }

//        public HNumber(byte[] mantissa, int exponent, int precision)
//        {
//            Mantissa = new BigInteger(mantissa);
//            Exponent = Mantissa.IsZero ? 0 : exponent;
//            DigitCount = CalculateDigitCount(Mantissa);
//            Precision = precision;
//            Round(RoundingMode.Precision);
//        }
//        public HNumber(decimal mantissa, int exponent, int precision)
//        {
//            Mantissa = new BigInteger(mantissa);
//            Exponent = Mantissa.IsZero ? 0 : exponent;
//            DigitCount = CalculateDigitCount(Mantissa);
//            Precision = precision;
//            Round(RoundingMode.Precision);
//        }
//        public HNumber(double mantissa, int exponent, int precision)
//        {
//            Mantissa = new BigInteger(mantissa);
//            Exponent = Mantissa.IsZero ? 0 : exponent;
//            DigitCount = CalculateDigitCount(Mantissa);
//            Precision = precision;
//            Round(RoundingMode.Precision);
//        }
//        public HNumber(float mantissa, int exponent, int precision)
//        {
//            Mantissa = new BigInteger(mantissa);
//            Exponent = Mantissa.IsZero ? 0 : exponent;
//            DigitCount = CalculateDigitCount(Mantissa);
//            Precision = precision;
//            Round(RoundingMode.Precision);
//        }
//        public HNumber(ulong mantissa, int exponent, int precision)
//        {
//            Mantissa = new BigInteger(mantissa);
//            Exponent = Mantissa.IsZero ? 0 : exponent;
//            DigitCount = CalculateDigitCount(Mantissa);
//            Precision = precision;
//            Round(RoundingMode.Precision);
//        }
//        public HNumber(long mantissa, int exponent, int precision)
//        {
//            Mantissa = new BigInteger(mantissa);
//            Exponent = Mantissa.IsZero ? 0 : exponent;
//            DigitCount = CalculateDigitCount(Mantissa);
//            Precision = precision;
//            Round(RoundingMode.Precision);
//        }
//        public HNumber(uint mantissa, int exponent, int precision)
//        {
//            Mantissa = new BigInteger(mantissa);
//            Exponent = Mantissa.IsZero ? 0 : exponent;
//            DigitCount = CalculateDigitCount(Mantissa);
//            Precision = precision;
//            Round(RoundingMode.Precision);
//        }
//        public HNumber(int mantissa, int exponent, int precision)
//        {
//            Mantissa = new BigInteger(mantissa);
//            Exponent = Mantissa.IsZero ? 0 : exponent;
//            DigitCount = CalculateDigitCount(Mantissa);
//            Precision = precision;
//            Round(RoundingMode.Precision);
//        }
//        public HNumber(BigInteger mantissa, int exponent, int precision)
//        {
//            Mantissa = mantissa;
//            Exponent = Mantissa.IsZero ? 0 : exponent;
//            DigitCount = CalculateDigitCount(Mantissa);
//            Precision = precision;
//            Round(RoundingMode.Precision);
//        }

//        public HNumber(byte[] mantissa, int exponent) : this(mantissa, exponent, DEFAULT_PRECISION)
//        {
//        }
//        public HNumber(decimal mantissa, int exponent) : this(mantissa, exponent, DEFAULT_PRECISION)
//        {
//        }
//        public HNumber(double mantissa, int exponent) : this(mantissa, exponent, DEFAULT_PRECISION)
//        {
//        }
//        public HNumber(float mantissa, int exponent) : this(mantissa, exponent, DEFAULT_PRECISION)
//        {
//        }
//        public HNumber(ulong mantissa, int exponent) : this(mantissa, exponent, DEFAULT_PRECISION)
//        {
//        }
//        public HNumber(long mantissa, int exponent) : this(mantissa, exponent, DEFAULT_PRECISION)
//        {
//        }
//        public HNumber(uint mantissa, int exponent) : this(mantissa, exponent, DEFAULT_PRECISION)
//        {
//        }
//        public HNumber(int mantissa, int exponent) : this(mantissa, exponent, DEFAULT_PRECISION)
//        {
//        }
//        public HNumber(BigInteger mantissa, int exponent) : this(mantissa, exponent, DEFAULT_PRECISION)
//        {
//        }

//        public HNumber(byte[] mantissa) : this(mantissa, 0, DEFAULT_PRECISION)
//        {

//        }
//        public HNumber(decimal mantissa) : this(mantissa, 0, DEFAULT_PRECISION)
//        {

//        }
//        public HNumber(double mantissa) : this(mantissa, 0, DEFAULT_PRECISION)
//        {

//        }
//        public HNumber(float mantissa) : this(mantissa, 0, DEFAULT_PRECISION)
//        {

//        }
//        public HNumber(ulong mantissa) : this(mantissa, 0, DEFAULT_PRECISION)
//        {

//        }
//        public HNumber(long mantissa) : this(mantissa, 0, DEFAULT_PRECISION)
//        {

//        }
//        public HNumber(uint mantissa) : this(mantissa, 0, DEFAULT_PRECISION)
//        {

//        }
//        public HNumber(int mantissa) : this(mantissa, 0, DEFAULT_PRECISION)
//        {

//        }
//        public HNumber(BigInteger mantissa) : this(mantissa, 0, DEFAULT_PRECISION)
//        {

//        }

//        public static HNumber One {
//            get { return new HNumber(1, 0); }
//        }
//        public static HNumber Zero {
//            get { return new HNumber(0, 0); }
//        }
//        public static HNumber MinusOne {
//            get { return new HNumber(-1, 0); }
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

//        public static HNumber Abs(HNumber value)
//        {
//            if (value.Mantissa < 0)
//                value.Mantissa *= -1;
//            return value;
//        }
//        public static HNumber Add(HNumber left, HNumber right, PrecisionMode precisionMode = PrecisionMode.UseHigher)
//        {
//            int digitsTotal = left.DigitCount + right.DigitCount;
//            left.Truncate(digitsTotal);
//            right.Truncate(digitsTotal);

//            if (left.Exponent < right.Exponent)
//                left.Truncate(left.DigitCount - (right.Exponent - left.Exponent));
//            else if (left.Exponent > right.Exponent)
//                right.Truncate(right.DigitCount - (left.Exponent - right.Exponent));

//            BigInteger mantissa = left.Mantissa + right.Mantissa;
//            int exponent = Math.Max(left.Exponent, right.Exponent);
//            int precision = CalculatePrecision(left, right, mantissa, precisionMode);
//            return new HNumber(mantissa, exponent, precision);
//        }
//        public static HNumber Subtract(HNumber left, HNumber right, PrecisionMode precisionMode = PrecisionMode.UseHigher)
//        {
//            int digitsTotal = left.DigitCount + right.DigitCount;
//            left.Truncate(digitsTotal);
//            right.Truncate(digitsTotal);

//            if (left.Exponent < right.Exponent)
//                left.Truncate(left.DigitCount - (right.Exponent - left.Exponent));
//            else if (left.Exponent > right.Exponent)
//                right.Truncate(right.DigitCount - (left.Exponent - right.Exponent));

//            BigInteger mantissa = left.Mantissa - right.Mantissa;
//            int exponent = Math.Max(left.Exponent, right.Exponent);
//            int precision = CalculatePrecision(left, right, mantissa, precisionMode);
//            HNumber result = new HNumber(mantissa, exponent, precision);
//            return result;
//        }
//        public static HNumber Divide(HNumber left, HNumber right, PrecisionMode precisionMode = PrecisionMode.UseHigher)
//        {
//            if (right.IsZero)
//                throw new DivideByZeroException("The Divisor is zero");

//            int digitDiff = left.Precision - (left.DigitCount - right.DigitCount);
//            digitDiff = Math.Max(0, digitDiff);
//            left.Mantissa *= BigInteger.Pow(10, digitDiff);

//            BigInteger mantissa = BigInteger.Divide(left.Mantissa, right.Mantissa);
//            int exponent = left.Exponent - right.Exponent - digitDiff;
//            int precision = CalculatePrecision(left, right, mantissa, precisionMode);
//            return new HNumber(mantissa, exponent, precision);
//        }
//        public static HNumber Multiply(HNumber left, HNumber right, PrecisionMode precisionMode = PrecisionMode.UseHigher)
//        {
//            BigInteger mantissa = left.Mantissa * right.Mantissa;
//            int exponent = left.Exponent + right.Exponent;
//            int precision = CalculatePrecision(left, right, mantissa, precisionMode);
//            //Console.WriteLine(precisionMode.ToString());
//            //Console.WriteLine("PRECISION: " + precision);
//            //Console.WriteLine("Mantissa: " + mantissa);
//            return new HNumber(mantissa, exponent, precision);
//        }
//        public static HNumber Remainder(HNumber left, HNumber right)
//        {
//            //Remainder = Numerator - Quotient x Denominator 
//            HNumber quotient = Divide(left, right, PrecisionMode.UseDefault);
//            HNumber qd = Multiply(quotient, right, PrecisionMode.KeepPrecision);
//            Console.WriteLine("Quoteint = " + left + " / " + right + " = " + quotient);
//            Console.WriteLine("QD = " + quotient + " * " + right + " = " + qd);
//            Console.WriteLine("FINAL = " + left + " - " + qd + " = " + Subtract(left, qd));
//            Console.WriteLine();
//            return Subtract(left, qd);
//        }
//        public static HNumber DivRem(HNumber left, HNumber right, out HNumber remainder)
//        {
//            //Remainder = Numerator - Quotient x Denominator 
//            HNumber quotient = Divide(left, right, PrecisionMode.KeepPrecision);
//            HNumber qd = Multiply(quotient, right, PrecisionMode.KeepPrecision);
//            remainder = Subtract(left, qd);
//            quotient.Round(RoundingMode.Precision);
//            return quotient;
//        }
//        public static HNumber Pow(HNumber value, int exponent)
//        {
//            if (exponent < 0)
//                throw new ArgumentOutOfRangeException();
//            BigInteger mantissa = BigInteger.Pow(value.Mantissa, exponent);
//            int exp = value.Exponent * exponent;
//            return new HNumber(mantissa, exp);
//        }
//        public static HNumber Negate(HNumber value)
//        {
//            return new HNumber(-value.Mantissa, value.Exponent);
//        }
//        public static HNumber Max(HNumber left, HNumber right)
//        {
//            return Compare(left, right) == 1 ? left : right;
//        }
//        public static HNumber Min(HNumber left, HNumber right)
//        {
//            return Compare(left, right) == -1 ? left : right;
//        }
//        public static double Log(HNumber value, double baseValue)
//        {
//            return BigInteger.Log(value.Mantissa, baseValue) + (value.Exponent * Math.Log(10, baseValue));
//        }
//        public static double Log(HNumber value)
//        {
//            return BigInteger.Log(value.Mantissa) + (value.Exponent * Math.Log(10));
//        }
//        public static double Log10(HNumber value)
//        {
//            return BigInteger.Log10(value.Mantissa) + (value.Exponent * Math.Log10(10));
//        }
//        public static HNumber GreatestCommonDivisor(HNumber left, HNumber right)
//        {
//            left = Abs(left);
//            right = Abs(right);
//            HNumber a = Max(left, right);
//            HNumber b = Min(left, right);
//            HNumber rem;
//            while (true)
//            {
//                rem = Remainder(a, b);
//                if (rem == 0)
//                    return b;
//                a = b;
//                b = rem;
//            }
//        }
//        public static HNumber ModPow(HNumber value, HNumber exponent, HNumber modulus)
//        {
//            if (modulus == 1)
//                return 0;
//            HNumber curPow = value % modulus;
//            HNumber res = 1;
//            while (exponent > 0)
//            {
//                if (exponent % 2 == 1)
//                    res = (res * curPow) % modulus;
//                exponent = exponent / 2;
//                curPow = (curPow * curPow) % modulus;
//            }
//            return res;
//        }
//        public static HNumber Parse(string value)
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
//            return new HNumber(mantissa, exponent);
//        }
//        public static bool TryParse(string value, out HNumber result)
//        {
//            try
//            {
//                result = Parse(value);
//            }
//            catch (Exception)
//            {
//                result = HNumber.Zero;
//                return false;
//            }
//            return true;
//        }
//        public static int Compare(HNumber left, HNumber right)
//        {
//            if (left.Sign > right.Sign)
//                return 1;
//            else if (left.Sign < right.Sign)
//                return -1;

//            int leftTheoreticalExponent = left.Exponent + left.DigitCount;
//            int rightTheoreticalExponent = right.Exponent + right.DigitCount;

//            if (leftTheoreticalExponent == rightTheoreticalExponent)
//                return BigInteger.Compare(left.Mantissa, right.Mantissa);
//            else
//                return (leftTheoreticalExponent * left.Sign) > (rightTheoreticalExponent * right.Sign) ? 1 : -1;
//        }
//        public int CompareTo(long other)
//        {
//            return Compare(this, new HNumber(other));
//        }
//        public int CompareTo(ulong other)
//        {
//            return Compare(this, new HNumber(other));
//        }
//        public int CompareTo(HNumber other)
//        {
//            return Compare(this, other);
//        }
//        public int CompareTo(object obj)
//        {
//            HNumber other = (HNumber)obj;
//            return Compare(this, other);
//        }
//        public override bool Equals(object obj)
//        {
//            HNumber other = (HNumber)obj;
//            return Compare(this, other) == 0;
//        }
//        public bool Equals(long other)
//        {
//            return Compare(this, new HNumber(other)) == 0;
//        }
//        public bool Equals(ulong other)
//        {
//            return Compare(this, new HNumber(other)) == 0;
//        }
//        public bool Equals(HNumber other)
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
//        public static HNumber operator +(HNumber value)
//        {
//            return value;
//        }
//        public static HNumber operator +(HNumber left, HNumber right)
//        {
//            return Add(left, right);
//        }
//        public static HNumber operator -(HNumber value)
//        {
//            return new HNumber(-value.Mantissa, value.Exponent);
//        }
//        public static HNumber operator -(HNumber left, HNumber right)
//        {
//            return Subtract(left, right);
//        }
//        public static HNumber operator ++(HNumber value)
//        {
//            return value + 1;
//        }
//        public static HNumber operator --(HNumber value)
//        {
//            return value - 1;
//        }
//        public static HNumber operator *(HNumber left, HNumber right)
//        {
//            return Multiply(left, right);
//        }
//        public static HNumber operator /(HNumber dividend, HNumber divisor)
//        {
//            return Divide(dividend, divisor);
//        }
//        public static HNumber operator %(HNumber dividend, HNumber divisor)
//        {
//            return Remainder(dividend, divisor);
//        }
//        #endregion

//        #region Comparison Operators

//        public static bool operator ==(HNumber left, HNumber right)
//        {
//            int comp = Compare(left, right);
//            return comp == 0 ? true : false;
//        }
//        public static bool operator !=(HNumber left, HNumber right)
//        {
//            int comp = Compare(left, right);
//            return comp != 0 ? true : false;
//        }
//        public static bool operator <(HNumber left, HNumber right)
//        {
//            int comp = Compare(left, right);
//            return comp == -1 ? true : false;
//        }
//        public static bool operator >(HNumber left, HNumber right)
//        {
//            int comp = Compare(left, right);
//            return comp == 1 ? true : false;
//        }
//        public static bool operator <=(HNumber left, HNumber right)
//        {
//            int comp = Compare(left, right);
//            return comp == -1 || comp == 0 ? true : false;
//        }
//        public static bool operator >=(HNumber left, HNumber right)
//        {
//            int comp = Compare(left, right);
//            return comp == 1 || comp == 0 ? true : false;
//        }

//        #endregion

//        #region Implicit/Explicit Operators
//        public static implicit operator HNumber(ushort value)
//        {
//            return new HNumber(value);
//        }
//        public static implicit operator HNumber(short value)
//        {
//            return new HNumber(value);
//        }
//        public static implicit operator HNumber(sbyte value)
//        {
//            return new HNumber(value);
//        }
//        public static implicit operator HNumber(ulong value)
//        {
//            return new HNumber(value);
//        }
//        public static implicit operator HNumber(byte value)
//        {
//            return new HNumber(value);
//        }
//        public static implicit operator HNumber(long value)
//        {
//            return new HNumber(value);
//        }
//        public static implicit operator HNumber(uint value)
//        {
//            return new HNumber(value);
//        }
//        public static implicit operator HNumber(int value)
//        {
//            return new HNumber(value);
//        }
//        public static implicit operator HNumber(float value)
//        {
//            return new HNumber(value);
//        }
//        public static implicit operator HNumber(double value)
//        {
//            return new HNumber(value);
//        }
//        public static implicit operator HNumber(decimal value)
//        {
//            return new HNumber(value);
//        }
//        #endregion

//        private static int CalculatePrecision(HNumber left, HNumber right, BigInteger value, PrecisionMode precisionMode)
//        {
//            switch (precisionMode)
//            {
//                case PrecisionMode.UseHigher:
//                    return Math.Max(left.DigitCount, right.DigitCount);
//                case PrecisionMode.UseLesser:
//                    return Math.Min(left.DigitCount, right.DigitCount);
//                case PrecisionMode.KeepPrecision:
//                    return CalculateDigitCount(value);
//                case PrecisionMode.UseDefault:
//                    return DEFAULT_PRECISION;
//                default:
//                    return DEFAULT_PRECISION;
//            }
//        }
//        private static int CalculateDigitCount(BigInteger value)
//        {
//            if (value.IsZero)
//                return 0;
//            double log10 = BigInteger.Log10(BigInteger.Abs(value));
//            return (int)Math.Floor(log10 + 1);
//        }
//        private void Round(RoundingMode roundingMode)
//        {
//            switch (roundingMode)
//            {
//                case RoundingMode.Precision:
//                    int prec = Precision - DigitCount;
//                    prec = Math.Min(prec, Exponent);
//                    Truncate(DigitCount + prec);
//                    break;
//                case RoundingMode.Floor:
//                    break;
//                case RoundingMode.Ceil:
//                    break;
//                case RoundingMode.Int:
//                    int exp = Math.Min(0, Exponent);
//                    Truncate(DigitCount + exp);
//                    break;
//                default:
//                    break;
//            }
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

//    }
//}
