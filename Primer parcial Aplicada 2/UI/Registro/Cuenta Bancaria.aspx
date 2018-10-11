<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Master Page/Master.Master" AutoEventWireup="true" CodeBehind="Cuenta Bancaria.aspx.cs" Inherits="Primer_parcial_Aplicada_2.UI.Registro.Cuenta_Bancaria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class=" panel panel-primary">
        <div class="panel-heading text-center">
            <h1><ins>Cuenta Bancaria</ins></h1>
            <br />
        </div>


        <div class="panel-body">
            <div class="form-horizontal col-md-12" role="form">
                <%--Id dropdown--%>
                <div class=" form-group">
                    <div class="col-md-8 col-sm-4 ">
                        <label for="Id_DropDownList" class="col-md-3 control-label input-sm">ID:</label>
                        <div class="col-md-4 col-sm-4">
                            <asp:DropDownList ID="Id_DropDownList" ValidationGroup="ID" OnSelectedIndexChanged="Id_DropDownList_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                            <asp:CustomValidator ID="CustomValidator1" ValidationGroup="ID" Display="Dynamic" SetFocusOnError="true" CssClass="ErrorMessage" ControlToValidate="Id_DropDownList" runat="server" ErrorMessage="Seleccione una Cuenta" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                        </div>
                    </div>
                </div>

                <%--Fecha--%>
                <div class="form-group">
                    <div class="col-md-8 col-sm-4 ">
                        <label for="FechaDateTime" class="col-md-3 control-label input-sm">Fecha:</label>
                        <div class="col-md-4 col-sm-4">
                            <asp:TextBox ID="FechaDateTime" ValidationGroup="Guardar" TextMode="Date" CssClass="form-control input-sm" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup="Guardar" ID="RequiredFieldValidator1" CssClass="ErrorMessage" ControlToValidate="FechaDateTime" runat="server" ErrorMessage="Seleccione una Fecha"></asp:RequiredFieldValidator>
                            </div>
                    </div>
                </div>

                <%--Nombre--%>
                <div class="form-group">
                    <div class="col-md-8 col-sm-4">
                        <label for="NombreTextBox" class="col-md-3 control-label input-sm">Nombre:</label>
                        <div class="col-md-4 col-sm-4">
                            <asp:TextBox ID="NombreTextBox" ValidationGroup="Guardar" placeholder="Nombre" CssClass="form-control input-sm" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup="Guardar" ID="RequiredFieldValidator2" ControlToValidate="NombreTextBox" CssClass="ErrorMessage" runat="server" ErrorMessage="Ingrese un Nombre"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <%--Balance--%>
                <div class="form-group">
                    <div class=" col-md-8 col-sm-4">
                        <label for="BalanceTextBox" class="col-md-3 control-label input-sm">Balance:</label>
                        <div class="col-md-4 col-sm-4">
                            <asp:TextBox ID="BalanceTextBox"  placeholder="Balance" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>

            </div>
        </div>
        <%--Botones--%>
        <div class="panel-footer">
            <div class="text-center">
                <div class="row">
                    <asp:Button OnClick="NuevoButton_Click" Text="Nuevo" class="btn btn-warning btn-md col-md-2 offset-md-4" CausesValidation="false" runat="server" ID="NuevoButton" />
                    <asp:Button OnClick="GuadarButton_Click" ValidationGroup="Guardar" Text="Guardar" class="btn btn-success btn-md col-md-2 " runat="server" ID="GuadarButton" />
                    <asp:Button OnClick="EliminarButton_Click" ValidationGroup="ID" Text="Eliminar" class="btn btn-danger btn-md col-md-2 "  runat="server" ID="EliminarButton" />
                </div>
            </div>
        </div>

    </div>



</asp:Content>
