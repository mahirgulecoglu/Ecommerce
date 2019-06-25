using MicroserviceECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MicroserviceECommerce.Employee.WebApi.Controllers
{
    public class ShippersController : ApiController
    {
        DataContext db = new DataContext();

        public void PutShipper(Shippers shipper)
        {
            db.Shippers.Add(shipper);
            db.SaveChanges();
        }
        public void DeleteShipper(int id)
        {
            var shipper = db.Shippers.FirstOrDefault(x => x.ShipperID == id);
            db.Shippers.Remove(shipper);
            db.SaveChanges();
        }
        public void PostShipper(Shippers shipper)
        {
            var ship = db.Shippers.FirstOrDefault(x => x.ShipperID == shipper.ShipperID);
            ship.ShipperID = shipper.ShipperID;
            ship.CompanyName = shipper.CompanyName;
            ship.Phone = shipper.Phone;
            db.SaveChanges();
        }
    }
}
