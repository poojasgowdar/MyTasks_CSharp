using System;
namespace DelegatesEx
{
    internal class Program
    {
        static int calculateSum(int x,int y)
        {
            return x + y;
        }

        //define a delegate
        public delegate int mydelegate(int num1, int num2);
        static void Main(string[] args)
        {
            mydelegate my = new mydelegate(calculateSum);
            int result=my(5, 6);
            Console.WriteLine(result);
            Console.ReadKey();

        }
    }
}
