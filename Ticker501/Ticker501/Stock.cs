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
        private string _tickerName; // ab. name
        private string _name; // full name 
        private double _price; // price 
        private int _quantity; // 
        public static Dictionary<string, KeyValuePair<string, double>> _initialstock;
        public static Dictionary<string, KeyValuePair<string, double>> _updatedstock;

        public Stock(string tickername, string fullname, double price, int quantity)
        {
            _tickerName = tickername;
            _name = fullname;
            _price = price;
            _quantity = quantity;
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
     
        /*
        public double Add(int count)
        {
            double 
            return 
        }
        */

        public static void ReadFile()
        {
            string filename = "Ticker.txt";
            _initialstock = new Dictionary<string, KeyValuePair<string, double>>();
            using (StreamReader file = new StreamReader(filename))
            {
                while (!file.EndOfStream)
                {
                    string[] line = file.ReadLine().Split('-');
                    if(line.Length == 3)
                    {
                        _initialstock.Add(line[0].ToString(), new KeyValuePair<string, double>(line[1].ToString(), Convert.ToDouble(line[2].Substring(1))));
                    }
                   
                }
            }
            _updatedstock = _initialstock;
        }
       
        public static void DisplayTicker()
        {
            Console.WriteLine("Current Ticker Values");
            foreach(var item in _updatedstock)
            {
                string ticker = item.Key;
                KeyValuePair<string, double> pair = item.Value;
                Console.WriteLine(ticker + "-" + pair.Key + "-" + pair.Value);
            }

            Console.WriteLine("");
        }
    }
}
