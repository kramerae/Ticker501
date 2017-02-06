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
            Console.WriteLine("Enter ticker name for stock you wish to buy:");
            string tickername = Console.ReadLine();

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

            return cost; 
            
            /*
            // ********* Check to see if stock is already in portfolio
            foreach (Stock s in _stocks)
            {
                if(s.GetTickerName == tickername.ToUpper())
                {
                    // add stock to portfolio
                    throw new NotImplementedException();
                }
            }
            
            throw new NotImplementedException();
            */
        }
        
        public double SellStock(string tickername)
        {
            throw new NotImplementedException();
        }

        public double PositionsBalance()
        {
            throw new NotImplementedException();
            double total = 0;
            foreach(Stock s in _stocks.Values)
            {
                int q = s.GetQuantity;
                double p = s.GetPrice;
                total += (p * q);
            }
            foreach(Stock x in _stocks.Values)
            {
                Console.WriteLine("\t" + x.GetTickerName + " = ");
            }
        }
    }
}
