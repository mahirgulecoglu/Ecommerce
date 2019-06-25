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
    public class CustomersController : ApiController
    {
        DataContext db = new DataContext();
        public CustomersModel GetCustomerDetail(string id)
        {
            return db.Customers.Where(x => x.CustomerID == id).Select(x => new CustomersModel
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
            }).FirstOrDefault();
        }
        public void PostCustomer(Customers customer)
        {
            var cust = db.Customers.FirstOrDefault(x => x.CustomerID == customer.CustomerID);
            cust.CustomerID = customer.CustomerID;
            cust.CompanyName = customer.CompanyName;
            cust.ContactName = customer.ContactName;
            cust.ContactTitle = customer.ContactTitle;
            cust.Address = customer.Address;
            cust.City = customer.City;
            cust.Region = customer.Region;
            cust.PostalCode = customer.PostalCode;
            cust.Country = customer.Country;
            cust.Phone = customer.Phone;
            cust.Fax = customer.Fax;
            cust.Password = customer.Password;
            db.SaveChanges();
        }
        
    }
}
