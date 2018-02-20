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
    public class TipoPensionistaBL
    {
        public int ObtenerTipoPensionista(string descripcionTipoPensionista)
        {
            var tipoPensionista = new tb_TipoPensionista();
            try
            {
                using (var ctx = new SeguroContext())
                {
                    tipoPensionista = ctx.tb_TipoPensionista
                        .Where(x => x.DescripcionTipoPensionista.StartsWith(descripcionTipoPensionista))
                                    .SingleOrDefault();
                }
            }
            catch (Exception e)
            {

                ELog.save(this, e); //throw;
            }

            return tipoPensionista.IdTipoPensionista;
        }

    }
}
