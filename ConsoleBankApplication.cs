using System;

namespace BankApplication
{
  
    struct Account
    {
        public int accountID;
        public string name;
        public double amount;
        public string pin;
    };

    struct Transaction
    {
        public int toID;
        public string description;
        public double amount;
        public string datetime;
    };
    class ConsoleBankApplication
    {
        static Account[] accounts = new Account[10];
        static Transaction[,] transactions = new Transaction[10, 10];
        static int[] transactionIndex = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        static int index = -1;
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("1. Create a Account");
                Console.WriteLine("2. Deposit Amount");
                Console.WriteLine("3. Withdraw Amount");
                Console.WriteLine("4. Transfer Amount");
                Console.WriteLine("5. Print Transaction History");
                Console.WriteLine("6. Exit");
                Console.Write("Select Your Choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddAccount();
                        break;

                    case 2:
                        Deposit();
                        break;

                    case 3:
                        Withdraw();
                        break;

                    case 4:
                        TransferAmount();
                        break;

                    case 5:
                        TransactionHistory();
                        break;

                    case 6:
                        Console.WriteLine("Exited");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
                Console.WriteLine("\n");
            } while (choice != 6);

        }
        static void AddAccount()
        {
            index++;
            accounts[index].accountID = index;
            Console.Write("Enter Your Name: ");
            accounts[index].name = Console.ReadLine();
            Console.Write("Enter Your Pin: ");
            accounts[index].pin = Console.ReadLine();
            accounts[index].amount = 0;
            Console.WriteLine("Your Account Is Created Successfully");
            Console.WriteLine("Your Account ID is " + index);
        }
        static void Deposit()
        {
            Console.Write("Enter Your Account ID: ");
            int accountID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Your PIN: ");
            string pin = Console.ReadLine();
            if (accountID <= index)
            {
                if (accounts[accountID].pin == pin)
                {
                    Console.Write("Enter Amount To Deposit: ");
                    double amount = Convert.ToDouble(Console.ReadLine());
                    accounts[accountID].amount += amount;
                    Console.WriteLine("Amount Deposited Successfully");
                    Console.WriteLine("Your Account Has Amount: " + accounts[accountID].amount);
                    transactions[accountID, transactionIndex[accountID]].toID = -1;
                    transactions[accountID, transactionIndex[accountID]].description = "deposit";
                    transactions[accountID, transactionIndex[accountID]].amount = amount;
                    transactions[accountID, transactionIndex[accountID]].datetime = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
                    transactionIndex[accountID]++;
                }
                else
                {
                    Console.WriteLine("Wrong/Invalid PIN");
                }
            }
            else
            {
                Console.WriteLine("Account Doesn't Exist");
            }
        }

        static void Withdraw()
        {
            Console.Write("Enter Your Account ID: ");
            int accountID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Your PIN: ");
            string pin = Console.ReadLine();
            if (accountID <= index)
            {
                if (accounts[accountID].pin == pin)
                {
                    Console.Write("Enter Amount To Withdraw: ");
                    double amount = Convert.ToDouble(Console.ReadLine());
                    if (accounts[accountID].amount >= amount)
                    {
                        accounts[accountID].amount -= amount;
                        Console.WriteLine("Amount Withdrawn Successfully");
                        Console.WriteLine("Your Account Has Amount: " + accounts[accountID].amount);
                        transactions[accountID, transactionIndex[accountID]].toID = -1;
                        transactions[accountID, transactionIndex[accountID]].description = "withdraw";
                        transactions[accountID, transactionIndex[accountID]].amount = amount;
                        transactions[accountID, transactionIndex[accountID]].datetime = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
                        transactionIndex[accountID]++;
                    }
                    else
                    {
                        Console.WriteLine("Insufficient Amount");
                    }
                }
                else
                {
                    Console.WriteLine("Wrong/Invalid PIN");
                }
            }
            else
            {
                Console.WriteLine("Account Doesn't Exist");
            }
        }

        static void TransferAmount()
        {

            Console.Write("Enter Your Account ID: ");
            int accountID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Your PIN: ");
            string pin = Console.ReadLine();
            if (accountID <= index)
            {
                if (accounts[accountID].pin == pin)
                {
                    Console.Write("Enter Destination AccountID: ");
                    int destinationID = Convert.ToInt32(Console.ReadLine());
                    if (destinationID <= index)
                    {
                        Console.Write("Enter Amount To Withdraw: ");
                        double amount = Convert.ToDouble(Console.ReadLine());
                        if (accounts[accountID].amount >= amount)
                        {
                            accounts[accountID].amount -= amount;
                            accounts[destinationID].amount += amount;
                            Console.WriteLine("Amount Transfered Successfully");
                            Console.WriteLine("Your Account Has Amount: " + accounts[accountID].amount);
                            transactions[accountID, transactionIndex[accountID]].toID = destinationID;
                            transactions[accountID, transactionIndex[accountID]].description = "transfer";
                            transactions[accountID, transactionIndex[accountID]].amount = amount;
                            transactions[accountID, transactionIndex[accountID]].datetime = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
                            transactionIndex[accountID]++;
                        }
                        else
                        {
                            Console.WriteLine("Insufficient Amount");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Account Doesn't Exist");
                    }
                }
                else
                {
                    Console.WriteLine("Wrong/Invalid PIN");
                }
            }
            else
            {
                Console.WriteLine("Account Doesn't Exist");
            }

        }

        static void TransactionHistory()
        {
            Console.Write("Enter Your Account ID: ");
            int accountID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Your PIN: ");
            string pin = Console.ReadLine();
            if (accountID <= index)
            {
                if (accounts[accountID].pin == pin)
                {
                    Console.WriteLine("\nTRANSACTION HISTORY\n ");
                    for (int ind = transactionIndex[accountID] - 1; ind >= 0; ind--)
                    {
                        Console.Write(transactions[accountID, ind].datetime + "  " + transactions[accountID, ind].description + "  " + transactions[accountID, ind].amount + "  ");
                        if (transactions[accountID, ind].toID != -1)
                        {
                            Console.Write(" to " + accounts[transactions[accountID, ind].toID].name);
                        }
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                Console.WriteLine("Account Doesn't Exist");
            }
        }
    }
}

