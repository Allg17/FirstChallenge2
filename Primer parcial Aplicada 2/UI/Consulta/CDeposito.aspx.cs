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
    public partial class CDeposito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                AHoradateTimePicker1.Text = DateTime.Now.ToString("yyyy-MM-dd");
                FInaldateTimePicker2.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }
        BLL.RepositorioBase<Deposito> repositorio = new BLL.RepositorioBase<Deposito>();
        bool paso = false;
        Expression<Func<Deposito, bool>> filtrar = x => true;
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
                   
                    break;

                case 1:
                    if (paso)
                        return;
                    id = int.Parse(CriterioTextBox.Text);
                    if (FechacheckBox.Checked == true)
                    {
                        filtrar = t => t.CuentaId == id && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
                    }
                    else
                    {
                        filtrar = t => t.CuentaId == id;
                    }

                    break;

                case 2:
                    if (paso)
                        return;
                    if (FechacheckBox.Checked == true)
                    {
                        filtrar = t => t.DepositoId.Equals(CriterioTextBox.Text) && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
                    }
                    else
                    {
                        filtrar = t => t.DepositoId.Equals(CriterioTextBox.Text);

                    }
                    break;

                case 3:

                    if (FechacheckBox.Checked == true)
                    {
                        filtrar = t => t.Concepto.Equals(CriterioTextBox.Text) && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
                    }
                    else
                    {
                        filtrar = t => t.Concepto.Equals(CriterioTextBox.Text);
                    }

                    break;

                case 4:
                    if (paso)
                        return;
                    if (FechacheckBox.Checked == true)
                    {
                        filtrar = t => t.Monto.Equals(CriterioTextBox.Text) && (t.Fecha >= DesdeDateTime.Date) && (t.Fecha <= HastaDateTime.Date);
                    }
                    {
                        filtrar = t => t.Monto.Equals(CriterioTextBox.Text);
                    }

                    break;

            }
            DatosGridView.DataSource = repositorio.GetList(filtrar);
            DatosGridView.DataBind();
        
    }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int ejem = 0;
            if (FiltroComboBox.SelectedIndex.Equals(1) && int.TryParse(CriterioTextBox.Text, out ejem) == false || FiltroComboBox.SelectedIndex.Equals(2) && int.TryParse(CriterioTextBox.Text, out ejem) == false || FiltroComboBox.SelectedIndex.Equals(4) && int.TryParse(CriterioTextBox.Text, out ejem) == false)
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