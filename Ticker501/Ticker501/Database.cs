/* Database.cs
 * Abbey Kramer: Ticker501
 */ 
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticker501
{
    /// <summary>
    /// Class for the ticker database
    /// </summary>
    class Database
    {
        // Dictionary to hold all stocks from ticker
        public static Dictionary<string, Stock> _stockdatabase;

        /// <summary>
        /// Read in and stores ticker values from file
        /// </summary>
        public static void ReadFile()
        {
            string filename = "Ticker.txt";
            _stockdatabase = new Dictionary<string, Stock>();
            using (StreamReader file = new StreamReader(filename))
            {
                while (!file.EndOfStream)
                {
                    // Read and parse line from file
                    string[] line = file.ReadLine().Split('-');
                    if (line.Length == 3)
                    {
                        // Creates a new stock object from read in information
                        Stock newstk = new Stock(line[0].ToString(), line[1].ToString(), Convert.ToDouble(line[2].Substring(1)), Convert.ToDouble(line[2].Substring(1)));
                        // Adds stock to database of stocks
                        _stockdatabase.Add(line[0].ToString(), newstk);
                    }

                }
            }
        }

        /// <summary>
        /// Displays the current value of all stocks in database
        /// </summary>
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
