using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async_Await
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Method started");
            SomeMethod();
            Console.WriteLine("Main Method Ended");
            Console.ReadKey();
        }

        public async static  void SomeMethod()
        {
            Console.WriteLine("SomeMethod Started");
            await Task.Delay(1000);
            Console.WriteLine("SomeMethod Ended");

        }
    }
}
