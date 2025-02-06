using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Single_level_Inheritance
{
    public class Father
    {
        public int age;
        public Father()
        {
            age = 50;
        }
        public void Car()
        {
            Console.WriteLine("Daddy has a Car");
        }
    }
    public class Son:Father
    {
        public string Name;
        public Son()
        {
            Name = "Tom";
        }
        public void Bike()
        {
            Console.WriteLine("Son has a Bike");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Son s = new Son();
            Console.WriteLine("The Father age is:" +s.age);
            s.Car();
            Console.WriteLine("The Son name is:" + s.Name);
            s.Bike();
            Console.ReadKey();

        }
    }
}
