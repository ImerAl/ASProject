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
    public class SuplyInvoicesController : Controller
    {
        private ModeloProyecto db = new ModeloProyecto();

        // GET: SuplyInvoices
        public ActionResult Index()
        {
            var suplyInvoice = db.SuplyInvoice.Include(s => s.AccoutingBook).Include(s => s.LatePayment);
            return View(suplyInvoice.ToList());
        }

        // GET: SuplyInvoices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuplyInvoice suplyInvoice = db.SuplyInvoice.Find(id);
            if (suplyInvoice == null)
            {
                return HttpNotFound();
            }

            var suplyProduct = (from p in db.SuplyProduct where p.Id_SuplyInvoice == id select p);
            ViewBag.Productos = suplyProduct.ToList();

            return View(suplyInvoice);
        }

        // GET: SuplyInvoices/Create
        public ActionResult Create()
        {
            ViewBag.Id_AccountingBook = new SelectList(db.AccoutingBook, "Id", "Name");
            ViewBag.Id_LatePayment = new SelectList(db.LatePayment, "Id", "TypeIncrement");
            return View();
        }

        // POST: SuplyInvoices/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id_AccountingBook,Id_LatePayment,Date_Suply,TotalAmount,status")] SuplyInvoice suplyInvoice)
        {
            if (ModelState.IsValid)
            {
                suplyInvoice.status = "1";
                db.SuplyInvoice.Add(suplyInvoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_AccountingBook = new SelectList(db.AccoutingBook, "Id", "Name", suplyInvoice.Id_AccountingBook);
            ViewBag.Id_LatePayment = new SelectList(db.LatePayment, "Id", "TypeIncrement", suplyInvoice.Id_LatePayment);
            return View(suplyInvoice);
        }

        // GET: SuplyInvoices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuplyInvoice suplyInvoice = db.SuplyInvoice.Find(id);
            if (suplyInvoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_AccountingBook = new SelectList(db.AccoutingBook, "Id", "Name", suplyInvoice.Id_AccountingBook);
            ViewBag.Id_LatePayment = new SelectList(db.LatePayment, "Id", "TypeIncrement", suplyInvoice.Id_LatePayment);
            return View(suplyInvoice);
        }

        // POST: SuplyInvoices/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_AccountingBook,Id_LatePayment,Date_Suply,TotalAmount,status")] SuplyInvoice suplyInvoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suplyInvoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_AccountingBook = new SelectList(db.AccoutingBook, "Id", "Name", suplyInvoice.Id_AccountingBook);
            ViewBag.Id_LatePayment = new SelectList(db.LatePayment, "Id", "TypeIncrement", suplyInvoice.Id_LatePayment);
            return View(suplyInvoice);
        }

        // GET: SuplyInvoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuplyInvoice suplyInvoice = db.SuplyInvoice.Find(id);
            if (suplyInvoice == null)
            {
                return HttpNotFound();
            }
            return View(suplyInvoice);
        }

        // POST: SuplyInvoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SuplyInvoice suplyInvoice = db.SuplyInvoice.Find(id);
            db.SuplyInvoice.Remove(suplyInvoice);
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


        public ActionResult Cerrar(int Id)
        {
            SuplyInvoice suplyInvoice = db.SuplyInvoice.Find(Id);
            suplyInvoice.status = "0";

            db.SaveChanges();
            return RedirectToAction("Index");


        }


    }
}
