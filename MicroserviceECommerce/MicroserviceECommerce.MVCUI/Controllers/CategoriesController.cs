using MicroserviceECommerce.MVCUI.HTTPHelperMethpds;
using MicroserviceECommerce.MVCUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MicroserviceECommerce.MVCUI.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        [OutputCache(Duration = 120)]
        public ActionResult GetCategories()
        {
            var categories = HTTPHelpers.GetListMethod<List<CategoriesModel>>("http://localhost:37796/", "Categories/GetCategories", RestSharp.Method.GET);
            return View(categories);
        }
    }
}