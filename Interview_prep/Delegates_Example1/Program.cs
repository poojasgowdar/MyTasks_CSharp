using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_Example1
{
    internal class Program
    {
        //public delegate void DisplayMessage(string message);

        //public static void Show(string message)
        //{
        //    Console.WriteLine(message);
        //}
        //static void Main(string[] args)
        //{
        //    DisplayMessage dm = Show;
        //    dm("Good Morning");
        //    Console.ReadKey();



        //}

        static void Main(string[] args)
        {
            //string name = "John";
            //Console.WriteLine($"Hello,{name}");
            //Console.ReadKey();
            //string a = "Hello";
            //a += "World";
            //Console.WriteLine(a);
            //string a1 = "Apple";
            //string a2 = "Apple";
            //Console.WriteLine(a1 == a2);
            //Console.WriteLine(a1.Equals(a2));
            //Console.ReadKey();

                string name = "sandeep";
                string myName = name;
                Console.WriteLine("== operator result is {0}", name == myName);
                Console.WriteLine("Equals method result is {0}", name.Equals(myName));
                Console.ReadKey();
            
        }
    }
}
