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
        private string _name;
        private int _identifier;
        private List<Stock> _stocks; // the stocks in a portfolio

        public Portfolio(string name, int identifier)
        {
            _name = name;
            _identifier = identifier;
            _stocks = new List<Stock>();
        }

        public string GetName
        {
            get
            {
                return _name;
            }
        }

        public int GetIdentifier
        {
            get
            {
                return _identifier;
            }
        }

        public List<Stock> GetStocks
        {
            get
            {
                return _stocks;
            }
        }
       
        public double BuyStock()
        {
            int style = 0; // 1 = enter # of stocks; 2 = enter amount in $$
            Console.Write("Enter (1) to buy by entering number of stocks or (2) to buy by amount in dollars: ");
            style = Convert.ToInt32(Console.ReadLine());

            // Display current stock values
            Stock.DisplayTicker();

            Console.WriteLine("Enter 4 letter ticker abbreviation for stock you wish to buy:");
            string tickername = Console.ReadLine();
            
            
            // Check to see if stock is already in portfolio
            foreach(Stock s in _stocks)
            {
                if(s.GetTickerName == tickername.ToUpper())
                {
                    // add stock to portfolio
                    throw new NotImplementedException();
                }
            }

            KeyValuePair<string, double> pair; 
            // Checks to see if tickername is a valid option
            if (Stock._updatedstock.TryGetValue(tickername.ToUpper(), out pair))
            {
                if(style == 1)
                {
                    Console.Write("Enter the number of " + tickername.ToUpper() + " stocks you want to buy: ");
                    int quanitity = Convert.ToInt32(Console.ReadLine());
                    Stock nwstck = new Stock(tickername.ToUpper(), pair.Key, pair.Value, quanitity);
                    // Add to portfolio
                    // Change money + fee
                    throw new NotImplementedException();
                }  
                else if(style == 2)
                {
                    Console.Write("Enter the amount in dollars of " + tickername.ToUpper() + " stock you want to buy: ");
                    int amount = Convert.ToInt32(Console.ReadLine());
                    throw new NotImplementedException();
                } 
            }

            throw new NotImplementedException();
        }
        
        public double SellStock(string tickername)
        {
            throw new NotImplementedException();
        }
    }
}
