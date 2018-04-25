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
using System.Diagnostics;

namespace AdministradorSeguros.Controllers
{
    [Autenticado]
    public class PolizaController : Controller
    {
        // GET: Poliza
        #region variables
        private PolizaBL poliza = new PolizaBL();
        private EstadoBL estado = new EstadoBL();
        private SexoBL sexo = new SexoBL();
        private PersonaBL personaBL = new PersonaBL();
        private RelacionFamiliarBL relacionFamiliar = new RelacionFamiliarBL();
        private SaludBL salud = new SaludBL();
        private TipoPensionistaBL tipoPensionista = new TipoPensionistaBL();
        private TipoPersonaBL tipoPersona = new TipoPersonaBL();
        private PeriodoBL periodo = new PeriodoBL();
        private CoberturaBL cobertura = new CoberturaBL();
        private MonedaBL moneda = new MonedaBL();
        private ModalidadBL modalidad = new ModalidadBL();

        private IWorkbook _workbook;
        private IWorksheet _worksheetP;
        private IWorksheet _worksheetB;
        
        // private readonly Log _oLog = new Log();
        private readonly System.Globalization.CultureInfo _myCIintl = new System.Globalization.CultureInfo("es-PE", false);
        #endregion

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Crud(int id = 0)
        {
            ViewBag.Ramos = cobertura.ListarCobertura();
            ViewBag.Modalidades = modalidad.ListarModalidad();
            ViewBag.Periodos = periodo.ListarPeriodo();
            ViewBag.Monedas = moneda.ListarMoneda();

            var pol = new tb_Poliza();

            if (id == 0)
            {
                return View(pol);
            }
            else
            {
                pol=poliza.ObtenerPoliza(id);
                return View(pol);
            }


            //return View(
            //    id == 0 ? pol
            //            : poliza.ObtenerPoliza(id)
            //    );
        }

        public ActionResult Crud2(int id = 0)
        {
            ViewBag.Ramos = cobertura.ListarCobertura();
            ViewBag.Modalidades = modalidad.ListarModalidad();
            ViewBag.Periodos = periodo.ListarPeriodo();
            ViewBag.Monedas = moneda.ListarMoneda();

            var pol = new tb_Poliza();

            ////Correo mail = new Correo();
            
            ////var path = Path.Combine(Server.MapPath("~/Motor/"), "Motor.xlsx");

            ////mail.EnviarCorreoOuttlook("prueba de envio",true , path);


            if (id == 0)
            {
                return View(pol);
            }
            else
            {
                pol = poliza.ObtenerPoliza(id);
                return View(pol);
            }


            //return View(
            //    id == 0 ? pol
            //            : poliza.ObtenerPoliza(id)
            //    );
        }

        public JsonResult CargarPolizas(AnexGRID grid)
        {
            return Json(poliza.ListarPolizas(grid));
        }

        public ActionResult Ver(int id = 0)
        {
            return View(poliza.ObtenerPoliza(id));
        }

        public ActionResult Importar()
        {
            return View();
        }

