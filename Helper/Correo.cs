using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace Helper
{
    public class Correo
    {
        public void EnviarCorreoOuttlook(string mensaje)
        {
            try
            {
                var mail = new MailMessage();
                mail.From = new MailAddress("u201100215@upc.edu.pe", "sistema seguros");
                mail.To.Add("jaime.guerrerot@outlook.com");
                mail.Subject = "Correo desde contacto";
                mail.IsBodyHtml = true;
                mail.Body = mensaje;

                var SmtpServer = new SmtpClient("smtp.live.com"); // or "smtp.gmail.com"
                SmtpServer.Port = 587;
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.UseDefaultCredentials = false;

                // Agrega tu correo y tu contraseña, hemos usado el servidor de Outlook.
                SmtpServer.Credentials = new System.Net.NetworkCredential("jaime.guerrerot@outlook.com", "Sergio1@@5");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public void EnviarCorreoGmail()
        {
            try
            {
                var fromAddress = new MailAddress("jguerrerot@gmail.com", "From Prueba");
                var toAddress = new MailAddress("jguerrerot@gmail.com", "To Prueba");
                const string fromPassword = "Sergio1005";
                const string subject = "Subject";
                const string body = "Body";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
            }
            catch (Exception e)
            {
                throw;
            }

        }

    }
}
