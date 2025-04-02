using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SynchronousExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string res=GetData();
            Console.WriteLine(res);
            Console.ReadKey();
        }

        static string GetData()
        {
            Thread.Sleep(1000);
            return "Processing";
        }
    }
}
