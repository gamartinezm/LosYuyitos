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
    public class ProveedorController : Controller
    {
        private YuyitosModel db = new YuyitosModel();

        // GET: Proveedor
        public ActionResult Index()
        {
            var pROVEEDOR = db.PROVEEDOR.Include(p => p.COMUNA).Include(p => p.RUBRO).Include(p => p.COMUNA.REGION);
            return View(pROVEEDOR.ToList());
        }

        // GET: Proveedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROVEEDOR pROVEEDOR = db.PROVEEDOR.Find(id);
            if (pROVEEDOR == null)
            {
                return HttpNotFound();
            }
            return View(pROVEEDOR);
        }

        // GET: Proveedor/Create
        public ActionResult Create()
        {
            ViewBag.COMUNAID = new SelectList(db.COMUNA, "COMUNAID", "NOMBRE");
            ViewBag.RUBROID = new SelectList(db.RUBRO, "RUBROID", "NOMBRE");
            ViewBag.REGIONID = new SelectList(db.REGION, "REGIONID", "NOMBRE");

            RegionComunaViewModel RegionComunaViewModel = new RegionComunaViewModel();
            var listRegiones = RegionComunaViewModel.GetRegiones();
            ViewBag.listRegiones = listRegiones;

            return View();
        }

        // POST: Proveedor/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "PROVEEDORID,RUT,RAZONSOCIAL,TELEFONO,MAIL,CONTACTO,RUBROID,CALLE,NUMERO,COMUNAID,SITIOWEB")] PROVEEDOR pROVEEDOR)
        public ActionResult Create([Bind(Include = "PROVEEDORID,RUT,RAZONSOCIAL,TELEFONO,MAIL,CONTACTO,RUBROID,CALLE,NUMERO,COMUNAID")] PROVEEDOR pROVEEDOR)
        {
            if (ModelState.IsValid)
            {
                db.PROVEEDOR.Add(pROVEEDOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COMUNAID = new SelectList(db.COMUNA, "COMUNAID", "NOMBRE", pROVEEDOR.COMUNAID);
            ViewBag.RUBROID = new SelectList(db.RUBRO, "RUBROID", "NOMBRE", pROVEEDOR.RUBROID);
            ViewBag.REGIONID = new SelectList(db.REGION, "REGIONID", "NOMBRE", pROVEEDOR.COMUNA.REGIONID);

            RegionComunaViewModel RegionComunaViewModel = new RegionComunaViewModel();
            var listRegiones = RegionComunaViewModel.GetRegiones();
            ViewBag.listRegiones = listRegiones;

            return View(pROVEEDOR);
        }

        public JsonResult GetComunas(int REGIONID)
        {
            RegionComunaViewModel RegionComunaViewModel = new RegionComunaViewModel();
            var listComunas = RegionComunaViewModel.GetComunas(REGIONID);
            return Json(listComunas, JsonRequestBehavior.AllowGet);
        }

        // GET: Proveedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROVEEDOR pROVEEDOR = db.PROVEEDOR.Find(id);
            if (pROVEEDOR == null)
            {
                return HttpNotFound();
            }
            ViewBag.COMUNAID = new SelectList(db.COMUNA, "COMUNAID", "NOMBRE", pROVEEDOR.COMUNAID);
            ViewBag.RUBROID = new SelectList(db.RUBRO, "RUBROID", "NOMBRE", pROVEEDOR.RUBROID);

            RegionComunaViewModel RegionComunaViewModel = new RegionComunaViewModel();
            var listRegiones = RegionComunaViewModel.GetRegiones();
            ViewBag.listRegiones = listRegiones;

            return View(pROVEEDOR);
        }

        // POST: Proveedor/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "PROVEEDORID,RUT,RAZONSOCIAL,TELEFONO,MAIL,CONTACTO,RUBROID,CALLE,NUMERO,COMUNAID,SITIOWEB")] PROVEEDOR pROVEEDOR)
        public ActionResult Edit([Bind(Include = "PROVEEDORID,RUT,RAZONSOCIAL,TELEFONO,MAIL,CONTACTO,RUBROID,CALLE,NUMERO,COMUNAID")] PROVEEDOR pROVEEDOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pROVEEDOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COMUNAID = new SelectList(db.COMUNA, "COMUNAID", "NOMBRE", pROVEEDOR.COMUNAID);
            ViewBag.RUBROID = new SelectList(db.RUBRO, "RUBROID", "NOMBRE", pROVEEDOR.RUBROID);

            RegionComunaViewModel RegionComunaViewModel = new RegionComunaViewModel();
            var listRegiones = RegionComunaViewModel.GetRegiones();
            ViewBag.listRegiones = listRegiones;

            return View(pROVEEDOR);
        }

        // GET: Proveedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROVEEDOR pROVEEDOR = db.PROVEEDOR.Find(id);
            if (pROVEEDOR == null)
            {
                return HttpNotFound();
            }
            return View(pROVEEDOR);
        }

        // POST: Proveedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PROVEEDOR pROVEEDOR = db.PROVEEDOR.Find(id);
            db.PROVEEDOR.Remove(pROVEEDOR);
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
