using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2_1_Views.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }
    }
}