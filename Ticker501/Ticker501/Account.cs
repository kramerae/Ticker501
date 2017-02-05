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
        private List<Portfolio> _portfolios; // the portfolios in an account
        private int _portfolioCount = 0; // number of portfolios
        private double _funds; // funds in account

        public Account()
        {
            _portfolios = new List<Portfolio>(); 
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

        public List<Portfolio> GetPortfolio
        {
            get
            {
                return _portfolios;
            }
        }

        public double DepositFunds(double add)
        {
            _funds += add;
            return _funds;
        }

        public double WithdrawalFunds(double w)
        {
            throw new NotImplementedException();
        }

        public void CreatePortfolio()
        {
            if (_portfolioCount < 3)
            {
                _portfolioCount++;
                Console.Write("Enter portfolio name ");
                string name = Console.ReadLine();
                int identifier = _portfolioCount;
                _portfolios.Add(new Portfolio(name, identifier));
            }
            else
            {
                Console.WriteLine("Not possible, you already have 3 portfolios.");
            }
        }
    }
}
