using System;

namespace BankApplication
{
    class ConsoleBankApplication
    {
        static void Main(string[] args)
        {
            int choice;
            ATM atm = new ATM();
            do
            {
                StandardMessages.WelcomeMessage();
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ATM.AddAccount();
                        break;

                    case 2:
                        ATM.Deposit();
                        break;

                    case 3:
                        ATM.Withdraw();
                        break;

                    case 4:
                        ATM.TransferAmount();
                        break;

                    case 5:
                        ATM.TransactionHistory();
                        break;

                    case 6:
                        StandardMessages.Exit();
                        break;

                    default:
                        StandardMessages.Invalid();
                        break;
                }
                Console.WriteLine("\n");
            } while (choice != 6);

        }
    }
}