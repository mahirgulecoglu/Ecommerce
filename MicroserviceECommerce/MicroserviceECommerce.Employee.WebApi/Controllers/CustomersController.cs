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
    public class CustomersController : ApiController
    {
        DataContext db = new DataContext();

        public List<CustomersModel> GetCustomers()
        {
            return db.Customers.Select(x => new CustomersModel
            {
                CustomerID = x.CustomerID,
                CompanyName = x.CompanyName,
                ContactName = x.ContactName,
                ContactTitle = x.ContactTitle,
                Address = x.Address,
                City = x.City,
                Region = x.Region,
                PostalCode = x.PostalCode,
                Country = x.Country,
                Phone = x.Phone,
                Fax = x.Fax
            }).ToList();
        }
        
        public void PutCustomer(Customers customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
        }
        public void DeleteCustomer(string id)
        {
            var customer = db.Customers.FirstOrDefault(x => x.CustomerID == id);
            var orders = db.Orders.Where(x => x.CustomerID == id).ToList();
            foreach (var item in orders)
            {
                var order = db.Order_Details.Where(x => x.OrderID == item.OrderID).ToList();
                db.Order_Details.RemoveRange(order);
            }
            db.Orders.RemoveRange(orders);
            db.Customers.Remove(customer);
            db.SaveChanges();
        }
        
    }
}
