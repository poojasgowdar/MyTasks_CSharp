using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnBoxing_Boxing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            object BoxedValue = 200;
            int UnBoxedValue = (int)BoxedValue;
            Console.WriteLine(BoxedValue);
            Console.WriteLine(UnBoxedValue);
            Console.ReadKey();
        }
    }
}
