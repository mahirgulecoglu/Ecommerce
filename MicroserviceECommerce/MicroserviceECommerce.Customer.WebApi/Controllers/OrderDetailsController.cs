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
    public class OrderDetailsController : ApiController
    {
        DataContext db = new DataContext();

        public List<OrderDetailsModel> GetOrderDetails(int id)
        {
            return db.Order_Details.Where(x => x.OrderID == id).Select(x => new OrderDetailsModel
            {
                OrderID = x.OrderID,
                ProductID = x.ProductID,
                UnitPrice = x.UnitPrice,
                Quantity = x.Quantity,
                Discount = x.Discount
            }).ToList();
        }
        public void PutOrderDetails(Order_Details od)
        {
            db.Order_Details.Add(od);
            db.SaveChanges();
        }
    }
}
