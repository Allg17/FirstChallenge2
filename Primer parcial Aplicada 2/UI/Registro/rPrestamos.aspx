<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Master Page/Master.Master" AutoEventWireup="true" CodeBehind="rPrestamos.aspx.cs" Inherits="Primer_parcial_Aplicada_2.UI.Registro.rPrestamos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class=" panel panel-primary">
        <div class="panel-heading text-center">
            <h1><ins>Registro de Prestamos</ins></h1>
            <br />
        </div>

        <div class="panel-body">
            <div class="form-horizontal col-md-12" role="form">
                <%--Id dropdown--%>
                <div class=" form-group">
                    <div class="col-md-8 col-sm-4 ">
                        <span class="col-md-3 control-label input-sm">ID:</span>
                        <div class="col-md-4 col-sm-4">
                            <asp:DropDownList ID="Id_DropDownList" OnSelectedIndexChanged="Id_DropDownList_SelectedIndexChanged" ValidationGroup="ID" AutoPostBack="true" AppendDataBoundItems="true" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                            <asp:CustomValidator ID="CustomValidator1" OnServerValidate="CustomValidator1_ServerValidate" ValidationGroup="ID" Display="Dynamic" SetFocusOnError="true" CssClass="ErrorMessage" ControlToValidate="Id_DropDownList" runat="server" ErrorMessage="Seleccione un Prestamo"></asp:CustomValidator>
                        </div>
                    </div>
                </div>

                <%--Fecha--%>
                <div class="form-group">
                    <div class="col-md-8 col-sm-4 ">
                        <span class="col-md-3 control-label input-sm">Fecha:</span>
                        <div class="col-md-4 col-sm-4">
                            <asp:TextBox ID="FechaDateTime" ValidationGroup="Guardar" TextMode="Date" CssClass="form-control input-sm" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup="Guardar" ID="RequiredFieldValidator1" CssClass="ErrorMessage" ControlToValidate="FechaDateTime" runat="server" ErrorMessage="Seleccione una Fecha"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <%--Cuenta--%>
                <div class="form-group">
                    <div class="col-md-8 col-sm-4">
                        <span class="col-md-3 control-label input-sm">Cuenta:</span>
                        <div class="col-md-4 col-sm-4">
                            <asp:DropDownList ID="CuentaDropDownList" AppendDataBoundItems="true" CssClass="form-control input-sm" AutoPostBack="true" ValidationGroup="Guardar" runat="server"></asp:DropDownList>
                            <asp:CustomValidator ID="CustomValidator2" OnServerValidate="CustomValidator2_ServerValidate" ValidationGroup="Guardar" Display="Dynamic" SetFocusOnError="true" CssClass="ErrorMessage" ControlToValidate="CuentaDropDownList" runat="server" ErrorMessage="Seleccione una Cuenta"></asp:CustomValidator>
                        </div>
                    </div>
                </div>

                <%--Capital--%>
                <div class="form-group">
                    <div class=" col-md-8 col-sm-4">
                        <span class="col-md-3 control-label input-sm">Capital:</span>
                        <div class="col-md-4 col-sm-4">
                            <asp:TextBox ID="CapitalTextBox" ValidationGroup="Guardar" placeholder="Capital" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup="Calcular" CssClass="ErrorMessage" ControlToValidate="CapitalTextBox" ID="RequiredFieldValidator7" runat="server" ErrorMessage="Ingrese un capital"></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ValidationGroup="Guardar" CssClass="ErrorMessage" ControlToValidate="CapitalTextBox" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Ingrese un capital"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <%--Interes--%>
                <div class="form-group">
                    <div class=" col-md-8 col-sm-4">
                        <span class="col-md-3 control-label input-sm">Interes Anual:</span>
                        <div class="col-md-4 col-sm-4">
                            <asp:TextBox ID="InteresTextBox" ValidationGroup="Guardar" placeholder="% Interes" CssClass="form-control" runat="server"></asp:TextBox>
                            <span>%</span>
                            <asp:RequiredFieldValidator ValidationGroup="Calcular" CssClass="ErrorMessage" ControlToValidate="InteresTextBox" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ingrese un interes"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <%--Tiempo--%>
                <div class="form-group">
                    <div class=" col-md-8 col-sm-4">
                        <span class="col-md-3 control-label input-sm">Tiempo:</span>
                        <div class="col-md-4 col-sm-4">
                            <asp:TextBox ID="TiempoTextBox" ValidationGroup="Guardar" placeholder="Tiempo (Meses)" CssClass="form-control" runat="server"></asp:TextBox>
                            <span>Meses</span>
                            <asp:RequiredFieldValidator ValidationGroup="Calcular"  CssClass=" ErrorMessage" ControlToValidate="TiempoTextBox" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Ingrese un tiempo"></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ValidationGroup="Guardar"  CssClass=" ErrorMessage" ControlToValidate="TiempoTextBox" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Ingrese Tiempo"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <%--CalcularButton--%>
                <div class="form-group">
                    <div class=" col-md-8 col-sm-4">
                        <div class="col-md-4 col-sm-4">
                            <asp:Button ID="CalcularButton" OnClick="CalcularButton_Click" ValidationGroup="Calcular" CssClass="form-control btn btn-primary" runat="server" Text="Calcular" />
                        </div>
                    </div>
                </div>

                <%--GridCuotas--%>
                <div class="form-group">
                    <div class=" col-md-12 col-sm-12">
                        <div class="col-md-12 col-sm-12">
                            <div class="col-md-12 col-sm-12">
                                <asp:GridView ID="DatosGridView" AllowPaging="true" OnPageIndexChanging="DatosGridView_PageIndexChanging" PageSize="8" runat="server" Width="100%" class="table table-responsive text-center" AutoGenerateColumns="False"
                                    CellPadding="4" ForeColor="#333333" GridLines="None">
                                    <AlternatingRowStyle BackColor="White" />

                                    <Columns>
                                        <asp:BoundField DataField="CuotaNum" HeaderText="CuotaNum" />
                                        <asp:BoundField DataField="Interes" HeaderText="Interes" />
                                        <asp:BoundField DataField="Capital" HeaderText="Capital" />
                                        <asp:BoundField DataField="Valor" HeaderText="Valor" />
                                        <asp:BoundField DataField="Balance" HeaderText="Balance" />


                                    </Columns>

                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>
                            </div>

                        </div>
                    </div>
                </div>

            </div>

        </div>
        <%--Botones--%>
        <div class="panel-footer">
            <div class="text-center">
                <div class="row">
                    <asp:Button Text="Nuevo" OnClick="NuevoButton_Click" class="btn btn-warning btn-md col-md-2 offset-md-3" CausesValidation="false" runat="server" ID="NuevoButton" />
                    <asp:Button ValidationGroup="Guardar" OnClick="GuadarButton_Click" Text="Guardar" class="btn btn-success btn-md col-md-2 " runat="server" ID="GuadarButton" />
                    <asp:Button ValidationGroup="ID" OnClick="EliminarButton_Click" Text="Eliminar" class="btn btn-danger btn-md col-md-2 " runat="server" ID="EliminarButton" />
                    <asp:Button Text="Imprimir" OnClick="ImprimirButton_Click" class="btn btn-info btn-md col-md-2 " runat="server" ID="ImprimirButton" />
                </div>
            </div>
        </div>

    </div>



</asp:Content>
