/* Program.cs
 * Abbey Kramer: Ticker501
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticker501
{
    class Program
    {
        public static Account _account; 

        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Ticker501");

            // Read in file
            Database.ReadFile();
            // Create a new account
            _account = new Account();
            
            // Go through menu options
            // 1 = account menu, 2 = portfolio menu, 0 = exit
            int menu = 1;
            do
            {
                if(menu == 1)
                {
                    menu = AccountMenu();
                }
                else if(menu == 2)
                {
                    menu = PortfolioMenu();
                }
            } while (menu != 0);

            // Exit 
            System.Environment.Exit(0);

        }
        
        private static int AccountMenu()
        {
            int menu = 1; 
            while(menu == 1)
            {
                Console.WriteLine("\nAccount Menu");
                Console.WriteLine("Please select an option:");
                Console.WriteLine("(D) Deposit funds to account");
                Console.WriteLine("(W) Withdrawal funds from account");
                Console.WriteLine("(A) Account Balance");
                Console.WriteLine("(C) Cash Balance");
                Console.WriteLine("(P) Positions Balance");
                Console.WriteLine("(R) Gains/Loss Report");
                Console.WriteLine("(N) Create new portfolio");
                Console.WriteLine("(X) Delete portfolio");
                Console.WriteLine("(B) Buy stock");
                Console.WriteLine("(S) Sell stock");
                Console.WriteLine("(M) View portfolio menu");
                Console.WriteLine("(U) Update stock prices using simulator");
                Console.WriteLine("(E) Exit");
                string s = Console.ReadLine();
                menu = AccountSwitch(s[0]);
            }

            return menu;
        }

        private static int PortfolioMenu()
        {
            int menu = 2;
            Portfolio p = _account.SelectPortfolio();
            while(menu == 2)
            {
                Console.WriteLine("\nPortfolio Menu for portfolio " + p.GetName);
                Console.WriteLine("Please select an option:");
                Console.WriteLine("(A) Portfolio Balance");
                Console.WriteLine("(P) Positions Balance");
                Console.WriteLine("(B) Buy Stock");
                Console.WriteLine("(S) Sell Stock");
                Console.WriteLine("(R) Gains/Loss Report");
                Console.WriteLine("(M) Return to Account Menu");
                string s = Console.ReadLine();
                menu = PortfolioSwitch(s[0], p);
            }

            return menu;
        }

        private static int AccountSwitch(char option)
        {
            switch (option)
            {
                // Deposit funds to account
                case ('D'):
                case ('d'):
                    {
                        Console.WriteLine("\nDeposit funds to account:");
                        Console.Write("Enter deposit amount: ");
                        double d = Convert.ToDouble(Console.ReadLine());
                        double funds = _account.DepositFunds(d);
                        Console.WriteLine("Account Fund Balance = $" + funds.ToString("n2"));
                        return 1;
                    }
                // Withdrawal funds from account
                case ('W'):
                case ('w'):
                    {
                        Console.WriteLine("\nWithdrawal funds from account:");
                        Console.Write("Enter withdrawal amount: ");
                        double w = Convert.ToDouble(Console.ReadLine());
                        double funds = _account.WithdrawalFunds(w);
                        Console.WriteLine("Account Fund Balance = $" + funds.ToString("n2"));
                        return 1;
                    }
                // Get account balance
                case ('A'):
                case ('a'):
                    {
                        Console.WriteLine("\nGet account balance:");
                        double value = _account.CurrentValue();
                        double cash = _account.GetFunds;
                        double balance = value + cash; 
                        Console.WriteLine("Account Balance (cash available + current value of stocks) = $" + balance.ToString("n2"));
                        Console.WriteLine("\tCash available to invest: $" + cash.ToString("n2"));
                        Console.WriteLine("\tValue of stocks: $" + value.ToString("n2"));
                        return 1;
                    }
                // Get cash balance
                case ('C'):
                case ('c'):
                    {
                        Console.WriteLine("\nGet cash balance:");
                        Console.WriteLine("Cash Balance (value of stocks you own) = $" + _account.CurrentValue().ToString("n2"));
                        return 1;
                    }
                // Get positions balance
                case ('P'):
                case ('p'):
                    {
                        Console.WriteLine("\nGet positions balance:");
                        _account.PositionsBalance();
                        return 1;
                    }
                // Get gains/loss report
                case ('R'):
                case ('r'):
                    {
                        Console.WriteLine("\nGet gains/loss report:");
                        throw new NotImplementedException();
                        return 1;
                    }
                // Buy Stock
                case ('B'):
                case ('b'):
                    {
                        Console.WriteLine("\nBuy stock:");
                        _account.BuyStock();
                        return 1;
                    }
                // Sell Stock
                case ('S'):
                case ('s'):
                    {
                        Console.WriteLine("\nSell stock:");
                        _account.SellStock();
                        //throw new NotImplementedException();
                        return 1;
                    }
                // Create Portfolio
                case ('N'):
                case ('n'):
                    {
                        Console.WriteLine("\nCreate a new portfolio:");
                        _account.CreatePortfolio();
                        return 1;
                    }
                // Delete Portfolio
                case ('X'):
                case ('x'):
                    {
                        Console.WriteLine("\nDelete a portfolio:");
                        _account.DeletePortfolio();
                        return 1;
                    }
                // Go to Portfolio Menu
                case ('M'):
                case ('m'):
                    {
                        if(_account.GetPortfolioCount == 0)
                        {
                            Console.WriteLine("You do not have any portfolios to view.");
                            return 1;
                        }
                        else
                        {
                            return 2;
                        }
                    }
                // Update stock prices with simulator
                case ('U'):
                case ('u'):
                    {
                        Console.WriteLine("\nLauching simulator:");
                        Database.StartSimulator();
                        //throw new NotImplementedException();
                        return 1;
                    }
                case ('E'):
                case ('e'):
                    {
                        return 0;
                    }
                default:
                    {
                        Console.WriteLine("Invalid Option.");
                        return 1;
                    }
            }
        }

        private static int PortfolioSwitch(char option, Portfolio p)
        {
            switch (option)
            {
                // Get portfolio balance
                case ('A'):
                case ('a'):
                    {
                        Console.WriteLine("\nGet portfolio balance:");
                        int q = _account.Quantity();
                        p.PortfolioBalance(q);
                        return 2;
                    }
                // Get Positions Balance
                case ('P'):
                case ('p'):
                    {
                        Console.WriteLine("\nGet positions balance:");
                        p.PositionsBalance();
                        return 2;
                    }
                // Get gains/loss report
                case ('R'):
                case ('r'):
                    {
                        Console.WriteLine("\nGet gains/loss report:");
                        throw new NotImplementedException();
                        return 2;
                    }
                // Buy Stock
                case ('B'):
                case ('b'):
                    {
                        Console.WriteLine("\nBuy stock:");
                        p.BuyStock(_account.GetFunds);
                        return 2;
                    }
                // Sell Stock
                case ('S'):
                case ('s'):
                    {
                        Console.WriteLine("\nSell stock:");
                        p.SellStock();
                        //throw new NotImplementedException();
                        return 2;
                    }
                // Return to account menu 
                case ('M'):
                case ('m'):
                    {
                        return 1;
                    }
                default:
                    {
                        Console.WriteLine("Invalid Option.");
                        return 2;
                    }
            }
        }
        
        
    }
}
