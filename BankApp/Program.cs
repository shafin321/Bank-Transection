using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount();

            account.Deposite(900, DateTime.Now, "Hammer");
            account.Deposite(2000, DateTime.Now, "PS5");
            account.Withdraw(1100, DateTime.Now, "ps4");

            // Console.WriteLine(account.Balance);

            account.WriteToText();

          account.ReadFromText();
            
        }
    }
}
