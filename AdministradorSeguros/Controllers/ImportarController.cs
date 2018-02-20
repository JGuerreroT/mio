using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using AdimistradorSeguros.Filters;
using PlantillaObjetos;
using Repositorio;
using Helper;
using System.IO;
using SpreadsheetGear;
using System.Globalization;

namespace AdministradorSeguros.Controllers
{
    public class ImportarController : Controller
    {
        private FotoBL foto = new FotoBL();
        private PeriodoBL periodo = new PeriodoBL();
        private MonedaBL moneda = new MonedaBL();

        private readonly System.Globalization.CultureInfo _myCIintl = new System.Globalization.CultureInfo("es-PE", false);

        // GET: Reserva
        public ActionResult Index()
        {
            ViewBag.Periodos = periodo.ListarPeriodo();
            ViewBag.Monedas = moneda.ListarMoneda();
            return View();
        }

        public JsonResult GenerarCopia(EntidadFiltro model)
        {
            var rm = new ResponseModel();

            int idPeriodo = model.IdPeriodo;
            int idMoneda = model.IdMoneda;

            if (ModelState.IsValid)
            {
                rm = foto.GenerarFoto(model.IdPeriodo, 5, model.FechaCalculo);

                if (rm.response)
                {
                    var lista = foto.ListarFoto(model.IdPeriodo, 5);

                    if (lista.Count >0)
                    {
                        //rm.function = "MensajeGrabacion()";
                        rm.SetResponse(false, "La copia de las pólizas se generaron con exito!");
                        //rm.href = Url.Content("~/reserva/importar");
                    }
                    else
                    {
                        rm.SetResponse(false, "No hay pólizas para la moneda selecionada.");
                    }
                }
            }
            return Json(rm);
        }

        public ActionResult Importar()
        {
            ViewBag.Periodos = periodo.ListarPeriodo(1);
            ViewBag.Monedas = moneda.ListarMoneda();
            return View();
        }

        public JsonResult CargarFoto(AnexGRID grid)
        {
            return Json(foto.ListarFotos(grid));
        }


    }
}