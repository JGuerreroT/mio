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
using PlantillaObjetos;
using Model.Dominio;

namespace Model
{
    public class PolizaBL
    {
        public ResponseModel Guardar(tb_Poliza poliza)
        {
            var rm = new ResponseModel();
            try
            {

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
                    rm.SetResponse(true);
                    ctx.SaveChanges();

                }
            }
            catch (Exception e)
            {

                ELog.save(this, e); //throw;

            }

            return rm;
        }

        public AnexGRIDResponde ListarPolizas(AnexGRID grid)
        {
            try
            {
                using (var ctx = new SeguroContext())
                {
                    //inicializa la grilla
                    grid.Inicializar();

                    var query = ctx.tb_PolizaDetalle
                                .Include(x => x.tb_Poliza.tb_Estado)
                                .Include(x => x.tb_Poliza.tb_Cobertura )
                                .Include(x => x.tb_Poliza.tb_Moneda )
                                .Include(x => x.tb_Persona )
                                .Where(x => x.IdDetallePoliza > 0 && x.IdRelacionFamiliar == 1);
                    
                    // Ordenamiento
                    if (grid.columna == "IdPoliza")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.IdPoliza)
                                                             : query.OrderBy(x => x.IdPoliza);
                    }

                    if (grid.columna == "NumeroPoliza")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.tb_Poliza.NumeroPoliza )
                                                             : query.OrderBy(x => x.tb_Poliza.NumeroPoliza);
                    }

                    if (grid.columna == "NombrePersona")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.tb_Persona.Nombre + ' ' + x.tb_Persona.Apellido)
                                                             : query.OrderBy(x => x.tb_Persona.Nombre + ' ' + x.tb_Persona.Apellido);
                    }

                    // Filtros
                    foreach (var f in grid.filtros)
                    {
                        if (f.columna == "NumeroPoliza")
                            query = query.Where(x => x.tb_Poliza.NumeroPoliza.ToString().StartsWith(f.valor));

                        if (f.columna == "Nombre")
                            query = query.Where(x => x.tb_Persona.Nombre.Contains(f.valor));
                        //query = query.Where(x => (x.tb_Persona.Nombre + ' ' + x.tb_Persona.Apellido).Contains(f.valor));

                        if (f.columna == "Apellido")
                            query = query.Where(x => x.tb_Persona.Apellido.Contains(f.valor));
                        
                        if (f.columna == "DescripcionEstado")
                            query = query.Where(x => x.tb_Poliza.tb_Estado.DescripcionEstado.StartsWith(f.valor));
                    }

                    //Skip(grid.pagina)-->se indica desde que página se inicia la paginacion
                    //Take(grid.limite)-->se indica la cantidad de registros a mostrar
                    var polizas = query.Skip(grid.pagina)
                                       .Take(grid.limite)
                                       .ToList();

                    //Se obtiene la cantidad de registros que hay en la tabla, se usa en la paginacion
                    var total = query.Count();

                    //
                    grid.SetData(
                        from p in polizas
                        select new
                        {
                            p.IdPoliza,
                            p.tb_Poliza.NumeroPoliza,
                            p.tb_Persona.Nombre,
                            p.tb_Persona.Apellido,                            
                            p.tb_Persona.CUSSPP ,
                            p.tb_Poliza.tb_Cobertura.DescripcionCobertura,
                            p.tb_Poliza.tb_Moneda.DescripcionMoneda,
                            p.tb_Poliza.FechaNotificacion,
                            p.tb_Poliza.tb_Estado.DescripcionEstado
                        },
                        total
                    );
                }
            }
            catch (Exception e)
            {

                ELog.save(this, e); //throw;
            }

            return grid.responde();
        }

        public tb_Poliza ObtenerPoliza(int idPoliza)
        {
            var poliza = new tb_Poliza();
            try
            {
                using (var ctx = new SeguroContext())
                {
                    poliza = ctx.tb_Poliza
                        .Include(x => x.tb_Estado)
                        .Include(x => x.tb_Moneda)
                        .Include(x => x.tb_Cobertura)
                        .Include(x => x.tb_Modalidad)
                        .Include(x => x.tb_Periodo)
                        .Include(x => x.tb_PolizaDetalle.Select(y => y.tb_Persona))
                        .Include(x => x.tb_PolizaDetalle.Select(y => y.tb_Persona).Select(z => z.tb_Sexo))
                        .Include(x => x.tb_PolizaDetalle.Select(y => y.tb_RelacionFamiliar))
                        .Include(x => x.tb_PolizaDetalle.Select(y => y.tb_Salud))
                        .Include(x => x.tb_PolizaDetalle.Select(y => y.tb_Estado))
                        .Include(x => x.tb_PolizaDetalle.Select(y => y.tb_TipoPersona))
                        .Where(x => x.IdPoliza == idPoliza)    
                        //.Take(100)                    
                        .SingleOrDefault();

                    poliza.FechaDev= poliza.FechaDevengue.ToString("MM/dd/yyyy");
                    poliza.FechaEnv= poliza.FechaEnvio.ToString("MM/dd/yyyy");
                    poliza.FechaNot= poliza.FechaNotificacion.ToString("MM/dd/yyyy");
                    poliza.FechaVig= poliza.FechaVigencia.ToString("MM/dd/yyyy");
                    
                }
            }
            catch (Exception e)
            {

                ELog.save(this, e); //throw;
            }

            return poliza;
        }

        public ResponseModel Guardar(List<tb_Poliza> polizas)
        {
            var rm = new ResponseModel();
            PersonaBL persona = new PersonaBL();

            try
            {
                using (var ctx = new SeguroContext())
                {
                    foreach (tb_Poliza  poliza in polizas)
                    {
                        if (poliza.IdPoliza > 0)
                        {
                            ctx.Entry(poliza).State = EntityState.Modified;
                        }
                        else
                        {
                            //foreach (tb_PolizaDetalle  polDet in poliza.tb_PolizaDetalle )
                            //{
                            //    polDet.IdPersona= persona.GuardarPersona(polDet.tb_Persona);
                            //}

                            ctx.Entry(poliza).State = EntityState.Added;
                        }
                        rm.SetResponse(true);
                        ctx.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {

                ELog.save(this, e); //throw;

            }

            return rm;
        }

    }
}
