using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLayer;
using BusinessLayer.ViewModels;

namespace JumlaAPI.Controllers
{
    public class UserController : ApiController
    {

        [HttpPost]
        [Route("api/User/Signin")]
        public IHttpActionResult Signin(SigninVM vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    foreach (var item in ModelState.Values)
                    {
                        var ModelStateError = item.Errors[0].ErrorMessage;
                        return Ok(new { success = true, errorMessage = ModelStateError });
                    }
                    //return Ok(new { success = true, successMessage = "Success" });
                }
                var UserBL = new UserBL();
                string ErrorMessage = string.Empty;
                //    var Session = HttpContext.Current.Session;
                UserBL.ValidateSignin(vm, ref ErrorMessage);

                if (!string.IsNullOrEmpty(ErrorMessage))
                    return Json(new { success = false, errorMessage = ErrorMessage });

                var data = UserBL.Signin(vm, ref ErrorMessage);
              
                if (data != null)
                {
                    var token = UserBL.GenerateToken(data);
                    return Ok(new { success = true, successMessage = "Success", token = token });
                    //  Session["uname"] = vm.LoginName;
                    //return Ok(new DepartmentApiController().GetAllDepartment(1, 1000));
                }
                else
                    return Ok(new { success = true, errorMessage = "Please check your email and password" });
            }
            catch (Exception ex)
            {
                return Ok(new { success = false, ex.Message });
            }
        }

        [Route("api/User/GetAllLogin")]
        [HttpGet]
        public IHttpActionResult GetAllLogin()
        {
            try
            {
                var LoginData = new UserBL().GetAllLogin();
              
                return Json(new { success = true, LoginList = LoginData});
            }
            catch (Exception ex)
            {
             //   Utilities.LogEvent(ex, Helper.GetCurrentUser().UserName);
                return Json(new { success = false, errorMessage = ex.Message });
            }
        }

        [Route("api/User/SignUp")]
        [HttpPost]
        public IHttpActionResult SignUp(UserVM userVM)
        {
            try
            {
                var UserBL = new UserBL();
                string ErrorMessage = string.Empty;
                //    var Session = HttpContext.Current.Session;
                UserBL.DataValidatiOnSignup(userVM, ref ErrorMessage);

                if (!string.IsNullOrEmpty(ErrorMessage))
                    return Json(new { success = false, errorMessage = ErrorMessage });

                 UserBL.SignUp(userVM);
                 return Json(new { success = true, successMessage = "The account is saved successfully." });

            }
            catch (Exception ex)
            {
                //   Utilities.LogEvent(ex, Helper.GetCurrentUser().UserName);
                return Json(new { success = false, errorMessage = ex.Message });
            }
        }

        [Route("api/User/GetAllLookUps")]
        [HttpGet]
        public IHttpActionResult GetAllLookUps()
        {
            try
            {
                    var userBL = new UserBL();
                    var AllPrivilages = userBL.GetAllPrivilages();
                    var AllAccountTypes = userBL.GetAllAccountTypes();

                    return Json(new
                    {
                        success = true,
                        PrivilageList = AllPrivilages,
                        AccountTypeList = AllAccountTypes,
                    });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message });
            }
        }

    }
    }
