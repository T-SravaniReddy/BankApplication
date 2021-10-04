using System;
using System.Collections.Generic;
using System.Text;

namespace BankApplication
{
    class Transaction
    {
        public int accountID;
        public int toID;
        public string description;
        public double amount;
        public string datetime;

        public Transaction(int accountID, int toID, string description, double amount, string datetime)
        {
            this.accountID = accountID;
            this.toID = toID;
            this.description = description;
            this.amount = amount;
            this.datetime = datetime;
        }
    }
}
