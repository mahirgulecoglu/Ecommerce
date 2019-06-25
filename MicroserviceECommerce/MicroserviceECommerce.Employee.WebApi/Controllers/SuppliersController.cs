using MicroserviceECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MicroserviceECommerce.Employee.WebApi.Controllers
{
    public class SuppliersController : ApiController
    {
        DataContext db = new DataContext();

        public void PutSupplier(Suppliers supplier)
        {
            db.Suppliers.Add(supplier);
            db.SaveChanges();
        }
        public void DeleteSupplier(int id)
        {
            var supplier = db.Suppliers.FirstOrDefault(x => x.SupplierID == id);
            db.Suppliers.Remove(supplier);
            db.SaveChanges();
        }
        public void PostSupplier(Suppliers supplier)
        {
            var supp = db.Suppliers.FirstOrDefault(x => x.SupplierID == supplier.SupplierID);
            supp.SupplierID = supplier.SupplierID;
            supp.CompanyName = supplier.CompanyName;
            supp.ContactName = supplier.ContactName;
            supp.ContactTitle = supplier.ContactTitle;
            supp.Address = supplier.Address;
            supp.City = supplier.City;
            supp.Region = supplier.Region;
            supp.PostalCode = supplier.PostalCode;
            supp.Country = supplier.Country;
            supp.Phone = supplier.Phone;
            supp.Fax = supplier.Fax;
            supp.HomePage = supplier.HomePage;
            db.SaveChanges();
        }
    }
}
