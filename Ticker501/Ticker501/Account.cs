/* Account.cs
 * Abbey Kramer: Ticker501
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticker501
{
    public class Account
    {
        public const double FFPTrade = 9.99;
        public const double FFPTransfer = 4.99;
        private Dictionary<string,Portfolio> _portfolios; // the portfolios in an account
        private int _portfolioCount = 0; // number of portfolios
        private double _funds; // funds in account

        public Account()
        {
            _portfolios = new Dictionary<string, Portfolio>(); 
        }

        public int GetPortfolioCount
        {
            get
            { 
                return _portfolioCount;
            }
        }

        public double GetFunds
        {
            get
            {
                return _funds;
            }
        }


        public Dictionary<string,Portfolio> GetPortfolio
        {
            get
            {
                return _portfolios;
            }
        }

        public void BuyStock()
        {
            double cost = 0; 
            if(_portfolioCount == 0)
            {
                Console.Write("You have no portfolios.\nDo you want to create a portfolio? (y/n)");
                string option = Console.ReadLine();
                if (option[0] == 'y')
                {
                    CreatePortfolio();
                }
                else
                {
                   return;
                }
            }
            
            if(_portfolioCount > 0)
            {
                Portfolio p = SelectPortfolio();
                cost = p.BuyStock(_funds);
                _funds -= cost;
            }
        }

        public Portfolio SelectPortfolio()
        {
            Console.WriteLine("Choose a portfolio: ");
            foreach (string p in _portfolios.Keys)
            {
                Console.WriteLine(p);
            }
            string input = Console.ReadLine();
            Portfolio value;
            while(!(_portfolios.TryGetValue(input, out value)))
            {
                Console.WriteLine("Invalid option try again.");
                Console.WriteLine("Choose a portfolio: ");
                input = Console.ReadLine();
            }

            return value;
            
            
        }

        public double DepositFunds(double add)
        {
            _funds += add;
            _funds -= FFPTransfer;
            return _funds;
        }

        public double WithdrawalFunds(double w)
        {
          
            if(w <= _funds-FFPTransfer)
            {
                _funds -= w;
                _funds -= FFPTransfer;
            }
            return _funds;
        }

        public void CreatePortfolio()
        {
            if (_portfolioCount < 3)
            {
                _portfolioCount++;
                Console.Write("Enter portfolio name: ");
                string name = Console.ReadLine();
                Portfolio newptf = new Portfolio(name);
                _portfolios.Add(name, newptf);
            }
            else
            {
                Console.WriteLine("Not possible, you already have 3 portfolios.");
            }
        }

        public double CurrentValue()
        {
            double total = 0;
            foreach (Portfolio p in _portfolios.Values)
            {
                foreach (Stock s in p.GetStocks.Values)
                {
                    total += s.GetQuantity * s.GetPrice;
                }
            }
            return total; 
        }

        public void PositionsBalance()
        {
            double total = CurrentValue();
            Console.WriteLine("Value of all stocks in account: $" + total.ToString("n2"));
            Console.WriteLine("Breakdown by stock:");
            foreach (Portfolio p in _portfolios.Values)
            {
                foreach (Stock s in p.GetStocks.Values)
                {
                    double t = s.GetQuantity * s.GetPrice;
                    int percent = Convert.ToInt32((t / total) * 100);
                    Console.WriteLine("\t" + s.GetTickerName + " = $" + t.ToString("n2") + " = " + percent + "%");
                }
            }
        }
    }
}
