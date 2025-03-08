using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter any String");
            string name = Console.ReadLine();
            string reverseString = "";
            for (int i = name.Length - 1; i >= 0; i--)
            {
                reverseString += name[i];
            }
            Console.WriteLine(reverseString);
            Console.ReadKey();
        }
    }
}

