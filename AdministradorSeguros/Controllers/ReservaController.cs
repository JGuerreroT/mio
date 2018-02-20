using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using AdimistradorSeguros.Filters;
using PlantillaObjetos;
using Repositorio;
using Helper;
using System.IO;
using SpreadsheetGear;
using System.Globalization;

namespace AdministradorSeguros.Controllers
{
    public class ReservaController : Controller
    {
        private FotoBL foto = new FotoBL();
        private PeriodoBL periodo = new PeriodoBL();
        private MonedaBL moneda = new MonedaBL();
        private CoberturaBL cobertura = new CoberturaBL();
        private RelacionFamiliarBL relacionFamiliar = new RelacionFamiliarBL();
        private SaludBL salud = new SaludBL();
        private TipoPersonaBL tipoPersona = new TipoPersonaBL();
        private SexoBL sexo = new SexoBL();
        private SepelioBL sepelio = new SepelioBL();
        private TipoCambioBL tipoCambio = new TipoCambioBL();
        private IpcBL ipc = new IpcBL();
        private ReservaBL reserva = new ReservaBL();

        private IWorkbook _workbook;
        private IWorksheet _worksheetCalculo;

        tb_Reserva reservaEF;
        tb_ReservaDetalle reservaDetalleEF;

        List<tb_Reserva> listaReserva;
        List<tb_ReservaDetalle> listaDetalle;

        private readonly System.Globalization.CultureInfo _myCIintl = new System.Globalization.CultureInfo("es-PE", false);

        // GET: Reserva
        public ActionResult Index()
        {
            ViewBag.Periodos = periodo.ListarPeriodo();
            ViewBag.Monedas = moneda.ListarMoneda();
            return View();
        }

