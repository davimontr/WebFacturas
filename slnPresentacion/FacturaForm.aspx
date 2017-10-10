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
                <asp:TextBox ID="txtFecha" runat="server" TextMode="DateTime"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="La fecha es obligatoria." ControlToValidate="txtFecha" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="col-sm-6 col-md-6">
                <label for="contenido_ddlCliente">Cliente</label><br />
                <asp:DropDownList ID="ddlCliente" runat="server" DataValueField="Id" DataTextField="NombreCompleto"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Cliente es obligatorio." ControlToValidate="ddlCliente" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="col-sm-6 col-md-6">
                <label for="contenido_txtDescuento">Descuento</label><br />
                <asp:TextBox ID="txtDescuento" runat="server" TextMode="Number"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Descuento puede ser desde 1 al 100" ControlToValidate="txtDescuento" ForeColor="Red" MinimumValue="1" MaximumValue="100"></asp:RangeValidator>
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
                <asp:DropDownList ID="ddlProducto" runat="server" DataValueField="Id" DataTextField="Producto1"></asp:DropDownList>
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
                    OnRowEditing="gvLineaArticulos_RowEditing"
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
                        <asp:BoundField DataField="Producto.Producto1" HeaderText="Producto" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                        <asp:BoundField DataField="IdFactura" HeaderText="IdFactura">
                            <ItemStyle CssClass="d-none" />
                            <HeaderStyle CssClass="d-none" />
                        </asp:BoundField>
                        <asp:CommandField ShowEditButton="True" />
                        <asp:CommandField ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <hr />
    <div class="container">
        <div class="row">
            <div class="col-sm-4 col-md-6"></div>
            <div class="col-sm-8 col-md-6">
                <asp:Button ID="btnSalvar" runat="server" class="btn btn-primary" Text="Salvar" OnClick="btnSalvar_Click" />
            </div>
        </div>
    </div>
    <asp:Label ID="lblMensaje" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>
</asp:Content>
