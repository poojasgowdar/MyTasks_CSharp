using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aysnchronous
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Main Method Started");
            string res = await GetData();
            Console.WriteLine(res);
            Console.WriteLine("Main Method Ended");
            Console.ReadKey();
        }

        static async Task<string> GetData()
        {
            await Task.Delay(10000);
            return "Processing";
        }
    }
}
