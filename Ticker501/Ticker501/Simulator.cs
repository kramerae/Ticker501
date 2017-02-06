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
    public class Simulator
    {
        public void StartSimulator()
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
            Database.UpdatePrices(selection);
        }
        
    }
}
