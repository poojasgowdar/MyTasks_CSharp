using System;
namespace AreaOfRectangle
{
    internal class Program
    {
        delegate double Operation(double x, double y);
        //static double AreaOfRectangle(double length,double breadth)
        //{
        //    return length * breadth;
        //}
        static void Main(string[] args)
        {
            double length, breadth;
            Console.WriteLine("Enter the Length of the Rectangle:");
            length = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Breadth of the Rectangle:");
            breadth = double.Parse(Console.ReadLine());

            Operation operation = delegate (double x, double y)
            {
                return length * breadth;
            };
            double area = operation(length, breadth);

            Console.WriteLine("Area of the Rectangele:  " + area);
            Console.ReadKey();
        }
        
    }
}
