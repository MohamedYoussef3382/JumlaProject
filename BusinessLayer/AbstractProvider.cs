using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using System.Configuration;
using System.Security.Cryptography;

namespace BusinessLayer
{
    public abstract class AbstractProvider
    {
        protected JDBDataContext _JDB = null;

        protected static string _conString;

        public string ConString
        {
            get
            {
                if (string.IsNullOrEmpty(_conString))
                {
                  //  string encryptedConnectionString = ConfigurationManager.ConnectionStrings["JConnectionString"].ToString();
                    _conString = ConfigurationManager.ConnectionStrings["JConnectionString"].ToString();
                }

                return _conString;
            }

        }

        protected JDBDataContext JDB
        {
            get
            {
                if (_JDB == null)
                {
                    try
                    {
                        _JDB = new JDBDataContext(ConString);
                        _JDB.CommandTimeout = 3000;
                    }
                    catch (Exception e)
                    {
                    }
                }
                return _JDB;
            }
        }

    }
}