        public JsonResult CalcularReserva(EntidadFiltro model)
        {
            var rm = new ResponseModel();

            int idPeriodo = model.IdPeriodo;
            int idMoneda = model.IdMoneda;

            //tb_Foto fotoEF = new tb_Foto();
            List<tb_Foto> listaFotos = new List<tb_Foto>();

            listaReserva = new List<tb_Reserva>();
            listaDetalle = new List<tb_ReservaDetalle>();

            listaFotos = foto.ObtenerFoto(idPeriodo, idMoneda);

            if (listaFotos.Count()!=0)
            {
                var caso = reserva.BuscarReserva(idPeriodo, idMoneda);

                if (caso == null)
                {
                    var path = Path.Combine(Server.MapPath("~/Motor/"), "Motor.xlsx");

                    _workbook = Factory.GetWorkbook(path, _myCIintl);
                    _worksheetCalculo = _workbook.Worksheets["RS"];

                    _workbook.WorkbookSet.Calculation = Calculation.Manual;
                    _workbook.WorkbookSet.BackgroundCalculation = true;

                    foreach (tb_Foto fotoEF in listaFotos)
                    {
                        foreach (tb_FotoDetalle poliza in fotoEF.tb_FotoDetalle)
                        {
                            #region poliza
                            var _worksheetC = _worksheetCalculo;
                            var monPol = moneda.ObtenerMoneda(fotoEF.IdMoneda);
                            var cobPol = cobertura.ObtenerCobertura(poliza.IdCobertura);

                            DateTime fechaCalculo = model.FechaCalculo;

                            var sepelioPol = sepelio.ObtenerSepelio(fechaCalculo);
                            var tcPol = tipoCambio.ObtenerTipoCambio(fechaCalculo);
                            var ipcPol = ipc.ObtenerIPC(fechaCalculo);

                            _worksheetC.Cells["C4"].Value = monPol.CodigoMoneda.Trim();
                            _worksheetC.Cells["C5"].Value = cobPol.ResumenCobertura.Substring(0, 1).Trim();
                            _worksheetC.Cells["C6"].Value = poliza.PeriodoDiferido;
                            _worksheetC.Cells["C7"].Value = poliza.PeriodoGarantizado;
                            _worksheetC.Cells["C8"].Value = sepelioPol.MontoGS;
                            _worksheetC.Cells["C9"].Value = poliza.Gratificacion ? "S" : "N";
                            _worksheetC.Cells["C10"].Value = poliza.DerechoACrecer ? "S" : "N";
                            _worksheetC.Cells["C12"].Value = poliza.PorcentajeGarantizado;
                            _worksheetC.Cells["C13"].Value = poliza.TasaReserva;
                            _worksheetC.Cells["C15"].Value = poliza.PensionReserva;

                            _worksheetC.Cells["F4"].Value = poliza.Estudiante ? "1" : "0";
                            _worksheetC.Cells["F5"].Value = poliza.FechaEnvio;
                            _worksheetC.Cells["F6"].Value = fechaCalculo.ToShortDateString();
                            _worksheetC.Cells["F7"].Value = poliza.FechaDevengue;
                            _worksheetC.Cells["F14"].Value = poliza.TasaVenta;

                            _worksheetC.Cells["J8"].Value = tcPol.ImporteTC;
                            #endregion

                            int contador = 0;

                            foreach (tb_FotoDetallePoliza polizaDetalle in poliza.tb_FotoDetallePoliza)
                            {
                                #region beneficiarios
                                var parentesco = relacionFamiliar.ObtenerRelacionFamiliar(polizaDetalle.IdRelacionFamiliar);
                                var saludBene = salud.ObtenerSalud(polizaDetalle.IdSalud);
                                var tipoBene = tipoPersona.ObtenerTipoPersona(polizaDetalle.IdTipoPersona);
                                var sexoBene = sexo.ObtenerSexo(polizaDetalle.IdSexo);

                                var fallecimiento = "";

                                if (parentesco.ResumenRelacionFamiliar.Trim() == "T")
                                {
                                    if (polizaDetalle.FechaFallecimiento.Year != 1899)
                                    {
                                        fallecimiento = polizaDetalle.FechaFallecimiento.ToShortDateString();
                                    }

                                    _worksheetC.Cells["C11"].Value = fallecimiento;

                                    _worksheetC.Cells["A21"].Value = polizaDetalle.IdFotoDetallePoliza;
                                    _worksheetC.Cells["B21"].Value = polizaDetalle.FechaNacimiento;
                                    _worksheetC.Cells["C21"].Value = parentesco.ResumenRelacionFamiliar.Trim();
                                    _worksheetC.Cells["H21"].Value = saludBene.ResumenSalud.Trim();
                                    _worksheetC.Cells["I21"].Value = sexoBene.ResumenSexo.Trim() == "M" ? "H" : "M";
                                    _worksheetC.Cells["J21"].Value = poliza.PensionReserva * polizaDetalle.PorcentajeBeneficio;
                                    _worksheetC.Cells["K21"].Value = cobPol.ResumenCobertura.Substring(0, 1).Trim() == "I" ? cobPol.PorcentajeCobertura.ToString().Trim() : "";
                                }
                                else
                                {
                                    _worksheetC.Cells["A" + (26 + contador).ToString()].Value = polizaDetalle.IdFotoDetallePoliza;
                                    _worksheetC.Cells["B" + (26 + contador).ToString()].Value = polizaDetalle.FechaNacimiento;
                                    _worksheetC.Cells["C" + (26 + contador).ToString()].Value = parentesco.ResumenRelacionFamiliar.Trim();
                                    _worksheetC.Cells["H" + (26 + contador).ToString()].Value = saludBene.ResumenSalud.Trim();
                                    _worksheetC.Cells["I" + (26 + contador).ToString()].Value = sexoBene.ResumenSexo.Trim() == "M" ? "H" : "M";
                                    _worksheetC.Cells["J" + (26 + contador).ToString()].Value = poliza.PensionReserva * polizaDetalle.PorcentajeBeneficio;

                                }
                                #endregion
                            }

                            _workbook.WorkbookSet.Calculate();

                            var aaa = _worksheetC.Cells["A" + (26 + contador).ToString()].Value.ToString();

                            //var path1 = Path.Combine(Server.MapPath("~/Motor/"), "aaaaa.xlsx");
                            //_workbook.SaveAs(path1, FileFormat.OpenXMLWorkbook);

                            reservaEF = new tb_Reserva();

                            #region reservaCabecer
                            reservaEF.IdPeriodo = idPeriodo;
                            reservaEF.IdFoto = fotoEF.IdFoto;
                            reservaEF.IdFotoDetalle = poliza.IdFotoDetalle;
                            reservaEF.FechaReserva = fechaCalculo;
                            reservaEF.ReservaSepelio = Convert.ToDecimal(_worksheetC.Cells["J5"].Value.ToString());
                            reservaEF.ReservaGarantizado = Convert.ToDecimal(_worksheetC.Cells["L24"].Value.ToString());
                            reservaEF.ReservaMatematica = Convert.ToDecimal(_worksheetC.Cells["K4"].Value.ToString());
                            reservaEF.ReservaTotal = Convert.ToDecimal(_worksheetC.Cells["J6"].Value.ToString());
                            reservaEF.IdSepelio = sepelioPol.IdSepelio; ;
                            reservaEF.IdTipoCambio = tcPol.IdTipoCambio;
                            reservaEF.IdTasaMercado = 10;
                            reservaEF.IdTasaAnclaje = 1;
                            reservaEF.IdFactorSeguridad = 1;
                            reservaEF.FactorIPC = 1;
                            reservaEF.IdEdadMaxima = 1;
                            reservaEF.IdEstado = poliza.IdEstado;
                            reservaEF.PensionReserva = poliza.PensionReserva;
                            reservaEF.IdIPC = ipcPol.idIPC; ;
                            reservaEF.IPCInicial = 1;
                            reservaEF.IPCFinal = 1;
                            #endregion

                            listaDetalle = new List<tb_ReservaDetalle>();

                            reservaDetalleEF = new tb_ReservaDetalle();

                            #region reservaDetalle
                            reservaDetalleEF.IdFotoDetallePoliza = Convert.ToInt32(_worksheetC.Cells["A21"].Value);
                            reservaDetalleEF.ReservaMatematica = Convert.ToDecimal(_worksheetC.Cells["L21"].Value);
                            reservaDetalleEF.ReservaSepelio = 0;
                            reservaDetalleEF.ReservaGarantizada = 0;
                            reservaDetalleEF.PensionReserva = Convert.ToDecimal(_worksheetC.Cells["J21"].Value);

                            listaDetalle.Add(reservaDetalleEF);

                            contador = 0;

                            var aaaaa = _worksheetC.Cells["A" + (26 + contador).ToString()].Value.ToString();

                            for (int i = 0; i < 11; i++)
                            {
                                var aaaaaaaa = _worksheetC.Cells["A" + (26 + i).ToString()].Value.ToString();
                                var zaazzz = _worksheetC.Cells["A26"].Value.ToString();
                                var zzzz = _worksheetC.Cells["A" + (26 + i).ToString()].Value.ToString();
                                var vvv = Convert.ToInt32(_worksheetC.Cells["A" + (26 + i).ToString()].Value.ToString());

                                reservaDetalleEF = new tb_ReservaDetalle();
                                reservaDetalleEF.IdFotoDetallePoliza = Convert.ToInt32(_worksheetC.Cells["A" + (26 + i).ToString()].Value.ToString());
                                reservaDetalleEF.ReservaMatematica = Convert.ToDecimal(_worksheetC.Cells["L" + (26 + i).ToString()].Value.ToString());
                                reservaDetalleEF.ReservaSepelio = 0;
                                reservaDetalleEF.ReservaGarantizada = 0;
                                reservaDetalleEF.PensionReserva = Convert.ToDecimal(_worksheetC.Cells["J" + (26 + i).ToString()].Value.ToString());

                                listaDetalle.Add(reservaDetalleEF);

                                if (_worksheetC.Cells["A" + (26 + i + 1).ToString()].Value == null)
                                {
                                    break;
                                }
                            }

                            #region
                            //foreach (IRange row in _worksheetC.Cells["B26:B35"].Rows )
                            //{
                            //    var aaaaaaaa = _worksheetC.Cells["A" + (26 + contador).ToString()].Value.ToString();

                            //    var zaazzz = row.Cells["A26"].Value.ToString();

                            //    var zzzz = row.Cells["A" + (26 + contador).ToString()].Value.ToString();
                            //    var vvv= Convert.ToInt32(row.Cells["A" + (26 + contador).ToString()].Value.ToString());

                            //    reservaDetalleEF = new tb_ReservaDetalle();
                            //    reservaDetalleEF.IdFotoDetallePoliza = Convert.ToInt32(row.Cells["A" + (26 + contador).ToString()].Value.ToString());
                            //    reservaDetalleEF.ReservaMatematica = Convert.ToDecimal(row.Cells["L" + (26 + contador).ToString()].Value.ToString());
                            //    reservaDetalleEF.ReservaSepelio = 0;
                            //    reservaDetalleEF.ReservaGarantizada = 0;
                            //    reservaDetalleEF.PensionReserva = Convert.ToDecimal(row.Cells["J" + (26 + contador).ToString()].Value.ToString());

                            //    listaDetalle.Add(reservaDetalleEF);

                            //    if (row.Cells["A" + (26 + contador+1).ToString()].Value == null)
                            //    {
                            //        break;
                            //    }
                            //}
                            #endregion

                            #endregion

                            reservaEF.tb_ReservaDetalle = listaDetalle;

                            listaReserva.Add(reservaEF);
                        }
                    }

                    if (ModelState.IsValid)
                    {
                        rm = reserva.Guardar(listaReserva);

                        if (rm.response)
                        {
                            //rm.function = "MensajeGrabacion()";
                            rm.SetResponse(false, "El cálculo de la reserva terminó con exito!");
                            //rm.href = Url.Content("~/reserva/importar");
                        }

                    }
                }
                else
                {
                    rm.SetResponse(false, "No se puede calcular la reserva. Ya se calculó para el periodo y moneda seleccionada");
                    //rm.href = Url.Content("~/reserva");
                }
            }
            else
            {
                rm.SetResponse(false, "No se puede realizar el cálculo dela reserva, no hay copias de pólizas áctivas realizadas");
                //rm.href = Url.Content("~/reserva");
            }

            return Json(rm);
        }

        public ActionResult Importar()
        {
            ViewBag.Periodos = periodo.ListarPeriodo();
            ViewBag.Monedas = moneda.ListarMoneda();
            return View();
        }

        public JsonResult CargarReservas(AnexGRID grid)
        {
            return Json(reserva.ListarReservas(grid));
        }


    }
}