        public JsonResult ImportarPolizas(tb_Adjunto model, HttpPostedFileBase Ruta)
        {
            var rm = new ResponseModel();
            string path;
            string filename;
            int codigo = 0;

            tb_Persona persona;
            tb_Poliza polizaEF;
            tb_PolizaDetalle polizaDetalle;
            List<tb_Poliza> polizas = new List<tb_Poliza>();

            if (Ruta != null)
            {
                if (ModelState.IsValid )
                {
                    var agggg = Path.GetExtension(Ruta.FileName).ToString();
                    if (Path.GetExtension(Ruta.FileName).ToString() != ".xls" && Path.GetExtension(Ruta.FileName).ToString() != ".xlsx")
                    {
                        rm.SetResponse(false, "Debe escoger un archivo Excel (xls/xlsx)");
                    }
                    else
                    {
                        #region Guardar Archivo Excel
                        // Nombre del archivo, es decir, lo renombramos para que no se repita nunca
                        //                Archivo.SaveAs(Server.MapPath("~/uploads/" + Archivo.FileName ));
                        filename = Path.GetFileName(Ruta.FileName);

                        path = Path.Combine(Server.MapPath("~/uploads/"), filename);

                        Ruta.SaveAs(path);
                        #endregion

                        #region Manejo rango celdas SpreedsheetGear
                        _workbook = Factory.GetWorkbook(path, _myCIintl);
                        _worksheetP = _workbook.Worksheets["Polizas"];
                        _worksheetB = _workbook.Worksheets["Beneficiarios"];                        

                        string filaFinalP = _worksheetP.Cells.EndRight.EndDown.Address;
                        string filaFinalB = _worksheetB.Cells.EndRight.EndDown.Address;

                        string direccionfilaFinalP = "$A$2:" + filaFinalP;
                        string direccionfilaFinalB = "$A$2:" + filaFinalB;

                        IRange wsP = _worksheetP.Cells[direccionfilaFinalP].Rows;
                        IRange wsB = _worksheetB.Cells[direccionfilaFinalB].Rows;

                        IRange celdas = wsB.Cells;
                        #endregion

                        foreach (IRange rowPoliza in wsP.Cells.Rows)
                        {
                            polizaEF = new tb_Poliza();

                            polizaEF = CargarPoliza(rowPoliza , polizaEF );

                            foreach (IRange rowBeneficiario in wsB.Cells.Rows)
                            {
                                string a = polizaEF.NumeroPoliza.ToString();
                                string b = rowBeneficiario[0, 1].Value.ToString();

                                if (polizaEF.NumeroPoliza.ToString() == rowBeneficiario[0,1].Value.ToString())
                                {
                                    persona = new tb_Persona();

                                    persona = CargarPersona(rowBeneficiario, persona);

                                    //persona.idPersona = personaBL.GuardarPersona(persona);

                                    polizaDetalle = new tb_PolizaDetalle();

                                    polizaDetalle = CargarDetalle(rowBeneficiario, polizaDetalle, persona);

                                    polizaEF.tb_PolizaDetalle.Add(polizaDetalle);

                                    codigo = Convert.ToInt32(rowBeneficiario[0, 0].Value.ToString());
                                }
                                else
                                {
                                    if (codigo < Convert.ToInt32(rowBeneficiario[0, 0].Value.ToString()))
                                    {
                                        break;
                                    }
                                }
                            }

                            polizas.Add(polizaEF);
                            //rm = poliza.Guardar(polizaEF);
                        }

                        path = Path.Combine(Server.MapPath("~/uploads/"), "importar0.txt");

                        StreamWriter sw = new StreamWriter(path, true);

                        StackTrace stacktrace = new StackTrace();
                        sw.WriteLine("las polizas se importaron");
                        sw.WriteLine("hora:  " + System.DateTime.Now.ToString("HH:mm:ss"));
                        sw.WriteLine("");

                        sw.Flush();
                        sw.Close();

                        rm = poliza.Guardar(polizas );

                        path = Path.Combine(Server.MapPath("~/uploads/"), "importar.txt");

                        sw = new StreamWriter(path, true);

                        stacktrace = new StackTrace();
                        sw.WriteLine("las polizas se importaron");
                        sw.WriteLine("hora:  "+ System.DateTime.Now.ToString("HH:mm:ss"));
                        sw.WriteLine("");

                        sw.Flush();
                        sw.Close();

                        if (rm.response)
                        {
                            //rm.function = "MensajeGrabacion()";
                            //rm.href = Url.Content("~/poliza/importar");
                            rm.SetResponse(false, "Importación de pólizas terminó satisfactoriamente!");
                        }
                    }
                }
            }
            else
            {
                rm.SetResponse(false, "Debe escoger un archivo");
            }
            return Json(rm);
        }

