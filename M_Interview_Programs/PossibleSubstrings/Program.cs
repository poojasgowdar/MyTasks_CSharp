using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PossibleSubstrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a String:");
            string inputString = Console.ReadLine();
            Console.WriteLine("All substrings for given string are");
            for(int i = 0; i < inputString.Length; i++)
            {
                StringBuilder subString = new StringBuilder(inputString.Length - 1);
                for(int j=i;j<inputString.Length;j++)
                {
                    subString.Append(inputString[j]);
                    Console.Write(subString + " ");
                }
            }
            Console.ReadKey();
        }
    }
}
