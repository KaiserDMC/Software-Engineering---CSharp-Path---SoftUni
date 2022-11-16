using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyTransactions
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, double> accountBalance = new Dictionary<int, double>();

            string[] accountStrings = Console.ReadLine().Split(",").ToArray();

            foreach (var account in accountStrings)
            {
                int bankAccount = int.Parse(account.Split("-").First());
                double balance = double.Parse(account.Split("-").Last());

                accountBalance.Add(bankAccount, balance);
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                try
                {
                    string[] commadStrings = input.Split(" ").ToArray();

                    string command = commadStrings[0];
                    int accountNumber = int.Parse(commadStrings[1]);
                    double accBalance = double.Parse(commadStrings[2]);

                    switch (command)
                    {
                        case "Deposit":
                            Deposit(accountBalance, accountNumber, accBalance);

                            Console.WriteLine(
                                $"Account {accountNumber} has new balance: {accountBalance[accountNumber]:f2}");

                            break;
                        case "Withdraw":
                            Withdraw(accountBalance, accountNumber, accBalance);

                            Console.WriteLine(
                                $"Account {accountNumber} has new balance: {accountBalance[accountNumber]:f2}");

                            break;
                        default:
                            throw new ArgumentException($"Invalid command!");
                    }
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine($"Invalid account!");
                }
                //catch (InvalidOperationException e)
                //{
                //    Console.WriteLine(e.Message);
                //}
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine($"Enter another command");
                }

                input = Console.ReadLine();
            }
        }

        public static void Deposit(Dictionary<int, double> accounts, int accountNumber, double sum)
        {
            //if (!accounts.ContainsKey(accountNumber))
            //{
            //    throw new InvalidOperationException($"Invalid account!");
            //}

            accounts[accountNumber] += sum;
        }

        public static void Withdraw(Dictionary<int, double> accounts, int accountNumber, double sum)
        {
            //if (!accounts.ContainsKey(accountNumber))
            //{
            //    throw new InvalidOperationException($"Invalid account!");
            //}

            accounts[accountNumber] -= sum;

            if (accounts[accountNumber] < 0)
            {
                accounts[accountNumber] += sum;
                throw new ArgumentException($"Insufficient balance!");
            }
        }
    }
}
