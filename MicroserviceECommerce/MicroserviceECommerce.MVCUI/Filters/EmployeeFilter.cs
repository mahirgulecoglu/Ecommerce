using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace MicroserviceECommerce.MVCUI.Filters
{
    public class EmployeeFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if ((string)filterContext.HttpContext.Session["UserType"] != "Employee")
            {
                filterContext.Result = new RedirectResult("~/Logins/LoginHata");
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
        }
    }
}