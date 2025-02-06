using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Program
    {
        private double balance;
        public double getBalance()
        {
            return balance;
        }
        public void setBalance(double balance)
        {
            this.balance = balance;
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            p.setBalance(800);
            Console.WriteLine(p.getBalance());
            Console.ReadKey();
        }
    }
}
