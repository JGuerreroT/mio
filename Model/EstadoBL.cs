using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using Repositorio;
using Helper;
using ManejadorErrores;

namespace Model
{
    public class EstadoBL
    {
        public List<tb_Estado> ListarEstado()
        {
            var estados = new List<tb_Estado>();
            try
            {
                using (var ctx = new SeguroContext())
                {
                    estados = ctx.tb_Estado.ToList();
                }
            }
            catch (Exception e)
            {

                ELog.save(this, e); //throw;
            }

            return estados;
        }

        public tb_Estado ObtenerEstado(int idEstado)
        {
            var estado = new tb_Estado();
            try
            {
                using (var ctx = new SeguroContext())
                {
                    estado = ctx.tb_Estado
                        .Where(x => x.IdEstado == idEstado)
                                    .SingleOrDefault();

                }
            }
            catch (Exception e)
            {

                ELog.save(this, e); //throw;
            }

            return estado;
        }
    }
}
