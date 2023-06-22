namespace BankOOPApp.Models
{
    // Create an Account class to represent a bank account
    public class Account
    {
        // Define properties for an account
        //[Required(ErrorMessage = "First name is required")]
        //[StringLength(20, ErrorMessage = "First name must not exceed 20 characters")]
        //[RegularExpression(@"^[A-Z][a-zA-Z]*$", ErrorMessage = "First name must start with an uppercase letter and contain only letters")]
        //public string FirstName { get; set; }

        private string firstName;
        public string FirstName
        {
            get => firstName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First name is required");
                }

                if (value.Length > 20)
                {
                    throw new ArgumentException("First name must not exceed 20 characters");
                }

                if (char.IsLower(value[0]))
                {
                    throw new ArgumentException("First name must not start with lowercase");
                }

                if (char.IsDigit(value[0]))
                {
                    throw new ArgumentException("First name must not start with a number");
                }

                firstName = value;
            }
        }

        private string lastName;
        public string LastName
        {
            get => lastName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Last name is required");
                }

                if (value.Length > 20)
                {
                    throw new ArgumentException("Last name must not exceed 20 characters");
                }

                if (char.IsDigit(value[0]))
                {
                    throw new ArgumentException("Last name must not start with a number");
                }

                lastName = value;
            }
        }

        public long AccountNumber { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public string Note { get; set; }


        // Constructor to create an account
        public Account(string firstName, string lastName, long accountNumber, string accountType, decimal balance, string note)
        {
            FirstName = firstName;
            LastName = lastName;
            AccountNumber = accountNumber;
            AccountType = accountType;
            Balance = balance;
            Note = note;
        }

        // Method to deposit money into the account
        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        // Method to withdraw money from the account
        public void Withdraw(decimal amount)
        {
            // Check if the account is a savings account and if the withdrawal will result in a balance less than 1000
            if (AccountType == "Savings" && Balance - amount < 1000m)
            {
                // Throw an exception with a message if there are insufficient funds
                throw new Exception("Insufficient funds");
            }

            // Subtract the amount from the balance
            Balance -= amount;
        }

        // Method to transfer money from the current account to another account
        public void Transfer(decimal amount, Account otherAccount)
        {
            // Withdraw the amount from the current account
            Withdraw(amount);

            // Deposit the amount into the other account
            otherAccount.Deposit(amount);
        }

        // Override ToString() method to provide a string representation of the account
        public override string ToString()
        {
            return $"Account {AccountNumber}: {FirstName} {LastName} ({AccountType}) - Balance: {Balance}";
        }
    }
}