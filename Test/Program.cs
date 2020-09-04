using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Threading;
using Common;

namespace HugeInt
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rdm = new Random(0);

            double value1 = 12;
            double value2 = 10;

            int exp1 = 4;
            int exp2 = 4;


            HugeInt huge1 = new HugeInt(value1, exp1);
            HugeInt huge2 = new HugeInt(value2, exp2);

            BigInteger big1 = new BigInteger(value1);
            BigInteger big2 = new BigInteger(value2);
            big1 *= BigInteger.Pow(10, exp1);
            big2 *= BigInteger.Pow(10, exp2);


            HugeInt quotient1 = HugeInt.DivRem(huge1, huge2, out var remainder1);
            BigInteger quotient2 = BigInteger.DivRem(big1, big2, out var remainder2);

            HugeInt add1 = HugeInt.Add(huge1, huge2);
            BigInteger add2 = BigInteger.Add(big1, big2);

            HugeInt sub1 = HugeInt.Subtract(huge1, huge2);
            BigInteger sub2 = BigInteger.Subtract(big1, big2);

            Console.WriteLine("HugeInt Divide: ");
            Console.WriteLine("{0} / {1} = {2}", huge1, huge2, quotient1);
            Console.WriteLine("BigInt Divide: ");
            Console.WriteLine("{0} / {1} = {2}", big1, big2, quotient2);
            Console.WriteLine();

            Console.WriteLine("HugeInt DivRem: ");
            Console.WriteLine("{0} / {1} = {2} {3}", huge1, huge2, quotient1, remainder1);
            Console.WriteLine("BigInteger DivRem: ");
            Console.WriteLine("{0} / {1} = {2} {3}", big1, big2, quotient2, remainder2);
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

            Console.WriteLine("------");
        }

    }
}
