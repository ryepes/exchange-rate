using Money.Exchange.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Money.Exchange.Data.Rates
{
    public class RatesDataBase
    {
        #region [ Variables ]

        private string exchangeRatesConection = string.Empty;

        #endregion

        #region [ Constructor ]

        public RatesDataBase()
        {
            ConectionDatabase conectionDatabase = new ConectionDatabase();
            exchangeRatesConection = conectionDatabase.GetConection();
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<RatesModel> GetRates()
        {
            var rates = new List<RatesModel>();

            try
            {
                using (SqlConnection con = new SqlConnection(exchangeRatesConection))
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.GetRates", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        
                        con.Open();
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                int id = Convert.ToInt32(rdr["rId"]);
                                string name = rdr["rName"].ToString();
                                decimal rate = Convert.ToDecimal(rdr["rRate"]);
                                string description = rdr["rDescription"].ToString();
                                DateTime date = Convert.ToDateTime(rdr["rDate"]);

                                rates.Add(new RatesModel
                                {
                                    Id = id,
                                    Name = name,
                                    Rate = rate,
                                    Description = description,
                                    Date = date
                                });
                            }
                        }

                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return rates;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idRate"></param>
        /// <returns></returns>
        public RatesModel GetRatesById(int idRate)
        {
            var rate = new RatesModel();

            try
            {
                using (SqlConnection con = new SqlConnection(exchangeRatesConection))
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.GetRatesById", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@rId", idRate));

                        con.Open();
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                int id = Convert.ToInt32(rdr["rId"]);
                                string name = rdr["rName"].ToString();
                                decimal rateVal = Convert.ToDecimal(rdr["rRate"]);
                                string description = rdr["rDescription"].ToString();
                                DateTime date = Convert.ToDateTime(rdr["rDate"]);

                                rate.Id = id;
                                rate.Name = name;
                                rate.Rate = rateVal;
                                rate.Description = description;
                                rate.Date = date;
                            }
                        }

                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return rate;
        }

        #endregion
    }
}
