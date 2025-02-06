using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_Resize
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3 };
            Console.WriteLine("Original Array:");
            foreach(int i in numbers)
            {
                Console.WriteLine(i);
            }

            int[] resizedArray = new int[numbers.Length + 2];
            for(int i = 0; i < numbers.Length; i++)
            {
                resizedArray[i] = numbers[i];
            }
            resizedArray[3] = 4;
            resizedArray[4] = 5;
            Console.WriteLine("\nResized Array (Manually):");
            foreach(int i in resizedArray)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}
