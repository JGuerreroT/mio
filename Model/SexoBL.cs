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
    public class SexoBL
    {

        public int ObtenerSexo(string descripcionSexo)
        {
            var sexo = new tb_Sexo();
            try
            {
                using (var ctx = new SeguroContext())
                {
                    sexo = ctx.tb_Sexo
                        .Where(x => x.DescripcionSexo.StartsWith(descripcionSexo))
                                    .SingleOrDefault();
                }
            }
            catch (Exception e)
            {

                throw;//ELog.save(this, e); //throw;
            }

            return sexo.IdSexo;
        }

        public tb_Sexo ObtenerSexo(int idSexo)
        {
            var sexo = new tb_Sexo();
            try
            {
                using (var ctx = new SeguroContext())
                {
                    sexo = ctx.tb_Sexo
                        .Where(x => x.IdSexo == idSexo )
                                    .SingleOrDefault();
                }
            }
            catch (Exception e)
            {

                throw;//ELog.save(this, e); //throw;
            }

            return sexo;
        }


    }
}
