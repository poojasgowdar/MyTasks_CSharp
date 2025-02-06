using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter any String:");
            string sentence = Console.ReadLine();
            string[] words = sentence.Split(' ');
            Console.WriteLine("Number of Words: " + words.Length);
            Console.ReadKey();
        }
    }
}
