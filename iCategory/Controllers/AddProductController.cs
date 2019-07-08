using iCategory.DAL;
using iCategory.Models;
using Microsoft.AspNet.Identity;
using System;
using iCategory.ViewModels;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace iCategory.Controllers
{
    public class AddProductController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {

            //List<CategoryProductViewModel> VmList = new List<CategoryProductViewModel>();
            var username = User.Identity.GetUserName();
            try
            {
                MyContext db = new MyContext();
                var CategoryNames = db.CategoryList.Where(m => m.UserName == username).Select(m=> m.CategoryName).ToList();
                CategoryProductViewModel Vm = new CategoryProductViewModel();
                foreach (var CategoryName in CategoryNames)
                {                  
                    Vm.Cnames.Add(CategoryName);                   
                }
                return View(Vm);
            }
            catch(Exception ex)
            {
                throw ex;
            }
           // return View();
        }

        public ActionResult Save(Product m)
        {
            var username = User.Identity.GetUserName();
            try
            {
                
                MyContext db = new MyContext();
                Product p = new Product();
                string check = Request.Form.Get("select");
                var catid = db.CategoryList.Where(c => c.CategoryName.Equals(check)).Select(c => c.ID).Single();              
                p.Name = m.Name;
                p.UserName = username;
                p.Price = m.Price;
                p.Date = DateTime.Now;
                p.CategoryId = catid;
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