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
    public class ProductoFamiliaController : Controller
    {
        private YuyitosModel db = new YuyitosModel();

        // GET: ProductoFamilia
        public ActionResult Index()
        {
            return View(db.FAMILIAPRODUCTO.ToList());
        }

        // GET: ProductoFamilia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAMILIAPRODUCTO fAMILIAPRODUCTO = db.FAMILIAPRODUCTO.Find(id);
            if (fAMILIAPRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(fAMILIAPRODUCTO);
        }

        // GET: ProductoFamilia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoFamilia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FAMILIAPRODUCTOID,DESCRIPCION")] FAMILIAPRODUCTO fAMILIAPRODUCTO)
        {
            if (ModelState.IsValid)
            {
                db.FAMILIAPRODUCTO.Add(fAMILIAPRODUCTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fAMILIAPRODUCTO);
        }

        // GET: ProductoFamilia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAMILIAPRODUCTO fAMILIAPRODUCTO = db.FAMILIAPRODUCTO.Find(id);
            if (fAMILIAPRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(fAMILIAPRODUCTO);
        }

        // POST: ProductoFamilia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FAMILIAPRODUCTOID,DESCRIPCION")] FAMILIAPRODUCTO fAMILIAPRODUCTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fAMILIAPRODUCTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fAMILIAPRODUCTO);
        }

        // GET: ProductoFamilia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAMILIAPRODUCTO fAMILIAPRODUCTO = db.FAMILIAPRODUCTO.Find(id);
            if (fAMILIAPRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(fAMILIAPRODUCTO);
        }

        // POST: ProductoFamilia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FAMILIAPRODUCTO fAMILIAPRODUCTO = db.FAMILIAPRODUCTO.Find(id);
            db.FAMILIAPRODUCTO.Remove(fAMILIAPRODUCTO);
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