        private tb_Poliza CargarPoliza(IRange rowPoliza, tb_Poliza polizaEF)
        {
            var anioPeriodo = rowPoliza[0, 1].Value.ToString().Substring(0, 4);
            var mesPeriodo = rowPoliza[0, 1].Value.ToString().Substring(4, 2);

            polizaEF.NumeroPoliza = Convert.ToInt32(rowPoliza[0, 4].Value.ToString());
            polizaEF.FechaDevengue = DateTime.FromOADate(Double.Parse(rowPoliza[0, 5].Value.ToString()));
            polizaEF.FechaVigencia = DateTime.FromOADate(Double.Parse(rowPoliza[0, 6].Value.ToString()));
            polizaEF.FechaEnvio = DateTime.FromOADate(Double.Parse(rowPoliza[0, 17].Value.ToString()));
            polizaEF.FechaNotificacion = DateTime.FromOADate(Double.Parse(rowPoliza[0, 20].Value.ToString()));
            polizaEF.IdMoneda = moneda.ObtenerMoneda(rowPoliza[0, 3].Value.ToString());

            //var d = rowPoliza[0, 2].Value.ToString();

            polizaEF.IdCobertura = Convert.ToInt32(rowPoliza[0, 2].Value.ToString());
//            polizaEF.IdCobertura = cobertura.ObtenerCobertura1(rowPoliza[0, 2].Value.ToString());

            polizaEF.IdModalidad = modalidad.ObtenerModalidad(rowPoliza[0, 22].Value.ToString());
            polizaEF.PeriodoDiferido = Convert.ToInt32(rowPoliza[0, 7].Value.ToString());
            polizaEF.PeriodoGarantizado = Convert.ToInt32(rowPoliza[0, 8].Value.ToString());
            polizaEF.Gratificacion = (rowPoliza[0, 9].Value.ToString() == "1") ? true : false;
            polizaEF.DerechoACrecer = (rowPoliza[0, 14].Value.ToString() == "1") ? true : false;
            polizaEF.Calce = (rowPoliza[0, 18].Value.ToString() == "1") ? true : false;
            polizaEF.Repacto = (rowPoliza[0, 25].Value.ToString() == "1") ? true : false;
            polizaEF.Prima = Convert.ToDecimal(rowPoliza[0, 13].Value.ToString());
            polizaEF.CICInical = Convert.ToDecimal(rowPoliza[0, 21].Value.ToString());
            polizaEF.CICFInal = Convert.ToDecimal(rowPoliza[0, 21].Value.ToString());
            polizaEF.TasaVenta = Convert.ToDecimal(rowPoliza[0, 12].Value.ToString());
            polizaEF.TasaReserva = Convert.ToDecimal(rowPoliza[0, 11].Value.ToString());
            polizaEF.RentaTemporal = (rowPoliza[0, 26].Value.ToString() == "1") ? true : false;
            polizaEF.PorcentajeRentaTemporal = Convert.ToDecimal(rowPoliza[0, 23].Value.ToString());
            polizaEF.PeriodoInicialRentaTemporal = Convert.ToInt32(rowPoliza[0, 24].Value.ToString());
            polizaEF.IdCotizacion = 1;
            polizaEF.IdPeriodo = periodo.ObtenerPeriodo(anioPeriodo, mesPeriodo);
            polizaEF.Estudiante = (rowPoliza[0, 15].Value.ToString() == "1") ? true : false;
            polizaEF.PorcentajeGarantizado = Convert.ToDecimal(rowPoliza[0, 16].Value.ToString());
            polizaEF.PensionIncial = Convert.ToDecimal(rowPoliza[0, 10].Value.ToString());
            polizaEF.PensionDevengue = Convert.ToDecimal(rowPoliza[0, 10].Value.ToString());
            polizaEF.PensionReserva = Convert.ToDecimal(rowPoliza[0, 10].Value.ToString());
            polizaEF.IdEstado = estado.ObtenerEstado(rowPoliza[0, 19].Value.ToString());

            return polizaEF;
        }

        private tb_Persona CargarPersona(IRange rowBeneficiario, tb_Persona persona)
        {
            persona.Nombre = rowBeneficiario[0, 12].Value.ToString();
            persona.Apellido = rowBeneficiario[0, 13].Value.ToString();
            persona.CUSSPP = rowBeneficiario[0, 2].Value.ToString();
            persona.DNI = rowBeneficiario[0, 14].Value.ToString();
            persona.FechaNacimiento = DateTime.FromOADate(Double.Parse(rowBeneficiario[0, 5].Value.ToString()));
            persona.FechaFallecimiento = DateTime.FromOADate(Double.Parse(rowBeneficiario[0, 8].Value.ToString()));
            persona.IdEstado = estado.ObtenerEstado(rowBeneficiario[0, 10].Value.ToString());
            persona.IdSexo = sexo.ObtenerSexo(rowBeneficiario[0, 6].Value.ToString());

            return persona;

        }

        private tb_PolizaDetalle CargarDetalle(IRange rowBeneficiario, tb_PolizaDetalle polizaDetalle, tb_Persona persona)
        {
            //polizaDetalle.IdPersona = persona.idPersona;
            polizaDetalle.tb_Persona = persona;
            polizaDetalle.IdRelacionFamiliar = relacionFamiliar.ObtenerRelacionFamiliar(rowBeneficiario[0, 4].Value.ToString());
            polizaDetalle.IdSalud = salud.ObtenerSalud(rowBeneficiario[0, 7].Value.ToString());
            polizaDetalle.PorcentajeBeneficio = Convert.ToDecimal(rowBeneficiario[0, 9].Value.ToString());
            polizaDetalle.IdTipoPersona = tipoPersona.ObtenerTipoPersona(rowBeneficiario[0, 11].Value.ToString());
            polizaDetalle.IdTipoPensionista = tipoPensionista.ObtenerTipoPensionista(rowBeneficiario[0, 3].Value.ToString());
            polizaDetalle.IdEstado = estado.ObtenerEstado(rowBeneficiario[0, 15].Value.ToString());

            return polizaDetalle;

        }

        public JsonResult Guardar(tb_Poliza model)
        {
            var rm = new ResponseModel();

            if (ModelState.IsValid)
            {
                rm = poliza.Guardar(model);

                if (rm.response)
                {
                    rm.function = "MensajeGrabacion()";
                    rm.href = Url.Content("~/Poliza");
                }

            }
            return Json(rm);
        }

        public ActionResult Reporte()
        {
            return Redirect("~/Reportes/frm_reporte.aspx");
        }

    }
}