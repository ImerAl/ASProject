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
    public class AccoutingBooksController : Controller
    {
        private A_Model_proyecto db = new A_Model_proyecto();

        // GET: AccoutingBooks
        public ActionResult Index()
        {
            var accoutingBook = db.AccoutingBook.Include(a => a.Area);
            return View(accoutingBook.ToList());
        }

        // GET: AccoutingBooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccoutingBook accoutingBook = db.AccoutingBook.Find(id);
            if (accoutingBook == null)
            {
                return HttpNotFound();
            }
            return View(accoutingBook);
        }

        // GET: AccoutingBooks/Create
        public ActionResult Create()
        {
            ViewBag.Id_Area = new SelectList(db.Area, "Id", "Name");
            return View();
        }

        // POST: AccoutingBooks/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id_Area,Name,Description")] AccoutingBook accoutingBook)
        {
            if (ModelState.IsValid)
            {
                db.AccoutingBook.Add(accoutingBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Area = new SelectList(db.Area, "Id", "Name", accoutingBook.Id_Area);
            return View(accoutingBook);
        }

        // GET: AccoutingBooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccoutingBook accoutingBook = db.AccoutingBook.Find(id);
            if (accoutingBook == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Area = new SelectList(db.Area, "Id", "Name", accoutingBook.Id_Area);
            return View(accoutingBook);
        }

        // POST: AccoutingBooks/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_Area,Name,Description")] AccoutingBook accoutingBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accoutingBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Area = new SelectList(db.Area, "Id", "Name", accoutingBook.Id_Area);
            return View(accoutingBook);
        }

        // GET: AccoutingBooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccoutingBook accoutingBook = db.AccoutingBook.Find(id);
            if (accoutingBook == null)
            {
                return HttpNotFound();
            }
            return View(accoutingBook);
        }

        // POST: AccoutingBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccoutingBook accoutingBook = db.AccoutingBook.Find(id);
            db.AccoutingBook.Remove(accoutingBook);
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
