using Crud.Context;
using Crud.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud.Controllers
{
    public class HomeController : Controller
    {
        readonly ProductContext db = new ProductContext();
        public ActionResult Index()
        {
            List<Product> prod = db.product.ToList();

            return View(prod);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product products)
        {
            if (ModelState.IsValid)
            {
                db.product.Add(products);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return new HttpStatusCodeResult(400);
        }
        public ActionResult Details(int id)
        {
            Product prod = db.product.FirstOrDefault(x => x.ID == id);
            return View(prod);
        }
        //public ActionResult ProductToDelet(int id)
        //{
        //    Product prod = db.product.FirstOrDefault(x => x.ID == id);
        //    return View(prod);
        //}
        public ActionResult Edit(int id)
        {
            Product prod = db.product.FirstOrDefault(x => x.ID == id);
            if (prod == null)
            {
                return new HttpStatusCodeResult(404);
            }
            return View(prod);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            return new HttpStatusCodeResult(400);
        }

        public ActionResult ToDelete(int id)
        {
            Product prod = db.product.FirstOrDefault(x => x.ID == id);
            if (prod == null)
            {
                return new HttpStatusCodeResult(404);
            }
            return View(prod);
        }
        public ActionResult Delete(int? ID)
        {           
            if (ID != null)
            {
                Product currentProd = db.product.FirstOrDefault(p => p.ID == ID);

                if (currentProd != null)
                {
                    db.product.Remove(currentProd);
                    db.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }
            }
            return new HttpStatusCodeResult(404);
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