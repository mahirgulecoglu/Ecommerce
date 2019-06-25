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
    public class SuppliersController : ApiController
    {
        DataContext db = new DataContext();

        public List<SuppliersModel> GetSuppliers()
        {
            return db.Suppliers.Select(x => new SuppliersModel
            {
                SupplierID = x.SupplierID,
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
                HomePage = x.HomePage
            }).ToList();
        }
        public SuppliersModel GetSupplierDetail(int id)
        {
            return db.Suppliers.Where(x => x.SupplierID == id).Select(x => new SuppliersModel
            {
                SupplierID = x.SupplierID,
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
                HomePage = x.HomePage
            }).FirstOrDefault();
        }

    }
}
