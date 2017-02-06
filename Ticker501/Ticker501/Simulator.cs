/* Simulator.cs
 * Abbey Kramer: Ticker501
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticker501
{
    /// <summary>
    /// Simulator to update current values of stock
    /// </summary>
    public class Simulator
    {
        /// <summary>
        /// Runs simulator based on market volatility from user
        /// </summary>
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

        /// <summary>
        /// Randomly generates numbers based on volatility
        /// </summary>
        /// <param name="selection">market volatility</param>
        public static void UpdatePrices(int selection)
        {
            Random rnd = new Random();
            int randomnumber;
            int r;

            // High-volatility 
            if (selection == 1)
            {
                randomnumber = rnd.Next(3, 16);
                r = rnd.Next(1, 3);
                SimulateForeach(randomnumber, r);

            }
            // Medium-volatility
            else if (selection == 2)
            {
                randomnumber = rnd.Next(2, 9);
                r = rnd.Next(1, 3);
                SimulateForeach(randomnumber, r);

            }
            // Low-volatility
            else if (selection == 3)
            {
                randomnumber = rnd.Next(1, 5);
                r = rnd.Next(1, 3);
                SimulateForeach(randomnumber, r);
            }  

        }

        /// <summary>
        /// Updates each stock price in database and in account
        /// </summary>
        /// <param name="randomnumber">random number for change based on volatility</param>
        /// <param name="r">random number for +/- change</param>
        public static void SimulateForeach(int randomnumber, int r)
        {
            int sign;
            double price;
            double change;
            double multiplier;
            // Calculate multiplier value 
            multiplier = ((double)randomnumber / (double)100);
            if (r == 1)
            {
                sign = 1;
            }
            else
            {
                sign = -1;
            }
            // Loop through and update each stock in database
            foreach (Stock s in Database._stockdatabase.Values)
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
            // Loop through and update each stock in account
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
