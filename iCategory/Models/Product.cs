using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace iCategory.Models
{
    public class Product
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public float Price { get; set; }
        public int CategoryId { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
    }
}