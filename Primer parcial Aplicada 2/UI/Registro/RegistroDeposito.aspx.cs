using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Primer_parcial_Aplicada_2.UI.Registro
{
    public partial class RegistroDeposito : System.Web.UI.Page
    {
        string condicion = "Select One";
        BLL.RepositorioBase<Entidades.Deposito> repositorio = new BLL.RepositorioBase<Entidades.Deposito>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {

                LLenaCombo();
                LlenaComboCuenta();
                FechaDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }
        private void LLenaCombo()
        {
            Id_DropDownList.Items.Clear();
            Id_DropDownList.Items.Add(condicion);
            Id_DropDownList.DataSource = repositorio.GetList(x => true);
            Id_DropDownList.DataValueField = "DepositoId";
            Id_DropDownList.DataTextField = "Monto";
            Id_DropDownList.DataBind();
        }

        private void LlenaComboCuenta()
        {
            BLL.RepositorioBase<CuentaBancaria> repositorioCuenta = new BLL.RepositorioBase<CuentaBancaria>();
            Cuenta_Id_DropDownList.Items.Clear();
           Cuenta_Id_DropDownList.Items.Add(condicion);
            Cuenta_Id_DropDownList.DataSource = repositorioCuenta.GetList(x => true);
            Cuenta_Id_DropDownList.DataValueField = "CuentaId";
            Cuenta_Id_DropDownList.DataTextField = "Nombre";
            Cuenta_Id_DropDownList.DataBind();
        }

        private Deposito GetDeposito()
        {
            int id = 0;
            Entidades.Deposito depositos = new Entidades.Deposito();
            if (Id_DropDownList.SelectedValue != condicion)
                id = Convert.ToInt32(Id_DropDownList.SelectedValue);
            if (id != 0)
            {

                depositos.DepositoId = id;
            }
            else
                depositos.DepositoId = 0;
            depositos.CuentaId = Convert.ToInt32(Cuenta_Id_DropDownList.SelectedValue);
            depositos.Concepto = ConceptoTextBox.Text;
            depositos.Fecha = Convert.ToDateTime(FechaDateTime.Text);
            depositos.Monto = Convert.ToInt32(MontoTextBox.Text);
            return depositos;
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            LLenaCombo();
            LlenaComboCuenta();
            ConceptoTextBox.Text = string.Empty;
            MontoTextBox.Text = string.Empty;
            FechaDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {

            if (Cuenta_Id_DropDownList.SelectedValue == condicion)
                return;

            BLL.DepositosBLL depositosBLL = new BLL.DepositosBLL();
            if (Id_DropDownList.Text.Equals(condicion))
            {
                if (depositosBLL.Guardar(GetDeposito()))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Guardado');", addScriptTags: true);
                    NuevoButton_Click(sender, e);
                }
                else
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['danger']('No se pudo Guardar');", addScriptTags: true);
            }
            else
            {
                if (depositosBLL.Modificar(GetDeposito()))
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
            BLL.DepositosBLL depositosBLL = new BLL.DepositosBLL();
            if (Id_DropDownList.SelectedValue != condicion)
                id = Convert.ToInt32(Id_DropDownList.SelectedValue);
            else
                return;
            if (!Id_DropDownList.Text.Equals(condicion))
            {

                if (depositosBLL.Eliminar(id))
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
            var Deposito = repositorio.GetList(x => x.DepositoId.Equals(id)).ElementAt(0);

            FechaDateTime.Text = Deposito.Fecha.ToString("yyyy-MM-dd");
            ConceptoTextBox.Text = Deposito.Concepto;
            MontoTextBox.Text = Deposito.Monto.ToString();
            Cuenta_Id_DropDownList.SelectedValue = Deposito.CuentaId.ToString();
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