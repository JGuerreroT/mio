using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Repositorio;
using AdimistradorSeguros.Filters;
using PlantillaObjetos;
using Helper;

namespace AdimistradorSeguros.Controllers
{
    [Autenticado]
    public class PeriodoController : Controller
    {
        //localhost:xxxx/home/index
        private PeriodoBL periodo = new PeriodoBL();
        private EstadoBL estado = new EstadoBL();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult CargarPeriodos(AnexGRID grid)
        {
            return Json(periodo.ListarPeriodos(grid));
        }

        public ActionResult Ver(int id = 0)
        {
            return View(periodo.ObtenerPeriodo(id));
        }

        public ActionResult Crud(int id = 0)
        {
            ViewBag.Estados = estado.ListarEstado();
            return View(
                id == 0 ? new tb_Periodo()
                        : periodo.ObtenerPeriodo(id)
                );
        }

        public JsonResult Guardar(tb_Periodo model)
        {
            var rm = new ResponseModel();

            if (ModelState.IsValid)
            {
                rm = periodo.Guardar(model);

                if (rm.response)
                {
                    rm.function = "MensajeGrabacion()";
                    rm.href = Url.Content("~/Periodo");
                }

            }
            return Json(rm);
        }

    }
}