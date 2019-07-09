using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace iCategory.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public string UserName { get; set; }

        public List<Product> Products { get; set; }

        public Category()
        {
            Products = new List<Product>();
        }
    }
}