﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroserviceECommerce.MVCUI.Models
{
    public class ItemonCartModel
    {
        public ProductsModel Product { get; set; }
        public int Quantity { get; set; }
        public string CustomerID { get; set; }
    }
}