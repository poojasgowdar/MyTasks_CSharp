using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Method Started");
            SomeMethod();
            Console.WriteLine("Main Method Ended");
            Console.ReadKey();
        }

        public async static void SomeMethod()
        {
            Console.WriteLine("Some Method Started....");
            await Wait();
            Console.WriteLine("Some Method Ended");
        }

        private  async static Task Wait()
        {
            await Task.Delay(TimeSpan.FromSeconds(10));
            Console.WriteLine("\n10 Seconds Completed");
        }





    }
}
