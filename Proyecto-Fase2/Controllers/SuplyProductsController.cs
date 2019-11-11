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
    public class SuplyProductsController : Controller
    {
        private ModeloProyecto db = new ModeloProyecto();

        // GET: SuplyProducts
        public ActionResult Index()
        {
            var suplyProduct = db.SuplyProduct.Include(s => s.Product).Include(s => s.SuplyInvoice);
            return View(suplyProduct.ToList());
        }

        // GET: SuplyProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuplyProduct suplyProduct = db.SuplyProduct.Find(id);
            if (suplyProduct == null)
            {
                return HttpNotFound();
            }
            return View(suplyProduct);
        }

        // GET: SuplyProducts/Create
        public ActionResult Create()
        {
            ViewBag.Id_Product = new SelectList(db.Product, "Id", "Name");
            ViewBag.Id_SuplyInvoice = new SelectList(db.SuplyInvoice, "Id", "status");
            return View();
        }

        // POST: SuplyProducts/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id_SuplyInvoice,Id_Product,Quantity,UnitCost,TotalAmount")] SuplyProduct suplyProduct)
        {
            if (ModelState.IsValid)
            {
                db.SuplyProduct.Add(suplyProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Product = new SelectList(db.Product, "Id", "Name", suplyProduct.Id_Product);
            ViewBag.Id_SuplyInvoice = new SelectList(db.SuplyInvoice, "Id", "status", suplyProduct.Id_SuplyInvoice);
            return View(suplyProduct);
        }

        // GET: SuplyProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuplyProduct suplyProduct = db.SuplyProduct.Find(id);
            if (suplyProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Product = new SelectList(db.Product, "Id", "Name", suplyProduct.Id_Product);
            ViewBag.Id_SuplyInvoice = new SelectList(db.SuplyInvoice, "Id", "status", suplyProduct.Id_SuplyInvoice);
            return View(suplyProduct);
        }

        // POST: SuplyProducts/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_SuplyInvoice,Id_Product,Quantity,UnitCost,TotalAmount")] SuplyProduct suplyProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suplyProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Product = new SelectList(db.Product, "Id", "Name", suplyProduct.Id_Product);
            ViewBag.Id_SuplyInvoice = new SelectList(db.SuplyInvoice, "Id", "status", suplyProduct.Id_SuplyInvoice);
            return View(suplyProduct);
        }

        // GET: SuplyProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuplyProduct suplyProduct = db.SuplyProduct.Find(id);
            if (suplyProduct == null)
            {
                return HttpNotFound();
            }
            return View(suplyProduct);
        }

        // POST: SuplyProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SuplyProduct suplyProduct = db.SuplyProduct.Find(id);
            db.SuplyProduct.Remove(suplyProduct);
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
