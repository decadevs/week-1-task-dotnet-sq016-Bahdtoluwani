using System;
using System.Collections.Generic;

namespace BankOOPApp.Models
{

    public class Program
    {
        public static void Main()
        {
            Bank bank = new Bank();

            // Create some accounts
            Account account1 = new Account("John", "Doe", 1234567890, "Savings", 10000.00m, "Gift");
            Account account2 = new Account("Jane", "Smith", 9876543210, "Currents", 100000.00m, "Food");

            // Add the accounts to the bank
            bank.AddAccount(account1);
            bank.AddAccount(account2);

            // Deposit some money into account1
            bank.Deposit(1234567890, 5000.00m);

            // Withdraw some money from account1
            bank.Withdraw(1234567890, 2000.00m);

            // Transfer some money from account2 to account1
            bank.Transfer(9876543210, 1234567890, 1000.00m);

            // Print all accounts and balances
            bank.PrintAccounts();
        }
    }
}