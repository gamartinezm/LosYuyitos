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
    public class ProductoController : Controller
    {
        private YuyitosModel db = new YuyitosModel();

        // GET: Producto
        public ActionResult Index()
        {
            var pRODUCTO = db.PRODUCTO.Include(p => p.FAMILIAPRODUCTO).Include(p => p.PROVEEDOR).Include(p => p.TIPOPRODUCTO);
            return View(pRODUCTO.ToList());
        }

        // GET: Producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTO);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            ViewBag.FAMILIAPRODUCTOID = new SelectList(db.FAMILIAPRODUCTO, "FAMILIAPRODUCTOID", "DESCRIPCION");
            ViewBag.PROVEEDOR_PROVEEDORID = new SelectList(db.PROVEEDOR, "PROVEEDORID", "RUT");
            ViewBag.TIPOPRODUCTO_TIPOPRODUCTOID = new SelectList(db.TIPOPRODUCTO, "TIPOPRODUCTOID", "UNIDADMEDIDA");
            return View();
        }

        // POST: Producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRODUCTOID,PRECIOVENTA,PRECIOCOMPRA,STOCK,STOCKCRITICO,TIPOPRODUCTO_TIPOPRODUCTOID,FECHAVENCIMIENTO,PROVEEDOR_PROVEEDORID,FAMILIAPRODUCTOID")] PRODUCTO pRODUCTO)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCTO.Add(pRODUCTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FAMILIAPRODUCTOID = new SelectList(db.FAMILIAPRODUCTO, "FAMILIAPRODUCTOID", "DESCRIPCION", pRODUCTO.FAMILIAPRODUCTOID);
            ViewBag.PROVEEDOR_PROVEEDORID = new SelectList(db.PROVEEDOR, "PROVEEDORID", "RUT", pRODUCTO.PROVEEDOR_PROVEEDORID);
            ViewBag.TIPOPRODUCTO_TIPOPRODUCTOID = new SelectList(db.TIPOPRODUCTO, "TIPOPRODUCTOID", "UNIDADMEDIDA", pRODUCTO.TIPOPRODUCTO_TIPOPRODUCTOID);
            return View(pRODUCTO);
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.FAMILIAPRODUCTOID = new SelectList(db.FAMILIAPRODUCTO, "FAMILIAPRODUCTOID", "DESCRIPCION", pRODUCTO.FAMILIAPRODUCTOID);
            ViewBag.PROVEEDOR_PROVEEDORID = new SelectList(db.PROVEEDOR, "PROVEEDORID", "RUT", pRODUCTO.PROVEEDOR_PROVEEDORID);
            ViewBag.TIPOPRODUCTO_TIPOPRODUCTOID = new SelectList(db.TIPOPRODUCTO, "TIPOPRODUCTOID", "UNIDADMEDIDA", pRODUCTO.TIPOPRODUCTO_TIPOPRODUCTOID);
            return View(pRODUCTO);
        }

        // POST: Producto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRODUCTOID,PRECIOVENTA,PRECIOCOMPRA,STOCK,STOCKCRITICO,TIPOPRODUCTO_TIPOPRODUCTOID,FECHAVENCIMIENTO,PROVEEDOR_PROVEEDORID,FAMILIAPRODUCTOID")] PRODUCTO pRODUCTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FAMILIAPRODUCTOID = new SelectList(db.FAMILIAPRODUCTO, "FAMILIAPRODUCTOID", "DESCRIPCION", pRODUCTO.FAMILIAPRODUCTOID);
            ViewBag.PROVEEDOR_PROVEEDORID = new SelectList(db.PROVEEDOR, "PROVEEDORID", "RUT", pRODUCTO.PROVEEDOR_PROVEEDORID);
            ViewBag.TIPOPRODUCTO_TIPOPRODUCTOID = new SelectList(db.TIPOPRODUCTO, "TIPOPRODUCTOID", "UNIDADMEDIDA", pRODUCTO.TIPOPRODUCTO_TIPOPRODUCTOID);
            return View(pRODUCTO);
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTO);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            db.PRODUCTO.Remove(pRODUCTO);
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
