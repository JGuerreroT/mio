using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Diagnostics;

namespace ManejadorErrores
{
    public class ELog
    {
        public static void save(object obj, Exception ex)
        {
            string fecha = System.DateTime.Now.ToString("yyyyMMdd");
            string hora = System.DateTime.Now.ToString("HH:mm:ss");
            string path = HttpContext.Current.Request.MapPath("~/log/" + fecha + ".txt");

            StreamWriter sw = new StreamWriter(path, true);

            StackTrace stacktrace = new StackTrace();
            sw.WriteLine(obj.GetType().FullName + " " + hora);
            sw.WriteLine(stacktrace.GetFrame(1).GetMethod().Name + " - " + ex.Message);
            sw.WriteLine("");

            sw.Flush();
            sw.Close();
        }
    }
}
