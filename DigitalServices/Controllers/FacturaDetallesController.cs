using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DigitalServices.DAL;
using DigitalServices.Models;

namespace DigitalServices.Controllers
{
    public class FacturaDetallesController : Controller
    {
        private DigitalServicesDB db = new DigitalServicesDB();

        // GET: FacturaDetalles
        public ActionResult Index()
        {
            return View(db.FaturaDetalle.ToList());
        }

        // GET: FacturaDetalles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacturaDetalles facturaDetalles = db.FaturaDetalle.Find(id);
            if (facturaDetalles == null)
            {
                return HttpNotFound();
            }
            return View(facturaDetalles);
        }

        // GET: FacturaDetalles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FacturaDetalles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdFactura,IdServicio,Cantidad,Monto")] FacturaDetalles facturaDetalles)
        {
            if (ModelState.IsValid)
            {
                db.FaturaDetalle.Add(facturaDetalles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(facturaDetalles);
        }

        // GET: FacturaDetalles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacturaDetalles facturaDetalles = db.FaturaDetalle.Find(id);
            if (facturaDetalles == null)
            {
                return HttpNotFound();
            }
            return View(facturaDetalles);
        }

        // POST: FacturaDetalles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdFactura,IdServicio,Cantidad,Monto")] FacturaDetalles facturaDetalles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facturaDetalles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(facturaDetalles);
        }

        // GET: FacturaDetalles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacturaDetalles facturaDetalles = db.FaturaDetalle.Find(id);
            if (facturaDetalles == null)
            {
                return HttpNotFound();
            }
            return View(facturaDetalles);
        }

        // POST: FacturaDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FacturaDetalles facturaDetalles = db.FaturaDetalle.Find(id);
            db.FaturaDetalle.Remove(facturaDetalles);
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
