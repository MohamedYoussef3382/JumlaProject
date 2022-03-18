using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLayer;
namespace JumlaAPI.Controllers
{
    public class LoginController : ApiController
    {
        [Route("api/Login/GetAllLogin")]
        [HttpGet]
        public IHttpActionResult GetAllLogin()
        {
            try
            {
                var LoginData = new LoginBL().GetAllLogin();
              
                return Json(new { success = true, LoginList = LoginData});
            }
            catch (Exception ex)
            {
             //   Utilities.LogEvent(ex, Helper.GetCurrentUser().UserName);
                return Json(new { success = false, errorMessage = ex.Message });
            }
        }

        }
    }
