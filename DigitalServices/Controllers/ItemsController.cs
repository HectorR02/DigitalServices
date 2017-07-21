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
    public class ItemsController : Controller
    {

        [HttpGet]
        public JsonResult Cantidad(int id)
        {
            int cant = BLL.ItemsBLL.Buscar(id).Existencia;

            return Json(cant, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Listado()
        {
            return Json(BLL.ItemsBLL.Listar(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Siguiente()
        {
            int id = BLL.ItemsBLL.Identity();
            if (id > 1 || BLL.ItemsBLL.Listar().Count > 0)
            {
                ++id;
            }
            return Json(id, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Guardar(Items item)
        {
            bool res = false;
            if (ModelState.IsValid)
            {
                if (BLL.ItemsBLL.Buscar(item.IdItem) == null)
                {
                    res = BLL.ItemsBLL.Guardar(item);
                }
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Eliminar(Items item)
        {
            bool res = false;
            if (ModelState.IsValid)
            {
                if (BLL.ItemsBLL.Buscar(item.IdItem) != null)
                    res = BLL.ItemsBLL.Eliminar(item);
            }
            return Json(item,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Modificar(Items item)
        {
            bool res = false;
            if (ModelState.IsValid)
            {
                if (BLL.ItemsBLL.Buscar(item.IdItem) != null)
                {
                    res = BLL.ItemsBLL.Modificar(item);
                }
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Buscar(int id)
        {
            bool res = false;
            Items item = BLL.ItemsBLL.Buscar(id);
            res = (item != null);
            if (res)
            {
                return Json(item, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(res, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Items
        public ActionResult Index()
        {
            var listado = BLL.ItemsBLL.Listar();
            if (listado != null)
            {
                return View(listado);
            }
            return View();
        }

        // GET: Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Items items = BLL.ItemsBLL.Buscar(id);
            if (items == null)
            {
                return HttpNotFound();
            }
            return View(items);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            ViewBag.Id = @"/^([0-9]*)+$/";
            ViewBag.Precio = @"/^([0-9.,]*)+$/"; 
            ViewBag.Dimenciones = @"/^([A-Z0-9]*[a-z/.,#]+[\s]*)+$/";
            return View();
        }

        // POST: Items/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,Precio,Existencia,Duracion,EsArticulo")] Items items)
        {
            if (ModelState.IsValid)
            {
                BLL.ItemsBLL.Guardar(items);
                return RedirectToAction("Index");
            }

            return View(items);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Items items = BLL.ItemsBLL.Buscar(id);
            if (items == null)
            {
                return HttpNotFound();
            }
            return View(items);
        }

        // POST: Items/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,Precio,Existencia,Duracion,EsArticulo")] Items items)
        {
            if (ModelState.IsValid)
            {
                BLL.ItemsBLL.Modificar(items);
                return RedirectToAction("Index");
            }
            return View(items);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Items items = BLL.ItemsBLL.Buscar(id);
            if (items == null)
            {
                return HttpNotFound();
            }
            return View(items);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BLL.ItemsBLL.Eliminar(id);     
            return RedirectToAction("Index");
        }
    }
}
