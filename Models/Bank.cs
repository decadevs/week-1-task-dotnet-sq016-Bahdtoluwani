namespace BankOOPApp.Models
{
    // Represents a bank with multiple accounts
    public class Bank
    {
        private List<Account> accounts = new List<Account>();

        // Method to add a new account to the bank
        public void AddAccount(Account account)
        {
            // Check if the account number already exists
            foreach (Account existingAccount in accounts)
            {
                if (existingAccount.AccountNumber == account.AccountNumber)
                {
                    throw new Exception("Account number already exists");
                }
            }

            // Check if the user already has an account of the same type
            foreach (Account existingAccount in accounts)
            {
                if (existingAccount.AccountType == account.AccountType && existingAccount.FirstName == account.FirstName && existingAccount.LastName == account.LastName)
                {
                    throw new Exception("User cannot have the same account type");
                }
            }

            // Add the account to the list of accounts
            accounts.Add(account);
        }


        //// Method to remove an account from the bank
        //public void RemoveAccount(long accountNumber) // Change the parameter type to long
        //{
        //    // Remove the account with the specified account number from the list of accounts
        //    accounts.RemoveAll(a => a.AccountNumber == accountNumber);
        //}

        //// Method to get an account by account number
        //public Account GetAccount(long accountNumber) // Change the return type and parameter type to long
        //{
        //    // Find and return the account with the specified account number
        //    return accounts.Find(a => a.AccountNumber == accountNumber);
        //}

        public void RemoveAccount(long accountNumber)
        {
            // Iterate over the accounts and remove the one with the specified account number
            foreach (var account in accounts)
            {
                if (account.AccountNumber == accountNumber)
                {
                    accounts.Remove(account);
                    break; // Exit the loop once the account is found and removed
                }
            }
        }

        public Account GetAccount(long accountNumber)
        {
            // Iterate over the accounts and find the one with the specified account number
            foreach (var account in accounts)
            {
                if (account.AccountNumber == accountNumber)
                {
                    return account;
                }
            }

            // Account not found, return null or throw an exception based on your requirements
            return null;
        }

        // Method to get all accounts in the bank
        public List<Account> GetAccounts()
        {
            // Return the list of accounts
            return accounts;
        }

        // Method to deposit money into an account
        public void Deposit(long accountNumber, decimal amount) // Change the parameter type to long
        {
            // Get the account with the specified account number
            Account account = GetAccount(accountNumber);

            // Deposit the amount into the account
            account.Deposit(amount);
        }

        // Method to withdraw money from an account
        public void Withdraw(long accountNumber, decimal amount) // Change the parameter type to long
        {
            // Get the account with the specified account number
            Account account = GetAccount(accountNumber);

            // Check if the account is a savings account and if the withdrawal will result in a balance less than 1000
            if (account.AccountType == "Savings" && account.Balance - amount < 1000m)
            {
                throw new Exception("Insufficient funds");
            }

            // Withdraw the amount from the account
            account.Withdraw(amount);
        }

        // Method to transfer money between accounts
        public void Transfer(long fromAccountNumber, long toAccountNumber, decimal amount) // Change the parameter types to long
        {
            // Get the accounts involved in the transfer
            Account fromAccount = GetAccount(fromAccountNumber);
            Account toAccount = GetAccount(toAccountNumber);

            // Withdraw the amount from the sender's account
            fromAccount.Withdraw(amount);

            // Deposit the amount into the recipient's account
            toAccount.Deposit(amount);
        }

        // Method to print all accounts in the bank
        public void PrintAccounts()
        {
            Console.WriteLine("|---------------|------------------|--------------|-------------|--------|");
            Console.WriteLine("| FULL NAME     | ACCOUNT NUMBER   | ACCOUNT TYPE | ACCOUNT BAL | NOTE   |");
            Console.WriteLine("|---------------|------------------|--------------|-------------|--------|");

            foreach (var account in accounts)
            {
                Console.WriteLine($"| {account.FirstName} {account.LastName,-9} | {account.AccountNumber,-16} | {account.AccountType,-13} | {account.Balance,-11} | {account.Note,-6} |");
            }

            Console.WriteLine("|---------------|------------------|--------------|-------------|--------|");
        }
    }
}