using System;
namespace EncapsulationEx
{    
    internal class Program
    {
        int num1, num2, result;
        public int snum1
        {
            set
            {
                num1 = value;
            }
        }

        public int snum2
        {
            set
            {
                num2 = value;
            }
        }
        public int sresult
        {
            get
            {
                return result;
            }
        }

        public void add()
        {
            result = num1 + num2;
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine("Enter the numbers to add:");
            p.snum1 = Convert.ToInt32(Console.ReadLine());
            p.snum2 = Convert.ToInt32(Console.ReadLine());
            p.add();
            Console.WriteLine("Addition of Two Numbers:" + p.sresult);
            Console.ReadKey();
        }
    }
}