using System;
using System.Xml.Schema;
namespace Single_level_Inheritance
{
    
    public class Rectangle
    {
        public int length;
        public int breadth;
       
        public int Area()
        {
            return (length*breadth);
        }
        public int Perimeter()
        {
            return 2 * (length * breadth);
        }
    }

    public class Cuboid : Rectangle
    {
        public int height;
        public Cuboid(int l,int b,int h)
        {
            length = l;
            breadth = b;
            height = h;
        }
        public int Volume()
        {
            return length * breadth * height;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Cuboid c = new Cuboid(5, 6, 7);
            Console.WriteLine($"Volume is: { c.Volume()}");
            Console.WriteLine($"Area is: { c.Area()}");
            Console.WriteLine($"Perimeter is :{c.Perimeter()}");
            Console.ReadKey();
        }
    }
}
