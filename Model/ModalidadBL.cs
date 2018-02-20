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

                ELog.save(this, e); //throw;
            }

            return modalidad.IdModalidad;
        }

        public List<tb_Modalidad > ListarModalidad()
        {
            var lista = new List<tb_Modalidad>();
            try
            {
                using (var ctx = new SeguroContext())
                {
                    lista = ctx.tb_Modalidad.ToList();
                }
            }
            catch (Exception e)
            {

                ELog.save(this, e); //throw;//
            }

            return lista;
        }


    }
}