using MicroserviceECommerce.Customer.WebApi.Models;
using MicroserviceECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MicroserviceECommerce.Customer.WebApi.Controllers
{
    public class OrdersController : ApiController
    {
        DataContext db = new DataContext();


        public List<OrdersModel> GetCustomerOrders(string id)
        {
            return db.Orders.Where(x => x.CustomerID == id).Select(x => new OrdersModel
            {
                OrderID = x.OrderID,
                CustomerID = x.CustomerID,
                EmployeeID = x.EmployeeID,
                OrderDate = x.OrderDate,
                RequiredDate = x.RequiredDate,
                ShippedDate = x.ShippedDate,
                ShipVia = x.ShipVia,
                Freight = x.Freight,
                ShipName = x.ShipName,
                ShipAddress = x.ShipAddress,
                ShipCity = x.ShipCity,
                ShipRegion = x.ShipRegion,
                ShipPostalCode = x.ShipPostalCode,
                ShipCountry = x.ShipCountry,
                Status = x.Status
            }).ToList();
        }
        public OrdersModel GetOrder(int id)
        {
            return db.Orders.Where(x => x.OrderID == id).Select(x => new OrdersModel
            {
                OrderID = x.OrderID,
                CustomerID = x.CustomerID,
                EmployeeID = x.EmployeeID,
                OrderDate = x.OrderDate,
                RequiredDate = x.RequiredDate,
                ShippedDate = x.ShippedDate,
                ShipVia = x.ShipVia,
                Freight = x.Freight,
                ShipName = x.ShipName,
                ShipAddress = x.ShipAddress,
                ShipCity = x.ShipCity,
                ShipRegion = x.ShipRegion,
                ShipPostalCode = x.ShipPostalCode,
                ShipCountry = x.ShipCountry,
                Status = x.Status
            }).FirstOrDefault();
        }

        public int AddOrder(Orders order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.OrderID;
        }
        public void PutOrder(List<ItemonCartModel> cart, string id)
        {
            OrderDetailsController odc = new OrderDetailsController();
            var Total = cart.Sum(x => x.Product.UnitPrice * x.Quantity);
            Orders order = new Orders
            {
                CustomerID = cart[0].CustomerID,
                EmployeeID = 1,
                OrderDate = DateTime.Now,
                RequiredDate = DateTime.Now,
                ShippedDate = DateTime.Now,
                ShipVia = 1,
                Freight = Total,
                ShipName = "Toms Spezialitäten",
                ShipAddress = "Luisenstr. 48",
                ShipCity = null,
                ShipRegion = null,
                ShipPostalCode = null,
                ShipCountry = "Germany",
                Status = null
            };
            int oid = AddOrder(order);

            foreach (var item in cart)
            {
                Order_Details od = new Order_Details
                {
                    OrderID = oid,
                    ProductID = item.Product.ProductID,
                    UnitPrice = (decimal)item.Product.UnitPrice,
                    Quantity = (short)item.Quantity,
                    Discount = 0
                };
                odc.PutOrderDetails(od);
                var product = db.Products.FirstOrDefault(x => x.ProductID == item.Product.ProductID);
                product.UnitsInStock = (short)(product.UnitsInStock - item.Quantity);
                db.SaveChanges();

            }

        }
    }
}
