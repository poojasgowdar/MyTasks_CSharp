using System;
using System.Collections.Generic;
namespace Abstraction_Ex
{
    //Used Interface......
    public interface Bank
    {
        void CheckBalance();
        void MiniStatement();
        void ValidateCard();

    }

    public class SBI : Bank
    {
        public void CheckBalance()
        {
            Console.WriteLine("SBI Check Balance");
        }

        public void MiniStatement()
        {
            Console.WriteLine("SBI Mini Statement");
        }

        public void ValidateCard()
        {
            Console.WriteLine("SBI Validate Card");
        }
    }

    public class HDFC : Bank
    {
        public void CheckBalance()
        {
            Console.WriteLine("HDFC check Balance");
        }

        public void MiniStatement()
        {
            Console.WriteLine("HDFC Mini Statement");
        }

        public void ValidateCard()
        {
            Console.WriteLine("HDFC Validate Card");
        }
    }

   public class Program
    {
        static void Main(string[] args)
        {
            Bank f = new SBI();
            Console.WriteLine("=========SBI Bank Details=============");
            f.MiniStatement();
            f.ValidateCard();
            f.CheckBalance();

            Bank f1 = new HDFC();
            Console.WriteLine("=============HDFC Bank Details==========");
            f1.MiniStatement();
            f1.ValidateCard();
            f1.CheckBalance();
            Console.ReadKey();
        }
    }
}
