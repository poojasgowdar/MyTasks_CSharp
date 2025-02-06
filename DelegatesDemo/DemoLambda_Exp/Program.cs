using System;
using System.Collections.Generic;
namespace DemoLambda_Exp
{
    public delegate void dLambda(int a,int b);
    internal class Program
    {
        static void Main(string[] args)
        {
            //anonymous Method 
            dLambda dl = (int a, int b)=>
            {
                Console.WriteLine(a + b);
            };
            dl(4, 5);
           
            Console.ReadKey();
        }
    }
}
