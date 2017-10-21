<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="FacturaForm.aspx.cs" Inherits="slnPresentacion.FacturaForm" %>

<%@ Register Src="~/controles/MenuInterno.ascx" TagName="MenuInterno" TagPrefix="ucMenu" %>
<asp:Content ID="Content2" ContentPlaceHolderID="menuInterno" runat="server">
    <ucMenu:MenuInterno ID="MenuInterno" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contenido" runat="server">
    <h1>Factura</h1>
    <asp:HiddenField ID="hdnIdentificador" runat="server" />
    <section class="row text-center placeholders">
        <div class="col-10 col-sm-10 placeholder">
        </div>
    </section>
    <div class="container">
        <div class="row">
            <div class="col-sm-6 col-md-6">
                <label for="contenido_txtFactura">Factura</label><br />
                <asp:TextBox ID="txtFactura" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="La factura es obligatoria." ControlToValidate="txtFactura" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="col-sm-6 col-md-6">
                <label for="contenido_txtFecha">Fecha</label><br />
                <asp:Calendar ID="cldFecha" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                    <NextPrevStyle VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#808080" />
                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <WeekendDayStyle BackColor="#FFFFCC" />
                </asp:Calendar>
            </div>
            <div class="col-sm-4 col-md-4">
                <label for="contenido_ddlCliente">Cliente</label><br />
                <asp:DropDownList ID="ddlCliente" runat="server" DataValueField="Id" DataTextField="NombreCompleto"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Cliente es obligatorio." ControlToValidate="ddlCliente" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="col-sm-4 col-md-4">
                <label for="contenido_ddlFormaPago">Forma de pago</label><br />
                <asp:DropDownList ID="ddlFormaPago" runat="server" DataValueField="Id" DataTextField="Nombre"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Forma de pago es obligatorio." ControlToValidate="ddlFormaPago" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="col-sm-4 col-md-4">
                <label for="contenido_ddlTipoMoneda">Tipo de moneda</label><br />
                <asp:DropDownList ID="ddlTipoMoneda" runat="server" DataValueField="Id" DataTextField="Nombre"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Tipo de moneda es obligatorio." ControlToValidate="ddlTipoMoneda" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
    </div>
    <hr />
    <div class="container">
        <div class="row">
            <div class="col-sm-12 col-md-12">
                <div>
                    <h4>Lineas de Articulos</h4>
                </div>
            </div>
            <div class="col-sm-4 col-md-4">
                <label for="contenido_ddlProducto">Producto</label><br />
                <asp:DropDownList ID="ddlProducto" runat="server" DataValueField="Id" DataTextField="Nombre"></asp:DropDownList>
            </div>
            <div class="col-sm-4 col-md-4">
                <label for="contenido_txtCantidad">Cantidad</label><br />
                <asp:TextBox ID="txtCantidad" runat="server" TextMode="Number"></asp:TextBox>
                <%--<asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Cantidad puede positiva desde 1" ControlToValidate="txtCantidad" ForeColor="Red" MinimumValue="1"></asp:RangeValidator>--%>
            </div>
            <div class="col-sm-4 col-md-4">
                <asp:Button ID="btnAgregarArticulo" runat="server" CssClass="btn btn-secondary" Text="Agregar" OnClick="btnAgregarArticulo_Click" />
            </div>
            <div class="col-sm-12 col-md-12">
                <asp:GridView ID="gvLineaArticulos" runat="server" 
                    EmptyDataText="No Existen Lineas de articulos en la factura" 
                    CssClass="table table-striped"
                    OnRowDeleting="gvLineaArticulos_RowDeleting"
                    AutoGenerateColumns="False"
                    DataKeyNames="Id">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id">
                            <ItemStyle CssClass="d-none" />
                            <HeaderStyle CssClass="d-none" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IdProducto" HeaderText="IdProducto">
                            <ItemStyle CssClass="d-none" />
                            <HeaderStyle CssClass="d-none" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Producto.Nombre" HeaderText="Producto" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                        <asp:BoundField DataField="IdFactura" HeaderText="IdFactura">
                            <ItemStyle CssClass="d-none" />
                            <HeaderStyle CssClass="d-none" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Precio" HeaderText="Precio" />
                        <asp:CommandField DeleteText="Borrar" ShowDeleteButton="True" >
                            <ControlStyle CssClass="btn btn-danger btn-sm" />
                        </asp:CommandField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <hr />
    <div class="container">
        <div class="row">
            <div class="col-sm-4 col-md-6">
                <h4>Total:&nbsp;</h4>
                <asp:Label ID="lblTotal" runat="server" Text="0" Font-Bold="True"></asp:Label>
            </div>
            <div class="col-sm-8 col-md-6">
                <asp:Button ID="btnSalvar" runat="server" class="btn btn-primary" Text="Salvar" OnClick="btnSalvar_Click" />
            </div>
        </div>
    </div>
    <asp:Label ID="lblMensaje" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>
</asp:Content>
