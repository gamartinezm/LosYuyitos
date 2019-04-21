﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using LosYuyitos.Models;


namespace LosYuyitos.Controllers
{
    //[Authorize] //Se utiliza para bloquear el acceso a personas no registradas. Si es borrado o comentado, cualquier persona puede acceder a los datos.
    public class PersonaController : Controller
    {
        private YuyitosModel db = new YuyitosModel();

        // GET: Persona
        public ActionResult Index()
        {
            var pERSONA = db.PERSONA.OrderBy(x => x.PERSONAID).Include(p => p.COMUNA).Include(p => p.GENERO1).Include(p => p.COMUNA.REGION);
            return View(pERSONA.ToList());
        }

        // GET: Persona/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSONA pERSONA = db.PERSONA.Find(id);
            if (pERSONA == null)
            {
                return HttpNotFound();
            }
            return View(pERSONA);
        }


        // GET: Persona/Create
        public ActionResult Create()
        {

            ViewBag.COMUNAID = new SelectList(db.COMUNA, "COMUNAID", "NOMBRE");
            ViewBag.GENERO = new SelectList(db.GENERO, "GENEROID", "NOMBRE");
            ViewBag.REGIONID = new SelectList(db.REGION, "REGIONID", "NOMBRE");

            RegionComunaViewModel RegionComunaViewModel = new RegionComunaViewModel();
            var listRegiones = RegionComunaViewModel.GetRegiones();
            ViewBag.listRegiones = listRegiones;

            return View();
        }

        // POST: Persona/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PERSONAID,NOMBRE,APPATERNO,APMATERNO,RUT,GENERO,FECHANACIMIENTO,CALLE,NUMERO,COMUNAID")] PERSONA pERSONA)
        {
            if (ModelState.IsValid)
            {
                db.PERSONA.Add(pERSONA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COMUNAID = new SelectList(db.COMUNA, "COMUNAID", "NOMBRE", pERSONA.COMUNAID);
            ViewBag.GENERO = new SelectList(db.GENERO, "GENEROID", "NOMBRE", pERSONA.GENERO);
            ViewBag.REGIONID = new SelectList(db.REGION, "REGIONID", "NOMBRE", pERSONA.COMUNA.REGIONID);

            RegionComunaViewModel RegionComunaViewModel = new RegionComunaViewModel();
            var listRegiones = RegionComunaViewModel.GetRegiones();
            ViewBag.listRegiones = listRegiones;

            return View(pERSONA);
        }

        public JsonResult GetComunas(int REGIONID)
        {
            RegionComunaViewModel RegionComunaViewModel = new RegionComunaViewModel();
            var listComunas = RegionComunaViewModel.GetComunas(REGIONID);
            return Json(listComunas, JsonRequestBehavior.AllowGet);
        }

        // GET: Persona/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSONA pERSONA = db.PERSONA.Find(id);
            if (pERSONA == null)
            {
                return HttpNotFound();
            }
            ViewBag.COMUNAID = new SelectList(db.COMUNA, "COMUNAID", "NOMBRE", pERSONA.COMUNAID);
            ViewBag.GENERO = new SelectList(db.GENERO, "GENEROID", "NOMBRE", pERSONA.GENERO);

            RegionComunaViewModel RegionComunaViewModel = new RegionComunaViewModel();
            var listRegiones = RegionComunaViewModel.GetRegiones();
            ViewBag.listRegiones = listRegiones;

            return View(pERSONA);
        }

        public void Editar(int id)
        {
            if (id == null)
            {
                new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSONA pERSONA = db.PERSONA.Find(id);
            if (pERSONA == null)
            {
                HttpNotFound();
            }
            ViewBag.COMUNAID = new SelectList(db.COMUNA, "COMUNAID", "NOMBRE", pERSONA.COMUNAID);
            ViewBag.GENERO = new SelectList(db.GENERO, "GENEROID", "NOMBRE", pERSONA.GENERO);
            View(pERSONA);
        }

        // POST: Persona/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PERSONAID,NOMBRE,APPATERNO,APMATERNO,RUT,GENERO,FECHANACIMIENTO,CALLE,NUMERO,COMUNAID")] PERSONA pERSONA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pERSONA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COMUNAID = new SelectList(db.COMUNA, "COMUNAID", "NOMBRE", pERSONA.COMUNAID);
            ViewBag.GENERO = new SelectList(db.GENERO, "GENEROID", "NOMBRE", pERSONA.GENERO);
            return View(pERSONA);
        }

        // GET: Persona/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSONA pERSONA = db.PERSONA.Find(id);
            if (pERSONA == null)
            {
                return HttpNotFound();
            }
            return View(pERSONA);
        }

        // POST: Persona/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PERSONA pERSONA = db.PERSONA.Find(id);
            db.PERSONA.Remove(pERSONA);
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
