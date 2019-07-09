using iCategory.DAL;
using iCategory.Models;
using iCategory.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace iCategory.Controllers
{
    public class AddProductController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var username = User.Identity.GetUserName();
            try
            {
                MyContext db = new MyContext();
                
                var categories = db.CategoryList.Where(m => m.UserName == username).ToList();
                var viewModel = new ProductViewModel(categories);
                return View(viewModel);
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return View();
        }

        public ActionResult Save(ProductViewModel model)
        {
            var username = User.Identity.GetUserName();
            try
            {
                
                MyContext db = new MyContext();
                var catID = Int32.Parse(Request.Form.Get("select"));

                var category = db.CategoryList.Where(c => c.ID == catID).SingleOrDefault();

                if (category == null)
                    throw new NotImplementedException();


                Product p = new Product();
                p.Name = model.Name;
                p.UserName = username;
                p.Price = model.Price;
                p.Date = DateTime.Now;

                category.Products.Add(p);
                //db.ProductList.Add(p);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }
    }
}