/* Portfolio.cs
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
    /// Class for the type Portfolio which is made of stocks
    /// Handles all actions that need to be made at portfolio level
    /// </summary>
    public class Portfolio
    {
        public const double FFPTrade = 9.99; // Constant for flat fee per buy/sell
        public const double FFPTransfer = 4.99; // Constant for flat fee per deposit/withdrawal
        private string _name; // name of the portfolio
        private Dictionary<string, Stock> _stocks; // the stocks in a portfolio
        
        /// <summary>
        /// Constructs a portfolio
        /// Dictionary of stock tickername as keys and stock object as values
        /// </summary>
        /// <param name="name">name of portfolio</param>
        public Portfolio(string name)
        {
            _name = name;
            _stocks = new Dictionary<string, Stock>();
        }

        /// <summary>
        /// Gets the name of the portfolio
        /// </summary>
        public string GetName
        {
            get
            {
                return _name;
            }
        }

        /// <summary>
        /// Get the dictionary of stocks that make up the portfolio
        /// </summary>
        public Dictionary<string, Stock> GetStocks
        {
            get
            {
                return _stocks;
            }
        }
       
        /// <summary>
        /// Method to buy stock at portfolio level
        /// </summary>
        /// <param name="funds">amount of funds availabe to buy stocks</param>
        /// <returns>cost of buying stocks</returns>
        public double BuyStock(double funds)
        {
            // Display current stock values
            Database.DisplayTicker();

            // Get ticker name
            Console.Write("Enter ticker name for stock you wish to buy: ");
            string tickername = Console.ReadLine().ToUpper();

            double cost = 0;
            Stock value;
            // Check to see if stock is valid
            if(Database._stockdatabase.TryGetValue(tickername, out value))
            {
                Console.WriteLine("Purchasing: " + value.GetTickerName + "-" + value.GetName + "-" + value.GetPurchaseValue);

                int style = 0; // 1 = enter # of stocks; 2 = enter amount in $$
                Console.WriteLine("(1) to buy by entering number of stocks\n(2) to buy by amount in dollars");
                Console.Write("Selection: ");
                style = Convert.ToInt32(Console.ReadLine());
                
                int quantity = 0;
                // buy by entering number of stocks
                if(style == 1)
                {
                    // Get the quantity of stocks to buy
                    Console.Write("Enter the number of " + value.GetTickerName + " stocks you want to buy: ");
                    quantity = Convert.ToInt32(Console.ReadLine());
                    // Calculate cost by getting current value and multiple by number buying
                    cost = value.GetPurchaseValue * quantity;
                    // Add trade fee
                    cost += FFPTrade;
                    // Check to see if the account has enough funds to buy the stock
                    if (cost > funds)
                    {
                        // not enough funds return to menu
                        Console.WriteLine("You don't have that much money!");
                        Console.WriteLine("Exiting buy stock...");
                        return 0;
                    }

                    // Have enough money
                    // Create new stock object & add to dictionary
                    Stock nwstk = new Stock(value.GetTickerName, value.GetName, value.GetPurchaseValue, value.GetPurchaseValue, quantity);
                    _stocks.Add(value.GetTickerName, nwstk);

                }
                // buy by entering amount
                else if(style == 2)
                {
                    // Get the amount they want to spend on buying stocks
                    Console.Write("Enter the amount in dollars of " + value.GetTickerName + " stock you want to buy: ");
                    double amount = Convert.ToInt32(Console.ReadLine());
                    // Calculate the quantity to buy based on current cost / stock
                    quantity = Convert.ToInt32(amount / value.GetPurchaseValue);
                    // Calculate cost of buying stock & add fee for buying stock
                    cost = value.GetPurchaseValue * quantity;
                    cost += FFPTrade;
                    // check to see if enough money in account to make purchase
                    if (cost > funds)
                    {
                        // not enough funds return to menu
                        Console.WriteLine("You don't have that much money!");
                        Console.WriteLine("Exiting buy stock...");
                        return 0;
                    }

                    // Have enough money
                    // Create new stock object & add to dictionary
                    Stock nwstk = new Stock(value.GetTickerName, value.GetName, value.GetPurchaseValue, value.GetPurchaseValue, quantity);
                    _stocks.Add(value.GetTickerName, nwstk);

                }
            }
            // Did not select a valid ticker to buy
            else
            {
                Console.WriteLine("Invalid ticker option.");
            }
            // Check to validate if stock was purchased
            if(cost > 0)
            {
                Console.WriteLine("Successfully purchased " + tickername.ToUpper() + " stock.");
            }
            // return cost of purchase
            return cost; 
        }
        
        /// <summary>
        /// Method to sell stock at portfolio level
        /// </summary>
        /// <returns>total money from selling stocks</returns>
        public double SellStock()
        {
            // Display all stocks in portfolio & get which one user wants to sell
            Console.WriteLine("Select which stock to sell: ");
            foreach(Stock s in _stocks.Values)
            {
                Console.WriteLine(s.GetTickerName + "-" + s.GetName + "-" + s.GetQuantity + " @ $" + s.GetPrice);
            }
            Console.Write("Selection (enter tickername): ");
            string input = Console.ReadLine().ToUpper();
            Stock value;
            // Validate if stock entered is in portfolio
            while(!(_stocks.TryGetValue(input, out value)))
            {
                Console.WriteLine("Invalid option try again.");
                Console.WriteLine("Choose a stock to sell: ");
                Console.Write("Selection (enter tickername): ");
                input = Console.ReadLine().ToUpper();
            }

            // Get all the values of selected stock & store locally
            string name = value.GetName;
            string tn = value.GetTickerName;
            double price = value.GetPrice;
            int quantity = value.GetQuantity;
            double purchaseprice = value.GetPurchaseValue;

            // Display current value of selected stock and quantity in portfolio
            Console.WriteLine("Selling: " + tn + " @ $" + price.ToString("n2") + " / share");
            // Get the number of stocks user wants to sell
            Console.WriteLine("How many of your " + quantity + " stocks do you want to sell?");
            Console.Write("Amount: ");
            int sell = Convert.ToInt32(Console.ReadLine());
            // Check to see user has that many stocks to sell
            // Loop until given a valid quantity to sell
            while(sell > quantity)
            { 
                Console.WriteLine("You do not own that many stocks");
                Console.WriteLine("How many of your " + quantity + " stocks do you want to sell?");
                Console.Write("Amount: ");
                sell = Convert.ToInt32(Console.ReadLine());
            }
            // Get the amount for selling the stocks & remove stock
            double amount = sell * price;
            amount -= FFPTrade;
            _stocks.Remove(input.ToUpper());
            // Calculate new quantity for stock in portfolio after selling
            int newquanity = quantity - sell;
            // If stocks are remaing, add stock to portfolio based on new quantity remaining
            if(newquanity > 0)
            {
                Stock updatestk = new Stock(tn, name, purchaseprice, price, newquanity);
                _stocks.Add(input, updatestk);
            }

            // Return amount of cash received for selling stock 
            return amount; 
        }

        /// <summary>
        /// Method to get the initial value of all stock in specific portfolio
        /// </summary>
        /// <returns>amount spent to buy all stocks in portfolio</returns>
        public double InitialValue()
        {
            double total = 0;
            // loop through each stock in portfolio
            foreach (Stock s in _stocks.Values)
            {
                // adds purchase cost of stock to running total
                int q = s.GetQuantity;
                double p = s.GetPurchaseValue;
                total += (p * q);
            }
            // return total purchase cost of all stocks 
            return total;
        }

        /// <summary>
        /// Method to get the current value of all stock in a specific portfolio
        /// </summary>
        /// <returns>current amount of all stocks in portfolio</returns>
        public double CurrentValue()
        {
            double total = 0;
            // loop through each stock in portfolio
            foreach (Stock s in _stocks.Values)
            {
                // calculates the current value and adds to running total
                int q = s.GetQuantity;
                double p = s.GetPrice;
                total += (p * q);
            }
            // return current value of all stocks 
            return total;
        }

        /// <summary>
        /// Method to get the number of stocks in the portfolio
        /// </summary>
        /// <returns>total number of stocks</returns>
        public int Quantity()
        {
            int total = 0;
            // loop through each stock in portfolio
            foreach (Stock s in _stocks.Values)
            {
                // gets quantity and adds to running total
                int q = s.GetQuantity;
                total += q;
            }
            // return quantity 
            return total;
        }

        /// <summary>
        /// Displays the position balance of all stocks within the portfolio
        /// </summary>
        public void PositionsBalance()
        {
            
            double total = CurrentValue();
            int quantity = Quantity();
            // Displays the current value of all stocks in portfolio
            Console.WriteLine("Current value of all stocks in portfolio " + _name + " : $" + total.ToString("n2"));
            // For each stock displays the current value and the percent of the # of stocks of total quantity in portfolio
            Console.WriteLine("Breakdown by stock:");
            foreach (Stock s in _stocks.Values)
            {
                double t = s.GetQuantity * s.GetPrice;
                double percent = ((double)s.GetQuantity / (double)quantity)*100;
                Console.WriteLine("\t" + s.GetTickerName + " - " + s.GetName + "(" + percent.ToString("n2") + "%)" + " = $" + t.ToString("n2"));
            }
        }

        /// <summary>
        /// Displays the portfolio balance of the portfolio
        /// </summary>
        /// <param name="accttotal"></param>
        public void PortfolioBalance(double accttotal)
        {
            double invest = InitialValue();
            double percent = ((double)Quantity() / accttotal) * 100;
            // Displays the amount spend to purchase all stock in account
            Console.WriteLine("Total Investment: $" + invest.ToString("n2"));
            // Displays the percent the stocks in the portfolio are of the entire number of stocks in account
            Console.WriteLine("Percentage of Account: " + percent + "%");
        }

        /// <summary>
        /// Displays the gain/loss report of a portfolio
        /// </summary>
        public void Report()
        {
            // get current value of all stocks in portfolio
            double currenttotal = CurrentValue();
            // get purchase value of all stocks in portfolio
            double initialtotal = InitialValue();
            // Calculate and display the amount of change and percent change between the purchase and current
            double change = initialtotal - currenttotal;
            double percent = (change / initialtotal) * 100;
            Console.WriteLine("Value of all stocks at purchase = $" + initialtotal.ToString("n2"));
            Console.WriteLine("Value of stocks at current time = $" + currenttotal.ToString("n2"));
            Console.WriteLine("Gain/Loss in dollars: " + change.ToString("+0.00;-0.00"));
            Console.WriteLine("Percent change: " + percent.ToString("+0.00;-0.00") + "%");
        }
    }
}
