using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asynchronous_Ex
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Method Started......");
            SomeMethod();
            Console.WriteLine("Main Method End");
            Console.ReadKey();
        }
        public async static void SomeMethod()
        {
            Console.WriteLine("Some Method Started......");
            Wait();
            Console.WriteLine("Some Method End");
        }
        private static async Task Wait()
        {
            await Task.Delay(TimeSpan.FromSeconds(10));
            Console.WriteLine("\n10 Seconds wait Completed\n");
        }
    }
}

