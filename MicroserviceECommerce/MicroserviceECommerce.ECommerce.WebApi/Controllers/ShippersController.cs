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
    public class ShippersController : ApiController
    {
        DataContext db = new DataContext();

        public List<ShippersModel> GetShippers()
        {
            return db.Shippers.Select(x => new ShippersModel
            {
                ShipperID = x.ShipperID,
                CompanyName = x.CompanyName,
                Phone = x.Phone
            }).ToList();
        }
        public ShippersModel GetShipperDetail()
        {
            return db.Shippers.Select(x => new ShippersModel
            {
                ShipperID = x.ShipperID,
                CompanyName = x.CompanyName,
                Phone = x.Phone
            }).FirstOrDefault();
        }
    }
}
