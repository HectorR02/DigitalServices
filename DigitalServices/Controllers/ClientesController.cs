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
    public class ClientesController : Controller
    {

        [HttpGet]
        public JsonResult Listado()
        {
            List<Clientes> listado = BLL.ClientesBLL.Listar();
            if (listado.Count > 0)
                return Json(listado, JsonRequestBehavior.AllowGet);
            return Json(null, JsonRequestBehavior.DenyGet);
        }

        [HttpGet]
        public JsonResult Buscar(int? clienteId)
        {
            var cliente = BLL.ClientesBLL.Buscar(clienteId);
            return Json(cliente, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Guardar(Clientes cliente)
        {
            bool res = false;
            if (ModelState.IsValid)
            {
                res = BLL.ClientesBLL.Guardar(cliente);
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Modificar(Clientes cliente)
        {
            bool res = false;
            if (ModelState.IsValid)
            {
                if (BLL.ClientesBLL.Buscar(cliente.IdCliente) != null)
                    res = BLL.ClientesBLL.Modificar(cliente);
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Eliminar(Clientes cliente)
        {
            bool res = false;
            if (ModelState.IsValid)
            {
                if (BLL.ClientesBLL.Buscar(cliente.IdCliente) != null)
                    res = BLL.ClientesBLL.Eliminar(cliente);
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        // GET: Clientes
        public ActionResult Index()
        {
            return View(BLL.ClientesBLL.Listar());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = BLL.ClientesBLL.Buscar(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCliente,Nombres,Direccion,Email,Telefono")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                BLL.ClientesBLL.Guardar(clientes);
                return RedirectToAction("Index");
            }

            return View(clientes);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = BLL.ClientesBLL.Buscar(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCliente,Nombres,Direccion,Email,Telefono")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                BLL.ClientesBLL.Modificar(clientes);
                return RedirectToAction("Index");
            }
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = BLL.ClientesBLL.Buscar(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BLL.ClientesBLL.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}
