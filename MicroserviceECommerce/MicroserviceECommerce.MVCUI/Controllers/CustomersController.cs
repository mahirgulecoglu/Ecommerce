using MicroserviceECommerce.MVCUI.Filters;
using MicroserviceECommerce.MVCUI.HTTPHelperMethpds;
using MicroserviceECommerce.MVCUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MicroserviceECommerce.MVCUI.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        [EmployeeFilter]
        [OutputCache(Duration = 60)]
        public ActionResult GetCustomers()
        {
            var customers = HTTPHelpers.GetListMethod<List<CustomersModel>>("http://localhost:37786/", "Customers/GetCustomers", RestSharp.Method.GET);
            return View(customers);
        }
        [EmployeeFilter]
        public ActionResult PutCustomer(CustomersModel customer)
        {
            HTTPHelpers.PostMethod("http://localhost:37786/", "Customers/PutCustomer", RestSharp.Method.PUT, customer);
            return RedirectToAction("GetCustomers");
        }
        [LoginFilter]
        public ActionResult GetCustomer(string id)
        {
            var customer = HTTPHelpers.GetMethod<CustomersModel>("http://localhost:37776/", "Customers/GetCustomerDetail", RestSharp.Method.GET, id);
            return View(customer);
        }
        [EmployeeFilter]
        public ActionResult PostCustomer(CustomersModel customer)
        {
            HTTPHelpers.PostMethod("http://localhost:37776/", "Customers/PostCustomer", RestSharp.Method.POST, customer);
            return RedirectToRoute(new { controller = "Customers", action = "GetCustomer", id = customer.CustomerID });
        }
        [EmployeeFilter]
        public ActionResult DeleteCustomer(string id)
        {
            HTTPHelpers.DeleteMethod("http://localhost:37786/", "Customers/DeleteCustomer", RestSharp.Method.DELETE, id);
            return RedirectToAction("GetCustomers");
        }
        [EmployeeFilter]
        public ActionResult CustomerAdd()
        {
            return View(new CustomersModel());
        }
        [EmployeeFilter]
        public ActionResult UpdateCustomer(string id)
        {
            var customer = HTTPHelpers.GetMethod<CustomersModel>("http://localhost:37776/", "Customers/GetCustomerDetail", RestSharp.Method.GET, id);
            return View(customer);
        }
        
    }
}