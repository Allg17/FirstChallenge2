using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Primer_parcial_Aplicada_2.UI.Registro
{
    public partial class rPrestamos : System.Web.UI.Page
    {
        BLL.RepositorioBase<Prestamo> repositorio = new BLL.RepositorioBase<Prestamo>();
        BLL.PrestamoBLL Prestamo = new BLL.PrestamoBLL();
        string condicion = "Select One";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FechaDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                LlenaComboId();
                LlenaComboCuenta();
            }
        }

        private void LlenaComboId()
        {
            Id_DropDownList.Items.Clear();
            Id_DropDownList.Items.Add(condicion);
            Id_DropDownList.DataSource = repositorio.GetList(x => true);
            Id_DropDownList.DataValueField = "IdPrestamo";
            Id_DropDownList.DataTextField = "IdPrestamo";
            Id_DropDownList.DataBind();
        }

        private void LlenaComboCuenta()
        {
            BLL.RepositorioBase<CuentaBancaria> repositorioCuenta = new BLL.RepositorioBase<CuentaBancaria>();
            CuentaDropDownList.Items.Clear();
            CuentaDropDownList.Items.Add(condicion);
            CuentaDropDownList.DataSource = repositorioCuenta.GetList(x => true);
            CuentaDropDownList.DataValueField = "CuentaId";
            CuentaDropDownList.DataTextField = "Nombre";
            CuentaDropDownList.DataBind();
        }

        private Prestamo LlenaClase()
        {
            Prestamo prestamo = new Prestamo();
            int id = 0;
            if (Id_DropDownList.SelectedValue != condicion)
                id = Convert.ToInt32(Id_DropDownList.SelectedValue);
            if (id != 0)
            {
                prestamo.IdPrestamo = id;
            }
            else
                prestamo.IdPrestamo = 0;

            prestamo.Tiempo = Convert.ToInt32(TiempoTextBox.Text);
            prestamo.Capital = Convert.ToDecimal(CapitalTextBox.Text);
            prestamo.Interes = Convert.ToDecimal(InteresTextBox.Text);
            prestamo.Fecha = Convert.ToDateTime(FechaDateTime.Text);
            prestamo.IdCuenta = Convert.ToInt32(CuentaDropDownList.SelectedValue);
            prestamo.Detalle = (List<Cuota>)ViewState["Cuota"];
            return prestamo;

        }

        protected void CalcularButton_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (Id_DropDownList.SelectedValue != condicion)
                id = Convert.ToInt32(Id_DropDownList.SelectedValue);


            if (Id_DropDownList.Text.Equals(condicion))
                ViewState["Cuota"] = Prestamo.CalcularCuotas(Convert.ToInt32(TiempoTextBox.Text), Convert.ToDouble(CapitalTextBox.Text), (Convert.ToDouble(InteresTextBox.Text) / 100) / 12);
            else
                ViewState["Cuota"] = Prestamo.CalcularCuotasModificadas((List<Cuota>)ViewState["Cuota"], id, Convert.ToInt32(TiempoTextBox.Text), Convert.ToDouble(CapitalTextBox.Text), (Convert.ToDouble(InteresTextBox.Text) / 100) / 12);

            DatosGridView.DataSource = ViewState["Cuota"];
            DatosGridView.DataBind();



        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            FechaDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            CapitalTextBox.Text = string.Empty;
            InteresTextBox.Text = string.Empty;
            TiempoTextBox.Text = string.Empty;
            DatosGridView.DataSource = null;
            DatosGridView.DataBind();
            Id_DropDownList.Text = condicion;
            LlenaComboId();
            LlenaComboCuenta();
            ViewState["Cuota"] = null;
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            
            if (CuentaDropDownList.SelectedValue == condicion)
                return;

            if (Id_DropDownList.Text.Equals(condicion))
            {

                if (Prestamo.Guardar(LlenaClase()))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Guardado');", addScriptTags: true);
                    NuevoButton_Click(sender, e);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['danger']('No se pudo Guardar');", addScriptTags: true);
                    return;
                }
            }
            else
            {

                if (Prestamo.Modificar(LlenaClase()))
                {

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Modificado');", addScriptTags: true);
                    NuevoButton_Click(sender, e);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['danger']('No se pudo Modificar');", addScriptTags: true);
                    return;
                }
            }

        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {

            int id = 0;
            if (Id_DropDownList.SelectedValue != condicion)
                id = Convert.ToInt32(Id_DropDownList.SelectedValue);
            else
                return;
            if (!Id_DropDownList.Text.Equals(condicion))
            {
                if (Prestamo.Eliminar(id))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Eliminado');", addScriptTags: true);
                    NuevoButton_Click(sender, e);
                }
                else
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['danger']('No se pudo Eliminar');", addScriptTags: true);

            }
        }

        protected void Id_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(Id_DropDownList.SelectedValue);
            var prestamo = repositorio.GetList(x => x.IdPrestamo.Equals(id)).ElementAt(0);
            FechaDateTime.Text = prestamo.Fecha.ToString("yyyy-MM-dd");
            CuentaDropDownList.SelectedValue = prestamo.IdCuenta.ToString();
            CapitalTextBox.Text = prestamo.Capital.ToString();
            InteresTextBox.Text = prestamo.Interes.ToString();
            TiempoTextBox.Text = prestamo.Tiempo.ToString();
            ViewState["Cuota"] = prestamo.Detalle;
            DatosGridView.DataSource = (List<Cuota>)ViewState["Cuota"];
            DatosGridView.DataBind();

        }

        protected void DatosGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DatosGridView.DataSource = (List<Cuota>)ViewState["Cuota"];
            DatosGridView.PageIndex = e.NewPageIndex;
            DatosGridView.DataBind();
        }

        protected void ImprimirButton_Click(object sender, EventArgs e)
        {

          
            Response.Write("<script>window.open('../../PrestamoReporte.aspx','_blanck');</script");

        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Equals(condicion))
            {
                args.IsValid = false;

            }
            else
                args.IsValid = true;
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Equals(condicion))
            {
                args.IsValid = false;

            }
            else
                args.IsValid = true;
        }
    }
}