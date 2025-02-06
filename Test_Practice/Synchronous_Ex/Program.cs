using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Synchronous_Ex
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("Main Thread Started");
            int result=Task1();
            Console.WriteLine("Task1 is completed with result:" + result);
            Console.WriteLine("Main Thread Ended");
            Console.ReadKey();
        }

        public static int Task1()
        {

            Console.WriteLine("Task1 is running");
            Thread.Sleep(1000);
            Console.WriteLine("Task2 is running");
            return 100;
            
        }
    }
}
