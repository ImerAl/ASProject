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
    public class PurcharseDetailsController : Controller
    {
        private ModeloProyecto db = new ModeloProyecto();

        // GET: PurcharseDetails
        public ActionResult Index()
        {
            var purcharseDetails = db.PurcharseDetails.Include(p => p.ProductPurchase).Include(p => p.SuplyProduct);
            return View(purcharseDetails.ToList());
        }

        // GET: PurcharseDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurcharseDetails purcharseDetails = db.PurcharseDetails.Find(id);
            if (purcharseDetails == null)
            {
                return HttpNotFound();
            }
            return View(purcharseDetails);
        }

        // GET: PurcharseDetails/Create
        public ActionResult Create()
        {
            ViewBag.Id_Purcharse = new SelectList(db.ProductPurchase, "Id", "status");
            ViewBag.Id_SuplyProduct = new SelectList(db.SuplyProduct, "Id", "Id");
            return View();
        }

        // POST: PurcharseDetails/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id_Purcharse,Id_SuplyProduct,QuantityBuyed,Total")] PurcharseDetails purcharseDetails)
        {
            if (ModelState.IsValid)
            {
                db.PurcharseDetails.Add(purcharseDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Purcharse = new SelectList(db.ProductPurchase, "Id", "status", purcharseDetails.Id_Purcharse);
            ViewBag.Id_SuplyProduct = new SelectList(db.SuplyProduct, "Id", "Id", purcharseDetails.Id_SuplyProduct);
            return View(purcharseDetails);
        }

        // GET: PurcharseDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurcharseDetails purcharseDetails = db.PurcharseDetails.Find(id);
            if (purcharseDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Purcharse = new SelectList(db.ProductPurchase, "Id", "status", purcharseDetails.Id_Purcharse);
            ViewBag.Id_SuplyProduct = new SelectList(db.SuplyProduct, "Id", "Id", purcharseDetails.Id_SuplyProduct);
            return View(purcharseDetails);
        }

        // POST: PurcharseDetails/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_Purcharse,Id_SuplyProduct,QuantityBuyed,Total")] PurcharseDetails purcharseDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purcharseDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Purcharse = new SelectList(db.ProductPurchase, "Id", "status", purcharseDetails.Id_Purcharse);
            ViewBag.Id_SuplyProduct = new SelectList(db.SuplyProduct, "Id", "Id", purcharseDetails.Id_SuplyProduct);
            return View(purcharseDetails);
        }

        // GET: PurcharseDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurcharseDetails purcharseDetails = db.PurcharseDetails.Find(id);
            if (purcharseDetails == null)
            {
                return HttpNotFound();
            }
            return View(purcharseDetails);
        }

        // POST: PurcharseDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PurcharseDetails purcharseDetails = db.PurcharseDetails.Find(id);
            db.PurcharseDetails.Remove(purcharseDetails);
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
