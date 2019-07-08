using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using iCategory.DAL;
using iCategory.Models;
using Microsoft.AspNet.Identity;
using iCategory.ViewModels;

namespace iCategory.Controllers
{
    [Authorize]
    public class ViewProductsController : Controller
    {
        private MyContext db = new MyContext();
        
        
        public ActionResult Index()
        {
            try
            {
                MyContext db = new MyContext();
                var username = User.Identity.GetUserName();
                var CategoryNames = db.CategoryList.Where(m => m.UserName == username).Select(m => m.CategoryName).ToList();
                CategoryProductViewModel Vm = new CategoryProductViewModel();
                foreach (var CategoryName in CategoryNames)
                {
                    Vm.Cnames.Add(CategoryName);                    
                }
                var products = db.ProductList.Where(m => m.UserName == username).ToList();
                foreach(var item in products)
                {
                    Vm.Name = item.Name;
                    Vm.Price = item.Price;
                }
                return View(Vm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        [HttpPost]
        public ActionResult Filter()
        {
            var check = Request.Form.Get("select");
            Console.WriteLine();
            try
            {
                MyContext db = new MyContext();
                var username = User.Identity.GetUserName();
                ViewBag.Names = db.CategoryList.Where(m => m.UserName == username).Select(m => m.CategoryName).ToList();
                //var products = db.ProductList.Where(m => m.UserName == username && m.CategoryId == check).ToList();
                return View(/*products*/);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        // GET: ViewProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.ProductList.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: ViewProducts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ViewProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Price,CategoryId,UserName,Date")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.ProductList.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: ViewProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.ProductList.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: ViewProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Price,CategoryId,UserName,Date")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: ViewProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.ProductList.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: ViewProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.ProductList.Find(id);
            db.ProductList.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
