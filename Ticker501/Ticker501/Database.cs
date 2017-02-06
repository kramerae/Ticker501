using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticker501
{
    class Database
    {
        public static Dictionary<string, Stock> _stockdatabase;
        //public static Dictionary<string, KeyValuePair<string, double>> _updatedstock;

        public static void ReadFile()
        {
            string filename = "Ticker.txt";
            _stockdatabase = new Dictionary<string, Stock>();
            using (StreamReader file = new StreamReader(filename))
            {
                while (!file.EndOfStream)
                {
                    string[] line = file.ReadLine().Split('-');
                    if (line.Length == 3)
                    {
                        Stock newstk = new Stock(line[0].ToString(), line[1].ToString(), Convert.ToDouble(line[2].Substring(1)), Convert.ToDouble(line[2].Substring(1)));
                        _stockdatabase.Add(line[0].ToString(), newstk);
                    }

                }
            }
            //_updatedstock = _stockdatabase;
        }

        public static void DisplayTicker()
        {
            Console.WriteLine("Current Ticker Values");
            foreach (Stock s in _stockdatabase.Values)
            {
                s.DisplayStock();
            }

            Console.WriteLine("");
        }

        public static void StartSimulator()
        {
            Console.WriteLine("Enter Market Volatility:");
            Console.WriteLine("(1) High-Volatility (3%-15% change)");
            Console.WriteLine("(2) Medium-Volatility (2%-8% change)");
            Console.WriteLine("(3) Low-Volatility (1%-4% change)");
            Console.Write("Selection: ");
            int selection = Convert.ToInt32(Console.ReadLine());

            while (selection < 1 || selection > 3)
            {
                Console.WriteLine("Invalid option");
                Console.WriteLine("Enter Market Volatility:");
                Console.WriteLine("(1) High-Volatility (3%-15% change)");
                Console.WriteLine("(2) Medium-Volatility (2%-8% change)");
                Console.WriteLine("(3) Low-Volatility (1%-4% change)");
                Console.Write("Selection: ");
                selection = Convert.ToInt32(Console.ReadLine());
            }
            UpdatePrices(selection);
        }

        public static void UpdatePrices(int selection)
        {
            Random rnd = new Random();
            int randomnumber;
            int r;
            int sign;
            double price;
            double change;
            double multiplier;

            if (selection == 1)
            {
                randomnumber = rnd.Next(3, 16);
                multiplier = ((double)randomnumber / (double)100);
                r = rnd.Next(1, 3);
                if (r == 1)
                {
                    sign = 1;
                }
                else
                {
                    sign = -1;
                }
                foreach (Stock s in _stockdatabase.Values)
                {
                    price = s.GetPurchaseValue;
                    change = price * multiplier;
                    if (sign == 1)
                    {
                        s.UpdateStock(price + change);
                    }
                    else if (sign == -1)
                    {
                        s.UpdateStock(price - change);
                    }
                }
                foreach (Portfolio p in Program._account.GetPortfolio.Values)
                {
                    foreach (Stock s in p.GetStocks.Values)
                    {
                        price = s.GetPurchaseValue;
                        change = price * multiplier;
                        if (sign == 1)
                        {
                            s.UpdateStock(price + change);
                        }
                        else if (sign == -1)
                        {
                            s.UpdateStock(price - change);
                        }
                    }
                }



            }
            else if (selection == 2)
            {
                randomnumber = rnd.Next(2, 9);
                multiplier = ((double)randomnumber / (double)100);
                r = rnd.Next(1, 3);
                if (r == 1)
                {
                    sign = 1;
                }
                else
                {
                    sign = -1;
                }
                foreach (Stock s in _stockdatabase.Values)
                {
                    price = s.GetPurchaseValue;
                    change = price * multiplier;
                    if (sign == 1)
                    {
                        s.UpdateStock(price + change);
                    }
                    else if (sign == -1)
                    {
                        s.UpdateStock(price - change);
                    }
                }
                foreach (Portfolio p in Program._account.GetPortfolio.Values)
                {
                    foreach (Stock s in p.GetStocks.Values)
                    {
                        price = s.GetPurchaseValue;
                        change = price * multiplier;
                        if (sign == 1)
                        {
                            s.UpdateStock(price + change);
                        }
                        else if (sign == -1)
                        {
                            s.UpdateStock(price - change);
                        }
                    }
                }

            }
            else if (selection == 3)
            {
                randomnumber = rnd.Next(1, 5);
                multiplier = ((double)randomnumber / (double)100);
                r = rnd.Next(1, 3);
                if (r == 1)
                {
                    sign = 1;
                }
                else
                {
                    sign = -1;
                }
                foreach (Stock s in _stockdatabase.Values)
                {
                    price = s.GetPurchaseValue;
                    change = price * multiplier;
                    if (sign == 1)
                    {
                        s.UpdateStock(price + change);
                    }
                    else if (sign == -1)
                    {
                        s.UpdateStock(price - change);
                    }
                }
                foreach (Portfolio p in Program._account.GetPortfolio.Values)
                {
                    foreach (Stock s in p.GetStocks.Values)
                    {
                        price = s.GetPurchaseValue;
                        change = price * multiplier;
                        if (sign == 1)
                        {
                            s.UpdateStock(price + change);
                        }
                        else if (sign == -1)
                        {
                            s.UpdateStock(price - change);
                        }
                    }
                }

            }
        }
    }
}
