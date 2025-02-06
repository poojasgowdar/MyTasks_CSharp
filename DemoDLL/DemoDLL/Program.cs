using DemoClassLibrary;
using System;
namespace DemoDLL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Class1 c = new Class1();
            c.AreaOfTriangle();
            Console.ReadKey();
        }
    }
}