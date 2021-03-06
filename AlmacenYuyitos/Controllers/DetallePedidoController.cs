﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlmacenYuyitos.Models;
using OfficeOpenXml;
using System.Drawing;

namespace AlmacenYuyitos.Controllers
{
    [Authorize]
    public class DetallePedidoController : Controller
    {
        private YuyitosModel db = new YuyitosModel();

        public JsonResult GetOrdenes(int PROVEEDORID)
        {
            OrdenCompraViewModel OrdenCompraViewModel = new OrdenCompraViewModel();
            var listOrdenes = OrdenCompraViewModel.GetOrdenPedido(PROVEEDORID).ToList();
            var item = new SelectListItem() { Value = "0", Selected = true, Text = "Seleccionar Orden" };
            listOrdenes.Insert(0, item);
            return Json(listOrdenes, JsonRequestBehavior.AllowGet);
        }

        // GET: DetallePedido
        public ActionResult Index()
        {
            //var dETALLEPEDIDO = db.DETALLEPEDIDO.Include(d => d.FAMILIAPRODUCTO).Include(d => d.ORDENPEDIDO).Include(d => d.TIPOPRODUCTO);
            //return View(dETALLEPEDIDO.ToList());
            ViewBag.FAMILIAPRODUCTOID = new SelectList(db.FamiliaProducto, "FAMILIAPRODUCTOID", "DESCRIPCION");
            ViewBag.ORDENPEDIDO_ORDENPEDIDOID = new SelectList(db.OrdenPedido, "ORDENPEDIDOID", "ORDENESTADO_ESTADO");
            ViewBag.TIPOPRODUCTO_TIPOPRODUCTOID = new SelectList(db.TipoProducto, "TIPOPRODUCTOID", "UNIDADMEDIDA");
            ViewBag.PROVEEDORID = new SelectList(db.Proveedor, "PROVEEDORID", "RAZONSOCIAL");
            ViewBag.ORDENPEDIDOID = new SelectList(db.OrdenPedido, "ORDENPEDIDOID", "ORDENPEDIDOID");
            ViewBag.DETALLEPEDIDOID = new SelectList(db.DetallePedido, "ORDENPEDIDO_ORDENPEDIDOID", "ORDENPEDIDO_ORDENPEDIDOID");

            OrdenCompraViewModel OrdenCompraViewModel = new OrdenCompraViewModel();
            var listOrdenes = OrdenCompraViewModel.GetProveedor();
            ViewBag.listOrdenes = listOrdenes;

            return View();

        }

        // GET: DetallePedido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallePedido dETALLEPEDIDO = db.DetallePedido.Find(id);
            if (dETALLEPEDIDO == null)
            {
                return HttpNotFound();
            }
            return View(dETALLEPEDIDO);
        }

        // GET: DetallePedido/Create
        public ActionResult Create()
        {
            var ordenMax = db.OrdenPedido.Max(d => d.ORDENPEDIDOID);

            ViewBag.ORDENPEDIDO_ORDENPEDIDOID = ordenMax ;
            ViewBag.FAMILIAPRODUCTOID = new SelectList(db.FamiliaProducto, "FAMILIAPRODUCTOID", "DESCRIPCION");
            //ViewBag.ORDENPEDIDO_ORDENPEDIDOID = new SelectList(db.ORDENPEDIDO, "ORDENPEDIDOID", "ORDENPEDIDOID");
            ViewBag.TIPOPRODUCTO_TIPOPRODUCTOID = new SelectList(db.TipoProducto, "TIPOPRODUCTOID", "UNIDADMEDIDA");

            return View();

        }


        // POST: DetallePedido/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TIPOPRODUCTO_TIPOPRODUCTOID,ORDENPEDIDO_ORDENPEDIDOID,FAMILIAPRODUCTOID,CANTIDAD,PRECIOCOMPRA")] DetallePedido dETALLEPEDIDO)
        {
            if (ModelState.IsValid)
            {
                db.DetallePedido.Add(dETALLEPEDIDO);
                db.SaveChanges();
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }

            ViewBag.FAMILIAPRODUCTOID = new SelectList(db.FamiliaProducto, "FAMILIAPRODUCTOID", "DESCRIPCION", dETALLEPEDIDO.FAMILIAPRODUCTOID);
            ViewBag.ORDENPEDIDO_ORDENPEDIDOID = new SelectList(db.OrdenPedido, "ORDENPEDIDOID", "ORDENESTADO_ESTADO", dETALLEPEDIDO.ORDENPEDIDO_ORDENPEDIDOID);
            ViewBag.TIPOPRODUCTO_TIPOPRODUCTOID = new SelectList(db.TipoProducto, "TIPOPRODUCTOID", "UNIDADMEDIDA", dETALLEPEDIDO.TIPOPRODUCTO_TIPOPRODUCTOID);
            return View(dETALLEPEDIDO);
        }


