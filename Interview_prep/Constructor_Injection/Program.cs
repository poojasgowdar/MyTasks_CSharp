using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Constructor_Injection
{
    public interface IEngine
    {
        void Car();
    }

    public class Engine : IEngine
    {
        public void Car()
        {
            Console.WriteLine("Car has Started");
        }
    }

    public class Program
    {
        private readonly IEngine _engine;
        public Program(IEngine engine)
        {
            _engine = engine;
        }

        public void Drive()
        {
            Console.WriteLine("Driving License");
        }
    }

    public class Example
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            Program p = new Program(engine);
            p.Drive();
            Console.ReadKey();
        }
    }
}
