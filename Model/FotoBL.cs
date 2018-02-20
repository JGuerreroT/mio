using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using Repositorio;
using Helper;
using ManejadorErrores;

namespace Model
{
    public class FotoBL
    {

        public List<tb_Foto> ObtenerFoto(int idPeriodo, int idMoneda)
        {
            var foto = new List<tb_Foto>();
            try
            {
                using (var ctx = new SeguroContext())
                {
                    if (idMoneda == 5)
                    {
                        foto = ctx.tb_Foto
                            .Include(x => x.tb_FotoDetalle.Select(y => y.tb_FotoDetallePoliza))
                            .Where(x => x.IdPeriodo == idPeriodo)
                            .Where(x => x.IdEstado == 1)
                            .ToList();
                            //.SingleOrDefault();
                    }
                    else
                    {
                        foto = ctx.tb_Foto
                            .Include(x => x.tb_FotoDetalle.Select(y => y.tb_FotoDetallePoliza))
                            .Where(x => x.IdPeriodo == idPeriodo)
                            .Where(x => x.IdMoneda == idMoneda)
                            .Where(x => x.IdEstado == 1)
                            .ToList();
                            //.SingleOrDefault();
                    }
                }
            }
            catch (Exception e)
            {

                throw;//ELog.save(this, e); //throw;
            }

            return foto;
        }


    }
}
