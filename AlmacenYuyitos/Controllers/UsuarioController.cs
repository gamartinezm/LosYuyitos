using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AlmacenYuyitos.Models;

namespace AlmacenYuyitos.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        private YuyitosModel db = new YuyitosModel();

        // GET: Usuario
        public ActionResult LoginUsuario(string message = "")
        {
            ViewBag.Message = message;
            return View();
        }


        [HttpPost]
        public ActionResult LoginUsuario(string email, string password)
        {
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                var user = db.USUARIO.FirstOrDefault(u => u.EMAIL == email && u.PASSWORD == password);

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.EMAIL, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("LoginUsuario", "Usuario", new { Message = "Usuario no encontrado" });
                }
            }
            else
            {
                return RedirectToAction("LoginUsuario", "Usuario", new { Message = "Completar formulario" });
            }
            
        }

        public ActionResult LogoutUsuario()
        {
            FormsAuthentication.SignOut();
            return LoginUsuario();
        }

        public ActionResult VerifyUsuario(string correo, string clave)
        {
            if(!string.IsNullOrEmpty(correo) && !string.IsNullOrEmpty(clave))
            {
                var user = db.USUARIO.FirstOrDefault(u => u.EMAIL == correo && u.PASSWORD == clave);

                if(user != null)
                {

                }
                else
                {

                }
            }
            else
            {

            }
            return View();
        }

        // GET: Usuario
        public ActionResult Index()
        {
            var uSUARIO = db.USUARIO.Include(u => u.PERFIL).Include(u => u.PERSONA);
            return View(uSUARIO.ToList());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIO.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            ViewBag.PERFILID = new SelectList(db.PERFIL, "PERFILID", "NOMBRE");
            ViewBag.PERSONAID = new SelectList(db.PERSONA, "PERSONAID", "RUT");
            return View();
        }

        // POST: Usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "USUARIOID,PERSONAID,PERFILID,PERSONA_RUT,PASSWORD,EMAIL")] USUARIO uSUARIO)
        {
            if (ModelState.IsValid)
            {
                db.USUARIO.Add(uSUARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PERFILID = new SelectList(db.PERFIL, "PERFILID", "NOMBRE", uSUARIO.PERFILID);
            ViewBag.PERSONAID = new SelectList(db.PERSONA, "PERSONAID", "RUT", uSUARIO.PERSONAID);
            return View(uSUARIO);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIO.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.PERFILID = new SelectList(db.PERFIL, "PERFILID", "NOMBRE", uSUARIO.PERFILID);
            ViewBag.PERSONAID = new SelectList(db.PERSONA, "PERSONAID", "RUT", uSUARIO.PERSONAID);
            return View(uSUARIO);
        }

        // POST: Usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "USUARIOID,PERSONAID,PERFILID,PERSONA_RUT,PASSWORD,EMAIL")] USUARIO uSUARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSUARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PERFILID = new SelectList(db.PERFIL, "PERFILID", "NOMBRE", uSUARIO.PERFILID);
            ViewBag.PERSONAID = new SelectList(db.PERSONA, "PERSONAID", "RUT", uSUARIO.PERSONAID);
            return View(uSUARIO);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIO.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USUARIO uSUARIO = db.USUARIO.Find(id);
            db.USUARIO.Remove(uSUARIO);
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
