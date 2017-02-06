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
    public class Portfolio
    {
        public const double FFPTrade = 9.99;
        public const double FFPTransfer = 4.99;
        private string _name;
        private Dictionary<string, Stock> _stocks; // the stocks in a portfolio

        public Portfolio(string name)
        {
            _name = name;
            _stocks = new Dictionary<string, Stock>();
        }

        public string GetName
        {
            get
            {
                return _name;
            }
        }


        public Dictionary<string, Stock> GetStocks
        {
            get
            {
                return _stocks;
            }
        }
       
        public double BuyStock(double funds)
        {
            // Display current stock values
            Database.DisplayTicker();

            // Get ticker name
            Console.WriteLine("Enter ticker name for stock you wish to buy: ");
            string tickername = Console.ReadLine().ToUpper();

            double cost = 0;
            Stock value;
            if(Database._stockdatabase.TryGetValue(tickername, out value))
            {
                Console.WriteLine("Purchasing: " + value.GetTickerName + "-" + value.GetName + "-" + value.GetPurchaseValue);

                int style = 0; // 1 = enter # of stocks; 2 = enter amount in $$
                Console.WriteLine("\t(1) to buy by entering number of stocks\n\t(2) to buy by amount in dollars");
                style = Convert.ToInt32(Console.ReadLine());
                
                int quantity = 0;
                // buy by entering number of stocks
                if(style == 1)
                {
                    Console.Write("Enter the number of " + value.GetTickerName + " stocks you want to buy: ");
                    quantity = Convert.ToInt32(Console.ReadLine());
                    cost = value.GetPurchaseValue * quantity;
                    cost += FFPTrade;
                    if (cost > funds)
                    {
                        Console.WriteLine("You don't have that much money!");
                        Console.WriteLine("Exiting buy stock...");
                        return 0;
                    }

                    Stock nwstk = new Stock(value.GetTickerName, value.GetName, value.GetPurchaseValue, value.GetPurchaseValue, quantity);
                    _stocks.Add(value.GetTickerName, nwstk);

                }
                // buy by entering amount
                else if(style == 2)
                {
                    Console.Write("Enter the amount in dollars of " + value.GetTickerName + " stock you want to buy: ");
                    double amount = Convert.ToInt32(Console.ReadLine());
                    quantity = Convert.ToInt32(amount / value.GetPurchaseValue);
                    cost = value.GetPurchaseValue * quantity;
                    cost += FFPTrade;
                    if (cost > funds)
                    {
                        Console.WriteLine("You don't have that much money!");
                        Console.WriteLine("Exiting buy stock...");
                        return 0;
                    }

                    Stock nwstk = new Stock(value.GetTickerName, value.GetName, value.GetPurchaseValue, value.GetPurchaseValue, quantity);
                    _stocks.Add(value.GetTickerName, nwstk);

                }
            }
            else
            {
                Console.WriteLine("Invalid ticker option.");
            }

            if(cost > 0)
            {
                Console.WriteLine("Successfully purchased " + tickername.ToUpper() + " stock.");
            }
            return cost; 
        }
        
        public double SellStock()
        {
            Console.WriteLine("Select which stock to sell: ");
            foreach(Stock s in _stocks.Values)
            {
                Console.WriteLine(s.GetTickerName + "-" + s.GetName + "-" + s.GetQuantity + " @ $" + s.GetPrice);
            }
            Console.Write("Selection (enter tickername): ");
            string input = Console.ReadLine().ToUpper();
            Stock value;
            while(!(_stocks.TryGetValue(input, out value)))
            {
                Console.WriteLine("Invalid option try again.");
                Console.WriteLine("Choose a stock to sell: ");
                Console.Write("Selection (enter tickername): ");
                input = Console.ReadLine().ToUpper();
            }

            string name = value.GetName;
            string tn = value.GetTickerName;
            double price = value.GetPrice;
            int quantity = value.GetQuantity;
            double purchaseprice = value.GetPurchaseValue;

            Console.WriteLine("Selling: " + tn + " @ $" + price.ToString("n2") + " / share");
            Console.WriteLine("How many of your " + quantity + " stocks do you want to sell?");
            Console.Write("Amount: ");
            int sell = Convert.ToInt32(Console.ReadLine());
            while(sell > quantity)
            {
                Console.WriteLine("You do not own that many stocks");
                Console.WriteLine("How many of your " + quantity + " stocks do you want to sell?");
                Console.Write("Amount: ");
                sell = Convert.ToInt32(Console.ReadLine());
            }
            double amount = sell * price;
            _stocks.Remove(input.ToUpper());
            int newquanity = quantity - sell;
            if(newquanity > 0)
            {
                Stock updatestk = new Stock(tn, name, purchaseprice, price, newquanity);
                _stocks.Add(input, updatestk);
            }

            return amount; 
        }

        public double InitialValue()
        {
            double total = 0;
            foreach (Stock s in _stocks.Values)
            {
                int q = s.GetQuantity;
                double p = s.GetPurchaseValue;
                total += (p * q);
            }
            return total;
        }

        public double CurrentValue()
        {
            double total = 0;
            foreach (Stock s in _stocks.Values)
            {
                int q = s.GetQuantity;
                double p = s.GetPrice;
                total += (p * q);
            }
            return total;
        }

        public int Quantity()
        {
            int total = 0;
            foreach (Stock s in _stocks.Values)
            {
                int q = s.GetQuantity;
                total += q;
            }
            return total;
        }

        public void PositionsBalance()
        {
            double total = CurrentValue();
            int quantity = Quantity();
            Console.WriteLine("Current value of all stocks in portfolio " + _name + " : $" + total.ToString("n2"));
            Console.WriteLine("Breakdown by stock:");
            foreach (Stock s in _stocks.Values)
            {
                double t = s.GetQuantity * s.GetPrice;
                double percent = ((double)s.GetQuantity / (double)quantity)*100;
                Console.WriteLine("\t" + s.GetTickerName + " - " + s.GetName + "(" + percent.ToString("n2") + "%)" + " = $" + t.ToString("n2"));
            }
        }

        public void PortfolioBalance(double accttotal)
        {
            double invest = InitialValue();
            double percent = ((double)Quantity() / accttotal) * 100;
            Console.WriteLine("Total Investment: $" + invest.ToString("n2"));
            Console.WriteLine("Percentage of Account: " + percent + "%");
        }
    }
}
