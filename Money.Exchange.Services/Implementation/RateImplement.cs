using Money.Exchange.Data.Rates;
using Money.Exchange.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Exchange.Services.Implementation
{
    public class RateImplement
    {
        #region [ Variables ]

        private RatesDataBase ratesDataBase = new RatesDataBase();

        #endregion

        #region [ Methods ]
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<RatesModel> GetRates()
        {
            return ratesDataBase.GetRates();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public RatesModel GetRatesById(int idRate)
        {
            return ratesDataBase.GetRatesById(idRate);
        }

        #endregion
    }
}
