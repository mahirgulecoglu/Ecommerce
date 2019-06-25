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
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult GetProducts()
        {
            var products = HTTPHelpers.GetListMethod<List<ProductsModel>>("http://localhost:37796/", "Products/GetProducts", RestSharp.Method.GET);
            return View(products);
        }
        public ActionResult GetProductsByCategory(int id)
        {
            var products = HTTPHelpers.GetMethod<List<ProductsModel>>("http://localhost:37796/", "Products/GetProductsByCategoryID", RestSharp.Method.GET, id);
            return View(products);
        }
        [EmployeeFilter]
        public ActionResult PutProduct(ProductsModel product)
        {
            HTTPHelpers.PostMethod("http://localhost:37786/", "Products/PutProduct", RestSharp.Method.PUT, product);
            return RedirectToAction("GetProducts");
        }
        public ActionResult GetProduct(int id)
        {
            var product = HTTPHelpers.GetMethod<ProductsModel>("http://localhost:37796/", "Products/GetProductDetail", RestSharp.Method.GET, id);
            return View(product);
        }
        [EmployeeFilter]
        public ActionResult PostProduct(ProductsModel product)
        {
            HTTPHelpers.PostMethod("http://localhost:37786/", "Products/PostProduct", RestSharp.Method.POST, product);
            return RedirectToRoute(new { controller = "Products", action = "GetProduct", id = product.ProductID });
        }
        [EmployeeFilter]
        public ActionResult DeleteProduct(int id)
        {
            HTTPHelpers.DeleteMethod("http://localhost:37786/", "Products/DeleteProduct", RestSharp.Method.DELETE, id);
            return RedirectToAction("GetProducts");
        }
        [EmployeeFilter]
        public ActionResult ProductsAdd()
        {
            return View(new ProductsModel());
        }
        [EmployeeFilter]
        public ActionResult UpdateProduct(int id)
        {
            var product = HTTPHelpers.GetMethod<ProductsModel>("http://localhost:37796/", "Products/GetProductDetail", RestSharp.Method.GET, id);
            return View(product);
        }
    }
}