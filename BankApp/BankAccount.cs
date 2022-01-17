using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BankApp
{
    class BankAccount
    {
      public  string filePath = @"C:\Users\Shujaul\source\repos\Algorithm Implementation\Object Oriented\BankApp\BankApp\BankApp\TextFile\text.txt";
        public string path= @"C:\Users\Shujaul\source\repos\Algorithm Implementation\Object Oriented\BankApp\BankApp\BankApp\TextFile\transections.txt";


        List<Transection> allTransection = new List<Transection>();

        public int AccountNumber = 123243241;
        public string Owner { get; set; }
        public decimal Balance
        {
            
            get
            {
                decimal balance = 0;
                foreach (var item in allTransection)
                {
                    balance = item.Amount + balance;
                }

                return balance;
            }
        }
        
        public void Deposite(decimal amount, DateTime date, string note)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount Must be Positive ");
            }

            //else
            //{
            //    Transection depoite = new Transection(amount, date, note);
            //    allTransection.Add(depoite);
            //}



            allTransection.Add(new Transection
            {
                Amount = amount,
                Date = DateTime.Now,
                Note = note

            });
        }

        public void Withdraw(decimal amount, DateTime date, string note)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Must be positive");
            }

            if (amount > Balance)
            {
                throw new InvalidOperationException( "Insufficent fund");
            }

            //Transection withdraw = new Transection(-amount, date, note);
            //allTransection.Add(withdraw);


            //Without constructor initilize

            allTransection.Add(new Transection
            {
                Amount = -amount,
                Date = date,
                Note = note
            });
        }

        public void WriteToText()
        { 
            List<string> lines = new List<string>();

            foreach (var item in allTransection )
            {
                lines.Add($"{item.Note} {item.Amount}");
            }

            File.WriteAllLines(filePath, lines);
        }

        public void ReadFromText()
        {
            var lines = File.ReadAllLines(path);
            List<Transection> readlInes = new List<Transection>();                   
                        
            for (int i = 0; i < lines.Length; i++)
            {
                Transection transection = new Transection();
                //each line it will split read as array
                string[] col = lines[i].Split(' ');

                transection.Note = col[0];
                transection.Amount = int.Parse(col[1]);

                readlInes.Add(transection);
            }

            foreach (var item in readlInes)
            {
                Console.WriteLine($"{item.Note} {item.Amount}");
            }

        }

        public void TransectionHistroy()
        {
            foreach (var item in allTransection)
            {
                Console.WriteLine($"{item.Note} {item.Amount}");
            }
        }
    }
}
