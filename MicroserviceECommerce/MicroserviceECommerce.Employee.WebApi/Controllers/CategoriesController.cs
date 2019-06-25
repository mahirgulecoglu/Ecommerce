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
    public class CategoriesController : ApiController
    {
        DataContext db = new DataContext();
        public CategoriesModel GetCategoryDetail()
        {
            return db.Categories.Select(x => new CategoriesModel
            {
                CategoryID = x.CategoryID,
                CategoryName = x.CategoryName,
                Description = x.Description,
                Picture = x.Picture
            }).FirstOrDefault();
        }
        public void PutCategory(Categories category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }
        public void DeleteCategory(int id)
        {
            var category = db.Categories.FirstOrDefault(x => x.CategoryID == id);
            db.Categories.Remove(category);
            db.SaveChanges();
        }
        public void PostCategory(Categories category)
        {
            var cat = db.Categories.FirstOrDefault(x => x.CategoryID == category.CategoryID);
            cat.CategoryID = category.CategoryID;
            cat.CategoryName = category.CategoryName;
            cat.Description = category.Description;
            cat.Picture = category.Picture;
            db.SaveChanges();
        }
    }
}
