using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repositorio;
using Helper;
using Model;

namespace AdministradorSeguros.Controllers
{
    public class PersonaController : Controller
    {
        private PersonaBL persona = new PersonaBL();

        // GET: Persona
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Guardar()
        {
            var rm = new ResponseModel();
            tb_Persona model = new tb_Persona();
            model.Nombre="aaaa";
            model.Apellido="bbbbb";
            model.CUSSPP="11111";
            model.DNI="1234";
            model.FechaNacimiento=Convert.ToDateTime("30/12/1981");
            model.FechaFallecimiento= Convert.ToDateTime("01/01/1900");
            model.IdEstado=1;
            model.IdSexo=1;


            if (ModelState.IsValid)
            {
                rm = persona.Guardar(model);

                if (rm.response)
                {
                    //rm.function = "MensajeGrabacion()";
                    //rm.href = Url.Content("~/Periodo");
                }

            }
            return Json(rm);
        }

    }
}