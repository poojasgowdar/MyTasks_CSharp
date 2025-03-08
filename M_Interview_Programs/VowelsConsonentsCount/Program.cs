using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VowelsConsonentsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter any String");
            string name = Console.ReadLine();
            int vowelCount = 0, consonantCount = 0;
            string vowels = "aeiou";
            for(int i = 0; i < name.Length; i++)
            {
                char ch = name[i];//pooja
                if (char.IsLetter(ch))
                {
                    if (vowels.Contains(ch))
                        vowelCount++;
                    else
                        consonantCount++;
                }
            }
            Console.WriteLine($"Total vowels: {vowelCount}");
            Console.WriteLine($"Total consonants: {consonantCount}");
            Console.ReadKey();
        }
    }
}
