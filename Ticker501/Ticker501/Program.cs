using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticker501
{
    class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Ticker501");
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



        }



        private static bool switchstatement(char o)
        {
            switch (o)
            {
                // Deposit funds to account
                case ('D'):
                case ('d'):
                    {
                        throw new NotImplementedException();
                        return true;
                    }
                // Withdrawal funds from account
                case ('W'):
                case ('w'):
                    {
                        throw new NotImplementedException();
                        return true;
                    }
                // Get account balance
                case ('A'):
                case ('a'):
                    {
                        throw new NotImplementedException();
                        return true;
                    }
                // Get portfolio balance
                case ('P'):
                case ('p'):
                    {
                        throw new NotImplementedException();
                        return true;
                    }
                // Buy Stock
                case ('B'):
                case ('b'):
                    {
                        throw new NotImplementedException();
                        return true;
                    }
                // Sell Stock
                case ('S'):
                case ('s'):
                    {
                        throw new NotImplementedException();
                        return true;
                    }
                // Create Portfolio
                case ('C'):
                case ('c'):
                    {
                        throw new NotImplementedException();
                        return true;
                    }
                // Delete Portfolio
                case ('X'):
                case ('x'):
                    {
                        throw new NotImplementedException();
                        return true;
                    }
                default:
                    {
                        return false;
                    }
            }
        }
    }
}
