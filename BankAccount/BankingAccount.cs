using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NameisDuy.BankingAccount
{
    public class BankingAccount
    {
        private string accountID;
        private string customerName;
        private double balance;

        public BankingAccount(string accountID, string customerName, double balance)
        {
            if (accountID.Length == 10 || accountID.Contains(@"\D+"))
            {
                this.accountID = accountID;
                this.customerName = customerName;
                this.balance = balance;
            }
            else
            {
                throw new FormatException("Bank Account ID must contains 10 numbers.");
            }
        } 
        public string AccountID { get { return accountID; } }
        public string CustomerName { get; set; }
        public double Balance { get { return balance; } }

        public override string ToString()
        {
            return $"Account ID: {accountID}\n"
                + $"Customer Name: {customerName}\n"
                + $"Balance: {balance}";
        }

        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("Amount must be positive.");
            }
            balance += amount;
        }
        
        public void WithDraw(double amount)
        {
            if (amount > balance)
            {
                throw new ArgumentOutOfRangeException($"Amount must between [0..{balance}].");
            }
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("Amount must be positive.");
            }
            balance -= amount;
        }

        public static double ExchangeMoneyFromVndToDolar(double vnd)
        {
            double dolar;
            if (vnd < 24000)
            {
                throw new ArgumentOutOfRangeException("The money amount must greater than 24000 vnd.");
            }
            dolar = vnd / 24000;
            return dolar;
        }
    }
}
