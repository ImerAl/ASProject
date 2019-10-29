using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto_Fase2.Models;

namespace Proyecto_Fase2.Controllers
{
    public class ProductPurchasesController : Controller
    {
        private A_Model_proyecto db = new A_Model_proyecto();

        // GET: ProductPurchases
        public ActionResult Index()
        {
            var productPurchase = db.ProductPurchase.Include(p => p.LatePayment).Include(p => p.Users);
            return View(productPurchase.ToList());
        }

        // GET: ProductPurchases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductPurchase productPurchase = db.ProductPurchase.Find(id);
            if (productPurchase == null)
            {
                return HttpNotFound();
            }
            return View(productPurchase);
        }

        // GET: ProductPurchases/Create
        public ActionResult Create()
        {
            ViewBag.Id_LatePayment = new SelectList(db.LatePayment, "Id", "TypeIncrement");
            ViewBag.Id_User = new SelectList(db.Users, "Id", "Credentials");
            return View();
        }

        // POST: ProductPurchases/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id_User,DateP,DateLimit,Id_LatePayment,status,TotalAmount")] ProductPurchase productPurchase)
        {
            if (ModelState.IsValid)
            {
                db.ProductPurchase.Add(productPurchase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_LatePayment = new SelectList(db.LatePayment, "Id", "TypeIncrement", productPurchase.Id_LatePayment);
            ViewBag.Id_User = new SelectList(db.Users, "Id", "Credentials", productPurchase.Id_User);
            return View(productPurchase);
        }

        // GET: ProductPurchases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductPurchase productPurchase = db.ProductPurchase.Find(id);
            if (productPurchase == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_LatePayment = new SelectList(db.LatePayment, "Id", "TypeIncrement", productPurchase.Id_LatePayment);
            ViewBag.Id_User = new SelectList(db.Users, "Id", "Credentials", productPurchase.Id_User);
            return View(productPurchase);
        }

        // POST: ProductPurchases/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_User,DateP,DateLimit,Id_LatePayment,status,TotalAmount")] ProductPurchase productPurchase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productPurchase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_LatePayment = new SelectList(db.LatePayment, "Id", "TypeIncrement", productPurchase.Id_LatePayment);
            ViewBag.Id_User = new SelectList(db.Users, "Id", "Credentials", productPurchase.Id_User);
            return View(productPurchase);
        }

        // GET: ProductPurchases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductPurchase productPurchase = db.ProductPurchase.Find(id);
            if (productPurchase == null)
            {
                return HttpNotFound();
            }
            return View(productPurchase);
        }

        // POST: ProductPurchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductPurchase productPurchase = db.ProductPurchase.Find(id);
            db.ProductPurchase.Remove(productPurchase);
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
