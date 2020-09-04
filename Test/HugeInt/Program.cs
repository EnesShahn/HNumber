using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Threading;

namespace HugeInt
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] arr = new byte[]{ 0b0000_0001, 0b0111_1111 };
            string digits = BytesToString(arr);
            Console.WriteLine("Final " + digits);
            return;

            //HugeInt a = new HugeInt(10_000_000_000_000_000_000_000_000_000_000_000D, 0, 1);
            HugeInt a = new HugeInt(123456789123456789123456789123456789D, 0, 20);
            Console.WriteLine(a);

            return;
            for (int i = 0; i < 1000; i++)
            {
                //a = a * new HugeInt(10);
                //Console.WriteLine(a);
                a = a + new HugeInt(100);
                Console.WriteLine(a);
            }

        }


        static string BytesToString(byte[] data)
        {
            // Minimum length 1.
            if (data.Length == 0) return "0";

            // length <= digits.Length.
            var digits = new byte[(data.Length * 0x00026882/* (int)(Math.Log(2, 10) * 0x80000) */ + 0xFFFF) >> 16];
            int length = 1;
            Console.WriteLine("Digits count " + digits.Length);
            Console.WriteLine("Length " + length);
            Console.WriteLine();

            // For each byte:
            for (int j = 0; j != data.Length; ++j)
            {
                Console.WriteLine("----LOOP----");
                // digits = digits * 256 + data[j].
                int i, carry = data[j];
                Console.WriteLine("1 Carry " + carry);
                for (i = 0; i < length || carry != 0; ++i)
                {
                    Console.WriteLine("----INNER LOOP----");
                    int value = digits[i] * 256 + carry;
                    Console.WriteLine("Value " + value);
                    carry = Math.DivRem(value, 10, out value);
                    Console.WriteLine("2 Carry " + carry);
                    digits[i] = (byte)value;
                    Console.WriteLine("Reminder = " + value);
                }
                Console.WriteLine("--------------");
                // digits got longer.
                Console.WriteLine("i = " + i);
                if (i > length) length = i;
                Console.WriteLine("Length = " + length);
            }

            // Return string.
            var result = new StringBuilder(length);
            while (0 != length) result.Append((char)('0' + digits[--length]));
            return result.ToString();
        }
    }
}
