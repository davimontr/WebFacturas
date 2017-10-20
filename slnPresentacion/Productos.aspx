<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="slnPresentacion.Productos" %>

<%@ Register Src="~/controles/MenuInterno.ascx" TagName="MenuInterno" TagPrefix="ucMenu" %>
<asp:Content ID="Content3" ContentPlaceHolderID="menuInterno" runat="server">
    <ucMenu:MenuInterno ID="MenuInterno" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <h1>Productos</h1>
    <section class="row text-center placeholders">
        <div class="col-6 col-sm-6 placeholder">
            <h4>Administraci&oacute;n de productos</h4>
        </div>
        <div class="col-4 col-sm-4 placeholder">
            <a class="w3-button w3-large w3-circle w3-xlarge w3-ripple w3-teal" href="ProductoForm.aspx" style="z-index: 0">+</a>
            <h4>Nuevo</h4>
            <span class="text-muted">Agregar producto</span>
        </div>
    </section>
    <asp:GridView ID="gvProductos" runat="server" 
        EmptyDataText="No Existen Productos Registrados" 
        CssClass="table table-striped"
        OnRowDeleting="gvProductos_RowDeleting" 
        OnRowEditing="gvProductos_RowEditing"
        AutoGenerateColumns="False"
        DataKeyNames="Id">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id">
                <ItemStyle CssClass="d-none" />
                <HeaderStyle CssClass="d-none" />
            </asp:BoundField>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Costo" HeaderText="Costo" />
            <asp:BoundField DataField="Utilidad" HeaderText="Utilidad" />
            <asp:BoundField DataField="Impuesto" HeaderText="Impuesto" />
            <asp:BoundField DataField="Existencia" HeaderText="Existencia" />
            <asp:BoundField DataField="Proveedore.Nombre" HeaderText="Proveedor" />
            <asp:CommandField EditText="Editar" ShowEditButton="true">
                <ControlStyle CssClass="btn btn-primary active" />
            </asp:CommandField>
            <asp:CommandField DeleteText="Borrar" ShowDeleteButton="True">
                <ControlStyle CssClass="btn btn-danger btn-sm" />
            </asp:CommandField>
        </Columns>
    </asp:GridView>
    <asp:Label ID="lblMensaje" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>
</asp:Content>
