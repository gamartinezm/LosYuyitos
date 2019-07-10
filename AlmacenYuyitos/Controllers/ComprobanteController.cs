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
    public class ComprobanteController : Controller
    {
        private YuyitosModel db = new YuyitosModel();

        // GET: Comprobante
        public ActionResult Index(int ordenId)
        {
            var clienteId = db.Cliente.Where(x => x.PERSONAID == ordenId).Select(x => x.CLIENTEID).FirstOrDefault();
            var ventaDetalle = db.VentaDetalle.Where(x => x.CLIENTEID == clienteId);
            var listaComprobante = new List<Comprobante>();
            if (ventaDetalle.Any())
            {

                foreach (var detalle in ventaDetalle)
                {
                    var comprobante = db.Comprobante.Where(x => x.COMPROBANTEID == detalle.COMPROBANTE_COMPROBANTEID).OrderBy(x => x.FECHAEMISION).FirstOrDefault();
                    if (comprobante!=null)
                        listaComprobante.Add(comprobante);
                }
            }
            //var cOMPROBANTE = db.COMPROBANTE.Include(c => c.PAGOESTADO).Include(c => c.TIPOPAGO).Include(c => c.USUARIO).Include(c => c.VENTADETALLE).Where(C => C.)
            //var cOMPROBANTE = db.COMPROBANTE.Where(c => c.COMPROBANTEID == c.VENTADETALLE.
            return View(listaComprobante);
        }

        // GET: Comprobante/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comprobante cOMPROBANTE = db.Comprobante.Find(id);
            if (cOMPROBANTE == null)
            {
                return HttpNotFound();
            }
            return View(cOMPROBANTE);
        }

        // GET: Comprobante/Create
        public ActionResult Create()
        {
            ViewBag.ESTADOID = new SelectList(db.PagoEstado, "ESTADOID", "NOMBRE");
            ViewBag.TIPOPAGOID = new SelectList(db.TipoPago, "TIPOPAGOID", "NOMBRE");
            ViewBag.USUARIOID = new SelectList(db.Usuario, "USUARIOID", "PERSONA_RUT");
            return View();
        }

        // POST: Comprobante/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COMPROBANTEID,TIPOPAGOID,FECHAEMISION,ESTADOID,USUARIOID,TOTALCOMPRA,MONTOCANCELADO")] Comprobante cOMPROBANTE)
        {
            if (ModelState.IsValid)
            {
                db.Comprobante.Add(cOMPROBANTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ESTADOID = new SelectList(db.PagoEstado, "ESTADOID", "NOMBRE", cOMPROBANTE.ESTADOID);
            ViewBag.TIPOPAGOID = new SelectList(db.TipoPago, "TIPOPAGOID", "NOMBRE", cOMPROBANTE.TIPOPAGOID);
            ViewBag.USUARIOID = new SelectList(db.Usuario, "USUARIOID", "PERSONA_RUT", cOMPROBANTE.USUARIOID);
            return View(cOMPROBANTE);
        }

        // GET: Comprobante/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comprobante cOMPROBANTE = db.Comprobante.Find(id);
            if (cOMPROBANTE == null)
            {
                return HttpNotFound();
            }
            ViewBag.ESTADOID = new SelectList(db.PagoEstado, "ESTADOID", "NOMBRE", cOMPROBANTE.ESTADOID);
            ViewBag.TIPOPAGOID = new SelectList(db.TipoPago, "TIPOPAGOID", "NOMBRE", cOMPROBANTE.TIPOPAGOID);
            ViewBag.USUARIOID = new SelectList(db.Usuario, "USUARIOID", "PERSONA_RUT", cOMPROBANTE.USUARIOID);
            return View(cOMPROBANTE);
        }

        // POST: Comprobante/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COMPROBANTEID,TIPOPAGOID,FECHAEMISION,ESTADOID,USUARIOID,TOTALCOMPRA,MONTOCANCELADO")] Comprobante cOMPROBANTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOMPROBANTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ESTADOID = new SelectList(db.PagoEstado, "ESTADOID", "NOMBRE", cOMPROBANTE.ESTADOID);
            ViewBag.TIPOPAGOID = new SelectList(db.TipoPago, "TIPOPAGOID", "NOMBRE", cOMPROBANTE.TIPOPAGOID);
            ViewBag.USUARIOID = new SelectList(db.Usuario, "USUARIOID", "PERSONA_RUT", cOMPROBANTE.USUARIOID);
            return View(cOMPROBANTE);
        }

        // GET: Comprobante/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comprobante cOMPROBANTE = db.Comprobante.Find(id);
            if (cOMPROBANTE == null)
            {
                return HttpNotFound();
            }
            return View(cOMPROBANTE);
        }

        // POST: Comprobante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comprobante cOMPROBANTE = db.Comprobante.Find(id);
            db.Comprobante.Remove(cOMPROBANTE);
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
