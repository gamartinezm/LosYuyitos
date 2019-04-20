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
    //[Authorize] //Se utiliza para bloquear el acceso a personas no registradas. Si es borrado o comentado, cualquier persona puede acceder a los datos.
    public class PersonaController : Controller
    {
        private YuyitosModel db = new YuyitosModel();

        // GET: Persona
        public ActionResult Index()
        {
            var pERSONA = db.PERSONA.Include(p => p.COMUNA).Include(p => p.GENERO1).Include(p => p.COMUNA.REGION);
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

            return View(pERSONA);
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

    }
}
