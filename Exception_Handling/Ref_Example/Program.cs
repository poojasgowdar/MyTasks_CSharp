using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ref_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "Geek";

            SetValue(ref str);
            Console.WriteLine(str);
            Console.ReadKey();
        }
        static void SetValue(ref string str1)
        {
            if (str1 == "Geek")
            {
                Console.WriteLine("Hello Geek");
            }
            str1 = "GeekforGeek";
        }
    }
}
