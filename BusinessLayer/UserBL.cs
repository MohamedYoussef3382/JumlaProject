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
    public class UserBL : AbstractProvider
    {
        private const string Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";

        public static string GenerateToken(User_SigninResult userVM)//, int expireMinutes = 20
        {
            var symmetricKey = Convert.FromBase64String(Secret);
            var tokenHandler = new JwtSecurityTokenHandler();

            var accountType = userVM.AccountType == null ? "null" : userVM.AccountType;
            //  var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim("_id", userVM.UserId.ToString()),
            new Claim("name", userVM.Name),
            new Claim("email", userVM.Email),
            new Claim("address", userVM.Address),
            new Claim("accountType", accountType),
            new Claim("privilage", userVM.Privilage)
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

        public User_SigninResult Signin(SigninVM vm, ref string ErrorMessage)
        {
            //var data = db.AccountLogin.Where(a => a.IsDeleted == false).SingleOrDefault(a => a.LoginName == vm.LoginName && a.Password == vm.Password);
            var data = JDB.User_Signin(vm.Email, vm.Password).FirstOrDefault();
            //var data = JDB.Users.Where(a => a.IsDeleted == false).SingleOrDefault(a => a.Email == vm.Email && a.Password == vm.Password);
            return data;
        }


        public void ValidateSignin(SigninVM vm, ref string ErrorMessage)
        {
            var User = JDB.Users.Where(a => a.IsDeleted == false).FirstOrDefault(a => a.Email == vm.Email);

            if (User == null)
            {
                ErrorMessage = "Invalid email.";
                return;
            }

            var ValidPassword = JDB.Users.Where(a => a.IsDeleted == false).FirstOrDefault(a => a.Password == vm.Password);

            if (ValidPassword == null)
            {
                ErrorMessage = "Invalid password.";
                return;
            }

        }

        public List<User> GetAllLogin()
        {
            var data = JDB.Users.ToList();
            return data;
        }

        public void SignUp(UserVM userVM)
        {
                var NewUser = new User();

                NewUser.UserId = Guid.NewGuid();
                NewUser.PrivilageId = userVM.PrivilageId;
                NewUser.AccountTypeId = userVM.AccountTypeId;
                NewUser.Name = userVM.Name;
                NewUser.Email = userVM.Email;
                NewUser.Password = userVM.Password;
                NewUser.Address = userVM.Address;
                NewUser.IsDeleted = false;
                NewUser.CreatedBy = NewUser.UserId;
                NewUser.CreatedDate = DateTime.Now;

                JDB.Users.InsertOnSubmit(NewUser);
                JDB.SubmitChanges();
        }

        public void DataValidatiOnSignup(UserVM userVM, ref string ErrorMessage)
        {
            var UserObj = JDB.Users.FirstOrDefault(x => x.Email.ToLower() == userVM.Email.ToLower() && x.IsDeleted == false);
            if (UserObj != null)
            {
                ErrorMessage = "This email has been added before.";
                return;
            }

            if (string.IsNullOrEmpty(userVM.Name) || string.IsNullOrEmpty(userVM.Email) || string.IsNullOrEmpty(userVM.Password) || userVM.AccountTypeId == null ||
                string.IsNullOrEmpty(userVM.Address))//|| userVM.PrivilageId == null
            {
                ErrorMessage = "Please Fill All Data.";
                return;
            }
        }

        public List<Privilage> GetAllPrivilages()
        {
            var list = JDB.Privilages.ToList();
            return list;
        }

        public List<AccountType> GetAllAccountTypes()
        {
            var list = JDB.AccountTypes.ToList();
            return list;
        }

    }
}
