<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="Departamento.aspx.cs" Inherits="slnPresentacion.Departamento" %>

<%@ Register Src="~/controles/MenuInterno.ascx" TagName="MenuInterno" TagPrefix="ucMenu" %>
<asp:Content ID="Content3" ContentPlaceHolderID="menuInterno" runat="server">
    <ucMenu:MenuInterno ID="MenuInterno" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <h1>Departamentos</h1>
    <section class="row text-center placeholders">
        <div class="col-6 col-sm-6 placeholder">
            <h4>Administraci&oacute;n de departamentos</h4>
        </div>
        <div class="col-4 col-sm-4 placeholder">
            <a class="w3-button w3-large w3-circle w3-xlarge w3-ripple w3-teal" href="DepartamentoForm.aspx" style="z-index: 0">+</a>
            <h4>Nuevo</h4>
            <span class="text-muted">Agregar departamentos</span>
        </div>
    </section>
    <asp:GridView ID="gvDepartamentos" runat="server" 
        EmptyDataText="No Existen Departamentos Registrados" 
        CssClass="table table-striped" 
        OnRowDeleting="gvDepartamentos_RowDeleting" 
        OnRowEditing="gvDepartamentos_RowEditing"
        AutoGenerateColumns="False"
        DataKeyNames="Id">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id">
                <ItemStyle CssClass="d-none" />
                <HeaderStyle CssClass="d-none" />
            </asp:BoundField>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
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
