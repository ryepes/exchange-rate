using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Exchange.Data.User
{
    public class UserDatabase
    {
        #region [ Variables ]

        private string exchangeRatesConection = string.Empty;

        #endregion

        #region [ Constructor ]

        public UserDatabase()
        {
            ConectionDatabase conectionDatabase = new ConectionDatabase();
            exchangeRatesConection = conectionDatabase.GetConection();
        }

        #endregion

        #region [ Methods ]

        public bool LoginUser(string user, string password)
        {
            bool result = false;

            try
            {
                using (SqlConnection con = new SqlConnection(exchangeRatesConection))
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.ValidateUser", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@User", user));
                        cmd.Parameters.Add(new SqlParameter("@Password", password));

                        con.Open();
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                result = true;
                            }
                        }

                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {

                result = false;
            }

            return result;
        }

        #endregion
    }
}
