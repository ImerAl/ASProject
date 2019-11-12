using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto_Fase2.ModeloLogin.Commons;
using Proyecto_Fase2.Models;
using Proyecto_Fase2.Tags;

namespace Proyecto_Fase2.Controllers
{
    [PermisoAttribute(Permiso = RolesPermisos.General)]
    public class CxC90Controller : Controller
    {
        private ModelVistasCxC db = new ModelVistasCxC();

        // GET: CxC90
        public ActionResult Index()
        {
            return View(db.CxC90.ToList());
        }

        // GET: CxC90/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CxC90 cxC90 = db.CxC90.Find(id);
            if (cxC90 == null)
            {
                return HttpNotFound();
            }
            return View(cxC90);
        }

        // GET: CxC90/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CxC90/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id_User,DateP,DateLimit,Id_LatePayment,status,TotalAmount")] CxC90 cxC90)
        {
            if (ModelState.IsValid)
            {
                db.CxC90.Add(cxC90);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cxC90);
        }

        // GET: CxC90/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CxC90 cxC90 = db.CxC90.Find(id);
            if (cxC90 == null)
            {
                return HttpNotFound();
            }
            return View(cxC90);
        }

        // POST: CxC90/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_User,DateP,DateLimit,Id_LatePayment,status,TotalAmount")] CxC90 cxC90)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cxC90).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cxC90);
        }

        // GET: CxC90/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CxC90 cxC90 = db.CxC90.Find(id);
            if (cxC90 == null)
            {
                return HttpNotFound();
            }
            return View(cxC90);
        }

        // POST: CxC90/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CxC90 cxC90 = db.CxC90.Find(id);
            db.CxC90.Remove(cxC90);
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
