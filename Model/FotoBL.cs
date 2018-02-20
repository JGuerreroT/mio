using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using Repositorio;
using Helper;
using ManejadorErrores;
using PlantillaObjetos;

namespace Model
{
    public class FotoBL
    {

        public List<tb_Foto> ObtenerFoto(int idPeriodo, int idMoneda)
        {
            var foto = new List<tb_Foto>();
            try
            {
                using (var ctx = new SeguroContext())
                {
                    if (idMoneda == 5)
                    {
                        foto = ctx.tb_Foto
                            .Include(x => x.tb_FotoDetalle.Select(y => y.tb_FotoDetallePoliza))
                            .Where(x => x.IdPeriodo == idPeriodo)
                            .Where(x => x.IdEstado == 1)
                            .ToList();
                            //.SingleOrDefault();
                    }
                    else
                    {
                        foto = ctx.tb_Foto
                            .Include(x => x.tb_FotoDetalle.Select(y => y.tb_FotoDetallePoliza))
                            .Where(x => x.IdPeriodo == idPeriodo)
                            .Where(x => x.IdMoneda == idMoneda)
                            .Where(x => x.IdEstado == 1)
                            .ToList();
                            //.SingleOrDefault();
                    }
                }
            }
            catch (Exception e)
            {

                ELog.save(this, e); //throw;
            }

            return foto;
        }

        public ResponseModel GenerarFoto(int periodo, int moneda, DateTime fecha)
        {
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new SeguroContext())
                {
                    var sql = "";

                    ctx.Database.ExecuteSqlCommand("sp_GenerarFoto @p0, @p1, @p2", periodo, moneda, fecha);                    

                    //ctx.Database.SqlQuery<ListaFoto>("sp_GenerarFoto @p0, @p1, @p2", periodo, moneda, fecha).ToList();

                    rm.SetResponse(true);
                }
            }
            catch (Exception e)
            {

                ELog.save(this, e); //throw;
            }

            return rm;
        }

        public List<tb_Foto> ListarFoto(int periodo, int moneda)
        {
            List<tb_Foto> lista = new List<tb_Foto>();

            try
            {
                using (var ctx = new SeguroContext())
                {                    
                    lista=ctx.Database.SqlQuery<tb_Foto>("sp_ListarFoto @p0, @p1", periodo, moneda).ToList();
                }
            }
            catch (Exception e)
            {

                ELog.save(this, e); //throw;
            }

            return lista;
        }


        public AnexGRIDResponde ListarFotos(AnexGRID grid)
        {
            try
            {
                using (var ctx = new SeguroContext())
                {
                    //inicializa la grilla
                    grid.Inicializar();

                    string sql = "select (p.anio+p.mes) as periodo, f.fechafoto as Fecha, " +
                                " m.DescripcionMoneda as moneda, " +
                                " e.DescripcionEstado as estado" +
                                " from tb_Foto f inner " +
                                " join tb_Periodo p on f.IdPeriodo = p.IdPeriodo inner " +
                                " join tb_estado e on f.IdEstado = e.IdEstado inner " +
                                " join tb_Moneda m on f.IdMoneda = m.idMoneda " +
                                " group by p.anio, p.mes, f.fechafoto, m.DescripcionMoneda, " +
                                " e.DescripcionEstado" +
                                " order by periodo desc";

                    var query = ctx.Database.SqlQuery<ListaFoto>(sql).ToList();

                    //Skip(grid.pagina)-->se indica desde que página se inicia la paginacion
                    //Take(grid.limite)-->se indica la cantidad de registros a mostrar
                    var listaFotos = query.Skip(grid.pagina)
                                       .Take(grid.limite)
                                       .ToList();

                    //Se obtiene la cantidad de registros que hay en la tabla, se usa en la paginacion
                    var total = query.Count();

                    grid.SetData(
                        from p in listaFotos
                        select new
                        {
                            p.Periodo,
                            p.Fecha,
                            p.Moneda,
                            p.Estado,
                            p.total
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


    }
}
