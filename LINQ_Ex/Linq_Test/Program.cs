using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Test
{
    public class Program
    {
        string Name;
        int no;
        int quantity;
        int req;

        public static List<Program> Get()
        {
            return new List<Program>()
            {
               new Program { Name = "abc", no = 123, quantity = 5, req = -1 },
               new Program { Name = "abc", no = 123, quantity = 10, req = 0 },
               new Program { Name = "def", no = 345, quantity = 5, req = -5 }
            };
        }

            static void Main(string[] args)
            {

                var list = Get();
                var num = list.GroupBy(p => new { p.Name, p.no, p.quantity });


                foreach (var n in num)
                {
                    Console.WriteLine($"Name: {n.Key.Name}, No: {n.Key.no}, Quantity: {n.Key.quantity}");
                }

            
                int Total = list.Sum(p => p.quantity);
                Console.WriteLine(Total);

                Console.ReadKey();
            }


        
    }
}


