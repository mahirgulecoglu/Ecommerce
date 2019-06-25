using MicroserviceECommerce.ECommerce.WebApi.Models;
using MicroserviceECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MicroserviceECommerce.ECommerce.WebApi.Controllers
{
    public class LoginController : ApiController
    {
        DataContext db = new DataContext();
        public CustomersModel CustomersLogin(CustomersModel customer)
        {
            return db.Customers.Where(x => x.CustomerID == customer.CustomerID && x.Password == customer.Password).Select(x => new CustomersModel
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
                Fax = x.Fax,
                Password = x.Password
            }).FirstOrDefault();
        }
        public EmployeeModel EmployeeLogin(EmployeeModel employee)
        {
            return db.Employees.Where(x => x.FirstName == employee.FirstName && x.Password == employee.Password).Select(x => new EmployeeModel
            {
                EmployeeID = x.EmployeeID,
                LastName = x.LastName,
                FirstName = x.FirstName,
                Title = x.Title,
                TitleOfCourtesy = x.TitleOfCourtesy,
                BirthDate = x.BirthDate,
                HireDate = x.HireDate,
                Address = x.Address,
                City = x.City,
                Region = x.Region,
                PostalCode = x.PostalCode,
                Country = x.Country,
                HomePhone = x.HomePhone,
                Extension = x.Extension,
                Notes = x.Notes,
                ReportsTo = x.ReportsTo,
                Password = x.Password
            }).FirstOrDefault();
        }
    }
}
