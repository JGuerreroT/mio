using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace AdministradorSeguros.Reportes
{
    public partial class frm_reporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void Reporte()
        {
            try
            {
                //List<vConsultaPersona> datos = new List<vConsultaPersona>();

                //using (Repositorio<vConsultaPersona> obj = new Repositorio<vConsultaPersona>())
                //{
                //    datos = obj.Filter(x => true);
                //}

                ReportViewer1.LocalReport.DataSources.Clear();
                //ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("vConsultaPersona", datos));

                ReportViewer1.LocalReport.ReportPath = "Reportes/ReportePrueba.rpt";

                ReportViewer1.Visible = true;

                ReportViewer1.LocalReport.Refresh();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}