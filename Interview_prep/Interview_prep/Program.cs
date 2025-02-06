using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Interview_prep.Program;

namespace Interview_prep
{
    public delegate void dname(int a, int b);
    public class Program
    {
        public void Add(int a,int b)
        {
            Console.WriteLine(a + b);
        }
        public void Sub(int a,int b)
        {
            Console.WriteLine(a - b);
        }
    }


    class Example
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            dname d1 = new dname(p.Add);
            dname d2 = new dname(p.Sub);
            dname d3 = d1 + d2;
            d3(5, 5);
            Console.ReadKey();
        }
    }


}
