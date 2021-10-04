using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;



namespace BankApplication
{
    class Account
    {
        public static int index = 0;
        public int accountID;
        public string name;
        public double amount;
        public string pin;
        

        public Account(string name, string pin)
        {
            this.accountID = ++index;
            this.pin = pin;
            this.name = name;
            this.amount = 0;
            StandardMessages.CreateMessage(this.accountID, this.name, this.amount);
        }

        public String GetPin()
        {
            return pin;
        }


        public int GetAccountID()
        {
            return accountID;
        }

        public double GetAmount()
        {
            return amount;
        }
        public void SetAmount(double amount)
        {
             this.amount = amount;
        }
    }

}