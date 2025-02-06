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
       
            static void Main(String[] args)
            {
                method1();
                method2();
                Console.WriteLine("hi from method1");

            }
            static async void method1()
            {
                Console.WriteLine("hi from method1");
                await Task.Delay(500);
                Console.WriteLine("hi from method1 after sleep");
            }
            static void method2()
            {
                Console.WriteLine("hi from method2");
                Thread.Sleep(500);
                Console.WriteLine("hi from method2 after sleep");
            }
        
    }
}
