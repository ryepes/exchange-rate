using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Money.Exchange.Services.Implementation;

namespace Money.Exchange.Web.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        [HttpGet("[action]")]
        public bool LoginUser(string user, string password)
        {
            LoginImplement loginImplement = new LoginImplement();
            var result = loginImplement.LoginUser(user, password);

            return result;
        }
    }
}