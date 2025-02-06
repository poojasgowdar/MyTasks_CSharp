using System;
using System.CodeDom;
namespace Ref_InClass_Ex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string st = "Hi";
            SetValue(ref st);

            int g;
            Sum(out g);
            Console.WriteLine(g);
            Console.ReadKey();
        }

        public static void Sum(out int g)
        {
            g = 7;
            g = g + 8;
        }

        static void SetValue(ref string st1)
        {
            string str1 = "bye";
            Console.WriteLine(str1);
        }
    }
}
