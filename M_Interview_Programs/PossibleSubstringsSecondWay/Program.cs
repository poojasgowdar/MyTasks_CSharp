using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PossibleSubstringsSecondWay
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter any String");
            string input = Console.ReadLine();
            Console.WriteLine("All Substrings:");
            for (int i = 0; i < input.Length; i++) 
            {
                for (int j = i + 1; j <= input.Length; j++) 
                {
                    Console.WriteLine(input.Substring(i, j - i));
                }
            }
            Console.ReadKey();

        }
    }   
}
//y
//ya
//yas
//yash
//yashu
//a
//as
//ash
//ashu
//s
//sh
//shu
//h
//hu
//u

