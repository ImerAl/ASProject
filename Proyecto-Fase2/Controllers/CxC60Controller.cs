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
    public class CxC60Controller : Controller
    {
        private ModelVistas db = new ModelVistas();

        // GET: CxC60
        public ActionResult Index()
        {
            return View(db.CxC60.ToList());
        }

        // GET: CxC60/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CxC60 cxC60 = db.CxC60.Find(id);
            if (cxC60 == null)
            {
                return HttpNotFound();
            }
            return View(cxC60);
        }

        // GET: CxC60/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CxC60/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id_User,DateP,DateLimit,Id_LatePayment,status,TotalAmount")] CxC60 cxC60)
        {
            if (ModelState.IsValid)
            {
                db.CxC60.Add(cxC60);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cxC60);
        }

        // GET: CxC60/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CxC60 cxC60 = db.CxC60.Find(id);
            if (cxC60 == null)
            {
                return HttpNotFound();
            }
            return View(cxC60);
        }

        // POST: CxC60/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_User,DateP,DateLimit,Id_LatePayment,status,TotalAmount")] CxC60 cxC60)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cxC60).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cxC60);
        }

        // GET: CxC60/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CxC60 cxC60 = db.CxC60.Find(id);
            if (cxC60 == null)
            {
                return HttpNotFound();
            }
            return View(cxC60);
        }

        // POST: CxC60/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CxC60 cxC60 = db.CxC60.Find(id);
            db.CxC60.Remove(cxC60);
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
