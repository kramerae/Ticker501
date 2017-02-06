using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticker501
{
    public class Stock
    {
        private string _tickerName; // ticker name
        private string _name; // full name 
        private double _price; // current price 
        private int _quantity; // quantity to be purchased
        private double _purchasevalue; // purchase price

        /// <summary>
        /// Stock instance for reading in stock from file
        /// </summary>
        /// <param name="tickername">ticker name stock</param>
        /// <param name="fullname">full name of stock</param>
        /// <param name="purchasevalue">purchase value of stock</param>
        /// <param name="price">also the purchase value</param>
        public Stock(string tickername, string fullname, double purchasevalue, double price)
        {
            _tickerName = tickername;
            _name = fullname;
            _purchasevalue = purchasevalue;
            _price = price;
        }

        /// <summary>
        /// Stock instance when buying/selling stock 
        /// </summary>
        /// <param name="tickername">tickername</param>
        /// <param name="fullname">full name</param>
        /// <param name="purchasevalue">value from file</param>
        /// <param name="price">current price (updated by simulator)</param>
        /// <param name="quantity">number of stocks bought</param>
        public Stock(string tickername, string fullname, double purchasevalue, double price, int quantity)
        {
            _tickerName = tickername;
            _name = fullname;
            _price = price;
            _quantity = quantity;
            _purchasevalue = purchasevalue;
        }

        /// <summary>
        /// Gets the ticker name stock
        /// </summary>
        public string GetTickerName
        {
            get
            {
                return _tickerName;
            }
        }

        /// <summary>
        /// Gets the full name of stock
        /// </summary>
        public string GetName
        {
            get
            {
                return _name;
            }
        }

        /// <summary>
        /// Gets the current price of stock
        /// </summary>
        public double GetPrice
        {
            get
            {
                return _price;
            }
        }

        /// <summary>
        /// Gets the quantity of stock
        /// </summary>
        public int GetQuantity
        {
            get
            {
                return _quantity;
            }
        }
     
        /// <summary>
        /// Gets the purchase price for stock
        /// </summary>
        public double GetPurchaseValue
        {
            get
            {
                return _purchasevalue;
            }
        }
        
        /// <summary>
        /// Displays all of the stock information in one formatted line
        /// </summary>
        public void DisplayStock()
        {
            Console.WriteLine(_tickerName + "-" + _name + "-$" + _price.ToString("n2"));    
        }

        /// <summary>
        /// Updates the current stock price 
        /// </summary>
        /// <param name="price">new price given from simulator</param>
        public void UpdateStock(double price)
        {
            _price = price; 
        }
 
    }
}
