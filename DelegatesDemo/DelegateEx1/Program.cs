using System;
namespace DelegateEx1
{
    internal class Program
    {
        public  void sum(int a, int b)
        {
            Console.WriteLine(a+b);
        }
        public  void sub(int a, int b)
        {
            Console.WriteLine(a-b);
        }
    }
    public delegate void dname(int a, int b);
    class Test 
    { 
        static void Main(string[] args)
        {
            Program p = new Program();
            dname d1 = new dname(p.sum);
            dname d2 = new dname(p.sub);
            dname d3 = d1 + d2;
            d3(4, 5);
            d3.Invoke(4, 5);
            Console.ReadKey();
        }
    }
}
