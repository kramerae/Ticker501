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
    /// <summary>
    /// Main class that displays menu at the account and portfolio level
    /// </summary>
    class Program
    { 
        public static Account _account; // holds an account

        /// <summary>
        /// Main Method
        /// Reads in the file & creates a instance of an account
        /// Displays Either Account or Portfolio menu until user exits
        /// </summary>
        /// <param name="args"></param>
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
                    // Calls account menu
                    menu = AccountMenu();
                }
                else if(menu == 2)
                {
                    // Calls portfolio menu
                    menu = PortfolioMenu();
                }
            } while (menu != 0);

            // Exit when menu variable becomes 0 
            System.Environment.Exit(0);

        }
        
        /// <summary>
        /// Displays the account menu options 
        /// </summary>
        /// <returns>menu level (0/1/2)</returns>
        private static int AccountMenu()
        {
            try
            {
                int menu = 1;
                while (menu == 1)
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
                    Console.Write("Selection: ");
                    string s = Console.ReadLine();
                    // Calls switch based on option input
                    menu = AccountSwitch(s[0]);
                }

                return menu;
            }
            catch
            {
                Console.WriteLine("Error. Returning to main menu");
                return 1; 
            }
            
        }

        /// <summary>
        /// Displays the Portfolio Menu Option
        /// </summary>
        /// <returns>menu level (0/1/2)</returns>
        private static int PortfolioMenu()
        {
            try
            {
                int menu = 2;
                // Gets portfolio object
                Portfolio p = _account.SelectPortfolio();
                while (menu == 2)
                {
                    Console.WriteLine("\nPortfolio Menu for portfolio " + p.GetName);
                    Console.WriteLine("Please select an option:");
                    Console.WriteLine("(A) Portfolio Balance");
                    Console.WriteLine("(P) Positions Balance");
                    Console.WriteLine("(B) Buy Stock");
                    Console.WriteLine("(S) Sell Stock");
                    Console.WriteLine("(R) Gains/Loss Report");
                    Console.WriteLine("(M) Return to Account Menu");
                    Console.Write("Selection: ");
                    string s = Console.ReadLine();
                    // Calls portfolio switch based on option input
                    menu = PortfolioSwitch(s[0], p);
                }

                return menu;
            }
            catch
            {
                Console.WriteLine("Error. Returning to main menu");
                return 1;
            }
            
        }
        
        /// <summary>
        /// Switch statement for all the account menu input options
        /// Account actions are completed depending on char input
        /// </summary>
        /// <param name="option">single character inputed from account menu</param>
        /// <returns>menu level (0/1/2)</returns>
        private static int AccountSwitch(char option)
        {
            // Switch statement 
            switch (option)
            {
                // Deposit funds to account
                case ('D'):
                case ('d'):
                    {
                        try
                        {
                            Console.WriteLine("\nDeposit funds to account:");
                            Console.Write("Enter deposit amount: ");
                            double d = Convert.ToDouble(Console.ReadLine());
                            double funds = _account.DepositFunds(d);
                            Console.WriteLine("Account Fund Balance = $" + funds.ToString("n2"));
                            return 1;
                        }
                        catch
                        {
                            Console.WriteLine("Error. Invalid input. Returning to main menu.");
                            return 1; 
                        }
                    }
                // Withdrawal funds from account
                case ('W'):
                case ('w'):
                    {
                        try
                        {
                            Console.WriteLine("\nWithdrawal funds from account:");
                            Console.Write("Enter withdrawal amount: ");
                            double w = Convert.ToDouble(Console.ReadLine());
                            double funds = _account.WithdrawalFunds(w);
                            Console.WriteLine("Account Fund Balance = $" + funds.ToString("n2"));
                            return 1;
                        }
                        catch
                        {
                            Console.WriteLine("Error. Invalid input. Returning to main menu.");
                            return 1;
                        }
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
                        _account.Report();
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
                        // check to see if they have a portfolio to view its menu
                        if(_account.GetPortfolioCount == 0)
                        {
                            Console.WriteLine("\nYou do not have any portfolios to view.");
                            Console.WriteLine("Returning to main menu.");
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
                        Simulator.StartSimulator();
                        return 1;
                    }
                // Exit
                case ('E'):
                case ('e'):
                    {
                        return 0;
                    }
                // Any other letter is invalid 
                default:
                    {
                        Console.WriteLine("Invalid Option.");
                        return 1;
                    }
            }
        }

        /// <summary>
        /// Switch statement for all the portfolio menu input options
        /// </summary>
        /// <param name="option">single character inputed from portfolio menu</param>
        /// <param name="p">The Portfolio object that the menu is for</param>
        /// <returns>menu level (0/1/2)</returns>
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
                        p.Report();
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
