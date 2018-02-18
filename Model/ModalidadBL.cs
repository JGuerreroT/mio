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
    public class ModalidadBL
    {

        public int ObtenerModalidad(string resumenModalidad)
        {
            var modalidad = new tb_Modalidad();
            try
            {
                using (var ctx = new SeguroContext())
                {
                    modalidad = ctx.tb_Modalidad
                        .Where(x => x.ResumenModalidad.StartsWith(resumenModalidad))
                                    .SingleOrDefault();
                }
            }
            catch (Exception e)
            {

                throw;//ELog.save(this, e); //throw;
            }

            return modalidad.IdModalidad;
        }

    }
}