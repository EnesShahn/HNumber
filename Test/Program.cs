using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Threading;

namespace INLib
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rdm = new Random(0);

            string num1Str = "8e54695";
            string num2Str = "123456e-5";

            HugeInt num1 = HugeInt.Parse(num1Str);
            HugeInt num2 = HugeInt.Parse(num2Str);

            Console.WriteLine("HugeInt Parsing {0}, result = {1}", num1Str, num1);
            Console.WriteLine("BigInteger Parsing {0}, result = {1}", num2Str, num2);

            double value1 = -12;
            double value2 = 10;

            int exp1 = 4;
            int exp2 = 3;

            HugeInt huge1 = new HugeInt(value1, exp1);
            HugeInt huge2 = new HugeInt(value2, exp2);

            BigInteger big1 = new BigInteger(value1);
            BigInteger big2 = new BigInteger(value2);
            big1 *= BigInteger.Pow(10, exp1);
            big2 *= BigInteger.Pow(10, exp2);

            Console.WriteLine("HugeInt");
            Console.WriteLine("Value1: {0} , Value2: {1}", huge1, huge2);
            Console.WriteLine("BigInt");
            Console.WriteLine("Value1: {0} , Value2: {1}", big1, big2);
            Console.WriteLine();


            HugeInt remainder1 = huge1 % huge2;
            BigInteger remainder2 = big1 % big2;

            HugeInt quotient1 = huge1 / huge2;
            BigInteger quotient2 = big1 / big2;

            HugeInt add1 = huge1 + huge2;
            BigInteger add2 = big1 + big2;

            HugeInt sub1 = huge1 - huge2;
            BigInteger sub2 = big1 - big2;

            HugeInt gcd1 = HugeInt.GreatestCommonDivisor(huge1, huge2);
            BigInteger gcd2 = BigInteger.GreatestCommonDivisor(big1, big2);

            Console.WriteLine("HugeInt Divide: ");
            Console.WriteLine("{0} / {1} = {2}", huge1, huge2, quotient1);
            Console.WriteLine("BigInt Divide: ");
            Console.WriteLine("{0} / {1} = {2}", big1, big2, quotient2);
            Console.WriteLine();

            Console.WriteLine("HugeInt Remainder: ");
            Console.WriteLine("{0} / {1} = {2}", huge1, huge2, remainder1);
            Console.WriteLine("BigInteger Remainder: ");
            Console.WriteLine("{0} / {1} = {2}", big1, big2, remainder2);
            Console.WriteLine();

            Console.WriteLine("HugeInt Add: ");
            Console.WriteLine("{0} + {1} = {2}", huge1, huge2, add1);
            Console.WriteLine("BigInt Add: ");
            Console.WriteLine("{0} + {1} = {2}", big1, big2, add2);
            Console.WriteLine();

            Console.WriteLine("HugeInt Subtract: ");
            Console.WriteLine("{0} - {1} = {2}", huge1, huge2, sub1);
            Console.WriteLine("BigInt Subtract: ");
            Console.WriteLine("{0} - {1} = {2}", big1, big2, sub2);
            Console.WriteLine();

            Console.WriteLine("HugeInt GCD: ");
            Console.WriteLine("{0}  {1} = {2}", huge1, huge2, gcd1);
            Console.WriteLine("BigInt GCD: ");
            Console.WriteLine("{0}  {1} = {2}", big1, big2, gcd2);
            Console.WriteLine();

            Console.WriteLine("------");
        }

    }
}
