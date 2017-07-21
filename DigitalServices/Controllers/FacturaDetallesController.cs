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
        [HttpPost]
        public JsonResult Eliminar(int id)
        {
            var detail = BLL.FacturaDetalleBLL.Buscar(id);
            bool existe = (detail != null);
            if (existe)
            {
                existe = BLL.FacturaDetalleBLL.Eliminar(detail);
            }
            return Json(existe, JsonRequestBehavior.AllowGet);
        }

        // GET: FacturaDetalles
        public ActionResult Index()
        {
            return View(BLL.FacturaDetalleBLL.Listar());
        }

        // GET: FacturaDetalles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacturaDetalles facturaDetalles = BLL.FacturaDetalleBLL.Buscar(id);
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
                BLL.FacturaDetalleBLL.Guardar(facturaDetalles);
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
            FacturaDetalles facturaDetalles = BLL.FacturaDetalleBLL.Buscar(id);
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
                BLL.FacturaDetalleBLL.Modificar(facturaDetalles);
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
            FacturaDetalles facturaDetalles = BLL.FacturaDetalleBLL.Buscar(id);
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
            BLL.FacturaDetalleBLL.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}
