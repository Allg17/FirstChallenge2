<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Master Page/Master.Master" AutoEventWireup="true" CodeBehind="RegistroDeposito.aspx.cs" Inherits="Primer_parcial_Aplicada_2.UI.Registro.RegistroDeposito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class=" panel panel-primary">
        <div class="panel-heading text-center">
            <h1><ins>Deposito</ins></h1>
            <br />
        </div>


        <div class="panel-body">
            <div class="form-horizontal col-md-12" role="form">
                <%--Id dropdown--%>
                <div class=" form-group">
                    <div class="col-md-8 col-sm-4 ">
                        <label for="Id_DropDownList" class="col-md-3 control-label input-sm">ID:</label>
                        <div class="col-md-4 col-sm-4">
                            <asp:DropDownList ValidationGroup="ID" ID="Id_DropDownList" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="Id_DropDownList_SelectedIndexChanged" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                            <asp:CustomValidator ValidationGroup="ID" ID="CustomValidator1" Display="Dynamic" SetFocusOnError="true" CssClass="ErrorMessage" ControlToValidate="Id_DropDownList" runat="server" ErrorMessage="Seleccione una Deposito" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                        </div>
                    </div>
                </div>

                <%--Fecha--%>
                <div class="form-group">
                    <div class="col-md-8 col-sm-4 ">
                        <label for="FechaDateTime" class="col-md-3 control-label input-sm">Fecha:</label>
                        <div class="col-md-4 col-sm-4">
                            <asp:TextBox ID="FechaDateTime"  ValidationGroup="Guardar" TextMode="Date" CssClass="form-control input-sm" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup="Guardar" ID="RequiredFieldValidator1" ControlToValidate="FechaDateTime" CssClass="ErrorMessage" runat="server" ErrorMessage="Ingresar Fecha"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <%--Cuenta Id dropdown--%>
                <div class=" form-group">
                    <div class="col-md-8 col-sm-4 ">
                        <label for="Cuenta_Id_DropDownList" class="col-md-3 control-label input-sm">Cuenta ID:</label>
                        <div class="col-md-4 col-sm-4">
                            <asp:DropDownList  ValidationGroup="Guardar" AutoPostBack="true" ID="Cuenta_Id_DropDownList" AppendDataBoundItems="true" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator  ValidationGroup="Guardar" ID="RequiredFieldValidator2" ControlToValidate="Cuenta_Id_DropDownList" CssClass="ErrorMessage" runat="server" ErrorMessage="Seleccione una cuenta"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <%--Concepto--%>
                <div class="form-group">
                    <div class="col-md-8 col-sm-4">
                        <label for="ConceptoTextBox" class="col-md-3 control-label input-sm">Nombre:</label>
                        <div class="col-md-4 col-sm-4">
                            <asp:TextBox ID="ConceptoTextBox"  ValidationGroup="Guardar" TextMode="MultiLine" placeholder="Concepto" CssClass="form-control input-sm" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3"  ValidationGroup="Guardar" CssClass="ErrorMessage" ControlToValidate="ConceptoTextBox" runat="server" ErrorMessage="Digite un concepto"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <%--Monto--%>
                <div class="form-group">
                    <div class=" col-md-8 col-sm-4">
                        <label for="MontoTextBox" class="col-md-3 control-label input-sm">Balance:</label>
                        <div class="col-md-4 col-sm-4">
                            <asp:TextBox ID="MontoTextBox"  ValidationGroup="Guardar" placeholder="Balance" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4"  ValidationGroup="Guardar" runat="server" CssClass="ErrorMessage" ControlToValidate="MontoTextBox" ErrorMessage="Ingrese un monto"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>



            </div>
        </div>
        <%--Botones--%>
        <div class="panel-footer">
            <div class="text-center">
                <div class="row">
                    <asp:Button CausesValidation="false" OnClick="NuevoButton_Click" Text="Nuevo" class="btn btn-warning btn-md col-md-2 offset-md-4" runat="server" ID="NuevoButton" />
                    <asp:Button Text="Guardar" OnClick="GuadarButton_Click"  ValidationGroup="Guardar" class="btn btn-success btn-md col-md-2 " runat="server" ID="GuadarButton" />
                    <asp:Button Text="Eliminar" OnClick="EliminarButton_Click"  ValidationGroup="ID" class="btn btn-danger btn-md col-md-2 " runat="server" ID="EliminarButton" />
                </div>
            </div>
        </div>

    </div>

</asp:Content>
