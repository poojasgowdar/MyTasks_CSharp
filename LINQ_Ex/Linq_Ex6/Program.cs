using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Ex6
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>()
            {
                "Hai","Hello","Bye"
            };
            var filteredList = list.Where(item=>item != "Bye");
            foreach(var item in filteredList)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();

        }
    }
}
