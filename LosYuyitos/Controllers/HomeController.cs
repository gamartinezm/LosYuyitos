using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LosYuyitos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Informacion de contacto:";

            return View();
        }

        public ActionResult Persona()
        {
            ViewBag.Message = "Your contact page.";

            return View("/Persona/Index");
        }

        public ActionResult Cliente()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}