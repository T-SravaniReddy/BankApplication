using System;
using System.Collections.Generic;
using System.Text;

namespace BankApplication
{
     class ATM
    {
        public static Dictionary<int, Account> AccountsList;
        public static List<Transaction> transactionList;
        static ATM()
        {
            AccountsList = new Dictionary<int, Account>();
            transactionList = new List<Transaction>();
        }
        public static void AddAccount()
        {
            string name = StandardMessages.EnterUserName();
            string pin = StandardMessages.EnterPIN();
            Account account = new Account(name, pin);
            AccountsList.Add(account.GetAccountID(), account);
        }
         public static bool Validate(int accountID, string pin)
        {
            if (pin != AccountsList[accountID].pin)
            {
                return false;
            }
            return true;
        }
        public static void PrintBalance(Account account)
        {
            Console.WriteLine("Your Available Balance : " + account.GetAmount());
        }
        public static bool CheckBalance(Account account, double amount)
        {
            if (account.GetAmount() >= amount)
            {
                return true;
            }
            return false;
        }
        public static void AddTransaction(int accountID, int toID, string description, double amount, string datetime)
        {
            Transaction transaction = new Transaction(accountID, toID, description, amount, datetime);
            transactionList.Add(transaction);
        }
        public static void PrintTransactions(int accountID)
        {
            foreach (Transaction transaction in transactionList)
            {
                if (transaction.accountID == accountID)
                {
                    Console.Write(transaction.datetime + "  " + transaction.description + "  " + transaction.amount + "  ");
                    if (transaction.toID != -1)
                    {
                        if (transaction.description == "deposit")
                        {
                            Console.Write(" from " + AccountsList[transaction.toID].name);
                        } else
                        {
                            Console.Write(" to " + AccountsList[transaction.toID].name);
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
        public static void Deposit()
        {
            int accountID = StandardMessages.EnterAccountID();
            if (AccountsList.ContainsKey(accountID))
            {
                string pin = StandardMessages.EnterPIN();
                if (Validate(accountID, pin))
                {
                    double amount = StandardMessages.EnterAmount();
                    Account account = AccountsList[accountID];
                    account.SetAmount(account.GetAmount() + amount);
                    StandardMessages.DepositMessage();
                    PrintBalance(account);
                    AddTransaction(accountID, -1, "deposit", amount, DateTime.Now.ToString("MM/dd/yyyy h:mm tt"));
                } else
                {
                    StandardMessages.InvalidPIN();
                }
            } else
            {
                StandardMessages.AccountDoesntExist();
            }
            
        }

        public static void Withdraw()
        {
            int accountID = StandardMessages.EnterAccountID();
            if (AccountsList.ContainsKey(accountID))
            {
                string pin = StandardMessages.EnterPIN();
                if (Validate(accountID, pin))
                {
                    double amount = StandardMessages.EnterWithDrawAmount();
                    Account account = AccountsList[accountID];
                    if (CheckBalance(account, amount))
                    {
                        account.SetAmount(account.GetAmount() - amount);
                        StandardMessages.WithDrawMessage();
                        PrintBalance(account);
                        AddTransaction(accountID, -1, "withdraw", amount, DateTime.Now.ToString("MM/dd/yyyy h:mm tt"));
                    } else
                    {
                        StandardMessages.InsufficientAmount();
                    }
                  
                }
                else
                {
                    StandardMessages.InvalidPIN();
                }
            }
            else
            {
                StandardMessages.AccountDoesntExist();
            }

        }

        public static void TransferAmount()
        {
            int accountID = StandardMessages.EnterAccountID();
            if (AccountsList.ContainsKey(accountID))
            {
                string pin = StandardMessages.EnterPIN();
                if (Validate(accountID, pin))
                {
                    int toID = StandardMessages.EnterAccountID();
                    if (AccountsList.ContainsKey(toID))
                    {
                        double amount = StandardMessages.EnterTransferAmount();
                        Account account = AccountsList[accountID];
                        if (CheckBalance(account, amount))
                        {
                            account.SetAmount(account.GetAmount() - amount);
                            AccountsList[toID].SetAmount(AccountsList[toID].GetAmount() + amount);
                            StandardMessages.TransferMessage();
                            PrintBalance(account);
                            AddTransaction(accountID, toID, "withdraw", amount, DateTime.Now.ToString("MM/dd/yyyy h:mm tt"));
                            AddTransaction(toID, accountID, "deposit", amount, DateTime.Now.ToString("MM/dd/yyyy h:mm tt"));
                        }
                        else
                        {
                            StandardMessages.InsufficientAmount();
                        }
                    } else
                    {
                        StandardMessages.AccountDoesntExist();
                    }
                }
                else
                {
                    StandardMessages.InvalidPIN();
                }
            }
            else
            {
                StandardMessages.AccountDoesntExist();
            }
        }

        public static void TransactionHistory()
        {
            int accountID = StandardMessages.EnterAccountID();
            if (AccountsList.ContainsKey(accountID))
            {
                string pin = StandardMessages.EnterPIN();
                if (Validate(accountID, pin))
                {
                    StandardMessages.TransactionHeading();
                    PrintTransactions(accountID);
                }
                else
                {
                    StandardMessages.InvalidPIN();
                }
            }
            else
            {
                StandardMessages.AccountDoesntExist();
            }

        }

    }
}
