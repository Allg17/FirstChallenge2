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
    public partial class PrestamoReporte : System.Web.UI.Page
    {
        BLL.RepositorioBase<Prestamo> repositorio = new BLL.RepositorioBase<Prestamo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var Prestamos = repositorio.GetList(x => true).Last();
                List<Prestamo> prestamo = new List<Prestamo>();

                prestamo.Add(new Prestamo(Prestamos.IdPrestamo, Prestamos.Interes, Prestamos.IdCuenta, Prestamos.Capital, Prestamos.Tiempo, Prestamos.Fecha));

                ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                ReportViewer1.Reset();

                ReportViewer1.LocalReport.ReportPath = Server.MapPath(@"~\Reporte\ReportePrestamo.rdlc");

                ReportViewer1.LocalReport.DataSources.Clear();

                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("PrestamoDataset", prestamo));
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("CuotaDatSet", repositorio.GetList(x => true).Last().Detalle));

                ReportViewer1.LocalReport.Refresh();
            }
        }
    }
}