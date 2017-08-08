
using System;
using System.Net;
using System.Web.Mvc;
using DigitalServices.Models;
using DigitalServices.Models.Consultas;
using System.Collections.Generic;

namespace DigitalServices.Controllers
{
    public class FacturasController : Controller
    {
        [HttpGet]
        public JsonResult LastIndex()
        {
            int id = BLL.FacturasBLL.Identity();
            if (id > 1 || BLL.FacturasBLL.Listar().Count > 0)
                ++id;
            return Json(id, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Guardar(EncabezadoDetalle Factura)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                try
                {
                    DateTime now = DateTime.Now;
                    int y, m, d, h, min, s;
                    /*Se actualiza la hora de la fecha que viene desde 
                     * la ventana de registro a la hora actual*/
                    y = Factura.Encabezado.Fecha.Year;
                    m = Factura.Encabezado.Fecha.Month;
                    d = Factura.Encabezado.Fecha.Day;
                    h = now.Hour;
                    min = now.Minute;
                    s = now.Second;
                    Factura.Encabezado.Fecha = new DateTime(y, m, d, h, min, s);

                    result = BLL.FacturasBLL.Guardar(Factura);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Buscar(int? facturaId)
        {
            EncabezadoDetalle factura = BLL.FacturasBLL.Buscar(facturaId);
            if (factura != null)
            {
                return Json(factura, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }//"La factura que haz intentado consultar con Id: " + facturaId +", no esta disponible."
        }

        [HttpPost]
        public JsonResult Modificar(EncabezadoDetalle factura)
        {
            var existe = (BLL.FacturasBLL.Buscar(factura.Encabezado.IdFactura) != null);
            if (existe)
            {
                existe = BLL.FacturasBLL.Modificar(factura);
                return Json(existe, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(existe, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Eliminar(EncabezadoDetalle factura)
        {
            var existe = (BLL.FacturasBLL.BuscarEncabezado(factura.Encabezado.IdFactura) != null);

            if (existe)
            {
                existe = BLL.FacturasBLL.Eliminar(factura);
                return Json(existe, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(existe, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult Listado()
        {
            var facturas = BLL.FacturasBLL.Listar();
            if (facturas.Count > 0)
            {
                return Json(facturas, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Reporte(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacturaReporte factura = BLL.FacturasBLL.ParaReporte(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        [HttpPost]
        public JsonResult Filtrar(Filtro filtro)
        {
            DateTime now = DateTime.Now;
            int y, m, d, h, min, s;
            /*Se actualiza la hora de la fecha que viene desde 
             * la ventana de registro a la hora actual*/
            y = filtro.Hasta.Year;
            m = filtro.Hasta.Month;
            d = filtro.Hasta.Day;
            h = now.Hour;
            min = now.Minute;
            s = now.Second;
            filtro.Hasta = new DateTime(y, m, d, h, min, s);
            var listado = BLL.FacturasBLL.ListarC(filtro);
            if (listado != null)
            {
                return Json(listado, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Facturas
        public ActionResult Index()
        {
            return View(BLL.FacturasBLL.ListarC());
        }

        // GET: Facturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var facturas = BLL.FacturasBLL.Buscar(id);
            ViewBag.Factura = facturas;
            if (facturas == null)
            {
                return HttpNotFound();
            }
            return View(facturas);
        }

        // GET: Facturas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Facturas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdFactura,IdCliente,CantidadItems,SubTotal,ITBIS,TOTAL,IdEmpleado")] Facturas facturas)
        {
            if (ModelState.IsValid)
            {
                BLL.FacturasBLL.Guardar(facturas);
                return RedirectToAction("Index");
            }

            return View(facturas);
        }

        // GET: Facturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facturas facturas = BLL.FacturasBLL.BuscarEncabezado(id);
            if (facturas == null)
            {
                return HttpNotFound();
            }
            return View(facturas);
        }

        // POST: Facturas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdFactura,IdCliente,CantidadItems,SubTotal,ITBIS,TOTAL,IdEmpleado")] Facturas facturas)
        {
            if (ModelState.IsValid)
            {
                BLL.FacturasBLL.ModificarEncabezado(facturas.IdFactura);
                return RedirectToAction("Index");
            }
            return View(facturas);
        }

        // GET: Facturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var res = BLL.FacturasBLL.Eliminar(id);
            if (res)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BLL.FacturasBLL.EliminarEncabezado(id);
            return RedirectToAction("Index");
        }
    }
}
