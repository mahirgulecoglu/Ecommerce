using MicroserviceECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MicroserviceECommerce.Employee.WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        DataContext db = new DataContext();

        public void PutProduct(Products product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }
        public void DeleteProduct(int id)
        {
            var product = db.Products.FirstOrDefault(x => x.ProductID == id);
            db.Products.Remove(product);
            db.SaveChanges();
        }
        public void PostProduct(Products product)
        {
            var pro = db.Products.FirstOrDefault(x => x.ProductID == product.ProductID);
            pro.ProductID = product.ProductID;
            pro.ProductName = product.ProductName;
            pro.SupplierID = product.SupplierID;
            pro.CategoryID = product.CategoryID;
            pro.QuantityPerUnit = product.QuantityPerUnit;
            pro.UnitPrice = product.UnitPrice;
            pro.UnitsInStock = product.UnitsInStock;
            pro.UnitsOnOrder = product.ReorderLevel;
            pro.Discontinued = product.Discontinued;
            db.SaveChanges();
        }
    }
}
