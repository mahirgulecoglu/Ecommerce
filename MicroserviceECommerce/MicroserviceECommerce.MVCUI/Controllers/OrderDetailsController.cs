using MicroserviceECommerce.MVCUI.HTTPHelperMethpds;
using MicroserviceECommerce.MVCUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MicroserviceECommerce.MVCUI.Controllers
{
    public class OrderDetailsController : Controller
    {
        // GET: OrderDetails
        public ActionResult GetOrderDetails(int id)
        {
            var orderdetail = HTTPHelpers.GetMethod<List<OrderDetailsModel>>("http://localhost:37776/", "OrderDetails/GetOrderDetails", RestSharp.Method.GET, id);
            return View(orderdetail);
        }
    }
}