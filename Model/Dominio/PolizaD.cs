using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;
using System.Data.Entity;

namespace Model.Dominio
{
    public class PolizaD
    {
        public int IdPoliza { get; set; }
        public string Afiliado { get; set; }
        public string CUSPP { get; set; }
        public string Ramo { get; set; }
        public string Moneda{ get; set; }
        public DateTime Notificacion { get; set; }
        public string Estado { get; set; }

        public List<PolizaD> ListarPolizas()
        {
            var polizas = new List<PolizaD>();
            try
            {
                using (var ctx = new SeguroContext())
                {
                    //obtiene la relacion entre periodo y estado
                    //polizas = ctx.tb_Poliza 
                    //    .Include(x => x.tb_Estado )
                    //    .ToList();
                }
            }
            catch (Exception e)
            {

                throw;//ELog.save(this, e); //throw;
            }

            return polizas;
        }


    }
}
