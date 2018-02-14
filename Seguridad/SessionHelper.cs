using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Security;

namespace Seguridad
{
    public class SessionHelper
    {        
        //valida existencia de usuario en la sesion
        public static bool ExistUserInSession()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;            
        }

        //destuir cookies actual para la sesion del usuario
        public static void DestroyUserSession()
        {
            FormsAuthentication.SignOut();
        }

        //obtener id usuario
        public static int GetUser()
        {
            int user_id = 0;
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity is FormsIdentity)
            {
                FormsAuthenticationTicket ticket = ((FormsIdentity)HttpContext.Current.User.Identity).Ticket;
                if (ticket != null)
                {
                    user_id = Convert.ToInt32(ticket.UserData);
                }
            }
            return user_id;
        }

        //agregar usuario a la sesion
        public static void AddUserToSession(string id)
        {
            bool persist = true;
            var cookie = FormsAuthentication.GetAuthCookie("usuario", persist);

            cookie.Name = FormsAuthentication.FormsCookieName;
            //cookie.Expires = DateTime.Now.AddMonths(3);
            cookie.Expires = DateTime.Now.AddMinutes(20);

            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            var newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, id);

            cookie.Value = FormsAuthentication.Encrypt(newTicket);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

    }
}
