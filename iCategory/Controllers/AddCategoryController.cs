using iCategory.DAL;
using iCategory.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iCategory.Controllers
{
    public class AddCategoryController : Controller
    {
        
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Save(Category model)
        {
            
            try
            {
                string user = User.Identity.GetUserName();
                MyContext db = new MyContext();
                Category cat = new Category();
                cat.CategoryName = model.CategoryName;
                cat.UserName = user;
                db.CategoryList.Add(cat);
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