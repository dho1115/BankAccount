﻿using System;
using System.Linq;

namespace CoreConsoleApp
{
    public class Program
    {
        static void Main()
        {
            BankAccount a = new CheckingAccount("A1000", "Joe", 500);
            
            //Update on Bank Account.
            a.Deposit(300);
            a.Withdraw(900);
            a.Withdraw(50);
            a.Deposit(100); //More changes
            a.Withdraw(800);
            a.Deposit(9500); //Made a deposit of 9500.00;
            Console.WriteLine(a);   //Normally, this would display CoreConsoleApp.CheckingAccount, but I overrode the ToString() method!


            BankAccount b = new SavingsAccount("B2000", "Ripal", 200);

            b.Withdraw(30);
            b.AddInterest();
            Console.WriteLine(b);


            Console.ReadLine();
        }
        
    }

    public class BankAccount
    {
        public string AccountNumber { get; set; }
        public string Owner { get; set; }
        public decimal Balance { get; set; }

        public BankAccount(string accountNumber, string owner, decimal balance)
        {
            this.AccountNumber = accountNumber;
            this.Owner = owner;
            this.Balance = balance;
        }
        
        public BankAccount(string accountNumber, string owner) : this(accountNumber, owner, 0)
        {

        }

        public virtual void Withdraw(decimal amount)
        {
            this.Balance -= amount;
        }

        public virtual void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        public virtual void AddInterest()
        {

        }

        public override string ToString()
        {
            return this.Owner + ": " + this.Balance.ToString("c");
        }


    }

    public class CheckingAccount : BankAccount
    {
        public CheckingAccount(string accountNumber, string owner, decimal balance):base(accountNumber, owner, balance)
        {

        }

        public CheckingAccount(string accountNumber, string owner) : base(accountNumber, owner)
        {

        }

        public override void Withdraw(decimal amount)
        {
            if (amount <= this.Balance)
            {
                base.Withdraw(amount);
            }
        }
    }

    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(string accountNumber, string owner, decimal balance) : base(accountNumber, owner, balance)
        {

        }

        public SavingsAccount(string accountNumber, string owner) : base(accountNumber, owner)
        {

        }

        public override void Withdraw(decimal amount)
        {
            if(amount <= (.10m * this.Balance))
            {
                base.Withdraw(amount);
            }
        }

        public override void AddInterest()
        {
            this.Balance *= 1.002m;
        }
    }
    
}
