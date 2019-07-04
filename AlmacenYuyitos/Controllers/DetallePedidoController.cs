using System;
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
    public class DetallePedidoController : Controller
    {
        private YuyitosModel db = new YuyitosModel();

        public JsonResult GetOrdenes(int PROVEEDORID)
        {
            OrdenCompraViewModel OrdenCompraViewModel = new OrdenCompraViewModel();
            var listOrdenes = OrdenCompraViewModel.GetOrdenPedido(PROVEEDORID);
            return Json(listOrdenes, JsonRequestBehavior.AllowGet);
        }

        // GET: DetallePedido
        public ActionResult Index()
        {
            var dETALLEPEDIDO = db.DETALLEPEDIDO.Include(d => d.FAMILIAPRODUCTO).Include(d => d.ORDENPEDIDO).Include(d => d.TIPOPRODUCTO);
            return View(dETALLEPEDIDO.ToList());

        }

        // GET: DetallePedido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLEPEDIDO dETALLEPEDIDO = db.DETALLEPEDIDO.Find(id);
            if (dETALLEPEDIDO == null)
            {
                return HttpNotFound();
            }
            return View(dETALLEPEDIDO);
        }

        // GET: DetallePedido/Create
        public ActionResult Create()
        {
            ViewBag.FAMILIAPRODUCTOID = new SelectList(db.FAMILIAPRODUCTO, "FAMILIAPRODUCTOID", "DESCRIPCION");
            ViewBag.ORDENPEDIDO_ORDENPEDIDOID = new SelectList(db.ORDENPEDIDO, "ORDENPEDIDOID", "ORDENESTADO_ESTADO");
            ViewBag.TIPOPRODUCTO_TIPOPRODUCTOID = new SelectList(db.TIPOPRODUCTO, "TIPOPRODUCTOID", "UNIDADMEDIDA");
            ViewBag.PROVEEDORID = new SelectList(db.PROVEEDOR, "PROVEEDORID", "RAZONSOCIAL");
            ViewBag.ORDENPEDIDOID = new SelectList(db.ORDENPEDIDO, "ORDENPEDIDOID", "ORDENPEDIDOID");
            ViewBag.DETALLEPEDIDOID = new SelectList(db.DETALLEPEDIDO, "ORDENPEDIDO_ORDENPEDIDOID", "ORDENPEDIDO_ORDENPEDIDOID");

            OrdenCompraViewModel OrdenCompraViewModel = new OrdenCompraViewModel();
            var listOrdenes = OrdenCompraViewModel.GetProveedor();
            ViewBag.listOrdenes = listOrdenes;

            return View();

        }

        // POST: DetallePedido/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TIPOPRODUCTO_TIPOPRODUCTOID,ORDENPEDIDO_ORDENPEDIDOID,FAMILIAPRODUCTOID,CANTIDAD,PRECIOCOMPRA")] DETALLEPEDIDO dETALLEPEDIDO)
        {
            if (ModelState.IsValid)
            {
                db.DETALLEPEDIDO.Add(dETALLEPEDIDO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FAMILIAPRODUCTOID = new SelectList(db.FAMILIAPRODUCTO, "FAMILIAPRODUCTOID", "DESCRIPCION", dETALLEPEDIDO.FAMILIAPRODUCTOID);
            ViewBag.ORDENPEDIDO_ORDENPEDIDOID = new SelectList(db.ORDENPEDIDO, "ORDENPEDIDOID", "ORDENESTADO_ESTADO", dETALLEPEDIDO.ORDENPEDIDO_ORDENPEDIDOID);
            ViewBag.TIPOPRODUCTO_TIPOPRODUCTOID = new SelectList(db.TIPOPRODUCTO, "TIPOPRODUCTOID", "UNIDADMEDIDA", dETALLEPEDIDO.TIPOPRODUCTO_TIPOPRODUCTOID);

            OrdenCompraViewModel OrdenCompraViewModel = new OrdenCompraViewModel();
            var listOrdenes = OrdenCompraViewModel.GetProveedor();
            ViewBag.listOrdenes = listOrdenes;

            return View(dETALLEPEDIDO);
        }

        // GET: DetallePedido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLEPEDIDO dETALLEPEDIDO = db.DETALLEPEDIDO.Find(id);
            if (dETALLEPEDIDO == null)
            {
                return HttpNotFound();
            }
            ViewBag.FAMILIAPRODUCTOID = new SelectList(db.FAMILIAPRODUCTO, "FAMILIAPRODUCTOID", "DESCRIPCION", dETALLEPEDIDO.FAMILIAPRODUCTOID);
            ViewBag.ORDENPEDIDO_ORDENPEDIDOID = new SelectList(db.ORDENPEDIDO, "ORDENPEDIDOID", "ORDENESTADO_ESTADO", dETALLEPEDIDO.ORDENPEDIDO_ORDENPEDIDOID);
            ViewBag.TIPOPRODUCTO_TIPOPRODUCTOID = new SelectList(db.TIPOPRODUCTO, "TIPOPRODUCTOID", "UNIDADMEDIDA", dETALLEPEDIDO.TIPOPRODUCTO_TIPOPRODUCTOID);
            return View(dETALLEPEDIDO);
        }

        // POST: DetallePedido/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TIPOPRODUCTO_TIPOPRODUCTOID,ORDENPEDIDO_ORDENPEDIDOID,FAMILIAPRODUCTOID,CANTIDAD,PRECIOCOMPRA")] DETALLEPEDIDO dETALLEPEDIDO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dETALLEPEDIDO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FAMILIAPRODUCTOID = new SelectList(db.FAMILIAPRODUCTO, "FAMILIAPRODUCTOID", "DESCRIPCION", dETALLEPEDIDO.FAMILIAPRODUCTOID);
            ViewBag.ORDENPEDIDO_ORDENPEDIDOID = new SelectList(db.ORDENPEDIDO, "ORDENPEDIDOID", "ORDENESTADO_ESTADO", dETALLEPEDIDO.ORDENPEDIDO_ORDENPEDIDOID);
            ViewBag.TIPOPRODUCTO_TIPOPRODUCTOID = new SelectList(db.TIPOPRODUCTO, "TIPOPRODUCTOID", "UNIDADMEDIDA", dETALLEPEDIDO.TIPOPRODUCTO_TIPOPRODUCTOID);
            return View(dETALLEPEDIDO);
        }

        // GET: DetallePedido/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLEPEDIDO dETALLEPEDIDO = db.DETALLEPEDIDO.Find(id);
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
            DETALLEPEDIDO dETALLEPEDIDO = db.DETALLEPEDIDO.Find(id);
            db.DETALLEPEDIDO.Remove(dETALLEPEDIDO);
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
