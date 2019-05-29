using Money.Exchange.Data.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Exchange.Services.Implementation
{
    public class LoginImplement
    {
        #region [ Variables ]

        private UserDatabase userDatabase = new UserDatabase();

        #endregion

        #region [ Methods

        
        public bool LoginUser(string user, string password)
        {
            return userDatabase.LoginUser(user, password);
        }

        #endregion
    }
}
