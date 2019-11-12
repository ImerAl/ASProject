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
    public class DPBRsController : Controller
    {
        private ModeloProyecto db = new ModeloProyecto();

        // GET: DPBRs
        public ActionResult Index()
        {
            var dPBR = db.DPBR.Include(d => d.Permission).Include(d => d.Role);
            return View(dPBR.ToList());
        }

        // GET: DPBRs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DPBR dPBR = db.DPBR.Find(id);
            if (dPBR == null)
            {
                return HttpNotFound();
            }
            return View(dPBR);
        }

        // GET: DPBRs/Create
        public ActionResult Create()
        {
            ViewBag.Id_Permission = new SelectList(db.Permission, "Id", "Module");
            ViewBag.Id_Role = new SelectList(db.Role, "Id", "Name");
            return View();
        }

        // POST: DPBRs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id_Role,Id_Permission")] DPBR dPBR)
        {
            if (ModelState.IsValid)
            {
                db.DPBR.Add(dPBR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Permission = new SelectList(db.Permission, "Id", "Module", dPBR.Id_Permission);
            ViewBag.Id_Role = new SelectList(db.Role, "Id", "Name", dPBR.Id_Role);
            return View(dPBR);
        }

        // GET: DPBRs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DPBR dPBR = db.DPBR.Find(id);
            if (dPBR == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Permission = new SelectList(db.Permission, "Id", "Module", dPBR.Id_Permission);
            ViewBag.Id_Role = new SelectList(db.Role, "Id", "Name", dPBR.Id_Role);
            return View(dPBR);
        }

        // POST: DPBRs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_Role,Id_Permission")] DPBR dPBR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dPBR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Permission = new SelectList(db.Permission, "Id", "Module", dPBR.Id_Permission);
            ViewBag.Id_Role = new SelectList(db.Role, "Id", "Name", dPBR.Id_Role);
            return View(dPBR);
        }

        // GET: DPBRs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DPBR dPBR = db.DPBR.Find(id);
            if (dPBR == null)
            {
                return HttpNotFound();
            }
            return View(dPBR);
        }

        // POST: DPBRs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DPBR dPBR = db.DPBR.Find(id);
            db.DPBR.Remove(dPBR);
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
