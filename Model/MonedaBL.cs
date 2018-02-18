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
    public class MonedaBL
    {

        public int ObtenerMoneda(string codigoMoneda)
        {
            var moneda = new tb_Moneda();
            try
            {
                using (var ctx = new SeguroContext())
                {
                    moneda = ctx.tb_Moneda
                        .Where(x => x.CodigoMoneda.StartsWith(codigoMoneda))
                                    .SingleOrDefault();
                }
            }
            catch (Exception e)
            {

                throw;//ELog.save(this, e); //throw;
            }

            return moneda.idMoneda;
        }

    }
}
