using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlmacenYuyitos.Models;
using OfficeOpenXml;
using System.Drawing;


namespace AlmacenYuyitos.Controllers
{
    [Authorize]
    public class PersonaController : Controller
    {
        private YuyitosModel db = new YuyitosModel();

        // GET: Persona
        public ActionResult Index()
        {
            var pERSONA = db.PERSONA.Include(p => p.COMUNA).Include(p => p.GENERO1);
            return View(pERSONA.ToList());
        }

        // GET: Persona/Details/5
        public ActionResult Details(int? id)
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
        public ActionResult Create([Bind(Include = "PERSONAID,RUT,NOMBRE,APPATERNO,APMATERNO,FECHANACIMIENTO,TELEFONO,GENERO,CALLE,NUMERO,COMUNAID,COMPLEMENTO")] PERSONA pERSONA, [Bind(Include = "PERSONAID")] CLIENTE cLIENTE)
        {
            if (ModelState.IsValid)
            {
                db.PERSONA.Add(pERSONA);
                db.CLIENTE.Add(cLIENTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COMUNAID = new SelectList(db.COMUNA, "COMUNAID", "NOMBRE", pERSONA.COMUNAID);
            ViewBag.GENERO = new SelectList(db.GENERO, "GENEROID", "NOMBRE", pERSONA.GENERO);
            //ViewBag.REGIONID = new SelectList(db.REGION, "REGIONID", "NOMBRE", pERSONA.COMUNA.REGIONID);

            RegionComunaViewModel RegionComunaViewModel = new RegionComunaViewModel();
            var listRegiones = RegionComunaViewModel.GetRegiones();
            ViewBag.listRegiones = listRegiones;

            return View(pERSONA);
        }

        public JsonResult GetComunas(int RegionId)
        {
            RegionComunaViewModel RegionComunaViewModel = new RegionComunaViewModel();
            var listComunas = RegionComunaViewModel.GetComunas(RegionId);
            return Json(listComunas, JsonRequestBehavior.AllowGet);
        }

        // GET: Persona/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Persona/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PERSONAID,RUT,NOMBRE,APPATERNO,APMATERNO,FECHANACIMIENTO,TELEFONO,GENERO,CALLE,NUMERO,COMUNAID,COMPLEMENTO")] PERSONA pERSONA)
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
        public ActionResult Delete(int? id)
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

        public void ExportExcel()
        {
            var pERSONA = db.PERSONA.Include(p => p.COMUNA).Include(p => p.GENERO1);

            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");

            ws.Cells["A1"].Value = "Almacen";
            ws.Cells["B1"].Value = "Yuyitos";

            ws.Cells["A2"].Value = "Listado";
            ws.Cells["B2"].Value = "Clientes";

            ws.Cells["A3"].Value = "Fecha";
            ws.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy}", DateTimeOffset.Now);

            ws.Cells["A6"].Value = "RUT";
            ws.Cells["B6"].Value = "NOMBRE";
            ws.Cells["C6"].Value = "PATERNO";
            ws.Cells["D6"].Value = "MATERNO";
            ws.Cells["E6"].Value = "TELEFONO";
            ws.Cells["F6"].Value = "CALLE";
            ws.Cells["G6"].Value = "NUMERO";
            ws.Cells["H6"].Value = "COMPLEMENTO";
            ws.Cells["I6"].Value = "COMUNA";

            int rowStart = 7;
            foreach (var item in pERSONA)
            {
                ws.Cells[string.Format("A{0}", rowStart)].Value = item.RUT;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.NOMBRE;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.APPATERNO;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.APMATERNO;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.TELEFONO;
                ws.Cells[string.Format("F{0}", rowStart)].Value = item.CALLE;
                ws.Cells[string.Format("G{0}", rowStart)].Value = item.NUMERO;
                ws.Cells[string.Format("H{0}", rowStart)].Value = item.COMPLEMENTO;
                ws.Cells[string.Format("I{0}", rowStart)].Value = item.COMUNA.NOMBRE;
                rowStart++;
            }

            ws.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment : filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();

        }
    }
}
