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
    public class SuplyProductsController : Controller
    {
        private ModeloProyecto db = new ModeloProyecto();

        // GET: SuplyProducts
        public ActionResult Index(int Id)
        {
            SuplyInvoice SI = db.SuplyInvoice.Find(Id);

            if (SI.status == "0")
                return RedirectToAction("Index", "SuplyInvoices");


            var suplyProduct = (from p in db.SuplyProduct where p.Id_SuplyInvoice == Id select p);
                        
            ViewBag.Id = Id.ToString();
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
        public ActionResult Create(int Id)
        {
            ViewBag.Id = Id.ToString();
            ViewBag.Id_Product = new SelectList(db.Product, "Id", "Name");
            ViewBag.Id_SuplyInvoice = new SelectList(db.SuplyInvoice, "Id", "status");
            return View();
        }

        // POST: SuplyProducts/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(int Id,[Bind(Include = "Id,Id_SuplyInvoice,Id_Product,Quantity,UnitCost,TotalAmount")] SuplyProduct suplyProduct)
        {
            if (ModelState.IsValid)
            {
                suplyProduct.Id_SuplyInvoice = Id;
                suplyProduct.UnitCost = (decimal)suplyProduct.TotalAmount / (decimal)suplyProduct.Quantity;
               
                db.SuplyProduct.Add(suplyProduct);
                db.SaveChanges();


                SuplyInvoice SI = db.SuplyInvoice.Find(Id);               
                SI.TotalAmount = db.SuplyProduct.Where(t => t.Id_SuplyInvoice == Id).Select(i =>i.TotalAmount).Sum();
                db.SaveChanges();

                return RedirectToAction("Index", routeValues: new { Id = Id });
                         
            }

            return RedirectToAction("Index", routeValues: new { Id = Id });
        }

        
        

        public ActionResult DeleteConfirmed(int Id=0,int Id2=0)
        {
            if (Id == 0 || Id2 == 0)
                return RedirectToAction("Index", "SuplyInvoices");



            SuplyProduct suplyProduct = db.SuplyProduct.Find(Id);
            db.SuplyProduct.Remove(suplyProduct);
            db.SaveChanges();
            SuplyInvoice SI = db.SuplyInvoice.Find(Id2);
            SI.TotalAmount = db.SuplyProduct.Where(t => t.Id_SuplyInvoice == Id).Select(i => i.TotalAmount).Sum();
            db.SaveChanges();



            return RedirectToAction("Index", routeValues: new { Id = Id2 });
        }

    }
}
