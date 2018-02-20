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
    public class ReservaBL
    {
        public ResponseModel Guardar(List<tb_Reserva> ListaReseva)
        {
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new SeguroContext())
                {
                    foreach (tb_Reserva reserva in ListaReseva)
                    {
                        if (reserva.IdReserva > 0)
                        {
                            ctx.Entry(reserva).State = EntityState.Modified;
                        }
                        else
                        {
                            ctx.Entry(reserva).State = EntityState.Added;
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

        public AnexGRIDResponde ListarReservas(AnexGRID grid)
        {
            try
            {
                using (var ctx = new SeguroContext())
                {
                    //inicializa la grilla
                    grid.Inicializar();

                    string sql = "select (p.anio+p.mes) as periodo, m.DescripcionMoneda as moneda, r.FechaReserva as fecha," +
                                " sum(r.ReservaSepelio) as Sepelio, sum(r.ReservaGarantizado) as Garantizado, " +
                                " sum(r.ReservaMatematica) as Matematica, sum(r.ReservaTotal) as total" +
                                " , e.DescripcionEstado as estado " +
                                " from tb_Reserva r" +
                                " inner join tb_Periodo p on r.IdPeriodo = p.IdPeriodo" +
                                " inner join tb_estado e on r.IdEstado = e.IdEstado" +
                                " inner join tb_Foto f on r.IdFoto = f.IdFoto" +
                                " inner join tb_Moneda m on f.IdMoneda = m.idMoneda" +
                                " group by p.anio, p.mes, m.DescripcionMoneda , r.FechaReserva, e.DescripcionEstado" +
                                " order by periodo desc";

                    var query = ctx.Database.SqlQuery<ListaReseva>(sql).ToList();

                    //Skip(grid.pagina)-->se indica desde que página se inicia la paginacion
                    //Take(grid.limite)-->se indica la cantidad de registros a mostrar
                    var listaReserva = query.Skip(grid.pagina)
                                       .Take(grid.limite)
                                       .ToList();

                    //Se obtiene la cantidad de registros que hay en la tabla, se usa en la paginacion
                    var total = query.Count();

                    grid.SetData(
                        from p in listaReserva
                        select new
                        {
                            p.Periodo,
                            p.Moneda,
                            p.Fecha,
                            p.Sepelio,
                            p.Garantizado,
                            p.Matematica,
                            p.total,
                            p.Estado  
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

        public tb_Reserva BuscarReserva(int periodo, int moneda)
        {
            var caso = new tb_Reserva();
            try
            {
                using (var ctx = new SeguroContext())
                {
                    caso = ctx.Database.SqlQuery<tb_Reserva>("sp_BuscarReserva @p0, @p1", periodo, moneda ).SingleOrDefault();
                }
            }
            catch (Exception e)
            {
                ELog.save(this, e); //throw;
            }

            return caso;
        }

    }
}
