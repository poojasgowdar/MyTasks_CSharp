using System;
using System.Dynamic;
class Test
{ 
        public void sum()
        {
            Console.WriteLine("This is sum method");
        }

        public void sum2()
        {
            Console.WriteLine("this is sum2 method");
        }
}

public delegate void dname();
    class Program
    {
    static void Main(string[] args)
    {
        Test test = new Test();
        dname d1, d2, d3, d4, d5;

        d1 = new dname(test.sum);
        d2 = new dname(test.sum2);
        d3 = d1 + d2;
        Console.WriteLine("Calling from method" +d3);
        d3();
        d4 = d3 + d3;
        Console.WriteLine("from d4");
        d4();
        d5 = d4 - d3;
        Console.WriteLine("from d5");
        d5();
        Console.ReadKey();

    }
}
//Calling from methoddname
//This is sum method
//this is sum2 method
//from d4
//This is sum method
//this is sum2 method
//This is sum method
//this is sum2 method
//from d5
//This is sum method
//this is sum2 method
//this is sum2 method



