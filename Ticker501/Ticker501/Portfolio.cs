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
       
        public double BuyStock(string tickername)
        {
            throw new NotImplementedException();
            /*
            // Check to see if stock is already in portfolio
            foreach(Stock s in _PortfolioStocks)
            {
                if(s. == tickername)
                {

                }
            }
            // if not add to portfolio
            Stock nwstk = new Stock(ticker)
            _PortfolioStocks.Add()
            */  
        }
        
        public double SellStock(string tickername)
        {
            throw new NotImplementedException();
        }
    }
}
