using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    public class Program
    {
        static void Main(string[] args)
        {
             List<String> list = new List<String>
             {
                   "apple", "mango", "orange", "pineapple"
             };
             var result = list.Where(x => x == "apple").ToArray();

             foreach (var item in result)
              {
                Console.WriteLine(item);
              }
            Console.ReadKey();
        }
    }
}
