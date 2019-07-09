using iCategory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iCategory.ViewModels
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public float Price { get; set; }

        
        public List<CategoryViewModel> CategoriesVM { get; set; }

        public ProductViewModel()
        {
            CategoriesVM = new List<CategoryViewModel>();
           
        }

        public ProductViewModel( List<Category> categories) : this()
        {
            categories.ForEach(c => {
                this.CategoriesVM.Add(
                    new CategoryViewModel()
                    {
                        ID = c.ID,
                        Name = c.CategoryName
                    });
            });

        }

        public ProductViewModel(List<Category> categories,string name, float price) : this()
        {
            this.Name = name;
            this.Price = price;
            categories.ForEach(c => {
                this.CategoriesVM.Add(
                    new CategoryViewModel()
                    {
                        ID = c.ID,
                        Name = c.CategoryName
                    });
            });

        }


    }

    public class CategoryViewModel
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }

    
}