        [HttpPost]
        public ActionResult GetDetalle(int ordenId)
        {

            var dETALLEPEDIDO = db.DetallePedido.Include(d => d.FAMILIAPRODUCTO).Include(d => d.ORDENPEDIDO).Include(d => d.TIPOPRODUCTO).Where(d => d.ORDENPEDIDO_ORDENPEDIDOID == ordenId);
            return View(dETALLEPEDIDO.ToList());

            //ViewBag.FAMILIAPRODUCTOID = new SelectList(db.FAMILIAPRODUCTO, "FAMILIAPRODUCTOID", "DESCRIPCION");
            //ViewBag.ORDENPEDIDO_ORDENPEDIDOID = new SelectList(db.ORDENPEDIDO, "ORDENPEDIDOID", "ORDENESTADO_ESTADO");
            //ViewBag.TIPOPRODUCTO_TIPOPRODUCTOID = new SelectList(db.TIPOPRODUCTO, "TIPOPRODUCTOID", "UNIDADMEDIDA");
            //ViewBag.PROVEEDORID = new SelectList(db.PROVEEDOR, "PROVEEDORID", "RAZONSOCIAL");
            //ViewBag.ORDENPEDIDOID = new SelectList(db.ORDENPEDIDO, "ORDENPEDIDOID", "ORDENPEDIDOID");
            //ViewBag.DETALLEPEDIDOID = new SelectList(db.DETALLEPEDIDO, "ORDENPEDIDO_ORDENPEDIDOID", "ORDENPEDIDO_ORDENPEDIDOID");

            //OrdenCompraViewModel OrdenCompraViewModel = new OrdenCompraViewModel();
            //var listOrdenes = OrdenCompraViewModel.GetProveedor();
            //ViewBag.listOrdenes = listOrdenes;

            //return View();

        }

        // GET: DetallePedido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallePedido dETALLEPEDIDO = db.DetallePedido.Find(id);
            if (dETALLEPEDIDO == null)
            {
                return HttpNotFound();
            }
            ViewBag.FAMILIAPRODUCTOID = new SelectList(db.FamiliaProducto, "FAMILIAPRODUCTOID", "DESCRIPCION", dETALLEPEDIDO.FAMILIAPRODUCTOID);
            ViewBag.ORDENPEDIDO_ORDENPEDIDOID = new SelectList(db.OrdenPedido, "ORDENPEDIDOID", "ORDENESTADO_ESTADO", dETALLEPEDIDO.ORDENPEDIDO_ORDENPEDIDOID);
            ViewBag.TIPOPRODUCTO_TIPOPRODUCTOID = new SelectList(db.TipoProducto, "TIPOPRODUCTOID", "UNIDADMEDIDA", dETALLEPEDIDO.TIPOPRODUCTO_TIPOPRODUCTOID);
            return View(dETALLEPEDIDO);
        }

        // POST: DetallePedido/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TIPOPRODUCTO_TIPOPRODUCTOID,ORDENPEDIDO_ORDENPEDIDOID,FAMILIAPRODUCTOID,CANTIDAD,PRECIOCOMPRA")] DetallePedido dETALLEPEDIDO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dETALLEPEDIDO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FAMILIAPRODUCTOID = new SelectList(db.FamiliaProducto, "FAMILIAPRODUCTOID", "DESCRIPCION", dETALLEPEDIDO.FAMILIAPRODUCTOID);
            ViewBag.ORDENPEDIDO_ORDENPEDIDOID = new SelectList(db.OrdenPedido, "ORDENPEDIDOID", "ORDENESTADO_ESTADO", dETALLEPEDIDO.ORDENPEDIDO_ORDENPEDIDOID);
            ViewBag.TIPOPRODUCTO_TIPOPRODUCTOID = new SelectList(db.TipoProducto, "TIPOPRODUCTOID", "UNIDADMEDIDA", dETALLEPEDIDO.TIPOPRODUCTO_TIPOPRODUCTOID);
            return View(dETALLEPEDIDO);
        }

        // GET: DetallePedido/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallePedido dETALLEPEDIDO = db.DetallePedido.Find(id);
            if (dETALLEPEDIDO == null)
            {
                return HttpNotFound();
            }
            return View(dETALLEPEDIDO);
        }

        // POST: DetallePedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetallePedido dETALLEPEDIDO = db.DetallePedido.Find(id);
            db.DetallePedido.Remove(dETALLEPEDIDO);
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
