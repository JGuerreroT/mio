using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using Repositorio;
using Helper;
using PlantillaObjetos;
using ManejadorErrores;

namespace Model
{
    public class PeriodoBL
    {

        public List<tb_Periodo> ListarPeriodo()
        {
            var periodos = new List<tb_Periodo>();
            try
            {
                using (var ctx=new SeguroContext())
                {
                    //obtiene la relacion entre periodo y estado
                    periodos = ctx.tb_Periodo
                        .Include(x => x.tb_Estado)
                        .ToList();
                }
            }
            catch (Exception e)
            {

                throw;//ELog.save(this, e); //throw;
            }

            return periodos;
        }

        public AnexGRIDResponde ListarPeriodos(AnexGRID grid)
        {
            try
            {
                using (var ctx = new SeguroContext())
                {
                    //inicializa la grilla
                    grid.Inicializar();

                    var query = ctx.tb_Periodo
                                .Include(x => x.tb_Estado)
                                .Where(x => x.IdPeriodo > 0);

                    // Ordenamiento
                    if (grid.columna == "IdPeriodo")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.IdPeriodo)
                                                             : query.OrderBy(x => x.IdPeriodo);
                    }

                    if (grid.columna == "Anio")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.Anio)
                                                             : query.OrderBy(x => x.Anio);
                    }

                    if (grid.columna == "Mes")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.Mes)
                                                             : query.OrderBy(x => x.Mes);
                    }

                    if (grid.columna == "DescripcionEstado")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.tb_Estado.DescripcionEstado )
                                                             : query.OrderBy(x => x.tb_Estado.DescripcionEstado);
                    }

                    // Filtros
                    foreach (var f in grid.filtros)
                    {
                        if (f.columna == "Anio")
                            query = query.Where(x => x.Anio.StartsWith(f.valor));

                        if (f.columna == "Mes")
                            query = query.Where(x => x.Mes.StartsWith(f.valor));

                        if (f.columna == "DescripcionEstado")
                            query = query.Where(x => x.tb_Estado.DescripcionEstado.StartsWith(f.valor));
                    }

                    //Skip(grid.pagina)-->se indica desde que página se inicia la paginacion
                    //Take(grid.limite)-->se indica la cantidad de registros a mostrar
                    var periodos = query.Skip(grid.pagina)
                                       .Take(grid.limite)
                                       .ToList();

                    //Se obtiene la cantidad de registros que hay en la tabla, se usa en la paginacion
                    var total = query.Count();

                    //
                    grid.SetData(
                        from p in periodos
                        select new
                        {
                            p.IdPeriodo,
                            p.Anio ,
                            p.Mes,
                            p.tb_Estado.DescripcionEstado 
                        },
                        total
                    );
                }
            }
            catch (Exception e)
            {

                throw;//ELog.save(this, e); //throw;
            }

            return grid.responde();
        }

        public tb_Periodo ObtenerPeriodo(int idPeriodo)
        {
            var periodo = new tb_Periodo();
            try
            {
                using (var ctx = new SeguroContext())
                {
                    //formas de incluir una relacion entre objetos
/*                    periodo = ctx.tb_Periodo
                        .Include(x => x.tb_Estado)
                        .Where(x => x.IdPeriodo==idPeriodo )
                                    .SingleOrDefault() ;*/

                    periodo = ctx.tb_Periodo
                        .Include("tb_Estado")
                        .Where(x => x.IdPeriodo == idPeriodo)
                                    .SingleOrDefault();

                }
            }
            catch (Exception e)
            {

                throw;//ELog.save(this, e); //throw;
            }

            return periodo;
        }
        
        public ResponseModel Guardar(tb_Periodo periodo)
        {
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new SeguroContext())
                {
                    if (periodo.IdPeriodo > 0)
                    {
                        ctx.Entry(periodo).State = EntityState.Modified;
                    }
                    else
                    {
                        ctx.Entry(periodo).State = EntityState.Added;
                    }
                    rm.SetResponse(true);
                    ctx.SaveChanges();

                }
            }
            catch (Exception e)
            {

                throw;//ELog.save(this, e); //throw;
            }

            return rm;
        }

        public int ObtenerPeriodo(string anio, string mes)
        {
            var periodo = new tb_Periodo();
            try
            {
                using (var ctx = new SeguroContext())
                {
                    periodo = ctx.tb_Periodo
                        .Where(x => x.Anio.StartsWith(anio))
                        .Where(x => x.Mes.StartsWith(mes))
                                    .SingleOrDefault();
                }
            }
            catch (Exception e)
            {

                throw;//ELog.save(this, e); //throw;
            }

            return periodo.IdPeriodo ;
        }

    }
}
