using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Repositorio;
using Helper;
using ManejadorErrores;

namespace Model
{
    public class SepelioBL
    {

        public tb_Sepelio ObtenerSepelio(DateTime fechaSepelio)
        {
            var sepelio = new tb_Sepelio();
            try
            {
                using (var ctx = new SeguroContext())
                {
                    sepelio = ctx.tb_Sepelio 
                        .Where(x => x.FechaSepelio == fechaSepelio)
                                    .SingleOrDefault();
                }
            }
            catch (Exception e)
            {

                ELog.save(this, e); //throw;
            }

            return sepelio;
        }



    }
}
