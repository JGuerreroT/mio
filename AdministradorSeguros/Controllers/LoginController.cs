using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Repositorio;
using Helper;
using AdimistradorSeguros.Filters;
using Seguridad;

namespace AdimistradorSeguros.Controllers
{
    
    public class LoginController : Controller
    {
        private UsuarioBL usuario = new UsuarioBL();
        

        [NoLogin]
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Acceder(string Login, string Password)
        {
            var rm = new ResponseModel(); 

            if (Login != "")
            {
                rm= usuario.Acceder(Login, Password);

                if (rm.response)
                {
                    rm.href = Url.Content("~/Default");
                }
                else
                {
                     if (rm.bloqueo)
                     {
                        rm.href = Url.Content("~/");
                     }
                    //BloqueoUsuario(Login);
                    
                }
            }
            else
            {
                rm.SetResponse(false, "Correo o contraseña incorrecta");
            }

            return Json(rm);
        }

       

        public ActionResult Logout()
        {
            // Eliminar la sesion actual
            SessionHelper.DestroyUserSession();

            return Redirect("~/Login");
        }


    }
}