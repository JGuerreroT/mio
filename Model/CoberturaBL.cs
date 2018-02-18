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
    public class CoberturaBL
    {

        public int ObtenerCobertura(string descripcionCobertura)
        {
            var cobertura = new tb_Cobertura();
            try
            {
                using (var ctx = new SeguroContext())
                {
                    cobertura = ctx.tb_Cobertura
                        .Where(x => x.DescripcionCobertura.StartsWith(descripcionCobertura))
                                    .SingleOrDefault();
                }
            }
            catch (Exception e)
            {

                throw;//ELog.save(this, e); //throw;
            }

            return cobertura.IdCobertura;
        }

    }
}
