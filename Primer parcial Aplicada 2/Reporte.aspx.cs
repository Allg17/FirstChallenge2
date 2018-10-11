using Entidades;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Primer_parcial_Aplicada_2
{
    public partial class Reporte : System.Web.UI.Page
    {
        BLL.RepositorioBase<CuentaBancaria> repositorio = new BLL.RepositorioBase<CuentaBancaria>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                ReportViewer1.Reset();

                ReportViewer1.LocalReport.ReportPath = Server.MapPath(@"~\Reporte\Reporte.rdlc");

                ReportViewer1.LocalReport.DataSources.Clear();

                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", repositorio.GetList(x => true)));
                ReportViewer1.LocalReport.Refresh();
            }

        }
    }
}