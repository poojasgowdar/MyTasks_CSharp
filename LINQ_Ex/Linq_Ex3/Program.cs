using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Ex3
{
    public class Program
    {
        static void Main(string[] args)
        {
            var words = new List<string> { "apple", "banana", "cat", "dog", "elephant" };
            var groupedWords = words.GroupBy(word => word.Length);

            Console.WriteLine("Words grouped by length:");
            foreach (var group in groupedWords)
            {
                Console.WriteLine($"Length: {group.Key}");
                foreach (var word in group)
                {
                    Console.WriteLine($"  {word}");
                }
            }
            Console.ReadKey();

        }
    }
}
