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
    public class SubCategory_ProviderController : Controller
    {
        private ModeloProyecto db = new ModeloProyecto();

        // GET: SubCategory_Provider
        public ActionResult Index()
        {
            var subCategory_Provider = db.SubCategory_Provider.Include(s => s.Provider).Include(s => s.Sub_Category);
            return View(subCategory_Provider.ToList());
        }

        // GET: SubCategory_Provider/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory_Provider subCategory_Provider = db.SubCategory_Provider.Find(id);
            if (subCategory_Provider == null)
            {
                return HttpNotFound();
            }
            return View(subCategory_Provider);
        }

        // GET: SubCategory_Provider/Create
        public ActionResult Create()
        {
            ViewBag.Id_Provider = new SelectList(db.Provider, "Id", "Name");
            ViewBag.Id_SCategory = new SelectList(db.Sub_Category, "Id", "Description");
            return View();
        }

        // POST: SubCategory_Provider/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id_SCategory,Id_Provider")] SubCategory_Provider subCategory_Provider)
        {
            if (ModelState.IsValid)
            {
                db.SubCategory_Provider.Add(subCategory_Provider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Provider = new SelectList(db.Provider, "Id", "Name", subCategory_Provider.Id_Provider);
            ViewBag.Id_SCategory = new SelectList(db.Sub_Category, "Id", "Description", subCategory_Provider.Id_SCategory);
            return View(subCategory_Provider);
        }

        // GET: SubCategory_Provider/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory_Provider subCategory_Provider = db.SubCategory_Provider.Find(id);
            if (subCategory_Provider == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Provider = new SelectList(db.Provider, "Id", "Name", subCategory_Provider.Id_Provider);
            ViewBag.Id_SCategory = new SelectList(db.Sub_Category, "Id", "Description", subCategory_Provider.Id_SCategory);
            return View(subCategory_Provider);
        }

        // POST: SubCategory_Provider/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_SCategory,Id_Provider")] SubCategory_Provider subCategory_Provider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subCategory_Provider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Provider = new SelectList(db.Provider, "Id", "Name", subCategory_Provider.Id_Provider);
            ViewBag.Id_SCategory = new SelectList(db.Sub_Category, "Id", "Description", subCategory_Provider.Id_SCategory);
            return View(subCategory_Provider);
        }

        // GET: SubCategory_Provider/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory_Provider subCategory_Provider = db.SubCategory_Provider.Find(id);
            if (subCategory_Provider == null)
            {
                return HttpNotFound();
            }
            return View(subCategory_Provider);
        }

        // POST: SubCategory_Provider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubCategory_Provider subCategory_Provider = db.SubCategory_Provider.Find(id);
            db.SubCategory_Provider.Remove(subCategory_Provider);
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
