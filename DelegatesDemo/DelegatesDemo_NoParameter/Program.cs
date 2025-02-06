using System;
namespace DelegatesDemo_NoParameter
{
    internal class Program
    {
        public delegate void Dname();

        public static void Greet()
        {
            Console.WriteLine("Hello Good Morning");
        }
        static void Main(string[] args)
        {
            Dname d = Greet;
            d();
            Console.ReadKey();

        }
    }
}
