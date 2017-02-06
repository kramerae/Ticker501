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
                        Stock newstk = new Stock(line[0].ToString(), line[1].ToString(), Convert.ToDouble(line[2].Substring(1)));
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
    }
}
