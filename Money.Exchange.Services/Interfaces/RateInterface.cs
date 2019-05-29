using Money.Exchange.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Exchange.Services.Interfaces
{
    public interface RateInterface
    {
        List<RatesModel> GetRates();
    }
}
