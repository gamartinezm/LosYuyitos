using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlmacenYuyitos.Models;

namespace AlmacenYuyitos.Controllers
{
    [Authorize]
    public class OrdenPedidoController : Controller
    {
        private YuyitosModel db = new YuyitosModel();

        [HttpPost]
        public ActionResult GetDetalle(int proveedorId)
        {

            var oRDENPEDIDO = db.OrdenPedido.Include(o => o.ORDENESTADO).Include(o => o.PROVEEDOR).Where(d => d.PROVEEDOR_PROVEEDORID == proveedorId);
            return View(oRDENPEDIDO.ToList());

            //ViewBag.FAMILIAPRODUCTOID = new SelectList(db.FAMILIAPRODUCTO, "FAMILIAPRODUCTOID", "DESCRIPCION");
            //ViewBag.ORDENPEDIDO_ORDENPEDIDOID = new SelectList(db.ORDENPEDIDO, "ORDENPEDIDOID", "ORDENESTADO_ESTADO");
            //ViewBag.TIPOPRODUCTO_TIPOPRODUCTOID = new SelectList(db.TIPOPRODUCTO, "TIPOPRODUCTOID", "UNIDADMEDIDA");
            ////ViewBag.PROVEEDORID = new SelectList(db.PROVEEDOR, "PROVEEDORID", "RAZONSOCIAL");
            //ViewBag.ORDENPEDIDOID = new SelectList(db.ORDENPEDIDO, "ORDENPEDIDOID", "ORDENPEDIDOID");
            //ViewBag.DETALLEPEDIDOID = new SelectList(db.DETALLEPEDIDO, "ORDENPEDIDO_ORDENPEDIDOID", "ORDENPEDIDO_ORDENPEDIDOID");

            ////ViewBag.PROVEEDOR_PROVEEDORID = new SelectList(db.PROVEEDOR, "PROVEEDORID", "RUT");

            //ViewBag.PROVEEDOR_PROVEEDORID = new SelectList(db.ORDENPEDIDO, "PROVEEDOR_PROVEEDORID", "RAZONSOCIAL");

            //ViewBag.FAMILIAPRODUCTOID = new SelectList(db.FAMILIAPRODUCTO, "FAMILIAPRODUCTOID", "DESCRIPCION");
            //ViewBag.ORDENPEDIDO_ORDENPEDIDOID = new SelectList(db.ORDENPEDIDO, "ORDENPEDIDOID", "ORDENESTADO_ESTADO");
            //ViewBag.TIPOPRODUCTO_TIPOPRODUCTOID = new SelectList(db.TIPOPRODUCTO, "TIPOPRODUCTOID", "UNIDADMEDIDA");

            //OrdenCompraViewModel OrdenCompraViewModel = new OrdenCompraViewModel();
            //var listOrdenes = OrdenCompraViewModel.GetProveedor();
            //ViewBag.listOrdenes = listOrdenes;

            //return View();

        }

        // GET: ORDENPEDIDO
        public ActionResult Index()
        {
            var oRDENPEDIDO = db.OrdenPedido.Include(o => o.ORDENESTADO).Include(o => o.PROVEEDOR);
            return View(oRDENPEDIDO.ToList());
        }

        // GET: ORDENPEDIDO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenPedido oRDENPEDIDO = db.OrdenPedido.Find(id);
            if (oRDENPEDIDO == null)
            {
                return HttpNotFound();
            }
            return View(oRDENPEDIDO);
        }

        // GET: ORDENPEDIDO/Create
        public ActionResult Create()
        {
            ViewBag.ORDENESTADO_ESTADO = new SelectList(db.OrdenEstado, "ESTADO", "ESTADO");
            ViewBag.PROVEEDOR_PROVEEDORID = new SelectList(db.Proveedor, "PROVEEDORID", "RAZONSOCIAL");
            return View();
        }

        // POST: ORDENPEDIDO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ORDENPEDIDOID,FECHACREACION,ORDENESTADO_ESTADO,PROVEEDOR_PROVEEDORID")] OrdenPedido oRDENPEDIDO)
        {
            if (ModelState.IsValid)
            {
                db.OrdenPedido.Add(oRDENPEDIDO);
                db.SaveChanges();
                return RedirectToAction("Create","DetallePedido");
            }

            ViewBag.ORDENESTADO_ESTADO = new SelectList(db.OrdenEstado, "ESTADO", "ESTADO", oRDENPEDIDO.ORDENESTADO_ESTADO);
            ViewBag.PROVEEDOR_PROVEEDORID = new SelectList(db.Proveedor, "PROVEEDORID", "RUT", oRDENPEDIDO.PROVEEDOR_PROVEEDORID);
            return View(oRDENPEDIDO);
        }

        // GET: ORDENPEDIDO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenPedido oRDENPEDIDO = db.OrdenPedido.Find(id);
            if (oRDENPEDIDO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ORDENESTADO_ESTADO = new SelectList(db.OrdenEstado, "ESTADO", "ESTADO", oRDENPEDIDO.ORDENESTADO_ESTADO);
            ViewBag.PROVEEDOR_PROVEEDORID = new SelectList(db.Proveedor, "PROVEEDORID", "RUT", oRDENPEDIDO.PROVEEDOR_PROVEEDORID);
            return View(oRDENPEDIDO);
        }

        // POST: ORDENPEDIDO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ORDENPEDIDOID,FECHACREACION,ORDENESTADO_ESTADO,PROVEEDOR_PROVEEDORID")] OrdenPedido oRDENPEDIDO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oRDENPEDIDO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ORDENESTADO_ESTADO = new SelectList(db.OrdenEstado, "ESTADO", "ESTADO", oRDENPEDIDO.ORDENESTADO_ESTADO);
            ViewBag.PROVEEDOR_PROVEEDORID = new SelectList(db.Proveedor, "PROVEEDORID", "RUT", oRDENPEDIDO.PROVEEDOR_PROVEEDORID);
            return View(oRDENPEDIDO);
        }

        // GET: ORDENPEDIDO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenPedido oRDENPEDIDO = db.OrdenPedido.Find(id);
            if (oRDENPEDIDO == null)
            {
                return HttpNotFound();
            }
            return View(oRDENPEDIDO);
        }

        // POST: ORDENPEDIDO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdenPedido oRDENPEDIDO = db.OrdenPedido.Find(id);
            db.OrdenPedido.Remove(oRDENPEDIDO);
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
