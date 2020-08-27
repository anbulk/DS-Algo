using System;
using System.Collections;
using System.Linq;

namespace ArithmeticCalculator
{
    class Program
    {
    

        ///String reversal with stack [Please note here Stack_Array is my custom Stackclass, ///you can replace this with provided by .NET]  
        ///String Reversal without Copy to Char Array it's i <= j as we need to getthe middle /// character in case of odd number of characters in the string  
        public static string ReverseString3b(string str)
        {
            char[] chars = new char[str.Length];
            for (int i = 0, j = str.Length - 1; i <= j; i++, j--)
            {
                chars[i] = str[j];
                chars[j] = str[i];
            }
            return new string(chars);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            var res = MinimizeString("aabcccabba");

            Console.WriteLine("Minimized string is : " + res);

            //Binary Calculator 

            //ICalculator c = new BinaryCalculator();

            //var res = c.Add(12, 25);

            //Console.WriteLine("Sum:" + res);
            Console.ReadLine();

        }
    }
}
