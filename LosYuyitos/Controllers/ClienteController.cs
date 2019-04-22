using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LosYuyitos.Models;

namespace LosYuyitos.Controllers
{
    public class ClienteController : Controller
    {
        private YuyitosModel db = new YuyitosModel();

        // GET: Cliente
        public ActionResult Index()
        {
            var cLIENTE = db.CLIENTE.Include(c => c.CATEGORIA).Include(c => c.PERSONA);
            return View(cLIENTE.ToList());
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE cLIENTE = db.CLIENTE.Find(id);
            if (cLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(cLIENTE);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            ViewBag.CATEGORIAID = new SelectList(db.CATEGORIA, "CATEGORIAID", "NOMBRE");
            ViewBag.PERSONAID = new SelectList(db.PERSONA, "PERSONAID", "NOMBRE");
            return View();
        }

        // POST: Cliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CLIENTEID,PERSONAID,CATEGORIAID,FECHACREACION")] CLIENTE cLIENTE)
        {
            if (ModelState.IsValid)
            {
                db.CLIENTE.Add(cLIENTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CATEGORIAID = new SelectList(db.CATEGORIA, "CATEGORIAID", "NOMBRE", cLIENTE.CATEGORIAID);
            ViewBag.PERSONAID = new SelectList(db.PERSONA, "PERSONAID", "NOMBRE", cLIENTE.PERSONAID);
            return View(cLIENTE);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE cLIENTE = db.CLIENTE.Find(id);
            if (cLIENTE == null)
            {
                return HttpNotFound();
            }
            ViewBag.CATEGORIAID = new SelectList(db.CATEGORIA, "CATEGORIAID", "NOMBRE", cLIENTE.CATEGORIAID);
            ViewBag.PERSONAID = new SelectList(db.PERSONA, "PERSONAID", "NOMBRE", cLIENTE.PERSONAID);
            return View(cLIENTE);
        }

        // POST: Cliente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CLIENTEID,PERSONAID,CATEGORIAID,FECHACREACION")] CLIENTE cLIENTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLIENTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CATEGORIAID = new SelectList(db.CATEGORIA, "CATEGORIAID", "NOMBRE", cLIENTE.CATEGORIAID);
            ViewBag.PERSONAID = new SelectList(db.PERSONA, "PERSONAID", "NOMBRE", cLIENTE.PERSONAID);
            return View(cLIENTE);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE cLIENTE = db.CLIENTE.Find(id);
            if (cLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(cLIENTE);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CLIENTE cLIENTE = db.CLIENTE.Find(id);
            db.CLIENTE.Remove(cLIENTE);
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
