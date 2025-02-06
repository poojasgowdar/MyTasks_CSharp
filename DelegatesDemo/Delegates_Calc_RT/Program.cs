using System;
namespace Delegates_Calc_RT
{
    public delegate int  Operation(int a,int b);
    public delegate int  AreaSquare(int a);
    public class Calculator
    {
        public int add(int a,int b)
        {
            Console.WriteLine("Execution from add");
            return a + b;
        }
        public int sub(int a, int b)
        {
            Console.WriteLine("Execution from sub");
            return a - b;
        }
        public int mul(int a, int b)
        {
            return a * b;
        }
        public int div(int a, int b)
        {
            return a / b;
        }
    }

    public class Rectangle
    {
        public int area(int length,int breadth)
        {
            return length * breadth;
        }
    }

    public class Square
    {
        public int area(int side)
        {
            return side * side;
        }
    }

    class Test
    {
        public static void Main(string[] args)
        {
            Calculator c = new Calculator();
            Operation add = new Operation(c.add);
            Operation sub = new Operation(c.sub);
            Operation mul = new Operation(c.mul);
            Operation div = new Operation(c.div);

            Rectangle r = new Rectangle();

            Operation areaRec = new Operation(r.area);

            Square s = new Square();
            AreaSquare areaSqu = new AreaSquare(s.area);

            Console.WriteLine("Sum is:" + add(2, 3));
            Console.WriteLine("Sub is:" + sub(5, 3));
            Console.WriteLine("Mul is:" + mul(6, 7));
            Console.WriteLine("Div is:" + div(10, 5));
            Console.WriteLine("Area of Rect is:" + areaRec(4, 2));
            Console.WriteLine("Area of Squ is:" + areaSqu(5));


            Operation total = add + sub;
            //Console.WriteLine(total);
            Console.WriteLine(total(4, 7));
            total -= sub;
            Console.WriteLine(total(4, 7));

            Console.ReadKey();

        }
    }


}
