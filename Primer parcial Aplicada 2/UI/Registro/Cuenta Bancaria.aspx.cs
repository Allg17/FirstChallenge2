using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Primer_parcial_Aplicada_2.UI.Registro
{
    public partial class Cuenta_Bancaria : System.Web.UI.Page
    {
        BLL.RepositorioBase<CuentaBancaria> repositorio = new BLL.RepositorioBase<CuentaBancaria>();
        string condicion = "Select One";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FechaDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                LlenaComboBoxId();
            }
        }


        private void LlenaComboBoxId()
        {
            Id_DropDownList.Items.Clear();
            Id_DropDownList.Items.Add(condicion);
            Id_DropDownList.DataSource = repositorio.GetList(x => true);
            Id_DropDownList.DataValueField = "CuentaId";
            Id_DropDownList.DataTextField = "Nombre";
            Id_DropDownList.DataBind();
        }

        private CuentaBancaria GetCuenta()
        {
            int id = 0;
            if (Id_DropDownList.SelectedValue != condicion)
                id = Convert.ToInt32(Id_DropDownList.SelectedValue);
            CuentaBancaria cuentaBancaria = new CuentaBancaria();
            if (id != 0)
            {
                cuentaBancaria.CuentaId = id;
            }
            else
                cuentaBancaria.CuentaId = 0;

            cuentaBancaria.Nombre = NombreTextBox.Text;
            cuentaBancaria.Balance = 0;
            cuentaBancaria.Fecha = Convert.ToDateTime(FechaDateTime.Text);
            return cuentaBancaria;
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            LlenaComboBoxId();
            Id_DropDownList.Text = condicion;
            FechaDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            NombreTextBox.Text = string.Empty;
            BalanceTextBox.Text = string.Empty;
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            if (Id_DropDownList.Text.Equals(condicion))
            {
                if (repositorio.Guardar(GetCuenta()))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Guardado');", addScriptTags: true);
                    NuevoButton_Click(sender, e);
                }
                else
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['danger']('No se pudo Guardar');", addScriptTags: true);
            }
            else
            {
                if (repositorio.Modificar(GetCuenta()))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Modificado');", addScriptTags: true);
                    NuevoButton_Click(sender, e);
                }
                else
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['danger']('No se pudo Guardar');", addScriptTags: true);
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
                BLL.RepositorioBase<Deposito> repositorios = new BLL.RepositorioBase<Deposito>();
                if (repositorios.GetList(x => x.CuentaId == id).Count() > 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('No Eliminado tiene depositos');", addScriptTags: true);

                }
                else
                {
                    if (repositorio.Eliminar(id))
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Eliminado');", addScriptTags: true);
                        NuevoButton_Click(sender, e);
                    }
                    else
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['danger']('No se pudo Eliminar');", addScriptTags: true);
                }
                
            }
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

        protected void Id_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(Id_DropDownList.SelectedValue);
            var Cuenta = repositorio.GetList(x => x.CuentaId.Equals(id)).ElementAt(0);
            FechaDateTime.Text = Cuenta.Fecha.ToString("yyyy-MM-dd");
            NombreTextBox.Text = Cuenta.Nombre;
            BalanceTextBox.Text = Cuenta.Balance.ToString();
        }
    }
}