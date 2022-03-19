using BusinessLayer;
using BusinessLayer.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JumlaAPI.Controllers
{
    public class AccountLoginController : ApiController
    {
        //[HttpPost]
        //[Route("api/AccountLogin/Signin")]
        //public IHttpActionResult Signin(UserVM vm)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            foreach (var item in ModelState.Values)
        //            {
        //                var ModelStateError = item.Errors[0].ErrorMessage;
        //                return Ok(new { success = true, errorMessage = ModelStateError });
        //            }
        //            //return Ok(new { success = true, successMessage = "Success" });
        //        }
        //        var AccountLoginBL = new AccountLoginBL();
        //        string ErrorMessage = string.Empty;
        //        //    var Session = HttpContext.Current.Session;
        //        AccountLoginBL.ValidateAccountLogin(vm, ref ErrorMessage);

        //        if (!string.IsNullOrEmpty(ErrorMessage))
        //            return Json(new { success = false, errorMessage = ErrorMessage });

        //        var data = AccountLoginBL.Signin(vm, ref ErrorMessage);
        //        //var AccountUser = new AccountVM() { };

        //        //     AccountUser = JsonConvert.DeserializeObject<AccountVM>(data);
        //        //var accountLogin =  JsonConvert.DeserializeObject<AccountVM>(data);
        //        if (data != null)
        //        {
        //            var tokan =  AccountLoginBL.GenerateToken(data);
        //           // return JwtManager.GenerateToken(username);
        //            return Ok(new { success = true, successMessage = "Success", tokan = tokan });
        //            //  Session["uname"] = vm.LoginName;
        //            //return Ok(new DepartmentApiController().GetAllDepartment(1, 1000));
        //        }
        //        else
        //            return Ok(new { success = true, errorMessage = "Please check your user name and password" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new { success = false, ex.Message });
        //    }
        //}

        //[HttpPost]
        //[Route("api/AccountLogin/Signin")]
        //public IHttpActionResult Signin(AccountLoginVM vm)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            foreach (var item in ModelState.Values)
        //            {
        //                var ModelStateError = item.Errors[0].ErrorMessage;
        //                return Ok(new { success = true, errorMessage = ModelStateError });
        //            }
        //            //return Ok(new { success = true, erroeMessage = fdf });
        //            //return Ok(new { success = true, successMessage = "Success" });
        //        }
        //        var AccountLoginBL = new AccountLoginBL();
        //        string ErrorMessage = string.Empty;
        //        //    var Session = HttpContext.Current.Session;
        //         AccountLoginBL.ValidateAccountLogin(vm, ref ErrorMessage);

        //        if (!string.IsNullOrEmpty(ErrorMessage))
        //            return Json(new { success = false, errorMessage = ErrorMessage });

        //        var data = AccountLoginBL.Signin(vm, ref ErrorMessage);

        //        if (data != null)
        //        {
        //            return Ok(new { success = true, successMessage = "Success" });
        //            //  Session["uname"] = vm.LoginName;
        //            //return Ok(new DepartmentApiController().GetAllDepartment(1, 1000));
        //        }
        //        else
        //            return Ok(new { success = true, errorMessage = "Please check your user name and password" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new { success = false, ex.Message });
        //    }
        //}


        //[HttpPost]
        //[Route("api/AccountLogin/Signin")]
        //public IHttpActionResult Signin(AccountLoginVM vm)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            foreach (var item in ModelState.Values)
        //            {
        //                var ModelStateError =  item.Errors[0].ErrorMessage;
        //                return Ok(new { success = true, errorMessage = ModelStateError });
        //            }
        //            //return Ok(new { success = true, erroeMessage = fdf });
        //            //return Ok(new { success = true, successMessage = "Success" });
        //        }
        //        string ErrorMessage = string.Empty;
        //        //    var Session = HttpContext.Current.Session;
        //        var data = new AccountLoginBL().Signin(vm, ref ErrorMessage);

        //        if (!string.IsNullOrEmpty(ErrorMessage))
        //            return Json(new { success = false, errorMessage = ErrorMessage });
        //        if (data)
        //        {
        //            return Ok(new { success = true, successMessage = "Success" });
        //            //  Session["uname"] = vm.LoginName;
        //            //return Ok(new DepartmentApiController().GetAllDepartment(1, 1000));
        //        }
        //        else
        //            return Ok(new { success = true, errorMessage = "Please check your user name and password" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new { success = false, ex.Message });
        //    }
        //}

    }
}
