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
    public class RubroController : Controller
    {
        private YuyitosModel db = new YuyitosModel();

        // GET: Rubro
        public ActionResult Index()
        {
            return View(db.RUBRO.ToList());
        }

        // GET: Rubro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RUBRO rUBRO = db.RUBRO.Find(id);
            if (rUBRO == null)
            {
                return HttpNotFound();
            }
            return View(rUBRO);
        }

        // GET: Rubro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rubro/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RUBROID,NOMBRE,DESCRIPCION")] RUBRO rUBRO)
        {
            if (ModelState.IsValid)
            {
                db.RUBRO.Add(rUBRO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rUBRO);
        }

        // GET: Rubro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RUBRO rUBRO = db.RUBRO.Find(id);
            if (rUBRO == null)
            {
                return HttpNotFound();
            }
            return View(rUBRO);
        }

        // POST: Rubro/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RUBROID,NOMBRE,DESCRIPCION")] RUBRO rUBRO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rUBRO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rUBRO);
        }

        // GET: Rubro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RUBRO rUBRO = db.RUBRO.Find(id);
            if (rUBRO == null)
            {
                return HttpNotFound();
            }
            return View(rUBRO);
        }

        // POST: Rubro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RUBRO rUBRO = db.RUBRO.Find(id);
            db.RUBRO.Remove(rUBRO);
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
