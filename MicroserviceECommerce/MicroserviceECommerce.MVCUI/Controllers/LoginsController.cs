using MicroserviceECommerce.MVCUI.HTTPHelperMethpds;
using MicroserviceECommerce.MVCUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MicroserviceECommerce.MVCUI.Controllers
{
    public class LoginsController : Controller
    {
        // GET: Logins
        public ActionResult CustomersLogin(CustomersModel customer)
        {
            var cust = HTTPHelpers.LoginMethod<CustomersModel>("http://localhost:37796/", "Login/CustomersLogin", RestSharp.Method.POST, customer);
            if (cust != null)
            {
                Session["Login"] = cust;
                Session["UserType"] = "Customer";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("LoginHata");
            }
        }
        public ActionResult EmployeesLogin(EmployeeModel employee)
        {
            var emp = HTTPHelpers.LoginMethod<EmployeeModel>("http://localhost:37796/", "Login/EmployeeLogin", RestSharp.Method.POST, employee);
            if (emp != null)
            {
                Session["Login"] = emp;
                Session["UserType"] = "Employee";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("LoginHata");
            }
        }
        public ActionResult CustomerLogin()
        {
            return View();
        }
        public ActionResult EmployeeLogin()
        {
            return View();
        }
        public ActionResult LoginHata()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            Session.Remove("Login");
            Session.Remove("UserType");
            Session.Remove("Cart");
            return RedirectToAction("Index", "Home");
        }

    }
}