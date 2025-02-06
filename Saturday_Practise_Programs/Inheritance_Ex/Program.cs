using System;
namespace Inheritance_Ex
{
    class A
    {   
        public A(int number)
        {
            Console.WriteLine("Explicitly Constructor1 Called" +number);
        }
         public void Method1()
        {
            Console.WriteLine("Calling from Method1");
        }
         public void Method2()
        {
            Console.WriteLine("Calling from Method2");
        }
    }

    class B : A 
    { 
        public B():base (10)
        {
            Console.WriteLine("Explicitly Constructor2 Called");
        }
        public void Method3()
        {
            Console.WriteLine("Calling from Method3");
        }
        static void Main(string[] args)
        {
            B b = new B();
            b.Method1();
            b.Method2();
            b.Method3();

            //A a = new A();
            //a.Method1();

            Console.ReadKey();
        }
    }
}
