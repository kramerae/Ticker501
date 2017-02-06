/* Account.cs
 * Abbey Kramer: Ticker501
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticker501
{
    /// <summary>
    /// Class for the type Account which is made up of portfolios 
    /// Handles all actions that need to be made at the accout level
    /// </summary>
    public class Account
    {
        public const double FFPTrade = 9.99; // Constant for flat fee per buy/sell
        public const double FFPTransfer = 4.99; // Constant for flat fee per deposit/withdraws
        private Dictionary<string,Portfolio> _portfolios; // the portfolios in an account
        private int _portfolioCount = 0; // number of portfolios
        private double _funds; // funds in account

        /// <summary>
        /// Constructs an account 
        /// dictionary of portfolio names as keys and the portfolio object as values
        /// </summary>
        public Account()
        {
            _portfolios = new Dictionary<string, Portfolio>(); 
        }

        /// <summary>
        /// Gets the number of portfolios in the account
        /// </summary>
        public int GetPortfolioCount
        {
            get
            { 
                return _portfolioCount;
            }
        }

        /// <summary>
        /// Gets the current funds available without selling stock
        /// </summary>
        public double GetFunds
        {
            get
            {
                return _funds;
            }
        }

        /// <summary>
        /// Get the dictionary of Portfolio Names (keys) & Portfolios (values)
        /// </summary>
        public Dictionary<string,Portfolio> GetPortfolio
        {
            get
            {
                return _portfolios;
            }
        }

        /// <summary>
        /// Method to buy stock at the account level
        /// </summary>
        public void BuyStock()
        {
            double cost = 0; // variable to keep track of cost of purchase
            // Checks to see if the account contains a portfolio
            // If no portfolios in acct
            if(_portfolioCount == 0)
            {
                // Asks user if they want to create portfolio
                Console.Write("You have no portfolios.\nDo you want to create a portfolio? (y/n) ");
                string option = Console.ReadLine();
                // Yes > allows them to continue with buying stock
                if (option[0] == 'y')
                {
                    // Call Create portfolio 
                    CreatePortfolio();
                }
                // No > return to account menu 
                else
                {
                   return;
                }
            }
            // If there are portfolios in account
            if(_portfolioCount > 0)
            {
                // User selects which portfolio to buy stock in
                Portfolio p = SelectPortfolio();
                // Call buy stock at portfolio level to add stocks and get cost
                cost = p.BuyStock(_funds);
                // Subtract cost of purchase from funds 
                _funds -= cost;
            }
        }

        /// <summary>
        /// Method to sell stock at the account level
        /// </summary>
        public void SellStock()
        {
            double soldtotal = 0; // variable to keep track of money from selling
            // if there are no portfolios, there is no stock to sell
            if (_portfolioCount == 0)
            {
                Console.Write("You have no stock to sell.");
                return;
            }
            
            if (_portfolioCount > 0)
            {
                // Has user select portfolio they want to sell stock from
                Portfolio p = SelectPortfolio();
                // Call sell stock at the portfolio level
                soldtotal = p.SellStock();
                // if the amount of money changes the stock was sold 
                if (soldtotal != 0)
                {
                    // add amount to funds
                    _funds += soldtotal;
                    Console.WriteLine("Successfully sold stock.");
                }
                // returns to account menu if stock was not sold
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Method to ask user to select a portfolio from those in account
        /// </summary>
        /// <returns>The Portfolio object the user selected</returns>
        public Portfolio SelectPortfolio()
        {
            Console.WriteLine("Choose a portfolio: ");
            // displays all portfolis in account
            foreach (string p in _portfolios.Keys)
            {
                Console.WriteLine(p);
            }
            // Gets user to input name of portfolio they want
            Console.Write("Selection: ");
            string input = Console.ReadLine();
            // Trys to see if portfolio exists in dictionary 
            Portfolio value;
            while(!(_portfolios.TryGetValue(input, out value)))
            {
                // If not asks for another input
                Console.WriteLine("Invalid option try again.");
                Console.WriteLine("Choose a portfolio: ");
                input = Console.ReadLine();
            }
            // Returns portfolio object
            return value;
            
            
        }

        /// <summary>
        /// Method to deposit funds to account 
        /// </summary>
        /// <param name="add">Amount to deposit</param>
        /// <returns>The new funds available amount</returns>
        public double DepositFunds(double add)
        {
            // Adds deposit to funds
            _funds += add;
            // Deducts the fee
            _funds -= FFPTransfer;
            // Returns new amount available 
            return _funds;
        }

        /// <summary>
        /// Method to withdrawal funds from account
        /// </summary>
        /// <param name="w">Amount to withdrawal</param>
        /// <returns>The new funds available amount</returns>
        public double WithdrawalFunds(double w)
        {
            
            if(w <= _funds-FFPTransfer)
            {
                // Deduct withdrawal from funds
                _funds -= w;
                // Deduct fee 
                _funds -= FFPTransfer;
            }
            // Return new funds avaiable after withdrawal
            return _funds;
        }

        /// <summary>
        /// Adds a portfolio to the account
        /// </summary>
        public void CreatePortfolio()
        {
            // checks to see if the account has less than 3 portfolios in it
            if (_portfolioCount < 3)
            {
                // increment portfolio count
                _portfolioCount++;
                // Get portfolio name from user
                Console.Write("Enter portfolio name: ");
                string name = Console.ReadLine();
                // Create new portfolio & add it to the dictionary
                Portfolio newptf = new Portfolio(name);
                _portfolios.Add(name, newptf);
            }
            // if there are three portfolios in account. Error. Cant add another
            else
            {
                Console.WriteLine("Not possible, you already have 3 portfolios.");
            }
        }

        /// <summary>
        /// Deletes a portfolio from the account
        /// </summary>
        public void DeletePortfolio()
        {
            // Checks to see if there are any portfolios in the account to delete
            if(_portfolioCount > 0)
            {
                // Displays current portfolios
                // Has user select which portfolio to delete
                Console.WriteLine("Choose a portfolio to delete: ");
                foreach (string x in _portfolios.Keys)
                {
                    Console.WriteLine(x);
                }
                string input = Console.ReadLine();
                Portfolio value;
                while (!(_portfolios.TryGetValue(input, out value)))
                {
                    Console.WriteLine("Invalid option try again.");
                    Console.WriteLine("Choose a portfolio: ");
                    input = Console.ReadLine();
                }

                // Gets current value of all stocks in selected portfolio
                double amount = value.CurrentValue();
                // Deletes the portfolio from dictionary 
                _portfolios.Remove(input);
                // Adds current value to funds (sold all in single transaction) - fee
                _funds += amount;
                _funds -= FFPTrade;
                _portfolioCount--;
                Console.WriteLine("Portfolio deleted.");
            }
            // No portfolios in account, no actions can be taken
            else
            {
                Console.WriteLine("You do not have any portfolios within your account.");
            }
            
        }

        /// <summary>
        /// Gets current value of all stocks within the account
        /// </summary>
        /// <returns>The value of all stocks</returns>
        public double CurrentValue()
        {
            // variable to hold value
            double total = 0;
            // loop through every portfolio in account
            foreach (Portfolio p in _portfolios.Values)
            {
                // loop through every stock within each portfoli
                foreach (Stock s in p.GetStocks.Values)
                {
                    // Gets current value of stock 
                    total += s.GetQuantity * s.GetPrice;
                }
            }
            // return running total 
            return total; 
        }

        /// <summary>
        /// Displays the position balance for all stocks within account
        /// </summary>
        public void PositionsBalance()
        {
            double total = CurrentValue(); // holds current value of all stocks within account
            int quantity = Quantity(); // holds total number of stocks within entire account
            // Displays current value
            Console.WriteLine("Current value of all stocks in account: $" + total.ToString("n2"));
            // For each stock displays the current value and the percent of the # of stocks of total quantity in account
            Console.WriteLine("Breakdown by stock:");
            foreach (Portfolio p in _portfolios.Values)
            {
                foreach (Stock s in p.GetStocks.Values)
                {
                    double t = s.GetQuantity * s.GetPrice;
                    double percent = ((double)s.GetQuantity / (double)quantity) * 100;
                    Console.WriteLine("\t" + s.GetTickerName + " - " + s.GetName + "(" + percent.ToString("n2") + "%)" + " = $" + t.ToString("n2"));
                }
            }
            
        }

        /// <summary>
        /// Method to get total number of stocks within the account
        /// </summary>
        /// <returns>total quanity of stocks</returns>
        public int Quantity()
        {
            int total = 0;
            // loop through every portfolio
            foreach (Portfolio p in _portfolios.Values)
            {
                // loop through every stock in that portfolio
                foreach (Stock s in p.GetStocks.Values)
                {
                    // add quantity of specific stock to running total 
                    total += s.GetQuantity;
                }
            }
            // return total quantity 
            return total;


        }

        /// <summary>
        /// Method to display gains/loss report
        /// </summary>
        public void Report()
        {
            double initialtotal = 0;
            // Loop through every portfolio 
            foreach(Portfolio p in _portfolios.Values)
            {
                // Loop through every stock in specific portfolio
                foreach (Stock s in p.GetStocks.Values)
                {
                    // Get the intital amount spent to buy all stocks 
                    initialtotal += s.GetQuantity * s.GetPurchaseValue;
                }
            }
            // Get the current value of all stocks in account
            double currenttotal = CurrentValue();
            // Calculate and display the amount of change and percent change between the initial and current 
            double change = initialtotal - currenttotal;
            double percent = (change / initialtotal) * 100;
            Console.WriteLine("Value of all stocks at purchase = $" + initialtotal.ToString("n2"));
            Console.WriteLine("Value of stocks at current time = $" + currenttotal.ToString("n2"));
            Console.WriteLine("Gain/Loss in dollars: " + change.ToString("+0.00;-0.00"));
            Console.WriteLine("Percent change: " + percent.ToString("+0.00;-0.00") + "%");
        }

    }
}
