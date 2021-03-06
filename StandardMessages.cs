using System;
using System.Collections.Generic;
using System.Text;

namespace BankApplication
{
    class StandardMessages
    {
        public static void WelcomeMessage()
        {
            Console.WriteLine("1. Create a Account");
            Console.WriteLine("2. Deposit Amount");
            Console.WriteLine("3. Withdraw Amount");
            Console.WriteLine("4. Transfer Amount");
            Console.WriteLine("5. Print Transaction History");
            Console.WriteLine("6. Exit");
            Console.Write("Select Your Choice: ");
        }

        public static string EnterPIN()
        {
            Console.Write("Enter Your PIN: ");
            return Console.ReadLine();
            
        }

        public static string EnterUserName()
        {
            Console.Write("Enter Your Name: ");
            return Console.ReadLine();
        }

        public static int EnterAccountID()
        {
            Console.Write("Enter Your Account ID: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public static double EnterAmount()
        {
            Console.Write("Enter Amount To Deposit: ");
            return Convert.ToDouble(Console.ReadLine());
        }

        public static void InvalidPIN()
        {
            Console.WriteLine("Wrong/Invalid PIN");
        }

        public static void AccountDoesntExist()
        {
            Console.WriteLine("Account Doesn't Exist");
        }

        public static void Invalid()
        {
            Console.WriteLine("Invalid Choice");
        }
        public static void Exit()
        {
            Console.WriteLine("Successfully Exited");
        }
        public static void CreateMessage(int accountID,string name, double amount)
        {
            Console.WriteLine("Account Created Successfully with Account No: " + accountID +  " Name: " + name +  " Balance: " +  amount);
        }

        public static double EnterWithDrawAmount()
        {
            Console.Write("Enter Amount To Withdraw: ");
            return Convert.ToDouble(Console.ReadLine());
        }

        public static void InsufficientAmount()
        {
            Console.WriteLine("Insufficient Amount");
        }

        public static void TransactionHeading()
        {
            Console.WriteLine("\nTRANSACTION HISTORY\n ");
        }
        public static void DepositMessage()
        {
            Console.WriteLine("Successfully Deposited");
        }
        public static void WithDrawMessage()
        {
            Console.WriteLine("Successfully WithDrawn");
        }
        public static void TransferMessage()
        {
            Console.WriteLine("Successfully Transferred");
        }

        public static double EnterTransferAmount()
        {
            Console.Write("Enter Amount To Transfer: ");
            return Convert.ToDouble(Console.ReadLine());
        }
    }
}
