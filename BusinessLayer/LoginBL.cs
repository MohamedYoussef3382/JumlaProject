using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace BusinessLayer
{
    public class LoginBL : AbstractProvider
    {
        public List<AccountLogin> GetAllLogin()
        {
            var data = JDB.AccountLogins.ToList();
            return data;
        }

    }
}
