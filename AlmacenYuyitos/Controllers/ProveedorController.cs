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
    public class ProveedorController : Controller
    {
        private YuyitosModel db = new YuyitosModel();

        // GET: Proveedor
        public ActionResult Index()
        {
            var pROVEEDOR = db.Proveedor.Include(p => p.COMUNA).Include(p => p.RUBRO);
            return View(pROVEEDOR.ToList());
        }

        // GET: Proveedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor pROVEEDOR = db.Proveedor.Find(id);
            if (pROVEEDOR == null)
            {
                return HttpNotFound();
            }
            return View(pROVEEDOR);
        }

        // GET: Proveedor/Create
        public ActionResult Create()
        {
            ViewBag.COMUNAID = new SelectList(db.Comuna, "COMUNAID", "NOMBRE");
            ViewBag.RUBROID = new SelectList(db.Rubro, "RUBROID", "NOMBRE");

            ViewBag.REGIONID = new SelectList(db.Region, "REGIONID", "NOMBRE");

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
        public ActionResult Create([Bind(Include = "PROVEEDORID,RUT,RAZONSOCIAL,TELEFONO,MAIL,CONTACTO,RUBROID,CALLE,NUMERO,COMUNAID,COMPLEMENTO")] Proveedor pROVEEDOR)
        {
            if (ModelState.IsValid)
            {
                db.Proveedor.Add(pROVEEDOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COMUNAID = new SelectList(db.Comuna, "COMUNAID", "NOMBRE", pROVEEDOR.COMUNAID);
            ViewBag.RUBROID = new SelectList(db.Rubro, "RUBROID", "NOMBRE", pROVEEDOR.RUBROID);

            RegionComunaViewModel RegionComunaViewModel = new RegionComunaViewModel();
            var listRegiones = RegionComunaViewModel.GetRegiones();
            ViewBag.listRegiones = listRegiones;

            return View(pROVEEDOR);
        }

        public JsonResult GetComunas(int RegionId)
        {
            RegionComunaViewModel RegionComunaViewModel = new RegionComunaViewModel();
            var listComunas = RegionComunaViewModel.GetComunas(RegionId);
            return Json(listComunas, JsonRequestBehavior.AllowGet);
        }

        // GET: Proveedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor pROVEEDOR = db.Proveedor.Find(id);
            if (pROVEEDOR == null)
            {
                return HttpNotFound();
            }
            ViewBag.COMUNAID = new SelectList(db.Comuna, "COMUNAID", "NOMBRE", pROVEEDOR.COMUNAID);
            ViewBag.RUBROID = new SelectList(db.Rubro, "RUBROID", "NOMBRE", pROVEEDOR.RUBROID);
            ViewBag.REGIONID = new SelectList(db.Region, "REGIONID", "NOMBRE", pROVEEDOR.COMUNA.REGIONID);

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
        public ActionResult Edit([Bind(Include = "PROVEEDORID,RUT,RAZONSOCIAL,TELEFONO,MAIL,CONTACTO,RUBROID,CALLE,NUMERO,COMUNAID,COMPLEMENTO")] Proveedor pROVEEDOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pROVEEDOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COMUNAID = new SelectList(db.Comuna, "COMUNAID", "NOMBRE", pROVEEDOR.COMUNAID);
            ViewBag.RUBROID = new SelectList(db.Rubro, "RUBROID", "NOMBRE", pROVEEDOR.RUBROID);

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
            Proveedor pROVEEDOR = db.Proveedor.Find(id);
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
            Proveedor pROVEEDOR = db.Proveedor.Find(id);
            db.Proveedor.Remove(pROVEEDOR);
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

        public JsonResult ValidacionRut(string RUT)
        {
            bool validacion = false;
            try
            {
                RUT = RUT.ToUpper();
                RUT = RUT.Replace(".", "");
                RUT = RUT.Replace("-", "");
                int rutAux = int.Parse(RUT.Substring(0, RUT.Length - 1));

                char dv = char.Parse(RUT.Substring(RUT.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception)
            {
            }

            return Json(validacion, JsonRequestBehavior.AllowGet);
        }
    }
}