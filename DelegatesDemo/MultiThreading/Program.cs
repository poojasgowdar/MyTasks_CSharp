using System;
using System.Collections.Generic;
using System.Threading;


namespace MultiThreading
{
    internal class Program
    {

        public static void p1()
        {
            for (int i = 1; i <=10; i++)
            {
                Console.WriteLine(i);
            }
        }

        public static void p2()
        {
            for (int i = 11; i <=20; i++)
            {
                Console.WriteLine(i);
            }
        }
            static void Main(string[] args)
            {
            ThreadStart ts1 = new ThreadStart(Program.p1);
            ThreadStart ts2 = new ThreadStart(Program.p2);
            Thread t1 = new Thread(ts1);
            Thread t2 = new Thread(ts2);
            t1.Start();
            t2.Start();
            t1.Abort();

            Console.ReadKey();
        }

                
        
    }
}
