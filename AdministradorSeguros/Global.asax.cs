using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AdimistradorSeguros
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        /*
        //para manejo de errores personalizados.
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            Response.Clear();

            HttpException httpException = exception as HttpException;

            int error = httpException != null ? httpException.GetHttpCode() : 0;

            Server.ClearError();
            Response.Redirect(String.Format("~/Error/?error={0}", error, exception.Message));
        }
        */
    }
}
