<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="FacturaForm.aspx.cs" Inherits="slnPresentacion.FacturaForm" %>

<%@ Register Src="~/controles/MenuInterno.ascx" TagName="MenuInterno" TagPrefix="ucMenu" %>
<asp:Content ID="Content2" ContentPlaceHolderID="menuInterno" runat="server">
    <ucMenu:MenuInterno ID="MenuInterno" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contenido" runat="server">
    <h1>Factura</h1>
    <section class="row text-center placeholders">
        <div class="col-10 col-sm-10 placeholder">
        </div>
    </section>
    <div class="container">
        <div class="row">
            <div class="col-sm-4 col-md-4">
                <label for="contenido_txtFactura">Factura</label><br />
                <asp:TextBox ID="txtFactura" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="La factura es obligatoria." ControlToValidate="txtFactura" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="col-sm-4 col-md-4">
                <label for="contenido_txtFecha">Fecha</label><br />
                <asp:TextBox ID="txtFecha" runat="server" TextMode="DateTime"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="La fecha es obligatoria." ControlToValidate="txtFecha" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="col-sm-4 col-md-4">
                <label for="contenido_txtDescuento">Descuento</label><br />
                <asp:TextBox ID="txtDescuento" runat="server" TextMode="Number"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Descuento puede ser desde 1 al 100" ControlToValidate="txtDescuento" ForeColor="Red" MinimumValue="1" MaximumValue="100"></asp:RangeValidator>
            </div>
        </div>
    </div>
    <hr/>
    <div class="container">
        <div class="row">
            <div class="col-sm-12 col-md-12">
                <div>
<h4>Lineas de Articulos</h4>
</div>
            </div>
            <div class="col-sm-4 col-md-4">
                <label for="contenido_ddlProducto">Producto</label><br />
                <asp:DropDownList ID="ddlProducto" runat="server"></asp:DropDownList>
            </div>
            <div class="col-sm-4 col-md-4">
                <label for="contenido_txtCantidad">Cantidad</label><br />
                    <asp:TextBox ID="txtCantidad" runat="server" TextMode="Number"></asp:TextBox>
                    <%--<asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Cantidad puede positiva desde 1" ControlToValidate="txtCantidad" ForeColor="Red" MinimumValue="1"></asp:RangeValidator>--%>
            </div>
            <div class="col-sm-4 col-md-4">
                <asp:HyperLink ID="lnkAgregarLinea" runat="server" CssClass="btn btn-secondary">Agregar</asp:HyperLink>
            </div>
            <div class="col-sm-12 col-md-12">
                <asp:GridView ID="gvLineaArticulos" runat="server" EmptyDataText="No Existen Lineas de articulos en la factura" CssClass="table table-striped"></asp:GridView>
            </div>
        </div>
    </div>
    <hr/>
    <div class="container">
        <div class="row">
            <div class="col-sm-4 col-md-6"></div>
            <div class="col-sm-8 col-md-6">
                <asp:Button ID="btnSalvar" runat="server" class="btn btn-primary" Text="Salvar" />
            </div>
        </div>
    </div>
    <asp:Label ID="lblMensaje" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>
</asp:Content>
