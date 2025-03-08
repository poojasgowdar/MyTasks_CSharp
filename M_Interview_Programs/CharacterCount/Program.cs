using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter any String");
            string name = Console.ReadLine();
            int letterCount = 0;
            foreach(char c in name)
            {
                if (char.IsLetter(c))
                {
                    letterCount++;
                }
            }
            Console.WriteLine($"Total number of letters: {letterCount}");
            Console.ReadKey();
        }
    }
}
