using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            List<int> MethodSyntax = list.Where(x => x > 5).ToList();
            foreach (var method in MethodSyntax)
            {
                Console.Write(method + " ");
            }
            //IEnumerable<int> QuerySyntax = from obj in list
            //                  where obj > 5
            //                  select obj;
            //foreach (var item in QuerySyntax)
            //{
            //    Console.WriteLine(item);
            //}

            //IEnumerable<int> EvenNumbers = list.Where(x => x % 2 == 0);
            //foreach (var method in EvenNumbers)
            //{
            //    Console.Write(method + " ");
            //}
            Console.ReadKey();
            

            
        }
    }
   
}
