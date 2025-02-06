using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asynchronous_Ex
{
    internal class Program
    {
        static  void Main(string[] args)
        {
            Console.WriteLine("Main method started");
            SomeMethod();
            Console.WriteLine("Main method Ended");
            Console.ReadKey();
        }

        public async static void SomeMethod()
        {
            Console.WriteLine("Some Method Started");
            await Task.Delay(TimeSpan.FromSeconds(10));
            Console.WriteLine("Some Method Ended");

        }
    }
}
