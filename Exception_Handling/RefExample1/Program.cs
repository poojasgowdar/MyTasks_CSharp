using System;
namespace RefExample1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 20, b = 30;
            Console.WriteLine($"Before Swapping: {a} and {b}");
            Swap(ref a, ref b);
            Console.WriteLine($"After Swapping: {a} and {b}");
            Console.ReadKey();
        }

        static void Swap(ref int x,ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
    }
}





