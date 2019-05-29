using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Exchange.Data
{
    public class ConectionDatabase
    {
        public string GetConection()
        {
            return "Data Source=RYEPES;Initial Catalog=ExchangeRates;Persist Security Info=True;User ID=sa;Password=123456";
        }
    }
}
