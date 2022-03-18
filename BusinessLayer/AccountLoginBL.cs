using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.ViewModels;
using DataLayer;
using Microsoft.IdentityModel.Tokens;

namespace BusinessLayer
{
    public class AccountLoginBL : AbstractProvider
    {
        private const string Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";

        public static string GenerateToken(AccountLogin accountVM)//, int expireMinutes = 20
        {
            var symmetricKey = Convert.FromBase64String(Secret);
            var tokenHandler = new JwtSecurityTokenHandler();

            //  var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim("_id", accountVM.AccountLoginId.ToString()),
            new Claim("name", accountVM.Name),
            new Claim("email", accountVM.Email),
            new Claim("address", accountVM.Address),
            new Claim("privilageId", accountVM.IsAdmin.ToString())
              }),

                //Expires = now.AddMinutes(Convert.ToInt32(expireMinutes)),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(symmetricKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
        }

        public AccountLogin Signin(AccountLoginVM vm, ref string ErrorMessage)
        {
            //var data = db.AccountLogin.Where(a => a.IsDeleted == false).SingleOrDefault(a => a.LoginName == vm.LoginName && a.Password == vm.Password);
            var data = JDB.AccountLogins.Where(a => a.IsDeleted == false).SingleOrDefault(a => a.Email == vm.Email && a.Password == vm.Password);
            return data;
        }


        public void ValidateAccountLogin(AccountLoginVM accountLogin, ref string ErrorMessage)
        {
            var User = JDB.AccountLogins.Where(a => a.IsDeleted == false).FirstOrDefault(a => a.Email == accountLogin.Email);

            if (User == null)
            {
                ErrorMessage = "Invalid email.";
                return;
            }

            var ValidPassword = JDB.AccountLogins.Where(a => a.IsDeleted == false).FirstOrDefault(a => a.Password == accountLogin.Password);

            if (ValidPassword == null)
            {
                ErrorMessage = "Invalid password.";
                return;
            }

        }

        //public AccountLogin Signin(AccountLoginVM vm, ref string ErrorMessage)
        //{
        //    //var data = db.AccountLogin.Where(a => a.IsDeleted == false).SingleOrDefault(a => a.LoginName == vm.LoginName && a.Password == vm.Password);
        //    var data = JDB.AccountLogins.Where(a => a.IsDeleted == false).SingleOrDefault(a => a.Email == vm.Email && a.Password == vm.Password);
        //    return data;
        //}

        //public void ValidateAccountLogin(AccountLoginVM accountLogin, ref string ErrorMessage)
        //{
        //    var User = JDB.AccountLogins.Where(a => a.IsDeleted == false).FirstOrDefault(a => a.Email == accountLogin.Email);

        //    if (User == null)
        //    {
        //        ErrorMessage = "Invalid email.";
        //        return;
        //    }

        //    var ValidPassword = JDB.AccountLogins.Where(a => a.IsDeleted == false).FirstOrDefault(a => a.Password == accountLogin.Password);

        //    if (ValidPassword == null)
        //    {
        //        ErrorMessage = "Invalid password.";
        //        return;
        //    }

        //}
        //public void Signin(AccountLoginVM vm, ref string ErrorMessage)
        //{
        //    var User = JDB.AccountLogins.Where(a => a.IsDeleted == false).FirstOrDefault(a => a.Email == vm.Email);

        //    if (User == null)
        //    {
        //        ErrorMessage = "Invalid email.";
        //        return;
        //    }

        //    var ValidPassword = JDB.AccountLogins.Where(a => a.IsDeleted == false).FirstOrDefault(a => a.Password == vm.Password);

        //    if (ValidPassword == null)
        //    {
        //        ErrorMessage = "Invalid password.";
        //        return;
        //    }

        //    //var data = db.AccountLogin.Where(a => a.IsDeleted == false).SingleOrDefault(a => a.LoginName == vm.LoginName && a.Password == vm.Password);
        //    var data = JDB.AccountLogins.Where(a => a.IsDeleted == false).SingleOrDefault(a => a.Email == vm.Email && a.Password == vm.Password);

        //}
    }
}
