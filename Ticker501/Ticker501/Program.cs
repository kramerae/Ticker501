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
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Ticker501");

            // Read in file
            Stock.ReadFile();
            Account account = new Account();
            
            int menu = 1; // menu value (1 = account; 2 = portfolio; exit = 0)
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
            /*
            // Main option menu 
            char option; // variable to hold main menu selection
            bool valid = false;
            Console.WriteLine("Please select an option: \n  (D) Deposit funds to account \n  (W) Withdrawal funds from account\n  (A) Account Balance\n  (P) Portfolio Balance\n  (B) Buy Stock\n  (S) Sell Stock\n  (C) Create Porfolio\n  (X) Delete Portfolio");
            string s = Console.ReadLine();
            valid = switchstatement(s[0]);

            while (valid == false)
            {
                Console.WriteLine("Invalid Option. Please try again");
                Console.WriteLine("Please select an option: \n  (D) Deposit funds to account \n  (W) Withdrawal funds from account\n  (A) Account Balance\n  (P) Portfolio Balance\n  (B) Buy Stock\n  (S) Sell Stock\n  (C) Create Porfolio\n  (X) Delete Portfolio");
                s = Console.ReadLine();
                option = s[0];
                valid = switchstatement(s[0]);
            }
            */



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
                Console.WriteLine("(N) Create new Portfolio");
                Console.WriteLine("(X) Delete Portfolio");
                Console.WriteLine("(B) Buy Stock");
                Console.WriteLine("(S) Sell Stock");
                Console.WriteLine("(M) View Portfolio Menu");
                Console.WriteLine("(U) Update Stock Prices using simulator");
                Console.WriteLine("(E) Exit");
                string s = Console.ReadLine();
                menu = AccountSwitch(s[0]);
            }

            return menu;
        }

        private static int PortfolioMenu()
        {
            int menu = 2;
            while(menu == 2)
            {
                Console.WriteLine("\nPortfolio Menu");
                Console.WriteLine("Please select an option:");
                Console.WriteLine("(C) Cash Balance");
                Console.WriteLine("(P) Positions Balance");
                Console.WriteLine("(B) Buy Stock");
                Console.WriteLine("(S) Sell Stock");
                Console.WriteLine("(R) Gains/Loss Report");
                Console.WriteLine("(M) Return to Account Menu");
                string s = Console.ReadLine();
                menu = PortfolioSwitch(s[0]);
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
                        throw new NotImplementedException();
                        return 1;
                    }
                // Withdrawal funds from account
                case ('W'):
                case ('w'):
                    {
                        throw new NotImplementedException();
                        return 1;
                    }
                // Get account balance
                case ('A'):
                case ('a'):
                    {
                        throw new NotImplementedException();
                        return 1;
                    }
                // Get cash balance
                case ('C'):
                case ('c'):
                    {
                        throw new NotImplementedException();
                        return 1;
                    }
                // Get positions balance
                case ('P'):
                case ('p'):
                    {
                        throw new NotImplementedException();
                        return 1;
                    }
                // Get gains/loss report
                case ('R'):
                case ('r'):
                    {
                        throw new NotImplementedException();
                        return 1;
                    }
                // Buy Stock
                case ('B'):
                case ('b'):
                    {
                        throw new NotImplementedException();
                        return 1;
                    }
                // Sell Stock
                case ('S'):
                case ('s'):
                    {
                        throw new NotImplementedException();
                        return 1;
                    }
                // Create Portfolio
                case ('N'):
                case ('n'):
                    {
                        throw new NotImplementedException();
                        return 1;
                    }
                // Delete Portfolio
                case ('X'):
                case ('x'):
                    {
                        throw new NotImplementedException();
                        return 1;
                    }
                // Go to Portfolio Menu
                case ('M'):
                case ('m'):
                    {
                        return 2;
                    }
                // Update stock prices with simulator
                case ('U'):
                case ('u'):
                    {
                        throw new NotImplementedException();
                        return 1;
                    }
                default:
                    {
                        Console.WriteLine("Invalid Option.");
                        return 1;
                    }
            }
        }

        private static int PortfolioSwitch(char option)
        {
            switch (option)
            {
                // Get cash balance
                case ('C'):
                case ('c'):
                    {
                        throw new NotImplementedException();
                        return 2;
                    }
                // Get Positions Balance
                case ('P'):
                case ('p'):
                    {
                        throw new NotImplementedException();
                        return 2;
                    }
                // Get gains/loss report
                case ('R'):
                case ('r'):
                    {
                        throw new NotImplementedException();
                        return 2;
                    }
                // Buy Stock
                case ('B'):
                case ('b'):
                    {
                        throw new NotImplementedException();
                        return 2;
                    }
                // Sell Stock
                case ('S'):
                case ('s'):
                    {
                        throw new NotImplementedException();
                        return 2;
                    }
                // Return to account menu 
                case ('M'):
                case ('m'):
                    {
                        throw new NotImplementedException();
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
