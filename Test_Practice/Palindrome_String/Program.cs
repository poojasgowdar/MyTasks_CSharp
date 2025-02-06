using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter any String");
            string org_str = Console.ReadLine();
            string reverseString = "";
            for(int i = org_str.Length - 1; i >= 0; i--)
            {
                reverseString += org_str[i];
            }
            if(org_str== reverseString)
            {
                Console.WriteLine("Palindrome");
            }
            else
            {
                Console.WriteLine("Not Palindrome");
            }
            Console.ReadKey();
        }
    }
}
