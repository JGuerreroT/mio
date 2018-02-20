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
    public class RelacionFamiliarBL
    {
        public int ObtenerRelacionFamiliar(string descripcionRelacionFamiliar)
        {
            var relacionFamiliar = new tb_RelacionFamiliar();
            try
            {
                using (var ctx = new SeguroContext())
                {
                    relacionFamiliar = ctx.tb_RelacionFamiliar
                        .Where(x => x.DescripcionRelacionFamiliar.StartsWith(descripcionRelacionFamiliar))
                                    .SingleOrDefault();
                }
            }
            catch (Exception e)
            {

                ELog.save(this, e); //throw;
            }

            return relacionFamiliar.IdRelacionFamiliar;
        }

        public tb_RelacionFamiliar ObtenerRelacionFamiliar(int idRelacionFamiliar)
        {
            var relacionFamiliar = new tb_RelacionFamiliar();
            try
            {
                using (var ctx = new SeguroContext())
                {
                    relacionFamiliar = ctx.tb_RelacionFamiliar
                        .Where(x => x.IdRelacionFamiliar == idRelacionFamiliar )
                                    .SingleOrDefault();
                }
            }
            catch (Exception e)
            {

                ELog.save(this, e); //throw;
            }

            return relacionFamiliar;
        }


    }
}
