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
    public class ShopCartController : Controller
    {
        // GET: ShopCart
        [LoginFilter]
        public ActionResult CartView()
        {
            return View();
        }
        [LoginFilter]
        [HttpGet]
        public ActionResult AddShopCart(int id)
        {
            ProductsModel product = new ProductsModel();
            if (Session["Cart"] == null)
            {
                var cust = (CustomersModel)Session["Login"];
                List<ItemonCartModel> cart = new List<ItemonCartModel>();
                cart.Add(new ItemonCartModel { Product = HTTPHelpers.GetMethod<ProductsModel>("http://localhost:37796/", "Products/GetProductDetail", RestSharp.Method.GET, id), Quantity = 1, CustomerID = cust.CustomerID });
                Session["Cart"] = cart;
            }
            else
            {
                List<ItemonCartModel> cart = (List<ItemonCartModel>)Session["Cart"];
                int index = cart.FindIndex(a => a.Product.ProductID == id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new ItemonCartModel { Product = HTTPHelpers.GetMethod<ProductsModel>("http://localhost:37796/", "Products/GetProductDetail", RestSharp.Method.GET, id), Quantity = 1 });
                }
                Session["Cart"] = cart;
            }
            return RedirectToRoute(new { controller = "Products", action = "GetProducts" });
        }
        [LoginFilter]
        public ActionResult DeleteShopCart(int id)
        {
            List<ItemonCartModel> cart = (List<ItemonCartModel>)Session["Cart"];
            int index = cart.FindIndex(a => a.Product.ProductID == id);
            cart.RemoveAt(index);
            Session["Cart"] = cart;
            return RedirectToAction("CartView");
        }

        public ActionResult UpdateShopCart(FormCollection form)
        {
            List<ItemonCartModel> cart = (List<ItemonCartModel>)Session["Cart"];
            int index = cart.FindIndex(a => a.Product.ProductID == Convert.ToInt32(form["id"]));
            cart[index].Quantity= Convert.ToInt32(form["quantity"]);
            Session["Cart"] = cart;
            return RedirectToAction("CartView");
        }
    }
}