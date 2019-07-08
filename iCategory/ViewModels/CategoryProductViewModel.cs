using iCategory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iCategory.ViewModels
{
    public class CategoryProductViewModel
    {
        public string CategoryName { get; set; } //Category
        public string Name { get; set; } //Product
        public float Price { get; set; } //Product
        public List<string> Cnames { get; set;}

        public CategoryProductViewModel()
        {
            Cnames = new List<string>();
        }
    }
}