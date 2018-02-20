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
    public class TipoPersonaBL
    {
        public int ObtenerTipoPersona(string descripcionTipoPersona)
        {
            var tipoPersona = new tb_TipoPersona();
            try
            {
                using (var ctx = new SeguroContext())
                {
                    tipoPersona = ctx.tb_TipoPersona
                        .Where(x => x.DescripcionTipoPersona.StartsWith(descripcionTipoPersona))
                                    .SingleOrDefault();
                }
            }
            catch (Exception e)
            {

                ELog.save(this, e); //throw;
            }

            return tipoPersona.IdTipoPersona;
        }

        public tb_TipoPersona ObtenerTipoPersona(int idTipoPersona)
        {
            var tipoPersona = new tb_TipoPersona();
            try
            {
                using (var ctx = new SeguroContext())
                {
                    tipoPersona = ctx.tb_TipoPersona
                        .Where(x => x.IdTipoPersona == idTipoPersona )
                                    .SingleOrDefault();
                }
            }
            catch (Exception e)
            {

                ELog.save(this, e); //throw;
            }

            return tipoPersona;
        }


    }
}
