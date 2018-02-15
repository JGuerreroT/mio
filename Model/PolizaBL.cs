using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;
using Helper;
using PlantillaObjetos;
using ManejadorErrores;
using System.Data.Entity;

namespace Model
{
    public class PolizaBL
    {
        public void Guardar()
        {
            //var rm = new ResponseModel();
            tb_Poliza poliza = new tb_Poliza();
            tb_PolizaDetalle polizaDetalle = new tb_PolizaDetalle();

            try
            {
                poliza.NumeroPoliza=1;
                poliza.FechaDevengue=DateTime.Now;
                poliza.FechaVigencia= DateTime.Now; 
                poliza.FechaEnvio= DateTime.Now;
                poliza.FechaNotificacion= DateTime.Now;
                poliza.IdMoneda=1;
                poliza.IdCobertura=1;
                poliza.IdModalidad=1;
                poliza.PeriodoDiferido=0;
                poliza.PeriodoGarantizado=0;
                poliza.Gratificacion=false;
                poliza.DerechoACrecer=false;
                poliza.Calce=false;
                poliza.Repacto=false;
                poliza.Prima=0;
                poliza.CICInical=0;
                poliza.CICFInal=0;
                poliza.TasaVenta=0;
                poliza.TasaReserva=0;
                poliza.RentaTemporal=false;
                poliza.PorcentajeRentaTemporal=0;
                poliza.PeriodoInicialRentaTemporal=0;
                poliza.IdCotizacion=1;
                poliza.IdPeriodo=13;
                poliza.Estudiante=false;
                poliza.PorcentajeGarantizado=0;

                polizaDetalle.IdPersona = 1;
                polizaDetalle.IdRelacionFamiliar = 1;
                polizaDetalle.IdSalud = 1;
                polizaDetalle.PorcentajeBeneficio = 0;
                polizaDetalle.IdTipoPensionista = 1;
                polizaDetalle.IdTipoPersona = 1;

                poliza.tb_PolizaDetalle.Add(polizaDetalle);

                using (var ctx = new SeguroContext())
                {
                    if (poliza.IdPoliza> 0)
                    {
                        ctx.Entry(poliza).State = EntityState.Modified;
                    }
                    else
                    {
                        ctx.Entry(poliza).State = EntityState.Added;
                    }
                    //rm.SetResponse(true);
                    ctx.SaveChanges();

                }
            }
            catch (Exception e)
            {

                throw;//ELog.save(this, e); 

            }

            //return rm;
        }

    }
}
