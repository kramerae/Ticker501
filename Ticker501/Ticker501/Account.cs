using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticker501
{
    public class Account
    {
        private List<Portfolio> a; // the portfolios in an account

        public Account()
        {
            a = new List<Portfolio>(); 
        }
    }
}
