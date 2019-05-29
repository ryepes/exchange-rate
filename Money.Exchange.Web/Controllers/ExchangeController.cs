using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Money.Exchange.Model;
using Money.Exchange.Services.Implementation;
using Money.Exchange.Services.Interfaces;

namespace Money.Exchange.Web.Controllers
{
    [Route("api/[controller]")]
    public class ExchangeController : Controller
    {
        #region [ Variables ]

        
        #endregion

        #region [ Constructor ]

        public ExchangeController()
        {
            
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public List<RatesModel> GetExchangeRates()
        {
            RateImplement rateImplement = new RateImplement();
            var ratesModel = rateImplement.GetRates();

            return ratesModel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idRate"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public RatesModel GetExchangeRatesById(int idRate)
        {
            RateImplement rateImplement = new RateImplement();
            var model = rateImplement.GetRatesById(idRate);

            return model;
        }

        #endregion
    }
}