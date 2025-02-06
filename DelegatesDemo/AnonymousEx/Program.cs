using System;
namespace AnonymousEx


    public class DelegateTest
    {
        public delegate void DelegateTestDelegate();

        public static void Greetings()
        {
            Console.WriteLine("Hello Good Morning");
        }

        static void Main(string[] args)
        {
            DelegateTestDelegate dt = Greetings;
            dt();
            Console.ReadKey();
        }
    }
   

    
}
