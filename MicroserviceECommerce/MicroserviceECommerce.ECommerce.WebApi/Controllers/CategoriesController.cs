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
    public class CategoriesController : ApiController
    {
        DataContext db = new DataContext();

        public List<CategoriesModel> GetCategories()
        {
            return db.Categories.Select(x => new CategoriesModel
            {
                CategoryID = x.CategoryID,
                CategoryName = x.CategoryName,
                Description = x.Description
            }).ToList();
        }
    }
}
