using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aysnchronous_Example1
{
    public class Program
    {
        public async static void MakingTea()
        {
            Console.WriteLine("Start");
            await Task.Delay(3000);
            Console.WriteLine("Stop");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Main Method Started");
            MakingTea();
            Console.WriteLine("Main Method Ended");
            Console.ReadKey();
        }
    }
}
