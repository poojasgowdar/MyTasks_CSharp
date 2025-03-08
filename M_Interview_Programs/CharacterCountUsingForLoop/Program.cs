using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CharacterCountUsingForLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter any String");
            string name = Console.ReadLine();
            int letterCount = 0;
            for(int i = 0; i < name.Length; i++)
            {
                if (char.IsLetter(name[i]))
                {
                    letterCount++;
                }
            }
            Console.WriteLine($"The total number of Letters are: {letterCount}");
            Console.ReadKey();
        }
    }
}
