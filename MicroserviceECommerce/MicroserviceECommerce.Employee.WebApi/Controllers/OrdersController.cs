using MicroserviceECommerce.Employee.WebApi.Models;
using MicroserviceECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MicroserviceECommerce.Employee.WebApi.Controllers
{
    public class OrdersController : ApiController
    {
        DataContext db = new DataContext();

        public List<OrdersModel> GetOrders()
        {
            return db.Orders.Select(x => new OrdersModel
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
        public void DeleteOrder(int id)
        {
            var order = db.Orders.FirstOrDefault(x => x.OrderID == id);
            var od = db.Order_Details.Where(x => x.OrderID == id).ToList();
            db.Order_Details.RemoveRange(od);
            db.Orders.Remove(order);
            db.SaveChanges();
        }
        public void PostOrder(Orders order)
        {
            var ord = db.Orders.FirstOrDefault(x => x.OrderID == order.OrderID);
            ord.OrderID = order.OrderID;
            ord.CustomerID = order.CustomerID;
            ord.EmployeeID = order.EmployeeID;
            ord.OrderDate = order.OrderDate;
            ord.RequiredDate = order.RequiredDate;
            ord.ShippedDate = order.ShippedDate;
            ord.ShipVia = order.ShipVia;
            ord.Freight = order.Freight;
            ord.ShipName = order.ShipName;
            ord.ShipAddress = order.ShipAddress;
            ord.ShipCity = order.ShipCity;
            ord.ShipRegion = order.ShipRegion;
            ord.ShipPostalCode = order.ShipPostalCode;
            ord.ShipCountry = order.ShipCountry;
            ord.Status = order.Status;
            db.SaveChanges();
        }
    }
}
