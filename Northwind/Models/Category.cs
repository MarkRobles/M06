using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        public object GetProducts()
        {
            return new List<Product>();
        }
    }
}