using System;
using System.Diagnostics;
using System.Numerics;

namespace EnesShahn
{
    class Program
    {
        static void Main(string[] args)
        {
            BigIntegerCompareTest();
        }

        static void PerformanceTest()
        {
            //Compares Performance BigInteger--Integer--HNumber
            Stopwatch timer = new Stopwatch();
            for (int i = 0; i < 1000000; i++)
            {

            }
        }

        static void ParseTest()
        {
            string num1Str = "8e54695";
            string num2Str = "123456e-5";

            HNumber num1 = HNumber.Parse(num1Str);
            HNumber num2 = HNumber.Parse(num2Str);

            Console.WriteLine("HugeInt Parsing {0}, result = {1}", num1Str, num1);
            Console.WriteLine("BigInteger Parsing {0}, result = {1}", num2Str, num2);

            Console.WriteLine();
        }

        static void BigIntegerCompareTest()
        {
            Random rdm = new Random(1);

            for (int i = 0; i < 1; i++)
            {
                int sign1 = rdm.Next() % 2 == 0 ? 1 : -1;
                int sign2 = rdm.Next() % 2 == 0 ? 1 : -1;

                double value1 = 12500;
                double value2 = 11300;

                int exp1 = 20;
                int exp2 = 0;

                //double value1 = rdm.Next() * sign1;
                //double value2 = rdm.Next() * sign2;

                //int exp1 = rdm.Next() % 100;
                //int exp2 = rdm.Next() % 100;

                HNumber huge1 = new HNumber(value1, exp1);
                HNumber huge2 = new HNumber(value2, exp2);

                BigInteger big1 = new BigInteger(value1);
                BigInteger big2 = new BigInteger(value2);
                big1 *= BigInteger.Pow(10, exp1);
                big2 *= BigInteger.Pow(10, exp2);


                //Console.WriteLine("HugeInt");
                //Console.WriteLine("Value1: {0} , Value2: {1}", huge1, huge2);
                //Console.WriteLine("BigInt");
                //Console.WriteLine("Value1: {0} , Value2: {1}", big1, big2);
                //Console.WriteLine();


                HNumber remainder1 = huge1 % huge2;
                BigInteger remainder2 = big1 % big2;

                HNumber quotient1 = huge1 / huge2;
                BigInteger quotient2 = big1 / big2;

                HNumber mul1 = huge1 * huge2;
                BigInteger mul2 = big1 * big2;

                HNumber add1 = huge1 + huge2;
                BigInteger add2 = big1 + big2;

                HNumber sub1 = huge1 - huge2;
                BigInteger sub2 = big1 - big2;

                //HNumber gcd1 = HNumber.GreatestCommonDivisor(huge1, huge2);
                //BigInteger gcd2 = BigInteger.GreatestCommonDivisor(big1, big2);

                Console.WriteLine("HugeInt Remainder: ");
                Console.WriteLine("{0} % {1} = {2}", huge1, huge2, remainder1);
                Console.WriteLine("BigInteger Remainder: ");
                Console.WriteLine("{0} % {1} = {2}", new HNumber(big1, 0, 10), new HNumber(big2, 0, 10), new HNumber(remainder2, 0, remainder1.DigitCount + 2));
                Console.WriteLine();

                Console.WriteLine("HugeInt Divide: ");
                Console.WriteLine("{0} / {1} = {2}", huge1, huge2, quotient1);
                Console.WriteLine("BigInt Divide: ");
                Console.WriteLine("{0} / {1} = {2}", new HNumber(big1, 0, 10), new HNumber(big2, 0, 10), new HNumber(quotient2, 0, quotient1.DigitCount + 2));
                Console.WriteLine();

                Console.WriteLine("HugeInt Multiply: ");
                Console.WriteLine("{0} * {1} = {2}", huge1, huge2, mul1);
                Console.WriteLine("BigInt Divide: ");
                Console.WriteLine("{0} * {1} = {2}", new HNumber(big1, 0, 10), new HNumber(big2, 0, 10), new HNumber(mul2, 0, mul1.DigitCount + 2));
                Console.WriteLine();

                Console.WriteLine("HugeInt Add: ");
                Console.WriteLine("{0} + {1} = {2}", huge1, huge2, add1);
                Console.WriteLine("BigInt Add: ");
                Console.WriteLine("{0} + {1} = {2}", new HNumber(big1, 0, 10), new HNumber(big2, 0, 10), new HNumber(add2, 0, add1.DigitCount + 2));
                Console.WriteLine();

                Console.WriteLine("HugeInt Subtract: ");
                Console.WriteLine("{0} - {1} = {2}", huge1, huge2, sub1);
                Console.WriteLine("BigInt Subtract: ");
                Console.WriteLine("{0} - {1} = {2}", new HNumber(big1, 0, 10), new HNumber(big2, 0, 10), new HNumber(sub2, 0, sub1.DigitCount + 2));
                Console.WriteLine();

                //Console.WriteLine("HugeInt GCD: ");
                //Console.WriteLine("{0}  {1} = {2}", huge1, huge2, gcd1);
                //Console.WriteLine("BigInt GCD: ");
                //Console.WriteLine("{0}  {1} = {2}", new HNumber(big1, 0, 10), new HNumber(big2, 0, 10), new HNumber(gcd2, 0, gcd1.DigitCount+2));
                //Console.WriteLine();

                Console.WriteLine("------");
            }
        }
    }
}
