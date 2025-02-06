using System;
namespace EncapBankAccount
{
    internal class BankAccount
    {
        private int balance;
        public int Balance
        {
            get
            {
                return balance;
            }
        }

        public BankAccount(int initialBalance)
        {
            if (initialBalance < 0)
            {
                Console.WriteLine("Initial balance cannot be negative.");
            }
            balance = initialBalance;

        }

        public void Deposit(int amount)
        {
            if (amount <= 0)
                {
                    Console.WriteLine("Deposit amount should be positive.");

                }
                balance += amount;
         }
    }
        public class Program
        {   
            static void Main(string[] args)
            {  
                BankAccount myAccount = new BankAccount(-500);
                myAccount.Deposit(200);
                Console.WriteLine(myAccount.Balance);
                Console.ReadKey();
            }

        }
    
}
