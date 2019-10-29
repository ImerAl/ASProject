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
    public class LatePaymentsController : Controller
    {
        private A_Model_proyecto db = new A_Model_proyecto();

        // GET: LatePayments
        public ActionResult Index()
        {
            return View(db.LatePayment.ToList());
        }

        // GET: LatePayments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LatePayment latePayment = db.LatePayment.Find(id);
            if (latePayment == null)
            {
                return HttpNotFound();
            }
            return View(latePayment);
        }

        // GET: LatePayments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LatePayments/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Increment,TypeIncrement,DaysForIncrement,LateDayPayment,status")] LatePayment latePayment)
        {
            if (ModelState.IsValid)
            {
                db.LatePayment.Add(latePayment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(latePayment);
        }

        // GET: LatePayments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LatePayment latePayment = db.LatePayment.Find(id);
            if (latePayment == null)
            {
                return HttpNotFound();
            }
            return View(latePayment);
        }

        // POST: LatePayments/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Increment,TypeIncrement,DaysForIncrement,LateDayPayment,status")] LatePayment latePayment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(latePayment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(latePayment);
        }

        // GET: LatePayments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LatePayment latePayment = db.LatePayment.Find(id);
            if (latePayment == null)
            {
                return HttpNotFound();
            }
            return View(latePayment);
        }

        // POST: LatePayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LatePayment latePayment = db.LatePayment.Find(id);
            db.LatePayment.Remove(latePayment);
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
