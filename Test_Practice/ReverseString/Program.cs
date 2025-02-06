using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter any String");
            string org_str = Console.ReadLine();
            string reversestring = "";
            Console.WriteLine("Before Reversing: " +org_str);
            for(int i = org_str.Length - 1; i >= 0; i--)
            {
                reversestring += org_str[i];
            }
            Console.WriteLine("Reverse String is:" +reversestring);
            Console.ReadKey();

        }
    }
}
