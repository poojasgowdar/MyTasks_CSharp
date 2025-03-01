using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaOfTriangle
{
    internal class Program
    {
         public void AreaOfTriangle()
            {
                int side1 = 4, side2 = 13, side3 = 15;
                Console.WriteLine($"Value of side1 = {side1}, side2 = {side2}, and side2 = {side2}");
                double semiperimeter = (side1 + side2 + side3) / 2;
                double Area = Math.Sqrt(semiperimeter * (semiperimeter - side1) * (semiperimeter - side2) * (semiperimeter - side3));
                Console.Write("Area of a Triangle = " + Area);
                Console.ReadKey();
            }
        
    }
}
