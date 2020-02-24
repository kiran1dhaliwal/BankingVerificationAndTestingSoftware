    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    public class BankAccount
    {
        //FIELDS 

        private String accountHolderName;
        private long accountNumber;
        private double balance;
        public const String INSUFFICIENT_BALANCE = "Insufficient balance";
        public const String WRONG_ACCOUNT_NUMBER = "Wrong account number generated";
        public const String WRONG_AMOUNT = "Cannot withdraw or deposit zero or negative amount";
        

        //PROPERTIES

        public string AccountHolderName
        {
            get
            {
                //Returning account holder name
                return accountHolderName;
            }
        }       

        public double Balance
        {
            get
            {
                //returning balance
                return balance;
            }
        }

        //METHOD

            //Constructor
        public BankAccount(double initialBalance, String accountHolderName)
        {
            //initialising values
            this.balance = initialBalance;
            this.accountHolderName = accountHolderName;

            //Verifying generated account number
            if (IsAccountNumberVerified(GetNewAccountNumber()) == true)
            {
                //assigning value
                this.accountNumber = GetNewAccountNumber();
            }
        }

        public double Debit(double amount)
        {
            //Checking for wrong amount
            if (IsAmountVerified(amount) == true)
            {
                //checking if the amount to be debited is equal to or less than the balance
                if (amount <= this.balance)
                {
                    //Updating balance
                    this.balance = this.balance - amount;                    
                }
                else
                {
                    throw new ArgumentOutOfRangeException(INSUFFICIENT_BALANCE);
                }                
            }
            else
            {
                throw new ArgumentOutOfRangeException(WRONG_AMOUNT);
            }            

            return amount;
        }
        
        public void Deposit(double amount)
        {
            //Verifying provided amount
            if (IsAmountVerified(amount) == false)
            {
                throw new ArgumentOutOfRangeException(WRONG_AMOUNT);
            }
            else
            {
                //Updating balance
                this.balance = this.balance + amount;
            }

        }

        private long GetNewAccountNumber()
        {
            //Generates a random number between 32000000 to 32999999
            Random randomNum = new Random();
            long accountNumber = randomNum.Next(32000000, 32999999);

            //Returning generated account number
            return accountNumber;
        }

        public bool IsAccountNumberVerified(long accountNumber)
        {
            
            Boolean isVerified = false;
            String strAccountNumber = accountNumber.ToString();

            //checking - accountNumber length should be 8 digits            
            if (strAccountNumber.Length == 8)
            {
                // checking - accountNumber should start with 32
                if (strAccountNumber.Substring(0, 2) == "32")
                {
                    isVerified = true;
                }
                else
                {
                    throw new ArgumentException(WRONG_ACCOUNT_NUMBER);
                }
            }
            else
            {
                throw new ArgumentException(WRONG_ACCOUNT_NUMBER);
            }
          
            return isVerified;
        }

        private bool IsAmountVerified(double amount)
        {
            Boolean isVerified = false;

            //checking if amount is not zero or negative
            if(amount > 0)
            {
                isVerified = true;
            }

            return isVerified;
        }

        public void UpdateAccountHolderName(string newName)
        {
            //updating account holder name
            this.accountHolderName = newName;
        }

    }
}
