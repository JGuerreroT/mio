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
    public class TipoCambioBL
    {

        public tb_TipoCambio ObtenerTipoCambio(DateTime fechaTipoCambio)
        {
            var tipoCambio = new tb_TipoCambio();
            try
            {
                using (var ctx = new SeguroContext())
                {
                    tipoCambio = ctx.tb_TipoCambio
                        .Where(x => x.FechaTipoCambio == fechaTipoCambio)
                                    .SingleOrDefault();
                }
            }
            catch (Exception e)
            {

                ELog.save(this, e); //throw;
            }

            return tipoCambio;
        }

    }
}
