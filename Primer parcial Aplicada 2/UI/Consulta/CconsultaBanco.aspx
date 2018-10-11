<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Master Page/Master.Master" AutoEventWireup="true" CodeBehind="CconsultaBanco.aspx.cs" Inherits="Primer_parcial_Aplicada_2.UI.Consulta.CconsultaBanco" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

        <div class="row">
            <div class="col-md-4 col-sm-5 col-lg-2">
                <asp:DropDownList ID="FiltroComboBox" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Todo"></asp:ListItem>
                    <asp:ListItem Text="IdCuenta"></asp:ListItem>
                    <asp:ListItem Text="Nombre"></asp:ListItem>
                    <asp:ListItem Text="Balance"></asp:ListItem>
                </asp:DropDownList>

            </div>

            <%--Criterio--%>
            <div class="col-md-4 col-sm-4 offset-sm-1 offset-md-1 col-lg-4 ">
                <asp:TextBox ID="CriterioTextBox" placeholder="Criterio" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:CustomValidator ID="CustomValidator1" Display="Dynamic" SetFocusOnError="true" CssClass="ErrorMessage" ControlToValidate="CriterioTextBox" runat="server" ErrorMessage="Verifique la cadena ingresada y el filtro" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
            </div>

            <%--Boton Buscar--%>
            <div class="col-md-3 col-sm-2">
                <asp:Button ID="BuscarButton" OnClick="BuscarButton_Click" runat="server" Text="Buscar" CssClass="form-control btn btn-primary" />
            </div>

        </div>
        <div class="row">
            <%--Fecha desde--%>
            <div class=" col-sm-5 col-md-4 col-lg-2">
                <asp:TextBox ID="AHoradateTimePicker1" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
            </div>
            <div class=" col-sm-1  col-md-1">
                <label >TO:</label>
            </div>
            <%--Fecha hasta--%>
            <div class=" col-sm-4 col-md-4 col-lg-2  ">
                <asp:TextBox ID="FInaldateTimePicker2" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
            </div>
        </div>
        <%--fecha checkBox--%>
        <div class="row">
            <div class="col-md-4 col-sm-4 col-lg-2">
                <asp:CheckBox ID="FechacheckBox" CssClass="form-control" Text="Fecha" runat="server" />
            </div>
        </div>
        <%--Grid--%>
        <div class="row">
            <div class="col-md-12 col-sm-12">
                <asp:GridView ID="DatosGridView" AllowPaging="true" PageSize="8" OnPageIndexChanging="DatosGridView_PageIndexChanging" runat="server" Width="100%" class="table table-responsive text-center" AutoGenerateColumns="False"
                    CellPadding="4" ForeColor="#333333" GridLines="None" >
                    <AlternatingRowStyle BackColor="White" />

                    <Columns>



                        <asp:BoundField DataField="CuentaId" HeaderText="CuentaId" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Balance" HeaderText="Balance" />
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" />



                        <asp:TemplateField>
                            <ItemTemplate>
                            </ItemTemplate>
                        </asp:TemplateField>
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

</asp:Content>
