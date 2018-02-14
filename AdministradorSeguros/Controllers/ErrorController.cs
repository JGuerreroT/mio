using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(int error = 0)
        {
            switch (error)
            {
                case 500:
                    ViewBag.Title = "Ocurrio un error inesperado";
                    ViewBag.Description = "Esto es muy vergonzoso, esperemos que no vuelva a pasar ..";
                    break;

                case 404:
                    ViewBag.Title = "Página no encontrada";
                    ViewBag.Description = "La URL que está intentando ingresar no existe";
                    break;

                default:
                    ViewBag.Title = "Página no encontrada";
                    ViewBag.Description = "Algo salio muy mal :( ..";
                    break;
            }

            return View("~/views/error/ErrorPage.cshtml");
        }
    }
}