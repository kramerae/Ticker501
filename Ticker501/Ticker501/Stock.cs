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

        // Stock isntance for reading in stock files
        public Stock(string tickername, string fullname, double purchasevalue)
        {
            _tickerName = tickername;
            _name = fullname;
            _purchasevalue = purchasevalue;
        }

        // Stock instance for when buying stock
        public Stock(string tickername, string fullname, double purchasevalue, double price, int quantity)
        {
            _tickerName = tickername;
            _name = fullname;
            _price = price;
            _quantity = quantity;
            _purchasevalue = purchasevalue;
        }



        public string GetTickerName
        {
            get
            {
                return _tickerName;
            }
        }

        public string GetName
        {
            get
            {
                return _name;
            }
        }

        public double GetPrice
        {
            get
            {
                return _price;
            }
        }

        public int GetQuantity
        {
            get
            {
                return _quantity;
            }
        }
     
        public double GetPurchaseValue
        {
            get
            {
                return _purchasevalue;
            }
        }
        
        public void DisplayStock()
        {
            Console.WriteLine(_tickerName + "-" + _name + "-$" + _purchasevalue);    
        }
        /*
        public double Add(int count)
        {
            double 
            return 
        }
        */

 
    }
}
