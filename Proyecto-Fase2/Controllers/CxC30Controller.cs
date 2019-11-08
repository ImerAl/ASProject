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
    public class CxC30Controller : Controller
    {
        private ModelVistas db = new ModelVistas();

        // GET: CxC30
        public ActionResult Index()
        {
            return View(db.CxC30.ToList());
        }

        // GET: CxC30/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CxC30 cxC30 = db.CxC30.Find(id);
            if (cxC30 == null)
            {
                return HttpNotFound();
            }
            return View(cxC30);
        }

        // GET: CxC30/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CxC30/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id_User,DateP,DateLimit,Id_LatePayment,status,TotalAmount")] CxC30 cxC30)
        {
            if (ModelState.IsValid)
            {
                db.CxC30.Add(cxC30);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cxC30);
        }

        // GET: CxC30/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CxC30 cxC30 = db.CxC30.Find(id);
            if (cxC30 == null)
            {
                return HttpNotFound();
            }
            return View(cxC30);
        }

        // POST: CxC30/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_User,DateP,DateLimit,Id_LatePayment,status,TotalAmount")] CxC30 cxC30)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cxC30).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cxC30);
        }

        // GET: CxC30/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CxC30 cxC30 = db.CxC30.Find(id);
            if (cxC30 == null)
            {
                return HttpNotFound();
            }
            return View(cxC30);
        }

        // POST: CxC30/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CxC30 cxC30 = db.CxC30.Find(id);
            db.CxC30.Remove(cxC30);
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
