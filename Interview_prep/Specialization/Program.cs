using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specialization
{
    public class Innova
    {
        public string Name { get; set; }
        public void Price()
        {
            Console.WriteLine("Innova cost is high");
        }
    }

    public class Fortuner : Innova
    {
        public int Cost;
        public void Color()
        {
            Console.WriteLine("Fortuner Color is white");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Innova innova = new Innova();
            Console.WriteLine("The Cost is:" +Name);
            innova.Price();

            Fortuner fortuner = new Fortuner();
            Console.WriteLine("The Cost is:" +Cost);
            fortuner.Color();

            Console.ReadKey();
        }

    }

}
