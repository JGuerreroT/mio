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

        public int ObtenerCobertura1(string descripcionCobertura)
        {
            var coberturaP = new tb_Cobertura();
            try
            {
                using (var ctx = new SeguroContext())
                {
                    coberturaP = ctx.tb_Cobertura
                        .Where(x => x.DescripcionCobertura.StartsWith(descripcionCobertura))
                                    .SingleOrDefault();
                }
            }
            catch (Exception e)
            {

                throw;//ELog.save(this, e); //throw;
            }

            return coberturaP.IdCobertura;
        }

        public tb_Cobertura ObtenerCobertura(int idCobertura)
        {
            var cobertura = new tb_Cobertura();
            try
            {
                using (var ctx = new SeguroContext())
                {
                    cobertura = ctx.tb_Cobertura
                        .Where(x => x.IdCobertura == idCobertura )
                                    .SingleOrDefault();
                }
            }
            catch (Exception e)
            {

                throw;//ELog.save(this, e); //throw;
            }

            return cobertura;
        }

        public List<tb_Cobertura> ListarCobertura()
        {
            var lista = new List<tb_Cobertura>();
            try
            {
                using (var ctx = new SeguroContext())
                {
                    lista = ctx.tb_Cobertura.ToList();
                }
            }
            catch (Exception e)
            {

                throw;//ELog.save(this, e); //throw;//
            }

            return lista;
        }




    }
}
