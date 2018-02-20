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
    public class SaludBL
    {
        public int ObtenerSalud(string descripcionSalud)
        {
            var salud = new tb_Salud();
            try
            {
                using (var ctx = new SeguroContext())
                {
                    salud = ctx.tb_Salud
                        .Where(x => x.DescripcionSalud.StartsWith(descripcionSalud))
                                    .SingleOrDefault();
                }
            }
            catch (Exception e)
            {

                throw;//ELog.save(this, e); //throw;
            }

            return salud.IdSalud;
        }

        public tb_Salud ObtenerSalud(int idSalud)
        {
            var salud = new tb_Salud();
            try
            {
                using (var ctx = new SeguroContext())
                {
                    salud = ctx.tb_Salud
                        .Where(x => x.IdSalud == idSalud )
                                    .SingleOrDefault();
                }
            }
            catch (Exception e)
            {

                throw;//ELog.save(this, e); //throw;
            }

            return salud;
        }


    }
}
