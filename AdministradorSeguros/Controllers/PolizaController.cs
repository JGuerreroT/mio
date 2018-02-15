using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using AdimistradorSeguros.Filters;

namespace AdministradorSeguros.Controllers
{
    [Autenticado]
    public class PolizaController : Controller
    {
        // GET: Poliza
        private PolizaBL poliza = new PolizaBL();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Crud()
        {
            poliza.Guardar();
            return Redirect("~/poliza");//View("~/poliza");
        }


    }
}