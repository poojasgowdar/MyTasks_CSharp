using System;
namespace DelegatesDemo_WithParameter
{
    internal class Program
    {
        public delegate string  dDemo(string name);
       
        public  static string Message(string name)
        {
            return "Hello " + name + " Welcome to You";
        }
        static void Main(string[] args)
        {
            //Program p = new Program();
            //dDemo d = new dDemo(p.Message);
            //dDemo d = new dDemo(Program.Message);
            //string msg = d.Invoke("Pranaya");
            //Console.WriteLine(msg);
            //string msg=d.Invoke("Praya");
            //Console.WriteLine(msg);

            //dDemo d = Message;
            //string s=d.Invoke("Pooja");
            //Console.WriteLine(s);

            dDemo d = new dDemo(Program.Message);
            string s = d.Invoke("Pooja");
            Console.WriteLine(s);
            Console.ReadKey();

        }
    }
}
