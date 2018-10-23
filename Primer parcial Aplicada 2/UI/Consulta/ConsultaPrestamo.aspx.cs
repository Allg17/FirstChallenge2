using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Primer_parcial_Aplicada_2.UI.Consulta
{
    public partial class ConsultaPrestamo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                AHoradateTimePicker1.Text = DateTime.Now.ToString("yyyy-MM-dd");
                FInaldateTimePicker2.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }

        }
        BLL.RepositorioBase<Prestamo> repositorio = new BLL.RepositorioBase<Prestamo>();
        bool paso = false;
        Expression<Func<Prestamo, bool>> filtrar = x => true;

        protected void DatosGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DatosGridView.DataSource = repositorio.GetList(filtrar);
            DatosGridView.PageIndex = e.NewPageIndex;
            DatosGridView.DataBind();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            var DesdeDateTime = Convert.ToDateTime(AHoradateTimePicker1.Text);
            var HastaDateTime = Convert.ToDateTime(FInaldateTimePicker2.Text);
            int id = 0;
            if (FiltroComboBox.Text == string.Empty && FechacheckBox.Checked == true)
            {
                filtrar = t => true && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
            }
            else
            {
                filtrar = t => true;
            }
            switch (FiltroComboBox.SelectedIndex)
            {

                //Lista todo
                case 0:

                    if (FechacheckBox.Checked == true)
                    {
                        filtrar = t => true && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
                    }
                    else
                    {
                        filtrar = t => true;
                    }
                    //filtrar = t => (t.Fecha.Day >= DesdeDateTime.Day) && (t.Fecha.Month >=  DesdeDateTime.Month) && (t.Fecha.Year >=  DesdeDateTime.Year) &&(t.Fecha.Day <= HastaDateTime.Day) && (t.Fecha.Month <= HastaDateTime.Month) && (t.Fecha.Year <= HastaDateTime.Year);
                    break;

                case 1:
                    if (paso)
                        return;
                    id = int.Parse(CriterioTextBox.Text);
                    if (FechacheckBox.Checked == true)
                    {
                        filtrar = t => t.IdPrestamo == id && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
                    }
                    else
                    {
                        filtrar = t => t.IdPrestamo == id;
                    }

                    break;

                case 2:

                    if (paso)
                        return;
                    id = int.Parse(CriterioTextBox.Text);
                    if (FechacheckBox.Checked == true)
                    {
                        filtrar = t => t.IdCuenta == id && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
                    }
                    else
                    {
                        filtrar = t => t.IdCuenta == id;

                    }
                    break;

                case 3:
                    if (paso)
                        return;

                   decimal   idDecimal = Convert.ToDecimal(CriterioTextBox.Text);
                    if (FechacheckBox.Checked == true)
                    {
                        filtrar = t => t.Interes == idDecimal && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
                    }
                    else
                    {
                        filtrar = t => t.Interes == idDecimal;
                    }

                    break;

                case 4:
                    if (paso)
                        return;

                    id = int.Parse(CriterioTextBox.Text);
                    if (FechacheckBox.Checked == true)
                    {
                        filtrar = t => t.Tiempo == id && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
                    }
                    else
                    {
                        filtrar = t => t.Tiempo == id;
                    }

                    break;
                case 5:
                    if (paso)
                        return;

                    decimal idDecimalCapital = Convert.ToDecimal(CriterioTextBox.Text);
                    if (FechacheckBox.Checked == true)
                    {
                        filtrar = t => t.Capital == idDecimalCapital && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
                    }
                    else
                    {
                        filtrar = t => t.Capital == idDecimalCapital;
                    }

                    break;


            }
            DatosGridView.DataSource = repositorio.GetList(filtrar);
            DatosGridView.DataBind();
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int ejem = 0;
            if (FiltroComboBox.SelectedIndex.Equals(1) && int.TryParse(CriterioTextBox.Text, out ejem) == false || FiltroComboBox.SelectedIndex.Equals(3) && int.TryParse(CriterioTextBox.Text, out ejem) == false)
            {
                paso = true;
                args.IsValid = false;
                CustomValidator1.ErrorMessage = "Debe introducir un numero en el criterio";
            }
            else
            {
                args.IsValid = true;
                paso = false;
            }
        }
    }
}