using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Repositorio;
using PlantillaObjetos;
using Helper;

namespace AdimistradorSeguros.Controllers
{
    public class HomeController : Controller
    {
        //localhost:xxxx/home/index
        private PeriodoBL periodo = new PeriodoBL();
        private EstadoBL estado = new EstadoBL();

        public ActionResult Index()
        {
            return View();
            //Se usa con index_copia
            //return View(periodo.ListarPeriodo());
        }

        public JsonResult CargarPeriodos(AnexGRID grid)
        {
            return Json(periodo.ListarPeriodos(grid));
        }

        public ActionResult Ver(int id=0)
        {
            return View(periodo.ObtenerPeriodo(id));
        }

        public ActionResult Crud(int id=0)
        {
            ViewBag.Estados = estado.ListarEstado();
            return View(
                id==0 ? new tb_Periodo()
                        : periodo.ObtenerPeriodo(id)
                );
        }

       /* public ActionResult Guardar(tb_Periodo model)
        {
            if (ModelState.IsValid )
            {
                periodo.Guardar(model);
                return Redirect("~/Home");
            }
            else
            {
                return View("~/Views/Home/Crud.cshtml", model);
            }
        }*/

        public JsonResult Guardar(tb_Periodo model)
        {
            var rm = new ResponseModel();

            if (ModelState.IsValid)
            {
                rm=periodo.Guardar(model);

                if (rm.response )
                {
                    rm.function = "MensajeGrabacion()";
                    rm.href = Url.Content("~/Home");
                }
                
            }
            return Json(rm);
        }

        public PartialViewResult Adjuntos()
        {
            return PartialView();
        }


    }
}