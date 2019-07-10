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
    public class VentaDetalleController : Controller
    {
        private YuyitosModel db = new YuyitosModel();

        [HttpPost]
        // GET: VentaDetalle
        public ActionResult Index(int ordenId)
        {
            var vENTADETALLE = db.VentaDetalle.Where(v => v.CLIENTE.PERSONAID == ordenId);
            //var vENTADETALLE = db.VENTADETALLE.Find(ordenId);
            return View(vENTADETALLE.ToList());
        }

        // GET: VentaDetalle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaDetalle vENTADETALLE = db.VentaDetalle.Find(id);
            if (vENTADETALLE == null)
            {
                return HttpNotFound();
            }
            return View(vENTADETALLE);
        }

        // GET: VentaDetalle/Create
        public ActionResult Create()
        {
            ViewBag.CLIENTEID = new SelectList(db.Cliente, "CLIENTEID", "CLIENTEID");
            ViewBag.PRODUCTO_PRODUCTOID = new SelectList(db.Producto, "PRODUCTOID", "PRODUCTOID");
            return View();
        }

        // POST: VentaDetalle/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VENTADETALLEID,PRODUCTOID,CLIENTEID,PRODUCTO_PRODUCTOID")] VentaDetalle vENTADETALLE)
        {
            if (ModelState.IsValid)
            {
                db.VentaDetalle.Add(vENTADETALLE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CLIENTEID = new SelectList(db.Cliente, "CLIENTEID", "CLIENTEID", vENTADETALLE.CLIENTEID);
            ViewBag.PRODUCTO_PRODUCTOID = new SelectList(db.Producto, "PRODUCTOID", "PRODUCTOID", vENTADETALLE.PRODUCTO_PRODUCTOID);
            return View(vENTADETALLE);
        }

        // GET: VentaDetalle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaDetalle vENTADETALLE = db.VentaDetalle.Find(id);
            if (vENTADETALLE == null)
            {
                return HttpNotFound();
            }
            ViewBag.CLIENTEID = new SelectList(db.Cliente, "CLIENTEID", "CLIENTEID", vENTADETALLE.CLIENTEID);
            ViewBag.PRODUCTO_PRODUCTOID = new SelectList(db.Producto, "PRODUCTOID", "PRODUCTOID", vENTADETALLE.PRODUCTO_PRODUCTOID);
            return View(vENTADETALLE);
        }

        // POST: VentaDetalle/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VENTADETALLEID,PRODUCTOID,CLIENTEID,PRODUCTO_PRODUCTOID")] VentaDetalle vENTADETALLE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vENTADETALLE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CLIENTEID = new SelectList(db.Cliente, "CLIENTEID", "CLIENTEID", vENTADETALLE.CLIENTEID);
            ViewBag.PRODUCTO_PRODUCTOID = new SelectList(db.Producto, "PRODUCTOID", "PRODUCTOID", vENTADETALLE.PRODUCTO_PRODUCTOID);
            return View(vENTADETALLE);
        }

        // GET: VentaDetalle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaDetalle vENTADETALLE = db.VentaDetalle.Find(id);
            if (vENTADETALLE == null)
            {
                return HttpNotFound();
            }
            return View(vENTADETALLE);
        }

        // POST: VentaDetalle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VentaDetalle vENTADETALLE = db.VentaDetalle.Find(id);
            db.VentaDetalle.Remove(vENTADETALLE);
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
