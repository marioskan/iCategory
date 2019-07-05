using iCategory.DAL;
using iCategory.Models;
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

                ViewBag.Names = db.CategoryList.Where(m => m.UserName == username).Select(m=> m.CategoryName).ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return View();
        }

        public ActionResult Save(Product m)
        {
            var username = User.Identity.GetUserName();
            try
            {
                
                MyContext db = new MyContext();
                Product p = new Product();
                p.Name = m.Name;
                p.UserName = username;
                p.Price = m.Price;
                p.Date = DateTime.Now;
                p.CategoryId = Request.Form.Get("select");
                db.ProductList.Add(p);
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